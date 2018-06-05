using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectGame
{
    public enum statusGame{
        EndGame,
        ContinueGame
    }
    public  class Move
    {
        public ChessPieces actionPiece { get; set; }
        public int destination { get; set; }
        public bool chieuTuong = false;
        public string WinGame = null;
        


        public Move(ChessPieces piece,int des)
        {
            this.actionPiece = piece;
            this.destination = des;
        }

        public int GetCurrentPosition()
        {
            return actionPiece.chessPiecePosition;
        }

        public virtual bool isAttack()
        {
            return false;
        }

        public virtual ChessPieces getAttackedPiece()
        {
            return null;
        }

        public bool IsPromote()
        {
            //khong can xet den quan co vi no khong the di lui.
            return ((destination / 8 == 0 || destination / 8 == 7) && this.actionPiece.IsPawn());
        }

        /// <summary>
        /// thực hiện di chuyển nước cờ trên boardlogic
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public virtual Board ExcuteMove(Board board)
        {
            if (TheKingDie(board))
            {
                string slide = (board.Curentlayer.sideplayer == ChessPieceSide.BLACK) ? " Black Win!!!" : "White Win!!!";
                // MessageBox.Show(slide);
                this.WinGame = slide;
                //se kiem tra o phia ngoai form Chinh de load lai ban co nua
                //o trong nay khong the goi toi ham resetGame. kho haha

            }

            //thay đổi loại cell trên bàn cờ cho 2 vị trí dang xet.
            // tao 1 quan co cung loai dua vao vi tri moi
            ChessPieces piece = actionPiece.movePiece(this);

            //thay doi cell
            board.listCell[this.GetCurrentPosition()] = new EmptyCell(this.GetCurrentPosition());
            board.listCell[this.destination] = new OccupiedCell(this.destination,piece);

            //theo doi quan co tren list piece
            board.SetPiece(piece);
            board.RemovePiece(this.actionPiece);

            //neu la vua di chuyen thi set vi tri thang vua cho player.
            if(this.actionPiece.IsKing())
            {
                board.Curentlayer.king =(King) piece; //= vua o vi tri moi
            }

            //neu la o vi tri chuyen toi co the phong tuong cho tot
          //  if(this.IsPromote())
         //   {
                //mo hop thoai cho chonj tuong muon phong va set lai gia tri cho vi tri moi phong
                
            // vi khong goi duoc form ben GUI nen thuc hien ben CellGUI truoc khi goi Move.

              //  MessageBox.Show("cho nay de phong tuong hahaha");
          //  }

            //kiem tra nuoc co vua di co de doa tinh mang cua tuong doi phuong khong.
            checkDangerousForTheKing(board);

            return board;
        }

        /// <summary>
        /// kiểm tra nguy hiểm của nước cờ tới vua của đối phương để đưa ra cảnh báo
        /// </summary>
        void checkDangerousForTheKing(Board board)
        {
            List<Move> listMoveFuture = new List<Move>();
            ChessPieces p = (ChessPieces) board.GetCell(this.destination).GetChessPieces();
            listMoveFuture = p.getLegalMoves(board);

            King king = board.GetNextPlayer().king;
            foreach (Move m in listMoveFuture)
            {
                if (m.destination == king.chessPiecePosition)
                {
                    // MessageBox.Show("Chiếu tướng. hahahaa !!!");
                    this.chieuTuong = true;
                    break;
                }
            }
        }

        /// <summary>
        /// Kiểm tra xem vua đã chết hay chưa
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool TheKingDie(Board board)
        {
            return (destination==board.GetNextPlayer().king.chessPiecePosition);
        }

    }

    public class NormalMove : Move
    {
        public NormalMove(ChessPieces piece, int des) : base(piece, des)
        {
        }
    }

    public class AttackMove : Move
    {
        public ChessPieces pieceWasAttacked;

        public AttackMove(ChessPieces piece, int des, ChessPieces pieceWasAttacked) : base(piece, des)
        {
            this.pieceWasAttacked = pieceWasAttacked;
        }

        public override bool isAttack()
        {
            return true;
        }

        public override ChessPieces getAttackedPiece()
        {
            return this.pieceWasAttacked;
        }
    }
}
