using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Office.Interop.Word;
namespace Form1_for_database
{
    public partial class EkleFormu : Form
    {
        MySqlConnection librarim = new MySqlConnection("Server=localhost;database=library;user=root;password=");
        public EkleFormu(String ID)
        {
            InitializeComponent();
            textBox1.Text = ID;
            //ara();
            
        }
        void YazarlarıGetir()
        {
            string sql = "Select * From yazarlar";
            librarim.Open();
            MySqlCommand cmd = new MySqlCommand(sql,librarim);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add(dr["yazarin_ismi"]);
            }
            librarim.Close();
        }

        private void EkleFormu_Load(object sender, EventArgs e)
        {
            YazarlarıGetir();
        }

        private void button4_Click(object sender, EventArgs e)
        {


            string sql = "insert into kitaplar (kitapin_numarasi,kitapin_ismi,kitapin_yayin_evi,kitapin_turu,kitapin_sayfa_sayisi,yazarin_idisi) values (@ID,@İsim,@yayin,@Tür,@sayfa,@yazarin_idisi)";
            librarim.Open();
            MySqlCommand komut = new MySqlCommand(sql, librarim);
            komut.Parameters.AddWithValue("@ID", textBox1.Text);
            komut.Parameters.AddWithValue("@İsim", textBox2.Text);
            komut.Parameters.AddWithValue("@yayin", textBox8.Text);
            komut.Parameters.AddWithValue("@Tür", textBox3.Text);
            komut.Parameters.AddWithValue("@sayfa", textBox5.Text);
            komut.Parameters.AddWithValue("@yazarin_idisi", textBox7.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Başarılı Eklenmistir","Ekleme",MessageBoxButtons.OK ,MessageBoxIcon.Information);

            librarim.Close();
            this.Close();
  
             
            }
            
           

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

 
    
        private void button1_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select yazarin_idisi from yazarlar where yazarin_ismi =@ad";
            librarim.Open();
            MySqlCommand komut = new MySqlCommand(sql,librarim);
            komut.Parameters.AddWithValue("@ad",listBox1.SelectedItem);
            MySqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                textBox7.Text = dr["yazarin_idisi"].ToString();

            }
            librarim.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "insert into yazarlar (yazarin_idisi,yazarin_ismi,yazarin_emaili) values (@idisi,@ismi,@emaili) ";
                librarim.Open();
                MySqlCommand komut2 = new MySqlCommand(sql, librarim);
                komut2.Parameters.AddWithValue("@idisi", textBox9.Text);
                komut2.Parameters.AddWithValue("@ismi", textBox10.Text);
                komut2.Parameters.AddWithValue("@emaili", textBox11.Text);

