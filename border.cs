using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;


namespace HMSystemfainal
{
    public partial class border : Form
    {
        public border()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\DB\\mydb.mdb;Jet OLEDB:Database Password=@2019madvartutsho;");
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ID")
            {
                OleDbDataAdapter oda = new OleDbDataAdapter("SELECT ID, name, room, mobile, mamount,amount,due FROM Members WHERE ID lIKE '" + textBox1.Text + "%'", con);
                // OleDbDataAdapter oda = new OleDbDataAdapter("SELECT ID, name, room, mobile, mamount FROM Members WHERE ID lIKE '" + textBox1.Text + "%'", con);
                DataTable data = new DataTable();
                oda.Fill(data);
                dataGridView1.DataSource = data;
            }
            if (comboBox1.Text == "NAME")
            {
                OleDbDataAdapter oda = new OleDbDataAdapter("SELECT ID, name, room, mobile, mamount FROM Members WHERE NAME lIKE '" + textBox1.Text + "%'", con);
                DataTable data = new DataTable();
                oda.Fill(data);
                dataGridView1.DataSource = data;
            }
            if (comboBox1.Text == "ROOM")
            {
                OleDbDataAdapter oda = new OleDbDataAdapter("SELECT ID, name, room, mobile, mamount FROM Members WHERE ROOM lIKE '" + textBox1.Text + "%'", con);
                DataTable data = new DataTable();
                oda.Fill(data);
                dataGridView1.DataSource = data;
            }
            if (comboBox1.Text == "MOBILE")
            {
                OleDbDataAdapter oda = new OleDbDataAdapter("SELECT ID, name, room, mobile, mamount FROM Members WHERE MOBILE lIKE '" + textBox1.Text + "%'", con);
                DataTable data = new DataTable();
                oda.Fill(data);
                dataGridView1.DataSource = data;
            }
        }

        private void border_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
