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
    public partial class GeriAl : Form
    {
        MySqlConnection librarim = new MySqlConnection("Server=localhost;database=library;user=root;password=");

        public GeriAl(String ID)
        {
            InitializeComponent();
            
        }

        private void GeriAl_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Max();
        }

        void Max() {
            string sql = "SELECT  `kitapin_sayfa_sayisi`,`kitapin_numarasi`,`kitapin_ismi`FROm kitaplar WHERE `kitapin_sayfa_sayisi`=(SELECT MAX(`kitapin_sayfa_sayisi`) FROM kitaplar);";
            librarim.Open();
            MySqlCommand komut = new MySqlCommand(sql,librarim);
            MySqlDataAdapter da = new MySqlDataAdapter(komut);
            MySqlDataReader dr = komut.ExecuteReader();


            if (dr.Read())
            {
               
                textBox1.Text = dr["kitapin_ismi"].ToString();
                textBox2.Text = dr["kitapin_numarasi"].ToString();
                textBox6.Text = dr["kitapin_sayfa_sayisi"].ToString();
              // MessageBox.Show(a.ToString());
            }
            librarim.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MIN();
        }

        void MIN()
        {

            string sql = "SELECT  `kitapin_sayfa_sayisi`,`kitapin_numarasi`,`kitapin_ismi`FROm kitaplar WHERE `kitapin_sayfa_sayisi`=(SELECT MIN(`kitapin_sayfa_sayisi`) FROM kitaplar);";
            librarim.Open();
            MySqlCommand komut = new MySqlCommand(sql, librarim);
            MySqlDataAdapter da = new MySqlDataAdapter(komut);
            MySqlDataReader dr = komut.ExecuteReader();


            if (dr.Read())
            {

                textBox3.Text = dr["kitapin_ismi"].ToString();
                textBox4.Text = dr["kitapin_numarasi"].ToString();
                textBox5.Text = dr["kitapin_sayfa_sayisi"].ToString();
                // MessageBox.Show(a.ToString());
            }
            librarim.Close();
        }
    }
}
