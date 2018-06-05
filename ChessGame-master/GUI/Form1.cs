using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            

        }

        private void btn2Player_Click(object sender, EventArgs e)
        {
            int mode = 1;
            Mode1AndMode2 mode12 = new Mode1AndMode2(mode);
            //this.Hide();
            mode12.ShowDialog();
            //this.Show();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDanhVoiMay_Click(object sender, EventArgs e)
        {
            int mode = 2;
            Mode1AndMode2 mode12 = new Mode1AndMode2(mode);
            //this.Hide();
            mode12.ShowDialog();
           // this.Show();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            int mode = 3;
            Mode1AndMode2 mode12 = new Mode1AndMode2(mode);
            this.Hide();
            mode12.ShowDialog();
            this.Show();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát,nhấn No để ở lại!!!","Thông Báo", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
          //  if(result==DialogResult.Yes)
            this.Close();
        }
    }
}
