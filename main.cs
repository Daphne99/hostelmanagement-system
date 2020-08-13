using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HMSystemfainal
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\DB\\mydb.mdb;Jet OLEDB:Database Password=@2019madvartutsho;");
        private void main_Load(object sender, EventArgs e)
        {

            byte[] ImageByte = null;
            MemoryStream MemStream = null;
            OleDbCommand vel = con.CreateCommand();
            OleDbCommand hn = con.CreateCommand();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            vel.Connection = con;
            OleDbDataReader reader = null;  // This is OleDb Reader
            string duec = "SELECT name,job,pic FROM Users Where id=1";
            string hname = "SELECT [hname] FROM hostelinfo Where hid=0";
            vel.CommandText = duec;
            reader = vel.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                try
                {

                    textBox1.Text = reader["name"].ToString();
                    textBox2.Text = reader["job"].ToString();
                    ImageByte = ((byte[])reader[2]);
                    MemStream = new MemoryStream(ImageByte);
                    pictureBox1.Image = Image.FromStream(MemStream);



                }
                catch (Exception)
                {

                }
            }
            reader.Close();

            OleDbDataReader hnames = null;
            hn.CommandText = hname;
            hnames = hn.ExecuteReader();
            hnames.Read();
            textBox3.Text = hnames["hname"].ToString();
            con.Close();


        }



        private void button1_Click(object sender, EventArgs e)
        {

            addmember a = new addmember();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // #1. Make second form
            // If you want to make equivalent one, then change Form2 -> Form1
            border form2 = new border();

            // #2. Set second form's size
            form2.Width = this.Width;
            form2.Height = this.Height;

            // #3. Set second form's start position as same as parent form
            form2.StartPosition = FormStartPosition.Manual;
            form2.Location = new Point(this.Location.X, this.Location.Y);

            // #4. Set parent form's visible to false
            this.Visible = false;

            // #5. Open second dialog
            form2.ShowDialog();

            // #6. Set parent form's visible to true
            this.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {


            Application.Exit();


        }
        private void button3_Click(object sender, EventArgs e)
        {
            // #1. Make second form
            // If you want to make equivalent one, then change Form2 -> Form1
            tran form2 = new tran();

            // #2. Set second form's size
            form2.Width = this.Width;
            form2.Height = this.Height;

            // #3. Set second form's start position as same as parent form
            form2.StartPosition = FormStartPosition.Manual;
            form2.Location = new Point(this.Location.X, this.Location.Y);

            // #4. Set parent form's visible to false
            this.Visible = false;

            // #5. Open second dialog
            form2.ShowDialog();

            // #6. Set parent form's visible to true
            this.Visible = true;
        }



        private void button5_Click(object sender, EventArgs e)
        {
            // If you want to make equivalent one, then change Form2 -> Form1
            empty form2 = new empty();

            // #2. Set second form's size
            form2.Width = this.Width;
            form2.Height = this.Height;

            // #3. Set second form's start position as same as parent form
            form2.StartPosition = FormStartPosition.Manual;
            form2.Location = new Point(this.Location.X, this.Location.Y);

            // #4. Set parent form's visible to false
            this.Visible = false;

            // #5. Open second dialog
            form2.ShowDialog();

            // #6. Set parent form's visible to true
            this.Visible = true;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            addrm a = new addrm();
            a.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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
                        textBox1.Text = reader["name"].ToString();
                        textBox2.Text = reader["job"].ToString();
                        ImageByte = ((byte[])reader[2]);
                    }

                    MemStream = new MemoryStream(ImageByte);
                    pictureBox1.Image = Image.FromStream(MemStream);
                }
                catch (Exception)
                {

                }
            con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // #1. Make second form
            // If you want to make equivalent one, then change Form2 -> Form1
            profile form2 = new profile();

            // #2. Set second form's size
            form2.Width = this.Width;
            form2.Height = this.Height;

            // #3. Set second form's start position as same as parent form
            form2.StartPosition = FormStartPosition.Manual;
            form2.Location = new Point(this.Location.X, this.Location.Y);

            // #4. Set parent form's visible to false
            this.Visible = false;

            // #5. Open second dialog
            form2.ShowDialog();

            // #6. Set parent form's visible to true
            this.Visible = true;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://madvartlabs.cf/");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // #1. Make second form
            // If you want to make equivalent one, then change Form2 -> Form1
            history form2 = new history();

            // #2. Set second form's size
            form2.Width = this.Width;
            form2.Height = this.Height;

            // #3. Set second form's start position as same as parent form
            form2.StartPosition = FormStartPosition.Manual;
            form2.Location = new Point(this.Location.X, this.Location.Y);

            // #4. Set parent form's visible to false
            this.Visible = false;

            // #5. Open second dialog
            form2.ShowDialog();

            // #6. Set parent form's visible to true
            this.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://madvartlabs.cf/");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            login v = new login();
            v.Show();
        }
    }
}
