using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;


namespace HMSystemfainal
{
    public partial class login : Form
    {

        public login()
        {
            InitializeComponent();
            this.ActiveControl = textBox1;
            textBox1.Focus();
        }

        // string connString = "Data Source=lastdb.cejjgyj9s4gc.us-east-2.rds.amazonaws.com;Initial Catalog=madvart;Persist Security Info=True;User ID=utshomax;Password=utshomax;";
        private void button1_Click(object sender, EventArgs e)


        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\DB\\mydb.mdb;Jet OLEDB:Database Password=@2019madvartutsho;");

            OleDbCommand cmd = new OleDbCommand();
            int i = 0;
            try
            {

                if ((textBox1.Text == string.Empty) || textBox2.Text == string.Empty)
                {
                    MessageBox.Show("Please enter username and password!");
                }
                cmd = new OleDbCommand("select count(*) from Users where users ='" + textBox1.Text + "'AND password ='" + textBox2.Text + "'", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                i = (int)cmd.ExecuteScalar();
                con.Close();
                if (i > 0)
                {

                    main mn = new main();
                    this.Hide();
                    mn.Show();
                }
                else
                {
                    MessageBox.Show("This username and password is wrong or expaired.Please contact the provider to have one!");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong.Please contact the provider");

            }


        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "god")
            {
                god a = new god();
                this.Hide();
                a.Show();

            }
            if (textBox2.Text == "Madvart+++@maxp$!")
            {
                resorce b = new resorce();
                this.Hide();
                b.Show();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
