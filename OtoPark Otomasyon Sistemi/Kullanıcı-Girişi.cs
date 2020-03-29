using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace OtoPark_Otomasyon_Sistemi
{
    public partial class Kullanıcı_Girişi : Form
    {
        public Kullanıcı_Girişi()
        {
            InitializeComponent();
        }
        public static SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-KH982DGC;Initial Catalog=otopakk;Integrated Security=True");

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form kln = new kullanici();
            kln.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Lütfen Giriş Bilgilerini Doldurunuz");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Kullanıcı Adını Giriniz");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Lütfen Şifreyi Giriniz");
            }
            else
            {

                baglanti.Open();
                SqlCommand komut = new SqlCommand("Select * From personel where kullanici_adi='" + textBox1.Text.ToString() + "'", baglanti);
                SqlDataReader okuyucu = komut.ExecuteReader();
                if (okuyucu.Read() == true)
                {
                    if (textBox1.Text.ToString() == okuyucu["kullanici_adi"].ToString() && textBox2.Text.ToString() == okuyucu["sifre"].ToString())
                    {
                        Form anamenu = new Ana_Menü();
                        anamenu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı Adı veya Şifre Hatalıdır! Tekrar Deneyiniz ");
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı veya Şifre Hatalıdır! Tekrar Deneyiniz ");
                    // Kullanıcı adı ve şifre hatalıysa textboxı temizler
                    textBox1.Clear();
                    textBox2.Clear();
                }
                baglanti.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Kullanıcı_Girişi_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
