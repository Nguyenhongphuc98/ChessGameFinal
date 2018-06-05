using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectGame
{
    public class Knight : ChessPieces
    {

        protected static int[] legalMoveArguments = { -17, -15, -10, -6, 6, 10, 15, 17 };

        public Knight(int position, ChessPieceType type, ChessPieceSide side) : base(position, type, side)
        {
        }

        public override object Clone()
        {
            return new Knight(this.chessPiecePosition, this.chessPieceType, this.side);
        }

        public override List<Move> getLegalMoves(Board board)
        {
            List<Move> ListCanMove = new List<Move>();

            foreach (int argument in Knight.legalMoveArguments)
            {
                int CheckPosition = this.chessPiecePosition + argument;
                if (!board.checkedForLegalPosition(CheckPosition) ||
                    Knight.firstColumnViolation(this.chessPiecePosition, argument) ||
                    Knight.secondColumnViolation(this.chessPiecePosition, argument) ||
                    Knight.seventhColumnViolation(this.chessPiecePosition, argument) ||
                    Knight.eightColumnViolation(this.chessPiecePosition, argument))
                    continue;
                else
                {
                    Cell currentCell = board.GetCell(CheckPosition); //cell dang xet de di chuyen toi
                    //neu cell trong/ chua bi chiem
                    if (!currentCell.Occupied())
                    {
                        ListCanMove.Add(new NormalMove(this, CheckPosition));
                    }
                    else
                    {
                        //neu da bi chiem ma khong phai quan cua minh
                        if (this.side != currentCell.GetChessPieces().side)
                        {
                            ListCanMove.Add(new AttackMove(this,CheckPosition, currentCell.GetChessPieces()));
                        }
                    }
                }
            }

            return ListCanMove;
        }

        private static bool eightColumnViolation(int piecePosition, int argument)
        {
            return piecePosition % 8 == 7 && ((argument == -15) || (argument == -6) || (argument == 10) || (argument == 17));
        }

        private static bool seventhColumnViolation(int piecePosition, int argument)
        {
            return piecePosition % 8 == 6 && ((argument == -6) || (argument == 10));
        }

        private static bool secondColumnViolation(int piecePosition, int argument)
        {
            return piecePosition % 8 == 1 && ((argument == -10) || (argument == 6));
        }

        private static bool firstColumnViolation(int piecePosition, int argument)
        {
           return piecePosition % 8 == 0 && ((argument == -17) || (argument == -10) || (argument == 6) || (argument == 15));
        }

        public override ChessPieces movePiece(Move move)
        {
            return new Knight(move.destination, move.actionPiece.chessPieceType, move.actionPiece.side);
        }
    }
}
