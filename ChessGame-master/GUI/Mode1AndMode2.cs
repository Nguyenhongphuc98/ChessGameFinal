using ObjectGame;
using System;
using System.Drawing;
using System.Windows.Forms;
//using ObjectGame;
using System.Threading;
using WMPLib;
//using System.Windows.Forms.Progcessbar;

namespace GUI
{
    public partial class Mode1AndMode2 : Form
    {
        #region Thuoc tinh chung
        BoardGui boardGui;
        SocketManager socket;
        public static statusGame status_game = statusGame.ContinueGame;
        
        public static string namePlayer="";
        public static int modeplay;

        public static int checkmove = 0; //de kiem tra coi da di nuoc co hay khong, pahi thi gui qua LAN
        public static Point moveLAN = new Point(0, 0);
        bool isClient = false; // su dung luc ve ban co
        //chua diem dau va diem cuoi cua nuoc co vua di

        // nhac nen
        WindowsMediaPlayer soundBackground = new WindowsMediaPlayer();
       // WindowsMediaPlayer soundClick = new WindowsMediaPlayer();
        #endregion

        #region Khoi tao form cung che do choi va nhac
        public Mode1AndMode2(int mode)
        {
           // System.Windows.Forms.Control.CheckForIllegalCrossT hreadCalls = File;
            InitializeComponent();
            modeplay = mode;

            //che do danh 2 nguoi 1 may hoac danh voi may thi !enable khung chat
            if (Mode1AndMode2.modeplay == 1 || Mode1AndMode2.modeplay == 2)
                //this.lvChat.Enabled = btnSendMessage.Enabled = tbmess.Enabled = false;
                pnChat.Visible = false;
            else
            {
                //nguoc lai la danh qua LAN
                btnPlay.Enabled = false;
                timerCheckMove.Start();
                socket = new SocketManager();
            }

            soundBackground.URL = Application.StartupPath + "\\BackgroundMusic.mp3";
            soundBackground.controls.play();
        }
        #endregion

        #region reset lai game khi nhan toolstrip menu
        private void reSetGameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (Mode1AndMode2.modeplay == 3)
            {
                SocketData data = new SocketData((int)TypeData.RESET, "", new Point(0, 0));
                socket.Send(data);
            }

            ResetGame();
        }
        #endregion

        #region timer kiem tra ket thuc game
        private void timerCheckEndGame_Tick(object sender, EventArgs e)
        {
            if (Mode1AndMode2.status_game == statusGame.EndGame)
            {
                Mode1AndMode2.status_game = statusGame.ContinueGame;

                if (Mode1AndMode2.modeplay == 3)
                {
                    SocketData data = new SocketData((int)TypeData.RESET, "", new Point(0, 0));
                    socket.Send(data);
                }

                ResetGame();

            }
        }
        #endregion

        #region timer kiem tra nguoi choi hien tai cho thanh procesbar
        private void timerProcessbarPlayer_Tick(object sender, EventArgs e)
        {
            if (boardGui.boardLogic.Curentlayer.sideplayer == ChessPieceSide.WHITE)
            {
                proBlack.Value = 100;
                if (proWhite.Value != 0) // player 1 la trang
                    proWhite.Value -= 1;
                else
                {
                    timerProcessbarPlayer.Stop();
                    MessageBox.Show(" time up - Black Win!!!");
                    ResetGame();
                    proBlack.Value = proWhite.Value = 100;
                    timerProcessbarPlayer.Start();

                }

            }
            else
            {
                proWhite.Value = 100;
                if (proBlack.Value != 0) // player 2 la den
                    proBlack.Value -= 1;
                else
                {
                    timerProcessbarPlayer.Stop();
                    MessageBox.Show(" time up - White Win!!!");
                    ResetGame();
                    proBlack.Value = proWhite.Value = 100;
                    timerProcessbarPlayer.Start();

                }

            }
        }
        #endregion

