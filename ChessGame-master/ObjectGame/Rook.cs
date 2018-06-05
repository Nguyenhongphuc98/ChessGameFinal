using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectGame
{
    public class Rook : ChessPieces
    {

        protected static int[] legalMoveArguments = { -8, -1, 1, 8 };

        public Rook(int position, ChessPieceType type, ChessPieceSide side) : base(position, type, side)
        {
        }

        public override object Clone()
        {
            return new Rook(this.chessPiecePosition, this.chessPieceType, this.side);
        }

        public override List<Move> getLegalMoves(Board board)
        {
            List<Move> ListCanMove = new List<Move>();
            foreach (int argument in Rook.legalMoveArguments)
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
            return checkPosition % 8 == 7 && argument == 1;
        }

        private  bool firstColumnViolation(int checkPosition, int argument)
        {
            return checkPosition % 8 == 0 && argument == -1;
        }

        public override ChessPieces movePiece(Move move)
        {
            return new Rook(move.destination, move.actionPiece.chessPieceType, move.actionPiece.side);
        }
    }
}
