using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectGame
{
    public class Pawn : ChessPieces
    {

        protected static int[] legalMoveArguments = { 8, 16, 7, 9 };
        int vector;

        public Pawn(int position, ChessPieceType type, ChessPieceSide side) : base(position, type, side)
        {
            if (side == ChessPieceSide.BLACK)
                this.vector = 1;
            else
                this.vector = -1;
        }

        public override object Clone()
        {
            return new Pawn(this.chessPiecePosition, this.chessPieceType, this.side);
        }

        public override List<Move> getLegalMoves(Board board)
        {
            List<Move> ListCanMove = new List<Move>();
            foreach (int argument in legalMoveArguments)
            {
                int checkPosition = this.chessPiecePosition + (this.vector * argument);

                if (!board.checkedForLegalPosition(checkPosition))
                    continue;

                //neu di thang len ve phia truoc ma chua co quan nao chan lai( can tro)
                if (argument == 8 && !board.GetCell(checkPosition).Occupied())
                {
                    ListCanMove.Add(new NormalMove(this, checkPosition));
                }

                //neu xet den nhay qua 1 o cho truong hop con tot di lan dau
                if (argument == 16 && ( this.chessPiecePosition / 8 == 1 && this.side==ChessPieceSide.BLACK ||
                     this.chessPiecePosition / 8 == 6 && this.side == ChessPieceSide.WHITE))
                {
                    // neu ca 2 o phia truoc no dang trong thi co the di chuyen
                    int behindPosition = this.chessPiecePosition + (this.vector * 8);
                    if (!board.GetCell(checkPosition).Occupied() &&
                        !board.GetCell(behindPosition).Occupied())
                    {
                        ListCanMove.Add(new NormalMove(this, checkPosition));
                    }
                }

                //neu co quan dich nam cheo sat 1 ben thi co the tan cong
                //neu nhu khong vi pham nguyen tac di chuyen
                if (((argument == 9 && CheckArgument9())||argument==7 &&CheckArgument7())
                    && board.GetCell(checkPosition).Occupied())
                { 
                    ChessPieces occupiedPiece = board.GetCell(checkPosition).GetChessPieces();
                    if (occupiedPiece.side != this.side)
                    {
                        ListCanMove.Add(new AttackMove(this, checkPosition, occupiedPiece));
                        //MessageBox.Show("attack");
                    }
                }

            }

            return ListCanMove;
        }

        bool CheckArgument9()
        {
            return !((this.chessPiecePosition % 8 == 7 && this.side == ChessPieceSide.BLACK) ||
                (this.chessPiecePosition % 8 == 0 && this.side == ChessPieceSide.WHITE));
        }

        bool CheckArgument7()
        {
            return !((this.chessPiecePosition % 8 == 0 && this.side == ChessPieceSide.BLACK) ||
                    (this.chessPiecePosition % 8 == 7 && this.side == ChessPieceSide.WHITE));
        }

        public override ChessPieces movePiece(Move move)
        {
            return new Pawn(move.destination, move.actionPiece.chessPieceType, move.actionPiece.side);
        }
    }
}