        #region undo khi click toolstrip menu
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Mode1AndMode2.modeplay == 3)
            {
                SocketData data = new SocketData((int)TypeData.UNDO, "", new Point(0, 0));
                socket.Send(data);
            }
            this.boardGui.Undo();
        }
        #endregion

        #region Update when resetgame
        delegate void updateResetGame(Form form);
        private void UpdateReset(Form form)
        {
            if (lvChat.InvokeRequired)
            {
                // this is worker thread
                updateResetGame del = new updateResetGame(UpdateReset);
                form.Invoke(del, new object[] { form });
            }
            else
            {
                // this is UI thread
                //chuc nang nay can fix bug haha. tu tu se xong thoi
                this.boardGui.boardLogic.CreateDefaultListPieceBoard();
                this.boardGui.boardLogic.CreateCellBoard(ChessPieceSide.WHITE);
                this.boardGui.AddCellGuiAndCell(isClient);

                //reset lai lich su. ahihi
                BoardGui.moveHistory.ListMoveHistory.Clear();
            }
        }
        #endregion
        public void ResetGame()
        {
            //chuc nang nay can fix bug haha. tu tu se xong thoi
            this.boardGui.boardLogic.CreateDefaultListPieceBoard();
            this.boardGui.boardLogic.CreateCellBoard(ChessPieceSide.WHITE);
            this.boardGui.AddCellGuiAndCell(isClient);

            //reset lai lich su. ahihi
            BoardGui.moveHistory.ListMoveHistory.Clear();
        }

        #region Update listView when chating LAN
        delegate void updateListViewTextDelegate(ListViewItem lvi);
        private void UpdateListView(ListViewItem lvi)
        {
            if (lvChat.InvokeRequired)
            {
                // this is worker thread
                updateListViewTextDelegate del = new updateListViewTextDelegate(UpdateListView);
                lvChat.Invoke(del, new object[] { lvi });
            }
            else
            {
                // this is UI thread
                lvChat.Items.Add(lvi);
            }
        }
        #endregion


        #region Update board when move to LAN
        delegate void updateExcuteLANDelegate(Form form);
        private void ExcuteMoveLAN(Form form)
        {
            if (form.InvokeRequired)
            {
                // this is worker thread
                updateExcuteLANDelegate del = new updateExcuteLANDelegate(ExcuteMoveLAN);
                form.Invoke(del, new object[] { form });
            }
            else
            {
                // this is UI thread
                Point position = Mode1AndMode2.moveLAN; // x la diem dau- y la diem den
                ChessPieces piece =(ChessPieces) this.boardGui.boardLogic.GetCell(position.X).GetChessPieces().Clone();
                //  MessageBox.Show(piece.chessPieceType.chessPieceName);

                Cell cell = this.boardGui.boardLogic.GetCell(position.Y);
                Move move;

                if (cell.Occupied())
                     move = new AttackMove(piece, position.Y, cell.GetChessPieces());
                else
                     move = new NormalMove(piece, position.Y);

                    
                

                CellGui cellG = this.boardGui.GetCellGui(position.X);

               // khong can thiet, cainay chi cap nhat game thoi ma, chi can hien ben nguoi choi duoc roi
                if (move.IsPromote())
                {
                    cellG.SetPromote(move);

                    //set lai icon cho ben nay-ban chat la phia ben nay board logic khong co con nay
                    //nhung chi co ben kia duoc di nen khong sao het- danh lua nguoi choi.

                }


                this.boardGui.boardLogic = move.ExcuteMove(this.boardGui.boardLogic);
                BoardGui.moveHistory.ListMoveHistory.Add(move);
                BoardGui.moveHistory.listRedo.Clear();
                if (move.TheKingDie(this.boardGui.boardLogic))
                {
                    Mode1AndMode2.status_game = statusGame.EndGame;

                }

                //set lai icon tren ban co cho nguoi xem biet duoc  da di.-> thay doi board gui
                this.boardGui.GetCellGui(position.X).SetImageIcon();
                this.boardGui.GetCellGui(position.Y).SetImageIcon();

                //reset thanh chua chon nuoc co nao va set nguoi choi tiep theo vi da danh xong nuoc co nay.
                this.boardGui.CellSelectedFirst = this.boardGui.CellSelectedSecond = null;
                this.boardGui.boardLogic.SetNextPlayer();
            }
           
        }
        #endregion

        #region Update board when REDO to LAN
        delegate void updateRedoLANDelegate(Form form);
        private void ExcuteRedoLAN(Form form)
        {
            if (form.InvokeRequired)
            {
                // this is worker thread
                updateRedoLANDelegate del = new updateRedoLANDelegate(ExcuteRedoLAN);
                form.Invoke(del, new object[] { form });
            }
            else
            {
                // this is UI thread

                if (BoardGui.moveHistory.listRedo.Count>0)
                {
                    Move move = BoardGui.moveHistory.listRedo.Peek();
                    this.boardGui.boardLogic = BoardGui.moveHistory.Redo(this.boardGui.boardLogic);
                    this.boardGui.listCellGui[move.actionPiece.chessPiecePosition].SetImageIcon();
                    this.boardGui.listCellGui[move.destination].SetImageIcon();
                    BoardGui.moveHistory.RemoveRedo();
                    this.boardGui.boardLogic.SetNextPlayer();
                }
            }

        }
        #endregion

        #region Update board when UNDO to LAN
        delegate void updateUndoLANDelegate(Form form);
        private void ExcuteUndoLAN(Form form)
        {
            if (form.InvokeRequired)
            {
                // this is worker thread
                updateUndoLANDelegate del = new updateUndoLANDelegate(ExcuteUndoLAN);
                form.Invoke(del, new object[] { form });
            }
            else
            {
                // this is UI thread

                if (BoardGui.moveHistory.GetNearestMove() != null)
                {
                    this.boardGui.boardLogic = BoardGui.moveHistory.Undo(this.boardGui.boardLogic);
                    this.boardGui.listCellGui[BoardGui.moveHistory.GetNearestMove().actionPiece.chessPiecePosition].SetImageIcon();
                    this.boardGui.listCellGui[BoardGui.moveHistory.GetNearestMove().destination].SetImageIcon();
                    BoardGui.moveHistory.RemoveHistoryForThisMove();
                    this.boardGui.boardLogic.SetNextPlayer();
                }     
            }

        }
        #endregion

        #region Update processbar when stargame LAN
        delegate void updateProcessBarDelegate(ProgressBar pro);
        private void updateProcessBar(ProgressBar pro)
        {
            if (proWhite.InvokeRequired)
            {
                // this is worker thread
                updateProcessBarDelegate del = new updateProcessBarDelegate(updateProcessBar);
                proWhite.Invoke(del, new object[] { pro });
            }
            else
            {
                // this is UI thread
                // proWhite.sta
                timerProcessbarPlayer.Start();
            }
        }
        #endregion

        /// <summary>
        /// Lắng nghe và cập nhật game đối với chơi LAN
        /// </summary>
        void Listen()
        {
            SocketData data = (SocketData)socket.Receive();

            switch (data.flag)
            {
                case (int)TypeData.GUI_TIN:
                    ListViewItem lvi = new ListViewItem(data.message);
                    UpdateListView(lvi);                 
                    break;

                case (int)TypeData.MOVE:
                    Mode1AndMode2.moveLAN = data.move;
                    ExcuteMoveLAN(this);
                    break;

                case (int)TypeData.START:
                    updateProcessBar(proWhite);
                    StartGame(ChessPieceSide.WHITE); 
                    break;

                case (int)TypeData.RESET:
                    // ResetGame();
                    UpdateReset(this);
                    break;

                case (int)TypeData.UNDO:
                    ExcuteUndoLAN(this);
                    break;

                case (int)TypeData.REDO:
                    ExcuteRedoLAN(this);
                    break;
            }


        }

        /// <summary>
        /// Gửi tin khi nhấn nút send ( LAN)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (btnSendMessage.Text == "Kết nối")
            {
                btnPlay.Enabled = true;
                btnSendMessage.Text = "Gửi tin";

                socket.IP = tbmess.Text;
                Mode1AndMode2.namePlayer = "Player black";
                if (!socket.ConnectServer())
                {
                    socket.CreateServer();
                    Mode1AndMode2.namePlayer = "Player white";
                }


                Thread listenThread = new Thread(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(500);
                        try
                        {
                            Listen();
                           // break;
                        }
                        catch
                        {

                        }
                    }
                });
                listenThread.IsBackground = true;
                listenThread.Start();
            }
            else
            {
                string mess = Mode1AndMode2.namePlayer + " : " + tbmess.Text;
                ListViewItem lvi = new ListViewItem(mess);
                lvChat.Items.Add(lvi);
                SocketData data = new SocketData((int)TypeData.GUI_TIN, mess, Mode1AndMode2.moveLAN);
                socket.Send(data);
                tbmess.Clear();
            }

        }

        /// <summary>
        /// Load ip 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mode1AndMode2_Load(object sender, EventArgs e)
        {
            if (Mode1AndMode2.modeplay == 3)
            {
                tbmess.Text = socket.GetLocalIPv4(System.Net.NetworkInformation.NetworkInterfaceType.Wireless80211);
                if (string.IsNullOrEmpty(tbmess.Text))
                {
                    tbmess.Text = socket.GetLocalIPv4(System.Net.NetworkInformation.NetworkInterfaceType.Wireless80211);
                }
            }        
        }

        #region Update boardgame when start game
        delegate void updateBoardDelegate(Button lb, BoardGui boardGui, ChessPieceSide side);
        private void UpdateBoardeGui(Button lb, BoardGui boardGui, ChessPieceSide side)
        {
            if (btnPlay.InvokeRequired)
            {
                // this is worker thread
                updateBoardDelegate del = new updateBoardDelegate(UpdateBoardeGui);
                btnPlay.Invoke(del, new object[] { lb,boardGui,side});
            }
            else
            {
                // this is UI thread
                btnPlay.Visible = false;               
                if (Mode1AndMode2.namePlayer == "Player black")
                    isClient = true;

                boardGui = new BoardGui(side,isClient);
                this.Controls.Add(boardGui);
                this.boardGui = boardGui;

            }
        }
        #endregion
        void StartGame(ChessPieceSide side)
        {
            UpdateBoardeGui(btnPlay,boardGui,side);
            timerCheckEndGame.Start();

            if (modeplay == 2)
                return;
            timerProcessbarPlayer.Start();

        }

        private void lbPlay_Click(object sender, EventArgs e)
        {

        }

        private void timerCheckMove_Tick(object sender, EventArgs e)
        {
            //neu co su di chuyen
            if (CellGui.checkmove != Mode1AndMode2.checkmove)
            {
                Mode1AndMode2.checkmove = CellGui.checkmove;
                SocketData data = new SocketData((int)TypeData.MOVE, "di chuyen", Mode1AndMode2.moveLAN);
                socket.Send(data);
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (Mode1AndMode2.modeplay == 3)
            {
                SocketData data = new SocketData((int)TypeData.UNDO, "", new Point(0, 0));
                socket.Send(data);
            }
            this.boardGui.Undo();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (Mode1AndMode2.modeplay == 3)
            {
                SocketData data = new SocketData((int)TypeData.RESET, "", new Point(0, 0));
                socket.Send(data);
            }

            ResetGame();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            //neu dang o che do danh qua LAN thu truyen cho ben kia biet da bat dau
            if (Mode1AndMode2.modeplay == 3)
            {
                SocketData data = new SocketData((int)TypeData.START, "start", Mode1AndMode2.moveLAN);
                socket.Send(data);
            }

          
            StartGame(ChessPieceSide.WHITE);
          
            //btnPlay.Visible = false;
        }

        bool IsPlaingMusic = true;
        private void pbSound_Click(object sender, EventArgs e)
        {
            pbSound.BackColor = Color.Transparent;
            if (IsPlaingMusic)
            {
                pbSound.BackgroundImage = Image.FromFile("stopSound.png");
                IsPlaingMusic = false;
                soundBackground.controls.pause();
            }
            else
            {
                pbSound.BackgroundImage = Image.FromFile("playSound.png");
                IsPlaingMusic = true;
                soundBackground.controls.play();
            }
          
        }

        private void Mode1AndMode2_FormClosed(object sender, FormClosedEventArgs e)
        {
            soundBackground.controls.stop();
            timerProcessbarPlayer.Stop();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if(BoardGui.moveHistory.listRedo.Count==0)
                return;
            if (Mode1AndMode2.modeplay == 3)
            {
                SocketData data = new SocketData((int)TypeData.REDO, "", new Point(0, 0));
                socket.Send(data);
            }
            this.boardGui.Redo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BoardGui.moveHistory.listRedo.Count == 0)
                return;
            if (Mode1AndMode2.modeplay == 3)
            {
                SocketData data = new SocketData((int)TypeData.REDO, "", new Point(0, 0));
                socket.Send(data);
            }
            this.boardGui.Redo();
        }
    }


}
