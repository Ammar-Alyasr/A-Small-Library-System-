using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Form1_for_database
{
    public partial class AraFormu : Form
    {
        MySqlConnection librarim = new MySqlConnection("Server=localhost;database=library;user=root;password=");
        public AraFormu(String ID)
        {
            InitializeComponent();
            textBox1.Text = ID;
            
        }

        private void AraFormu_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {


        }
        void ara()
        {
            string sql = "select * from kitaplar where kitapin_numarasi=@No";
            MySqlCommand komut = new MySqlCommand(sql, librarim);
            komut.Parameters.AddWithValue("@No", textBox1.Text);
            MySqlDataAdapter da = new MySqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
            dataGridView1.DataSource = dt;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            ara();
            librarim.Close();
        }
    }
}
