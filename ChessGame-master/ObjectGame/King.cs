using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ObjectGame
{
    public class King : ChessPieces
    {
        protected static int[] legalMoveArguments = { -9, -8, -7, -1, 1, 7, 8, 9 };


        public King(int position, ChessPieceType type, ChessPieceSide side) : base(position, type, side)
        {
        }

        public override object Clone()
        {
            return new King(this.chessPiecePosition, this.chessPieceType, this.side);
        }

        public override List<Move> getLegalMoves(Board board)
        {
            List<Move> ListCanMove = new List<Move>();
            foreach (int argument in King.legalMoveArguments)
            {
                int checkPosition = this.chessPiecePosition + argument;
                if (!board.checkedForLegalPosition(checkPosition) ||
                    King.firstColumnViolation(this.chessPiecePosition, argument) ||
                    King.eightColumnViolation(this.chessPiecePosition, argument))
                    continue;

                else
                {
                    Cell currentCell = board.GetCell(checkPosition);
                    if (!currentCell.Occupied())
                    {
                        ListCanMove.Add(new NormalMove(this,checkPosition));
                    }
                    else
                    {
                        if (this.side != currentCell.GetChessPieces().side)
                        {
                            ListCanMove.Add(new AttackMove(this,checkPosition,currentCell.GetChessPieces()));
                        }
                    }
                }
            }

            return ListCanMove;
        }

        private static bool firstColumnViolation(int Position, int argument)
        {
            return Position % 8 == 0 && ((argument == -1 || argument == -9 || argument == 7));
        }

        private static bool eightColumnViolation(int Position, int argument)
        {
            return Position % 8 == 7 && ((argument == 1) || (argument == -7) || (argument == 9));
        }

        public override ChessPieces movePiece(Move move)
        {
            return new King(move.destination, move.actionPiece.chessPieceType, move.actionPiece.side);
        }
    }
}
