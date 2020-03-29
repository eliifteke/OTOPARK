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
    public partial class yöneticiekle : Form
    {
        public yöneticiekle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-KH982DGC;Initial Catalog=otopakk;Integrated Security=True");
        DataTable tablo = new DataTable();


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form prs = new kullanici();
            prs.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form ym = new yoneticimenü();
            ym.Show();
            this.Hide();
        }



        //arama
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            tablo.Clear();
            SqlCommand adap = new SqlCommand("select * from yonetici where kullanici_adi like '%" + textBox1.Text + "%'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(adap);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }


        //verileri gösterme
        private void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void button4_Click(object sender, EventArgs e)
        {
            verilerigoster("Select * from yonetici");
        }


        //ekleme
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into yonetici (kullanici_adi, sifre, isim, soyisim) values (@kullanici_adi,@sifre,@isim,@soyisim)", baglanti);
            komut.Parameters.AddWithValue("@kullanici_adi", textBox2.Text);
            komut.Parameters.AddWithValue("@sifre", textBox3.Text);
            komut.Parameters.AddWithValue("@isim", textBox4.Text);
            komut.Parameters.AddWithValue("@soyisim", textBox5.Text);

            komut.ExecuteNonQuery();
            verilerigoster("Select * from yonetici");
            baglanti.Close();
            MessageBox.Show("Yeni Yönetici Eklenmiştir");

            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox2.Focus();
        }


        //listedekilerin textboxda çıkmasıı 
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string kullanici_adi = dataGridView1.Rows[secilialan].Cells[0].Value.ToString();
            string sifre = dataGridView1.Rows[secilialan].Cells[1].Value.ToString();
            string isim = dataGridView1.Rows[secilialan].Cells[2].Value.ToString();
            string soyisim = dataGridView1.Rows[secilialan].Cells[3].Value.ToString();


            textBox2.Text = kullanici_adi;
            textBox3.Text = sifre;
            textBox4.Text = isim;
            textBox5.Text = soyisim;
        }


        //silme
        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("delete from yonetici where kullanici_adi= @k1", baglanti);
            cmd.Parameters.AddWithValue("@k1", textBox2.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();

            verilerigoster("Select * from yonetici");


        }

        //update
        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update yonetici set sifre='" + textBox3.Text + "',isim='" + textBox4.Text + "',soyisim='" + textBox5.Text + "' where kullanici_adi='" + textBox2.Text + "'", baglanti);
            komut.ExecuteNonQuery();
            verilerigoster("select * from yonetici");
            baglanti.Close();
        }

    }
}
