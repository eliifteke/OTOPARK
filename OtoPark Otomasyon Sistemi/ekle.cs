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
    public partial class ekle : Form
    {
        public ekle()
        {
            InitializeComponent();
        }
       
        private void ekle_Load(object sender, EventArgs e)
        {
            Kullanıcı_Girişi.baglanti.Open();
            //databasedeki parkyeri 0 olanları seç 
            SqlCommand komut = new SqlCommand("Select * from parkyeri where durum=0", Kullanıcı_Girişi.baglanti);
            SqlDataReader okuyucu = komut.ExecuteReader();
            while(okuyucu.Read())
            {
                comboBox1.Items.Add(okuyucu["parkyeri"].ToString());
            }
            Kullanıcı_Girişi.baglanti.Close();
            
        }

       
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //şu anın tarihini al
            string tarih = DateTime.Now.ToString();

            //müşteri tablosuna ekle
            Kullanıcı_Girişi.baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Insert Into musteri (p,marka,model,plaka,adi,soyadi,gsaat,durum,aracyikama) Values ('" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + tarih.ToString() + "','0','"+comboBox2.Text+"')", Kullanıcı_Girişi.baglanti);
            komut2.ExecuteNonQuery();
            Kullanıcı_Girişi.baglanti.Close();

            //parkyeri tablosunu güncelle
            Kullanıcı_Girişi.baglanti.Open();
            SqlCommand komut3 = new SqlCommand("update parkyeri set durum='1' where parkyeri LIKE'" + comboBox1.Text + "'", Kullanıcı_Girişi.baglanti);
            komut3.ExecuteNonQuery();
            Kullanıcı_Girişi.baglanti.Close();

            //geçmiş tablsonua ekle
            Kullanıcı_Girişi.baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Insert Into gecmis (plaka,adi,soyadi,marka,model,p,aracyikama,gsaat) Values ('" + textBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','"+comboBox2.Text+"','" + tarih.ToString() + "')", Kullanıcı_Girişi.baglanti);
            komut4.ExecuteNonQuery();
            Kullanıcı_Girişi.baglanti.Close();

            MessageBox.Show( "Başarıyla tamamlandı", "OTOPARK");
            //araç eklendikten sonra verileri temizle
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            ekle_Load(sender, e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
