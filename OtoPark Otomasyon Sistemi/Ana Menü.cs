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
    public partial class Ana_Menü : Form
    {
        public Ana_Menü()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form kapat = new Kullanıcı_Girişi();
            kapat.Show();
            this.Close();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form ekle = new ekle();
            ekle.Show();
       
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form ac = new araccikis();
            ac.Show();
           
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form kn = new konum();
            kn.Show();
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form gc = new gecmis();
            gc.Show();
        }

        private void Ana_Menü_Load(object sender, EventArgs e)
        {

        }
    }
}
