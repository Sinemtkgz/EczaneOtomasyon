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
    public partial class IlacBilgi : Form
    {
        public IlacBilgi()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-SINEM\\SQLEXPRESS;Initial Catalog=EczaneOtomasyonSinemTokgöz;Integrated Security=True");

        private void IlacBilgi_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < 256; i++)
            {
                comboBox1.Items.Add(i);
            }

            // TODO: Bu kod satırı 'eczaneOtomasyonSinemTokgözDataSet1.IlacTablo' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ilacTabloTableAdapter.Fill(this.eczaneOtomasyonSinemTokgözDataSet1.IlacTablo);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand iekle = new SqlCommand();
            iekle.Connection = baglan;
            iekle.CommandType = CommandType.StoredProcedure;
            iekle.CommandText = "SP_veriekle";
            iekle.Parameters.Add("@IlacAdi", SqlDbType.VarChar, 50);
            iekle.Parameters.Add("@IlacKodu", SqlDbType.VarChar,20);
            iekle.Parameters.Add("@GeldigiTarih", SqlDbType.Date);
            iekle.Parameters.Add("@StokAdedi", SqlDbType.TinyInt);
            iekle.Parameters.Add("@StokYenilenmeTarih", SqlDbType.Date);

            iekle.Parameters["@IlacAdi"].Value = textBox1.Text;
            iekle.Parameters["@IlacKodu"].Value = textBox2.Text;
            iekle.Parameters["@GeldigiTarih"].Value = maskedTextBox1.Text;
            iekle.Parameters["@StokAdedi"].Value = comboBox1.Text;
            iekle.Parameters["@StokYenilenmeTarih"].Value = maskedTextBox2.Text;

            iekle.ExecuteNonQuery();

            MessageBox.Show("İlaç Başarıyla Eklendi");
            this.ilacTabloTableAdapter.Fill(this.eczaneOtomasyonSinemTokgözDataSet1.IlacTablo);
            baglan.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand gunc = new SqlCommand();
            gunc.Connection = baglan;
            gunc.CommandType = CommandType.StoredProcedure;
            gunc.CommandText = "SP_veriguncelle";
            gunc.Parameters.Add("@Id", SqlDbType.Int);
            gunc.Parameters.Add("@IlacAdi", SqlDbType.VarChar, 50);
            gunc.Parameters.Add("@IlacKodu", SqlDbType.VarChar, 20);
            gunc.Parameters.Add("@GeldigiTarih", SqlDbType.Date);
            gunc.Parameters.Add("@StokAdedi", SqlDbType.TinyInt);
            gunc.Parameters.Add("@StokYenilenmeTarih", SqlDbType.Date);

           
            gunc.Parameters["@IlacAdi"].Value = textBox1.Text;
            gunc.Parameters["@IlacKodu"].Value = textBox2.Text;
            gunc.Parameters["@GeldigiTarih"].Value = maskedTextBox1.Text;
            gunc.Parameters["@StokAdedi"].Value = comboBox1.Text;
            gunc.Parameters["@StokYenilenmeTarih"].Value = maskedTextBox2.Text;

            gunc.ExecuteNonQuery();

            MessageBox.Show("İlaç Başarıyla Güncellendi");
            this.ilacTabloTableAdapter.Fill(this.eczaneOtomasyonSinemTokgözDataSet1.IlacTablo);
            baglan.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand isil = new SqlCommand();
            isil.Connection = baglan;
            isil.CommandType = CommandType.StoredProcedure;
            isil.CommandText = "SP_ilacsil";
            isil.Parameters.Add("@IlacAdi", SqlDbType.VarChar, 50);
            isil.Parameters["@IlacAdi"].Value = textBox1.Text;
            isil.ExecuteNonQuery();
            MessageBox.Show("İlaç Başarıyla Silindi");
            this.ilacTabloTableAdapter.Fill(this.eczaneOtomasyonSinemTokgözDataSet1.IlacTablo);
            baglan.Close();
        }
    }
    
    
}
