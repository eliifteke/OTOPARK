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
    public partial class gecmis : Form
    {
        public gecmis()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-KH982DGC;Initial Catalog=otopakk;Integrated Security=True");

        DataTable tablo = new DataTable();

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        //arama
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            tablo.Clear();
            SqlCommand adap = new SqlCommand("select * from gecmis where plaka like '%" + textBox1.Text + "%'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(adap);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }


        //verileri tabloda gösterme
        private void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            verilerigoster("Select * from gecmis");

        }


        //listede üstüne basınca textboxda yerine gelmesi 
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string plaka = dataGridView1.Rows[secilialan].Cells[0].Value.ToString();

            textBox2.Text = plaka;
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
            if (Convert.ToString(selectedRow.Cells["csaat"].Value).Equals(""))
            {
                MessageBox.Show("Araç çıkışı yapılmadığı için tablodan silinemez");

            }
            else
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("delete from gecmis where plaka= @k1", baglanti);
                cmd.Parameters.AddWithValue("@k1", textBox2.Text);
                cmd.ExecuteNonQuery();
                baglanti.Close();

                verilerigoster("Select * from gecmis");
            }
        }

       
    }
}
