using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EczaneOtomastonSinemTokgöz
{
    public partial class KullaniciBilgiler : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-SINEM\\SQLEXPRESS;Initial Catalog=EczaneOtomasyonSinemTokgöz;Integrated Security=True");
        public KullaniciBilgiler()
        {
            InitializeComponent();
        }
        
        private void KullaniciBilgiler_Load(object sender, EventArgs e)
        {


            for (int i = 0; i < 256; i++)
            {
                comboBox1.Items.Add(i);
            }

            // TODO: Bu kod satırı 'eczaneOtomasyonSinemTokgözDataSet.BilgiTablosu' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.bilgiTablosuTableAdapter.Fill(this.eczaneOtomasyonSinemTokgözDataSet.BilgiTablosu);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //EKLE BUTONU 
            baglanti.Open();
            SqlCommand ekle = new SqlCommand();
            ekle.Connection = baglanti;
            ekle.CommandType = CommandType.StoredProcedure;
            ekle.CommandText = "Sp_ekle";
            ekle.Parameters.Add("@HastaTC", SqlDbType.VarChar, 15);
            ekle.Parameters.Add("@HastaAdi", SqlDbType.VarChar, 50);
            ekle.Parameters.Add("@HastaSoyadi", SqlDbType.VarChar, 50);
            ekle.Parameters.Add("@IlacBarkod", SqlDbType.VarChar, 20);
            ekle.Parameters.Add("@IlacAdi", SqlDbType.VarChar, 50);
            ekle.Parameters.Add("@IlacAdedi", SqlDbType.TinyInt);
            ekle.Parameters.Add("@VerilisTarihi", SqlDbType.Date);
            ekle.Parameters.Add("@KullanimAmaci", SqlDbType.VarChar, 50);
            ekle.Parameters.Add("@Fiyat", SqlDbType.Decimal);
            ekle.Parameters.Add("@TelefonNo", SqlDbType.VarChar, 15);


            ekle.Parameters["@HastaTC"].Value = maskedTextBox1.Text;
            ekle.Parameters["@HastaAdi"].Value = textBox1.Text;
            ekle.Parameters["@HastaSoyadi"].Value = textBox2.Text;
            ekle.Parameters["@IlacBarkod"].Value = textBox3.Text;
            ekle.Parameters["@IlacAdi"].Value = textBox4.Text;
            ekle.Parameters["@IlacAdedi"].Value = comboBox1.Text;
            ekle.Parameters["@VerilisTarihi"].Value = maskedTextBox2.Text;
            ekle.Parameters["@KullanimAmaci"].Value = textBox5.Text;
            ekle.Parameters["@Fiyat"].Value = textBox6.Text;
            ekle.Parameters["@TelefonNo"].Value = maskedTextBox3.Text;

            ekle.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarıyla Eklendi");
            this.bilgiTablosuTableAdapter.Fill(this.eczaneOtomasyonSinemTokgözDataSet.BilgiTablosu);
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //GÜNCELLE BUTONU 
            baglanti.Open();
            SqlCommand guncelle = new SqlCommand();
            guncelle.Connection = baglanti;
            guncelle.CommandType = CommandType.StoredProcedure;
            guncelle.CommandText = "Sp_guncelle";
       
            guncelle.Parameters.Add("@HastaTC", SqlDbType.VarChar, 15);
            guncelle.Parameters.Add("@HastaAdi", SqlDbType.VarChar, 50);
            guncelle.Parameters.Add("@HastaSoyadi", SqlDbType.VarChar, 50);
            guncelle.Parameters.Add("@IlacBarkod", SqlDbType.VarChar, 20);
            guncelle.Parameters.Add("@IlacAdi", SqlDbType.VarChar, 50);
            guncelle.Parameters.Add("@IlacAdedi", SqlDbType.TinyInt);
            guncelle.Parameters.Add("@VerilisTarihi", SqlDbType.Date);
            guncelle.Parameters.Add("@KullanimAmaci", SqlDbType.VarChar, 50);
            guncelle.Parameters.Add("@Fiyat", SqlDbType.Decimal);
            guncelle.Parameters.Add("@TelefonNo", SqlDbType.VarChar, 15);

          
            guncelle.Parameters["@HastaTC"].Value = maskedTextBox1.Text;
            guncelle.Parameters["@HastaAdi"].Value = textBox1.Text;
            guncelle.Parameters["@HastaSoyadi"].Value = textBox2.Text;
            guncelle.Parameters["@IlacBarkod"].Value = textBox3.Text;
            guncelle.Parameters["@IlacAdi"].Value = textBox4.Text;
            guncelle.Parameters["@IlacAdedi"].Value = comboBox1.Text;
            guncelle.Parameters["@VerilisTarihi"].Value = maskedTextBox2.Text;
            guncelle.Parameters["@KullanimAmaci"].Value = textBox5.Text;
            guncelle.Parameters["@Fiyat"].Value = textBox6.Text;
            guncelle.Parameters["@TelefonNo"].Value = maskedTextBox3.Text;

            guncelle.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarıyla Güncellendi");
            this.bilgiTablosuTableAdapter.Fill(this.eczaneOtomasyonSinemTokgözDataSet.BilgiTablosu);
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //SİL BUTONU
            baglanti.Open();
            SqlCommand sil = new SqlCommand();
            sil.Connection = baglanti;
            sil.CommandType = CommandType.StoredProcedure;
            sil.CommandText = "Sp_sil";
            sil.Parameters.Add("@HastaAdi", SqlDbType.VarChar, 50);
            sil.Parameters["@HastaAdi"].Value = textBox1.Text;
            sil.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarıyla Silindi");
            this.bilgiTablosuTableAdapter.Fill(this.eczaneOtomasyonSinemTokgözDataSet.BilgiTablosu);
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ARA BUTONU 
            baglanti.Open();
            SqlCommand ara = new SqlCommand();
            ara.Connection = baglanti;
            ara.CommandType = CommandType.StoredProcedure;
            ara.CommandText = "Sp_ara";
            ara.Parameters.Add("@HastaAdi", SqlDbType.VarChar, 50);
            ara.Parameters["@HastaAdi"].Value = textBox7.Text;
            SqlDataAdapter da = new SqlDataAdapter(ara);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables["BilgiTablosu"];
            ara.ExecuteNonQuery();
           
            baglanti.Close();

         

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int satirno;
            satirno = e.RowIndex;
            listBox1.Items.Clear();
            listBox1.Items.Add(dataGridView1.Rows[satirno].Cells[0].Value.ToString());
            listBox1.Items.Add(dataGridView1.Rows[satirno].Cells[1].Value.ToString());
            listBox1.Items.Add(dataGridView1.Rows[satirno].Cells[2].Value.ToString());
            listBox1.Items.Add(dataGridView1.Rows[satirno].Cells[3].Value.ToString());
            listBox1.Items.Add(dataGridView1.Rows[satirno].Cells[4].Value.ToString());
            listBox1.Items.Add(dataGridView1.Rows[satirno].Cells[5].Value.ToString());
            listBox1.Items.Add(dataGridView1.Rows[satirno].Cells[6].Value.ToString());
            listBox1.Items.Add(dataGridView1.Rows[satirno].Cells[7].Value.ToString());
            listBox1.Items.Add(dataGridView1.Rows[satirno].Cells[8].Value.ToString());
            listBox1.Items.Add(dataGridView1.Rows[satirno].Cells[9].Value.ToString());
        }
    }
}
