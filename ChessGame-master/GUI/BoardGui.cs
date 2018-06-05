using ObjectGame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    class BoardGui: TableLayoutPanel
    {
        #region thuoc tinh chung
        public List<CellGui> listCellGui { get; set; }
        public Cell CellSelectedFirst { get; set; }
        public Cell CellSelectedSecond { get; set; }
        public Board boardLogic { get; set; }
        public static MoveHistory moveHistory;
        #endregion

        public ChessPieces workingPiece { get; set; }

        public BoardGui(ChessPieceSide sidePlayFirst,bool isClient) : base()
        {
            this.boardLogic = new Board(sidePlayFirst);
            moveHistory = new MoveHistory();

            this.CellSelectedFirst = this.CellSelectedSecond = null;
            this.ColumnCount = 8;           
            this.RowCount = 8;


            this.Size = new Size(538, 538);
            this.Location = new Point(250, 40);
            this.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            this.listCellGui = new List<CellGui>();
            AddCellGuiAndCell(isClient);
        }

        /// <summary>
        /// them cac cellgui len boardgui
        /// </summary>
        /// <param name="isClient"></param>
        public void AddCellGuiAndCell(bool isClient)
        {
            // if(listCellGui!=null) listCellGui.Clear();
            this.Controls.Clear();
            if(listCellGui!=null)
                this.listCellGui.Clear();

            this.Visible = false;
            
            //Neu la client thi tao ban co dao nguoc
            if(isClient)
            {
                int position = 63;
                for (int i = 0; i < 64; i++)
                {
                    CellGui cell = new CellGui(this, i);
                    this.Controls.Add(cell, position % 8, position / 8);
                    this.listCellGui.Add(cell);
                    position--;
                }
            }
            else
            for (int i = 0; i < 64; i++)
            {
                CellGui cell = new CellGui(this, i);
                this.Controls.Add(cell, i % 8, i / 8);
                this.listCellGui.Add(cell);
            }

            this.Visible = true;
            this.Refresh();
        }

        public CellGui GetCellGui(int id)
        {
            return this.listCellGui[id];
        }

        public void Undo()
        {
            try
            {//set lai icon tren cellGui neu co buoc di truoc do
             //neu chua di cai nao thi bo tay. khong the undo
                if (BoardGui.moveHistory.GetNearestMove() != null)
                {
                    this.boardLogic = BoardGui.moveHistory.Undo(this.boardLogic);
                    this.listCellGui[BoardGui.moveHistory.GetNearestMove().actionPiece.chessPiecePosition].SetImageIcon();
                    this.listCellGui[BoardGui.moveHistory.GetNearestMove().destination].SetImageIcon();
                    BoardGui.moveHistory.RemoveHistoryForThisMove();
                    this.boardLogic.SetNextPlayer();
                }
            }

            catch { }

        }

        public void Redo()
        {
            try
            {
                //set lai icon tren cellGui neu co buoc di truoc do
                //neu chua undo cai nao thi bo tay. khong the redo

                if (BoardGui.moveHistory.listRedo.Count > 0)
                {
                    Move move = BoardGui.moveHistory.listRedo.Peek();
                    this.boardLogic = BoardGui.moveHistory.Redo(this.boardLogic);
                    this.listCellGui[move.actionPiece.chessPiecePosition].SetImageIcon();
                    this.listCellGui[move.destination].SetImageIcon();
                    BoardGui.moveHistory.RemoveRedo();
                    this.boardLogic.SetNextPlayer();
                }
            }
            catch { }
        }
    }
}
