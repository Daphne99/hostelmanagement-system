using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace HMSystemfainal
{
    public partial class empty : Form
    {
        public empty()
        {
            InitializeComponent();

        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\DB\\mydb.mdb;Jet OLEDB:Database Password=@2019madvartutsho;");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            panel7.BackColor = Color.Green;
            try
            {
                int i = 0;
                decimal v = 0;
                string vac;
                decimal a = decimal.Parse(textBox1.Text);


                OleDbCommand readr = con.CreateCommand();
                readr = new OleDbCommand("select count(*) from Members where room =" + a + "", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                i = (int)readr.ExecuteScalar();


                OleDbCommand cmd = con.CreateCommand();


                OleDbDataReader reader = null;  // This is OleDb Reader
                string duec = "SELECT vacancy from room WHERE roomno=" + a + "";
                cmd.CommandText = duec;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    vac = reader["vacancy"].ToString();
                    v = decimal.Parse(vac);
                }



                if (i >= v)
                {
                    textBox2.Text = "NOT AVAILABLE";
                    textBox2.ForeColor = Color.Red;

                }
                else
                {
                    textBox2.Text = "AVAILABLE";
                    textBox2.ForeColor = Color.Green;
                }
            }
            catch (Exception)
            {
                panel7.BackColor = Color.Red;
            }
            try
            {

                OleDbDataAdapter oda = new OleDbDataAdapter("SELECT ID, Name FROM Members WHERE Room = " + textBox1.Text + "", con);
                // OleDbDataAdapter oda = new OleDbDataAdapter("SELECT ID, name, room, mobile, mamount FROM Members WHERE ID lIKE '" + textBox1.Text + "%'", con);
                DataTable data = new DataTable();
                oda.Fill(data);
                dataGridView2.DataSource = data;


            }
            catch (Exception)
            {
                // panel3.BackColor = Color.Red;
            }



        }

        private void empty_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM room WHERE vacancy>inrooled", con);

            DataTable data = new DataTable();
            oda.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM room WHERE vacancy<=inrooled", con);

            DataTable data = new DataTable();
            oda.Fill(data);
            dataGridView3.DataSource = data;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
