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
    public partial class ManHinhChinh : Form
    {
        public ManHinhChinh()
        {
            InitializeComponent();
        }

        private void btPlay_Click(object sender, EventArgs e)
        {
            FormMenu form = new FormMenu();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        //thoat game hien tai
        private void btexit_Click(object sender, EventArgs e)
        {
           DialogResult result= MessageBox.Show("Bạn có chắc chắn muốn thoát Game!!!","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(result==DialogResult.Yes)
            this.Close();
        }

        //hien thi thong tin san pham
        private void btabout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
    }
}
