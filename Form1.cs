using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace ex1;

public partial class Form1 : Form
{
     SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
    public Form1()
    {
        InitializeComponent();
    } void MusteriGetir()
        {
            baglanti= new SqlConnection("server=.;Initial Catalog=ticaret;Integrated Security=SSPI"); 
            baglanti.Open();
            da= new SqlDataAdapter("SELECT * FROM musteri",baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MusteriGetir(); 
        }
        private void ekle(object sender, EventArgs e){
                string sor="INSERT INTO musteri(ad,soyad,dtarih,tel) VALUES (@ad,@soyad,@dtarih,@tel)";
                komut=new SqlCommand(sor,baglanti);
                komut.Parameters.AddWithValue("@ad", txtAd.Text);
                komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
                komut.Parameters.AddWithValue("@dtarih", dateTimePicker1.Value);
                komut.Parameters.AddWithValue("@tel", txtTelefon.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MusteriGetir();
        }
         private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtNo.Text=dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAd.Text=dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text=dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Text=dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtTelefon.Text=dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
        private void sil(object sender, EventArgs e){
                string sor="DELETE FROM musteri WHERE mno=@mno";
                komut=new SqlCommand(sor,baglanti);
                komut.Parameters.AddWithValue("@mno", Convert.ToInt32(txtNo.Text));
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MusteriGetir();
        }
        private void guncelle(object sender, EventArgs e){
                string sor="UPDATE musteri SET ad=@ad,soyad=@soyad,dtarih=@dtarih,tel=@tel WHERE mno=@mno";
                komut=new SqlCommand(sor,baglanti);
                komut.Parameters.AddWithValue("@mno", Convert.ToInt32(txtNo.Text));
                komut.Parameters.AddWithValue("@ad", txtAd.Text);
                komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
                komut.Parameters.AddWithValue("@dtarih", dateTimePicker1.Value);
                komut.Parameters.AddWithValue("@tel", txtTelefon.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MusteriGetir();
        }

    }
