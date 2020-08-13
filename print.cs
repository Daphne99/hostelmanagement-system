using System;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace HMSystemfainal
{
    public partial class print : Form
    {
        public print()
        {
            InitializeComponent();

            timer1.Start();
        }



        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\DB\\mydb.mdb;Jet OLEDB:Database Password=@2019madvartutsho;");

        private void print_Load(object sender, EventArgs e)
        {



            OleDbCommand cmd = con.CreateCommand();

            con.Open();
            cmd.Connection = con;
            OleDbDataReader reader = null;
            string room = "SELECT ID,amount,mamount,scharge,room,mname,datee,sname,due,inword,npatdate,ref,tnx,mode from printing WHERE ID=1";
            string hname = "SELECT hname FROM hostelinfo WHERE hid=0";
            cmd.CommandText = room;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox5.Text = reader["sname"].ToString();
                textBox9.Text = reader["mname"].ToString();
                textBox12.Text = reader["due"].ToString();
                textBox10.Text = reader["amount"].ToString();
                textBox7.Text = reader["scharge"].ToString();
                textBox3.Text = reader["datee"].ToString();
                textBox4.Text = reader["room"].ToString();
                textBox2.Text = reader["ID"].ToString();
                textBox11.Text = reader["inword"].ToString();
                textBox6.Text = reader["mamount"].ToString();
                textBox1.Text = reader["ref"].ToString();
                textBox8.Text = reader["npatdate"].ToString();
                textBox27.Text = reader["tnx"].ToString();
                textBox28.Text = reader["mode"].ToString();

            }
            reader.Close();
            OleDbDataReader nreader = null;
            cmd.CommandText = hname;
            nreader = cmd.ExecuteReader();
            while (nreader.Read())
            {
                textBox26.Text = nreader["hname"].ToString();
            }

            con.Close();
            textBox13.Text = textBox1.Text;
            textBox14.Text = textBox2.Text;
            textBox15.Text = textBox3.Text;
            textBox16.Text = textBox4.Text;
            textBox17.Text = textBox5.Text;
            textBox18.Text = textBox6.Text;
            textBox19.Text = textBox7.Text;
            textBox20.Text = textBox8.Text;
            textBox21.Text = textBox9.Text;
            textBox22.Text = textBox10.Text;
            textBox23.Text = textBox11.Text;
            textBox24.Text = textBox12.Text;
            textBox25.Text = textBox26.Text;
            textBox29.Text = textBox27.Text;
            textBox30.Text = textBox28.Text;



        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
        Bitmap bmp;
        private void button1_Click(object sender, EventArgs e)
        {

            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            this.Visible = false;
            printPreviewDialog1.ShowDialog();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            button1.PerformClick();
            timer1.Stop();

        }
    }
}
