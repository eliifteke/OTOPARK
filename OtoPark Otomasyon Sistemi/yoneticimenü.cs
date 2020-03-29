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
    public partial class yoneticimenü : Form
    {
        public yoneticimenü()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form kapat = new kullanici();
            kapat.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form anamenu = new Ana_Menü();
            anamenu.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form ana = new Ana_Menü();
            ana.Show();
            this.Close();
        }

        private void yoneticimenü_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form ye = new yöneticiekle();
            ye.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form ye = new yöneticiekle();
            ye.Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form pe = new personelekle();
            pe.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form pe = new personelekle();
            pe.Show();
            this.Close();
        }
    }
}
