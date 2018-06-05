using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectGame
{
    public class Queen : ChessPieces
    {

        protected static int[] legalMoveArguments = { -9, -8, -7, -1, 1, 7, 8, 9 };

        public Queen(int position, ChessPieceType type, ChessPieceSide side) : base(position, type, side)
        {
        }

        public override object Clone()
        {
            return new Queen(this.chessPiecePosition, this.chessPieceType, this.side);
        }

        public override List<Move> getLegalMoves(Board board)
        {
            List<Move> ListCanMove = new List<Move>();
            foreach (int argument in Queen.legalMoveArguments)
            {
                int checkPosition = this.chessPiecePosition;

                while (board.checkedForLegalPosition(checkPosition))
                {
                    if (this.firstColumnViolation(checkPosition, argument) ||
                        this.eightColumnViolation(checkPosition, argument))
                        break;

                    checkPosition += argument;
                    if (board.checkedForLegalPosition(checkPosition))
                    {
                        Cell currentCell = board.GetCell(checkPosition);
                        if (!currentCell.Occupied())
                        {
                            ListCanMove.Add(new NormalMove( this, checkPosition));
                        }
                        else
                        {
                            if (this.side != currentCell.GetChessPieces().side)
                            {
                                ListCanMove.Add(new AttackMove( this, checkPosition, currentCell.GetChessPieces()));
                            }
                            break;
                        }
                    }
                }
            }
            return ListCanMove;
        }

        private  bool eightColumnViolation(int checkPosition, int argument)
        {
            return checkPosition % 8 == 7 && ((argument == 1) || (argument == -7) || (argument == 9));
        }

        private  bool firstColumnViolation(int checkPosition, int argument)
        {
            return checkPosition % 8 == 0 && ((argument == -1 || argument == -9 || argument == 7));
        }

        public override ChessPieces movePiece(Move move)
        {
            return new Queen(move.destination, move.actionPiece.chessPieceType, move.actionPiece.side);
        }
    }
}
