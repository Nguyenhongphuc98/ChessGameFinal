using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectGame
{
    public class Machine
    {
        //MAX la White
        //MIN la Black

        
        ///<summary>
        ///lấy ra 1 move co the- easy to move
        ///</summary>
        public Move GetEasyMove(Board board)
        {
            List<Move> listCanMove = this.GetAllMove(board, board.Curentlayer.sideplayer);

            int value=Int32.MinValue;
            Move moveEasy = null;
           // string str = "";

            foreach(Move move in listCanMove)
            {
              
                if(move.isAttack())
                {
                    int tempValue = move.getAttackedPiece().chessPieceType.weight;
                    if (tempValue>value)
                    {
                        value = tempValue;
                        moveEasy = move;
                       
                    }
              //      str = str + "   " + move.getAttackedPiece().chessPieceType.chessPieceName;
                }
            }

          //  MessageBox.Show(str+listCanMove.Count());
            if (moveEasy != null)
                return moveEasy;
            else
            {
                Random r = new Random();
                return listCanMove[r.Next() % listCanMove.Count()];
            }
           
        }

        /// <summary>
        /// Lấy ra di chuyển thích hợp nhất
        /// </summary>
        /// <param name="board"></param>
        /// <param name="depth"></param>
        /// <returns></returns>
        public Move CaculateBestMove(Board board,int depth)
        {
            Move bestMove = null;
            int heightestValue = Int32.MinValue;
            int lowestValue = Int32.MaxValue;
            int currentValue;

            foreach (Move move in GetAllMove(board, board.Curentlayer.sideplayer))
            {
                Board currentBoard= new Board(board.Curentlayer.sideplayer);
                //currentBoard = board.Clone();
                currentBoard = move.ExcuteMove(board);
                currentBoard.SetNextPlayer();
               // board = move.ExcuteMove(board);
              //  board.SetNextPlayer();

                if (currentBoard.Curentlayer.sideplayer == ChessPieceSide.WHITE)
                {
                    currentValue = FindMax(currentBoard, depth - 1);
                    if (currentValue > heightestValue)
                    {
                        heightestValue = currentValue;
                        bestMove = move;
                    }
                }
                else
                {
                    currentValue = FindMin(currentBoard, depth - 1);
                    if (currentValue < lowestValue)
                    {
                        lowestValue = currentValue;
                        bestMove = move;
                    }
                }
            }

            return bestMove;
        }

        /// <summary>
        /// Lấy toàn bộ di chuyển có thể trong bàn cờ
        /// </summary>
        /// <param name="board"></param>
        /// <param name="side"></param>
        /// <returns></returns>
        List<Move> GetAllMove(Board board, ChessPieceSide? side=null)
        {
            //neu side=null co nghia la get toan bo quan co
            //nguoc lai chi get ben side thoi ne.

            List<Move> listmove = new List<Move>();

            //int count = 0;
            //string str = "";
            if (side != null)
            {
                foreach(Cell cell in board.listCell)
                {
                    ChessPieces piece = cell.GetChessPieces();
                    //neu tai vi tri cell nay co quan co 
                    // va la quan co dang can lay thi lay cai move cua no
                    if (piece != null && piece.side==side)
                    {
                        //count++;
                        listmove.AddRange(piece.getLegalMoves(board));
                        //str = str + "   " +piece.chessPieceType.chessPieceName+"  "+piece.side+"   ";
                    }
                }
            }
            // MessageBox.Show("so quan co: " + count+": "+str);
            //MessageBox.Show(board.listCell.Count()+"");
            return listmove;
        }

        ///<summary>
        /// lấy tổng số điểm còn lại của các quân cờ trên bàn cờ
        ///</summary>
        int ValuePiece(Board board, ChessPieceSide side)
        {
            int sum = 0;
            
            foreach(Cell cell in board.listCell)
            {
                ChessPieces piece = cell.GetChessPieces();
                if (piece != null)
                {
                    sum += piece.chessPieceType.weight;
                }
            }

            return sum;
        }        

        /// <summary>
        /// tính toán xem thế cờ này trị giá bao nhiêu
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        int EvalutorBoard(Board board)
        {
            return ValuePiece(board,ChessPieceSide.WHITE)- ValuePiece(board, ChessPieceSide.BLACK);
        }

        /// <summary>
        /// Tìm ra giá trị nhỏ nhất ( tốt nhất-> nước cờ tốt nhất cho Black)
        /// </summary>
        /// <returns></returns>
        int FindMin(Board board, int depth)
        {
            if (depth == 0/*||GameOver*/)
            {
                return this.EvalutorBoard(board);
            }

            int min = Int32.MaxValue;

            foreach(Move move in GetAllMove(board,board.Curentlayer.sideplayer))
            {
                Board currentBoard= new Board(board.Curentlayer.sideplayer);
                //currentBoard = board.Clone();
                currentBoard = move.ExcuteMove(board);
                currentBoard.SetNextPlayer();
                //board = move.ExcuteMove(board);
                //board.SetNextPlayer();

                int tempValue = FindMax(currentBoard, depth - 1);

                if (tempValue < min)
                    min = tempValue;
            }

            return min;
        }

        /// <summary>
        /// Tìm ra giá trị lon nhất ( tốt nhất-> nước cờ tốt nhất cho White)
        /// </summary>
        /// <returns></returns>
        int FindMax(Board board, int depth)
        {
            if (depth == 0/*||GameOver*/)
            {
                return this.EvalutorBoard(board);
            }

            int max = Int32.MinValue;

            foreach (Move move in GetAllMove(board, board.Curentlayer.sideplayer))
            {
                Board currentBoard= new Board(board.Curentlayer.sideplayer);
                //currentBoard = board.Clone();
                currentBoard = move.ExcuteMove(board);
                currentBoard.SetNextPlayer();
               // board = move.ExcuteMove(board);
                //board.SetNextPlayer();

                int tempValue = FindMin(currentBoard, depth - 1);

                if (tempValue > max)
                    max = tempValue;
            }

            return max;
        }
    }
}