                komut2.ExecuteNonQuery();
                librarim.Close();
                listBox1.Items.Clear();
                YazarlarıGetir();
                textBox7.Text = textBox9.Text;
                label15.Visible = true;
                label15.Text = textBox10.Text + " listeye eklenmistir";
            }
            catch(Exception hata)
            {
                MessageBox.Show("Hata olustu Tekrar deneyin \n"+hata + Environment.NewLine + "Yazarin ID'sinden emin olmak icin listele sayfasina gidin..", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { 
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            wordyazdir();
            //yazdir2();
        }

        void wordyazdir()
        {
            string sql = "SELECT yazarlar.yazarin_idisi , yazarlar.yazarin_ismi , yazarlar.yazarin_emaili as yazar,kitaplar.* from kitaplar inner join yazarlar on kitaplar.yazarin_idisi=yazarlar.yazarin_idisi WHERE kitaplar.kitapin_numarasi = @ad ";
            librarim.Open();
            MySqlCommand komut = new MySqlCommand(sql, librarim);
            komut.Parameters.AddWithValue("@ad", textBox12.Text);
            MySqlDataReader dr = komut.ExecuteReader();


            var applicationWord = new Microsoft.Office.Interop.Word.Application();


            Document mydoc = new Document();

            mydoc = applicationWord.Documents.Open(@"D:\Derslerim\2.1\C#\141601032_Ammar Saeed_Gkap kutuphane odevi\Form1 for database\Form1 for database\bin\Debug\musteriler.dotx");

            mydoc.Activate();


           

            


            if (dr.Read())
            {
                label18.Text = dr["kitapin_numarasi"].ToString() + "  numarali kiap bilgileri yazdirildi....";
               

                Bookmark bkm = mydoc.Bookmarks["mus_tc"];
                Bookmark bkm2 = mydoc.Bookmarks["mus_adsoyad"];
            
                Bookmark bkm5 = mydoc.Bookmarks["mus_adres"];

                Microsoft.Office.Interop.Word.Range rng = bkm.Range;
                Microsoft.Office.Interop.Word.Range rng2 = bkm2.Range;
           
                Microsoft.Office.Interop.Word.Range rng5 = bkm5.Range;

                rng.Text = dr["yazarin_idisi"].ToString();
                rng2.Text = dr["yazarin_ismi"].ToString();
             
                rng5.Text = "Istanbul - avcilar - sultan pasa";


                dr.Close();

            }


            //------------------ ikinci sorgu ----------------------

            string sql2 = "select * from kitaplar where kitapin_numarasi =@ad";

            MySqlCommand komut2 = new MySqlCommand(sql2, librarim);
            komut2.Parameters.AddWithValue("@ad", textBox12.Text);
            MySqlDataReader dr2 = komut2.ExecuteReader();
            if (dr2.Read())
            {

                Bookmark bkm6 = mydoc.Bookmarks["yapilan_islemler"];

                Microsoft.Office.Interop.Word.Range rng6 = bkm6.Range;

                rng6.Text = dr2["kitapin_ismi"].ToString();

            }
            librarim.Close();
           
            
             
        }




        //  void yazdir2()
        //{
        //    //string sql = "SELECT yazarlar.yazarin_idisi , yazarlar.yazarin_ismi , yazarlar.yazarin_emaili as yazar,kitaplar.* from kitaplar inner join yazarlar on kitaplar.yazarin_idisi=yazarlar.yazarin_idisi WHERE kitaplar.kitapin_numarasi = @ad ";
        //    string sql2 = "select * from kitaplar where kitapin_numarasi =@ad";
        //    librarim.Open();
        //    MySqlCommand komut2 = new MySqlCommand(sql2, librarim);
        //    komut2.Parameters.AddWithValue("@ad", textBox12.Text);
        //    MySqlDataReader dr2 = komut2.ExecuteReader();
        //    if (dr2.Read())
        //    {
        //       // label18.Text = dr["kitapin_numarasi"].ToString()+ "  numarali kiap bilgileri yazdirildi....";
        //        var applicationWord = new Microsoft.Office.Interop.Word.Application();

                
        //        Document mydoc = new Document();

        //        mydoc = applicationWord.Documents.Open(@"D:\Derslerim\2.1\C#\141601032_Ammar Saeed_Gkap kutuphane odevi\Form1 for database\Form1 for database\bin\Debug\musteriler.dotx");

        //        mydoc.Activate();

        //       /* Bookmark bkm = mydoc.Bookmarks["mus_tc"];
        //        Bookmark bkm2 = mydoc.Bookmarks["mus_adsoyad"];
        //        //Bookmark bkm3 = mydoc.Bookmarks["mus_tel"];
        //        Bookmark bkm4 = mydoc.Bookmarks["yapilan_islemler"];
        //        Bookmark bkm5 = mydoc.Bookmarks["mus_adres"];*/
        //        Bookmark bkm6 = mydoc.Bookmarks["yapilan_islemler"];

        //       /* Microsoft.Office.Interop.Word.Range rng = bkm.Range;
        //        Microsoft.Office.Interop.Word.Range rng2 = bkm2.Range;
        //        //Microsoft.Office.Interop.Word.Range rng3= bkm3.Range;
        //        Microsoft.Office.Interop.Word.Range rng4 = bkm4.Range;
        //        Microsoft.Office.Interop.Word.Range rng5 = bkm5.Range;*/
        //        Microsoft.Office.Interop.Word.Range rng6 = bkm6.Range;

        //        /*rng.Text = dr2["yazarin_idisi"].ToString();
        //        rng2.Text = dr2["yazarin_ismi"].ToString();
        //        //rng3.Text = dr["yazarin_emaili"].ToString();
        //        rng4.Text = dr2["kitapin_ismi"].ToString();
        //        rng5.Text = "Istanbul - avcilar - sultan pasa";*/
        //        rng6.Text = dr2["kitapin_ismi"].ToString();

        //    }
        //}
    }
}
