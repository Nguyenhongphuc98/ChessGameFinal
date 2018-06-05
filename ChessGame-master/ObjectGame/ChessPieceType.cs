using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectGame
{
    public class ChessPieceType
    {
        public string chessPieceName { get; }
        public int weight { get; }

        public ChessPieceType(string name,int value)
        {
            this.chessPieceName = name;
            this.weight = value;
        }

        public static ChessPieceType PAW = new ChessPieceType("Paw", 100);
        public static ChessPieceType KNIGHT = new ChessPieceType("Knight", 200);
        public static ChessPieceType ROOK = new ChessPieceType("Rook", 400);
        public static ChessPieceType BISHOP = new ChessPieceType("Bishop", 300);
        public static ChessPieceType QUEEN = new ChessPieceType("Queen", 700);
        public static ChessPieceType KING = new ChessPieceType("King", 1000);


    }
}
