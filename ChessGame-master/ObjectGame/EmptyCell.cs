using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectGame
{
    public class EmptyCell : Cell
    {
        public EmptyCell(int position):base(position)
        { }

        public override ChessPieces GetChessPieces()
        {
           return null;
        }

        public override bool Occupied()
        {
            return false;
        }
    }
}
