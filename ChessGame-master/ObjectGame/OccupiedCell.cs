using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectGame
{
    public class OccupiedCell : Cell
    {
        ChessPieces chessPiece;

        public OccupiedCell(int position, ChessPieces piece):base(position)
        {
            this.chessPiece = piece;
        }

        public override ChessPieces GetChessPieces()
        {
            return (ChessPieces) chessPiece.Clone();
        }

        public override bool Occupied()
        {
            return true;
        }
    }
}
