using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectGame;

namespace ObjectGame
{
    abstract public class Cell
    {
        public int iPosition { get; set; }

        public Cell(int position)
        {
            this.iPosition = position;
        }

        public abstract bool Occupied();
        public abstract ChessPieces GetChessPieces();
        public static Cell CreateCell(int position,ChessPieces piece)
        {
            if (piece != null)
                return new OccupiedCell(position, piece);
            else
                return new EmptyCell(position);
        }
    }
}
