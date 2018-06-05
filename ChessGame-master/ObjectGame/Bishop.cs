using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectGame
{
    public class Bishop : ChessPieces
    {
        private static int[] legalMovesArguments = { -9, -7, 7, 9 };

        public Bishop(int position, ChessPieceType type, ChessPieceSide side) : base(position, type, side)
        {
        }

        public override object Clone()
        {
            return new Bishop(this.chessPiecePosition, this.chessPieceType, this.side);
        }

        /// <summary>
        /// lấy ra tất cả các di chuyển có thể
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public override List<Move> getLegalMoves(Board board)
        {
            List<Move> listCanMove = new List<Move>();
            foreach (int argument in Bishop.legalMovesArguments)
            {
                int checkPosition = this.chessPiecePosition;

                while (board.checkedForLegalPosition(checkPosition))
                {
                    if (firstColumnViolation(checkPosition, argument) ||
                        eightColumnViolation(checkPosition, argument))
                        break;

                    checkPosition += argument;
                    if (board.checkedForLegalPosition(checkPosition))
                    {

                        Cell currentCell = board.GetCell(checkPosition);
                        if (!currentCell.Occupied())
                        {
                           listCanMove.Add(new NormalMove(this,checkPosition));
                        }
                        else
                        {
                            //da bi chiem dong
                            //neu khac thi moi co the them vao move
                            if (this.side != currentCell.GetChessPieces().side)
                            {
                                listCanMove.Add(new AttackMove(this,checkPosition, currentCell.GetChessPieces()));
                            }
                            break;
                        }
                    }
                }

            }
            return listCanMove;
        }

        private bool eightColumnViolation(int checkPosition, int argument)
        {
            return checkPosition % 8 == 7 && ((argument == -7) || (argument == 9));
        }

        private bool firstColumnViolation(int checkPosition, int argument)
        {
            return checkPosition % 8 == 0 && ((argument == -9) || (argument == 7));
        }

        public override ChessPieces movePiece(Move move)
        {
            return new Bishop(move.destination, move.actionPiece.chessPieceType, move.actionPiece.side);
        }
    }
}
