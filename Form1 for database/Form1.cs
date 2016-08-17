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

    public partial class Form1 : Form
    {
        //MySqlConnection librarim = new MySqlConnection("Server=localhost;database=library;user=root;password=");
        public Form1()
        {
            InitializeComponent();
            //librarim.Open();
            //MessageBox.Show("acildi"+librarim.State);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EkleFormu f = new EkleFormu(textBox1.Text);
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AraFormu f2 = new AraFormu(textBox1.Text);
            f2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VerFormu f3 = new VerFormu (textBox1.Text);
            f3.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GeriAl f4 = new GeriAl(textBox1.Text);
            f4.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SilFormu f5 = new SilFormu(textBox1.Text);
            f5.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ListeleFormu f6 = new ListeleFormu();
            f6.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
