using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectGame
{
    public class Player
    {
        public ChessPieceSide sideplayer { get; set; }
        public King king;

        public Player(King king,ChessPieceSide c)
        {
            this.king = king;
            this.sideplayer = c;
        }

    }
}
