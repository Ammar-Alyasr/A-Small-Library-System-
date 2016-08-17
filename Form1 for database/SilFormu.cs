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

    public partial class SilFormu : Form
    {
        MySqlConnection librarim = new MySqlConnection("Server=localhost;database=library;user=root;password=");
        MySqlCommand cmd;
        public SilFormu(String ID)
        {
            InitializeComponent();
            textBox1.Text = ID;
        }


        void kitaplarıGetir()
        {
            string sql = "Select * From kitaplar";
            librarim.Open();
            MySqlCommand cmd = new MySqlCommand(sql, librarim);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add(dr["kitapin_ismi"]);
            }
            librarim.Close();
        }



        private void SilFormu_Load(object sender, EventArgs e)
        {
            kitaplarıGetir();
        }
    
        private void button4_Click(object sender, EventArgs e)
        {
            

            try
            {
                cmd = new MySqlCommand("Delete From kitaplar Where kitapin_numarasi='" + textBox1.Text + "'", librarim);
                librarim.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("kitap silinmistir ", "Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Silme", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally {
                librarim.Close();
 
            }

            listBox1.Items.Clear();
            kitaplarıGetir();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select kitapin_numarasi from kitaplar where kitapin_ismi =@ad";
            librarim.Open();
            MySqlCommand komut = new MySqlCommand(sql, librarim);
            komut.Parameters.AddWithValue("@ad", listBox1.SelectedItem);
            MySqlDataReader dr = komut.ExecuteReader();
            //textBox1.Text = listBox1.SelectedItem.ToString();
            if (dr.Read())
            {
                textBox1.Text = dr["kitapin_numarasi"].ToString();
            }
            librarim.Close();
        }
    }
}
