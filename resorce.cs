using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace HMSystemfainal
{
    public partial class resorce : Form
    {
        public resorce()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\DB\\mydb.mdb;Jet OLEDB:Database Password=@2019madvartutsho;");
        private void button1_Click(object sender, EventArgs e)

        {
            con.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM Users", con);
            // OleDbDataAdapter oda = new OleDbDataAdapter("SELECT ID, name, room, mobile, mamount FROM Members WHERE ID lIKE '" + textBox1.Text + "%'", con);
            DataTable data = new DataTable();
            oda.Fill(data);
            dataGridView1.DataSource = data;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM Members", con);
            // OleDbDataAdapter oda = new OleDbDataAdapter("SELECT ID, name, room, mobile, mamount FROM Members WHERE ID lIKE '" + textBox1.Text + "%'", con);
            DataTable data = new DataTable();
            oda.Fill(data);
            dataGridView1.DataSource = data;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM lastpays", con);
            // OleDbDataAdapter oda = new OleDbDataAdapter("SELECT ID, name, room, mobile, mamount FROM Members WHERE ID lIKE '" + textBox1.Text + "%'", con);
            DataTable data = new DataTable();
            oda.Fill(data);
            dataGridView1.DataSource = data;
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM printing", con);
            // OleDbDataAdapter oda = new OleDbDataAdapter("SELECT ID, name, room, mobile, mamount FROM Members WHERE ID lIKE '" + textBox1.Text + "%'", con);
            DataTable data = new DataTable();
            oda.Fill(data);
            dataGridView1.DataSource = data;
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM room", con);
            // OleDbDataAdapter oda = new OleDbDataAdapter("SELECT ID, name, room, mobile, mamount FROM Members WHERE ID lIKE '" + textBox1.Text + "%'", con);
            DataTable data = new DataTable();
            oda.Fill(data);
            dataGridView1.DataSource = data;
            con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            con.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [hostelinfo]", con);
            // OleDbDataAdapter oda = new OleDbDataAdapter("SELECT ID, name, room, mobile, mamount FROM Members WHERE ID lIKE '" + textBox1.Text + "%'", con);
            DataTable data = new DataTable();
            oda.Fill(data);
            dataGridView1.DataSource = data;
            con.Close();


        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            con.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [god mode]", con);
            // OleDbDataAdapter oda = new OleDbDataAdapter("SELECT ID, name, room, mobile, mamount FROM Members WHERE ID lIKE '" + textBox1.Text + "%'", con);
            DataTable data = new DataTable();
            oda.Fill(data);
            dataGridView1.DataSource = data;
            con.Close();
        }
    }
}
