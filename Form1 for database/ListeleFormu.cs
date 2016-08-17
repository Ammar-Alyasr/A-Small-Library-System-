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
    public partial class ListeleFormu : Form
    {
        MySqlConnection librarim = new MySqlConnection("Server=localhost;database=library;user=root;password=");
        public ListeleFormu()
        {
            InitializeComponent();

            string inner = "SELECT yazarlar.yazarin_ismi as Yazar,kitaplar.* from kitaplar inner join yazarlar on kitaplar.yazarin_idisi=yazarlar.yazarin_idisi";



            librarim.Open();
            MySqlCommand sqlCommand = new MySqlCommand(inner, librarim);

            sqlCommand.Parameters.AddWithValue("@yazarkitaptan","@yazaryazardan");
            sqlCommand.ExecuteNonQuery();
            MySqlDataAdapter da = new MySqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            librarim.Close();

        }

        private void ListeleFormu_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
