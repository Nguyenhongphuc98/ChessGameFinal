using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObjectGame;

namespace GUI
{
    public partial class PromotionForm : Form
    {
        public  PictureBox Rook; //1
        public  PictureBox Queen;//2
        public  PictureBox Bishop;//3
        public  PictureBox Knight;//4


        public static int choosed;

        public PromotionForm()
        {
            InitializeComponent();
            Rook = this.pbRook;
            Queen = this.pbQueen;
            Bishop = this.pbBishop;
            Knight = this.pbKnight;

           // PromotionForm.SetIconImage(ChessPieceSide.BLACK);
        }

        public  void SetIconImage(ChessPieceSide s)
        {
            string side = s == ChessPieceSide.BLACK ? "black" : "white";
            string name = "Rook";
            string imagePath = Application.StartupPath + "\\ChessPieceIcon\\" + side + name + ".png";
            Rook.BackgroundImage = Image.FromFile(@imagePath);
            Rook.BackgroundImageLayout = ImageLayout.Center;

            name = "Knight";
            imagePath = Application.StartupPath + "\\ChessPieceIcon\\" + side + name + ".png";
            Knight.BackgroundImage = Image.FromFile(@imagePath);
            Knight.BackgroundImageLayout = ImageLayout.Center;

            name = "Queen";
            imagePath = Application.StartupPath + "\\ChessPieceIcon\\" + side + name + ".png";
            Queen.BackgroundImage = Image.FromFile(@imagePath);
            Queen.BackgroundImageLayout = ImageLayout.Center;

            name = "Bishop";
            imagePath = Application.StartupPath + "\\ChessPieceIcon\\" + side + name + ".png";
            Bishop.BackgroundImage = Image.FromFile(@imagePath);
            Bishop.BackgroundImageLayout = ImageLayout.Center;
        }

        void  ResetColorPictureBox(int option)
        {
            if(option==4)
            pbKnight.BackColor = Color.LightSteelBlue;
            else
                pbKnight.BackColor = Color.Lime;

            if(option==3)
                pbBishop.BackColor = Color.LightSteelBlue;
            else
            pbBishop.BackColor = Color.Lime;

            if (option == 1)
                pbRook.BackColor = Color.LightSteelBlue;
            else
            pbRook.BackColor = Color.Lime;

            if (option == 2)
                pbQueen.BackColor = Color.LightSteelBlue;
            else
                pbQueen.BackColor = Color.Lime;
        }
        private void pbKnight_Click(object sender, EventArgs e)
        {
            choosed = 4;
            ResetColorPictureBox(4);
        }

        private void pbBishop_Click(object sender, EventArgs e)
        {
            choosed = 3;
            ResetColorPictureBox(3);
        }


        private void pbQueen_Click(object sender, EventArgs e)
        {
            choosed = 2;
            ResetColorPictureBox(2);
        }

        private void pbRook_Click(object sender, EventArgs e)
        {
            choosed = 1;
            ResetColorPictureBox(1);
        }

        private void btok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public  ChessPieces GetChessPiece(ChessPieceSide s)
        {
            if (choosed == 1)
                return new Rook(1, ChessPieceType.ROOK, s);

            else if (choosed == 2)
                return new Queen(1, ChessPieceType.QUEEN, s);

            else if (choosed == 3)
                return new Bishop(1, ChessPieceType.BISHOP, s);

            else
                return new Knight(1, ChessPieceType.KNIGHT, s);

        }
    }
}

