using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OtoPark_Otomasyon_Sistemi
{
    public partial class araccikis : Form
    {
        public araccikis()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-KH982DGC;Initial Catalog=otopakk;Integrated Security=True");

        private void araccikis_Load(object sender, EventArgs e)
        {
            //combobox değerlerii 

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from musteri where durum=0", baglanti);
            SqlDataReader okuyucu = komut.ExecuteReader();
            while(okuyucu.Read())
            {
                comboBox1.Items.Add(okuyucu["plaka"].ToString());
            }
            baglanti.Close();
        }

        DateTime tarih;
        string parkyeri = "";
  
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            double aracyikama = 0;
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select * from musteri where durum=0 and plaka LIKE'" + comboBox1.Text + "'", baglanti);
            SqlDataReader okuyucu2 = komut2.ExecuteReader();

            while (okuyucu2.Read())
            {
                label3.Text = okuyucu2["marka"].ToString();
                label4.Text = okuyucu2["model"].ToString();
                label6.Text = okuyucu2["adi"].ToString();
                label8.Text = okuyucu2["soyadi"].ToString();
                tarih = Convert.ToDateTime(okuyucu2["gsaat"].ToString());
                parkyeri = okuyucu2["p"].ToString();
                label12.Text = okuyucu2["aracyikama"].ToString();

            }
            //araç yıkama vars 15tl ekleme  
            if (label12.Text=="Var")
            {
                aracyikama = 15;
            }
            else if(label12.Text=="Yok")
            {
                aracyikama = 0;
            }
            baglanti.Close();
            
            //Zaman Hesabı
            System.TimeSpan zaman;

            DateTime sondeger = DateTime.Now;
            zaman = sondeger.Subtract(tarih);
            double saat = Convert.ToDouble(zaman.TotalHours);

            //fiyat hesabıı 
            double para = 2 * double.Parse(saat.ToString("0.##"));
            label11.Text = (aracyikama + para).ToString() + " TL";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //park yeri tablosnun güncelle
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("update parkyeri set durum=0 where parkyeri='" + parkyeri + "'", baglanti);
            komut4.ExecuteNonQuery();
            baglanti.Close();

            //müşteri tablosunu güncelle
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("update musteri set durum=1 where plaka='" + comboBox1.Text + "'", baglanti);
            komut5.ExecuteNonQuery();
            baglanti.Close();

            //geçmiş tablsosunu güncelleme
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("update gecmis set csaat='" + DateTime.Now + "', fiyat='" + label11.Text + "' where plaka='" + comboBox1.Text + "'", baglanti);
            komut6.ExecuteNonQuery();
            baglanti.Close();


            MessageBox.Show("Araç çıkışı yapılmıştır.", "OTOPARK");
            parkyeri = "";
            label3.Text = "";
            label4.Text = "";
            label6.Text = "";
            label8.Text = "";
            comboBox1.Text = "";
            label11.Text = "";
            label12.Text = "";
            comboBox1.Items.Clear();
            araccikis_Load(sender, e);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
