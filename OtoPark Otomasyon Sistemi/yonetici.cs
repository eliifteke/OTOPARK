using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OtoPark_Otomasyon_Sistemi
{
    public partial class yonetici : Form
    {
        public yonetici()
        {
            InitializeComponent();
        }
        public static SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-KH982DGC;Initial Catalog=otopakk;Integrated Security=True");


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
                SqlCommand komut = new SqlCommand("Select * From yonetici where kullanici_adi='" + textBox1.Text.ToString() + "'", baglanti);
                SqlDataReader okuyucu = komut.ExecuteReader();
                if (okuyucu.Read() == true)
                {
                    if (textBox1.Text.ToString() == okuyucu["kullanici_adi"].ToString() && textBox2.Text.ToString() == okuyucu["sifre"].ToString())
                    {
                        Form yoneticimenü = new yoneticimenü();
                        yoneticimenü.Show();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form kl = new kullanici();
            kl.Show();
            this.Hide();
        }
    }
}

