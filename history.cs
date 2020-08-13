using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace HMSystemfainal
{
    public partial class history : Form
    {
        public history()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\DB\\mydb.mdb;Jet OLEDB:Database Password=@2019madvartutsho;");
        private void history_Load(object sender, EventArgs e)
        {

            OleDbDataAdapter odab = new OleDbDataAdapter("SELECT ReceiptID,ID, Name, Room,Paid,Due,Dateofpayment FROM lastpays", con);
            // OleDbDataAdapter oda = new OleDbDataAdapter("SELECT ID, name, room, mobile, mamount FROM Members WHERE ID lIKE '" + textBox1.Text + "%'", con);
            DataTable data = new DataTable();
            odab.Fill(data);
            dataGridView1.DataSource = data;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            panel3.BackColor = Color.Green;
            try
            {

                OleDbDataAdapter oda = new OleDbDataAdapter("SELECT ReceiptID,ID, Name, Room,Paid,Due,Dateofpayment FROM lastpays WHERE ReceiptID lIKE '" + textBox1.Text + "%'", con);
                // OleDbDataAdapter oda = new OleDbDataAdapter("SELECT ID, name, room, mobile, mamount FROM Members WHERE ID lIKE '" + textBox1.Text + "%'", con);
                DataTable data1 = new DataTable();
                oda.Fill(data1);
                dataGridView1.DataSource = data1;


            }
            catch (Exception)
            {
                panel3.BackColor = Color.Red;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
