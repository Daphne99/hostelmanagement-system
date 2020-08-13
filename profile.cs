using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HMSystemfainal
{
    public partial class profile : Form
    {
        public profile()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\DB\\mydb.mdb;Jet OLEDB:Database Password=@2019madvartutsho;");

        private void button3_Click(object sender, System.EventArgs e)
        {

        }

        private void button4_Click(object sender, System.EventArgs e)
        {

            OleDbDataAdapter odab = new OleDbDataAdapter("SELECT ID,Name,Amount,Room,Due FROM Members WHERE due > 0", con);
            // OleDbDataAdapter oda = new OleDbDataAdapter("SELECT ID, name, room, mobile, mamount FROM Members WHERE ID lIKE '" + textBox1.Text + "%'", con);
            DataTable data = new DataTable();
            odab.Fill(data);
            dataGridView1.DataSource = data;
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
            }
            button1.Text = "TOTAL DUE";
            textBox1.Text = sum.ToString();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            button1.Text = "TOTAL PAID";
            const String sql = @"SELECT ReceiptID,ID,Name,Paid,Due FROM lastpays where [Dateofpayment] >= ? AND [Dateofpayment] < ?";

            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;

            OleDbParameter pFrom = cmd.CreateParameter();
            pFrom.OleDbType = OleDbType.Date;
            pFrom.Value = dateTimePicker1.Value.Date;
            cmd.Parameters.Add(pFrom);

            OleDbParameter pTo = cmd.CreateParameter();
            pTo.OleDbType = OleDbType.Date;
            pTo.Value = dateTimePicker2.Value.Date;
            cmd.Parameters.Add(pTo);

            OleDbDataAdapter da = new OleDbDataAdapter(selectCommand: cmd);

            DataTable data = new DataTable();
            da.Fill(data);
            dataGridView1.DataSource = data;
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
            }
            textBox1.Text = sum.ToString();
        }


        private void profile_Load(object sender, System.EventArgs e)
        {

            byte[] ImageByte = null;
            MemoryStream MemStream = null;
            OleDbCommand vel = con.CreateCommand();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            vel.Connection = con;
            OleDbDataReader reader = null;  // This is OleDb Reader
            string duec = "SELECT name,job,pic FROM Users Where id=1";
            vel.CommandText = duec;
            reader = vel.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
                try
                {
                    {
                        textBox2.Text = reader["name"].ToString();
                        textBox3.Text = reader["job"].ToString();
                        ImageByte = ((byte[])reader[2]);
                    }

                    MemStream = new MemoryStream(ImageByte);
                    pictureBox1.Image = Image.FromStream(MemStream);
                }
                catch (Exception)
                {

                }
            con.Close();


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            OleDbDataAdapter odab = new OleDbDataAdapter("SELECT ReceiptID,ID,Name,Paid,Due FROM lastpays", con);
            // OleDbDataAdapter oda = new OleDbDataAdapter("SELECT ID, name, room, mobile, mamount FROM Members WHERE ID lIKE '" + textBox1.Text + "%'", con);
            DataTable data = new DataTable();
            odab.Fill(data);
            dataGridView1.DataSource = data;




            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
            }
            textBox1.Text = sum.ToString();
            con.Close();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
