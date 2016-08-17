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
    public partial class VerFormu : Form
    {
        public VerFormu(String ID)
        {
            InitializeComponent();
            
        }
        MySqlConnection librarim = new MySqlConnection("Server=localhost;database=library;user=root;password=");
        private void VerFormu_Load(object sender, EventArgs e)
        {
            string sql = "Select yazarin_ismi from yazarlar";
            librarim.Open();
            MySqlCommand komut = new MySqlCommand(sql,librarim);
            MySqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["yazarin_ismi"]);
            }

            librarim.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text!="")
            {
                string sql = "SELECT yazarlar.yazarin_ismi as Yazar,kitaplar.* from kitaplar inner join yazarlar on kitaplar.yazarin_idisi=yazarlar.yazarin_idisi where yazarlar.yazarin_ismi=@isim";
                listBox1.Items.Clear();
                librarim.Open();
                MySqlCommand komut = new MySqlCommand(sql,librarim);
                komut.Parameters.AddWithValue("@isim",comboBox1.SelectedItem);
                MySqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    listBox1.Items.Add(dr["kitapin_ismi"]);
                }

                librarim.Close();


            }
        }
    }
}
