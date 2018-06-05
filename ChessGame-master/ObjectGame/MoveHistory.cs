using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectGame
{
    public class MoveHistory
    {
        //listmove to undo
        public List<Move> ListMoveHistory;

        //redo to save redo when undo
        public Stack<Move> listRedo;

        public MoveHistory()
        {
            ListMoveHistory = new List<Move>();
            listRedo = new Stack<Move>();
        }

        /// <summary>
        /// lấy ra nước cờ vừa đi để undo
        /// </summary>
        /// <returns></returns>
        public Move GetNearestMove()
        {
            if (ListMoveHistory.Count > 0)
            {
                return ListMoveHistory[ListMoveHistory.Count - 1];
            }

            return null;
        }

        public Board Undo(Board board)
        {
            Move MoveUndo = this.GetNearestMove();

            int pos = MoveUndo.actionPiece.chessPiecePosition;
            board.listCell[pos] = new OccupiedCell(pos, MoveUndo.actionPiece);
            board.SetPiece(MoveUndo.actionPiece);
            board.RemovePiece(board.ListChessPiece[MoveUndo.destination]);

            if (MoveUndo.isAttack())
            {
                board.listCell[MoveUndo.destination] = new OccupiedCell(MoveUndo.destination, MoveUndo.getAttackedPiece());
                board.SetPiece(MoveUndo.getAttackedPiece());
            }
            else
            {
                board.listCell[MoveUndo.destination] = new EmptyCell(pos);
            }

            //  RemoveHistoryForThisMove();

            //add to redo
            listRedo.Push(MoveUndo);

            return board;
        }

        /// <summary>
        /// xóa lịch sử đi sau khi undo
        /// </summary>
        public void RemoveHistoryForThisMove()
        {
            Move m = ListMoveHistory[ListMoveHistory.Count - 1];
            ListMoveHistory.Remove(m);
        }

        public Board Redo(Board board)
        {
            Move currentMove = listRedo.Peek();

            ChessPieces piece = currentMove.actionPiece.movePiece(currentMove);

            //thay doi cell
            board.listCell[currentMove.GetCurrentPosition()] = new EmptyCell(currentMove.GetCurrentPosition());
            board.listCell[currentMove.destination] = new OccupiedCell(currentMove.destination, piece);

            //theo doi quan co tren list piece
            board.SetPiece(piece);
            board.RemovePiece(currentMove.actionPiece);

            //neu la vua di chuyen thi set vi tri thang vua cho player.
            if (currentMove.actionPiece.IsKing())
            {
                board.Curentlayer.king = (King)piece; //= vua o vi tri moi
            }

            return board;
        }

        public void RemoveRedo()
        {
            listRedo.Pop();
        }
    }
}
