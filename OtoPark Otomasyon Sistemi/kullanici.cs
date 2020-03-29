using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OtoPark_Otomasyon_Sistemi
{
    public partial class kullanici : Form
    {
        public kullanici()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form yn = new yonetici();
            yn.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form prs = new Kullanıcı_Girişi();
            prs.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
