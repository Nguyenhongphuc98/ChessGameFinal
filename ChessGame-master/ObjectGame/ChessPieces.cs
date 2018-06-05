using ObjectGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectGame
{
    abstract public class ChessPieces: ICloneable
    {
        public int chessPiecePosition { get; set; }
        public ChessPieceType chessPieceType { get; }
        public ChessPieceSide side { get; }

        public ChessPieces(int position,ChessPieceType type, ChessPieceSide side)
        {
            this.chessPiecePosition = position;
            this.chessPieceType = type;
            this.side = side;
        }

        public abstract List<Move> getLegalMoves(Board board);
        public abstract ChessPieces movePiece(Move move);
        public abstract object Clone();

        public bool IsPawn()
        {
            return this.chessPieceType==ChessPieceType.PAW;
        }

        public bool IsKing()
        {
            return this.chessPieceType == ChessPieceType.KING;
        }
    }
}
