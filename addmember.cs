using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace HMSystemfainal
{
    public partial class addmember : Form
    {
        public addmember()
        {
            InitializeComponent();

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\DB\\mydb.mdb;Jet OLEDB:Database Password=@2019madvartutsho;");



            try
            {

                int i = 0;
                OleDbCommand cmd = con.CreateCommand();
                if (textBox12.Text == string.Empty)
                {
                    MessageBox.Show("Please enter something");
                }
                cmd = new OleDbCommand("select count(*) from Users where password ='" + textBox12.Text + "'", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                i = (int)cmd.ExecuteScalar();
                con.Close();
                if (i > 0)
                {
                    decimal x = 0;
                    decimal y = 0;


                    try
                    {



                        OleDbCommand vel = con.CreateCommand();
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();
                        vel.Connection = con;
                        OleDbDataReader reader = null;  // This is OleDb Reader
                        string duec = "SELECT vacancy,inrooled from room WHERE roomno=" + textBox11.Text + "";
                        vel.CommandText = duec;
                        reader = vel.ExecuteReader();
                        while (reader.Read())
                        {
                            string d = reader["vacancy"].ToString();
                            string c = reader["inrooled"].ToString();
                            x = decimal.Parse(d);
                            y = decimal.Parse(c);

                        }
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error" + ex.Message);
                    }
                    if (y >= x)
                    {
                        MessageBox.Show("ROOM IS NOT AVAILABLE." +
                            "YOU CAN ADD A ROOM OR SEARCH FOR AN EMPTY ROOM ON EMPTY ROOM TAB", "SORRY");
                    }
                    else
                    {
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();

                        OleDbCommand add = con.CreateCommand();
                        decimal amount = decimal.Parse(textBox6.Text);
                        decimal afee = decimal.Parse(textBox7.Text);
                        decimal dep = decimal.Parse(textBox8.Text);
                        decimal due = afee + amount + dep;
                        textBox13.Text = due.ToString();


                        y = y + 1;
                        add.CommandText = "Insert into Members (name,fname,address,mobile,emergency,mamount,afee,deposit,uid,job,room,amount,due) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','0','" + textBox13.Text + "')";
                        add.ExecuteNonQuery();


                        string cup = "UPDATE room SET inrooled=" + y.ToString() + " WHERE roomno=" + textBox11.Text + "";


                        add.CommandText = cup;
                        add.ExecuteNonQuery();

                        MessageBox.Show("Admission for " + textBox1.Text + " is successfull", "Congrats");

                        con.Close();
                        //this.Hide();
                    }


                }
                else
                {
                    MessageBox.Show("This singeture is wrong or expaired.Please contact the provider to have one!");
                }








            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed due to" + ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void addmember_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            panel18.Visible = true;
            panel19.Visible = false;
            panel20.Visible = false;
            panel21.Visible = false;
            panel22.Visible = false;
            panel23.Visible = false;
            panel24.Visible = false;
            panel25.Visible = false;
            panel26.Visible = false;
            panel27.Visible = false;
            panel28.Visible = false;

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            panel18.Visible = false;
            panel19.Visible = true;
            panel20.Visible = false;
            panel21.Visible = false;
            panel22.Visible = false;
            panel23.Visible = false;
            panel24.Visible = false;
            panel25.Visible = false;
            panel26.Visible = false;
            panel27.Visible = false;
            panel28.Visible = false;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            panel18.Visible = false;
            panel19.Visible = false;
            panel20.Visible = true;
            panel21.Visible = false;
            panel22.Visible = false;
            panel23.Visible = false;
            panel24.Visible = false;
            panel25.Visible = false;
            panel26.Visible = false;
            panel27.Visible = false;
            panel28.Visible = false;
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            panel18.Visible = false;
            panel19.Visible = false;
            panel20.Visible = false;
            panel21.Visible = true;
            panel22.Visible = false;
            panel23.Visible = false;
            panel24.Visible = false;
            panel25.Visible = false;
            panel26.Visible = false;
            panel27.Visible = false;
            panel28.Visible = false;
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            panel18.Visible = false;
            panel19.Visible = false;
            panel20.Visible = false;
            panel21.Visible = false;
            panel22.Visible = true;
            panel23.Visible = false;
            panel24.Visible = false;
            panel25.Visible = false;
            panel26.Visible = false;
            panel27.Visible = false;
            panel28.Visible = false;
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            panel18.Visible = false;
            panel19.Visible = false;
            panel20.Visible = false;
            panel21.Visible = false;
            panel22.Visible = false;
            panel23.Visible = true;
            panel24.Visible = false;
            panel25.Visible = false;
            panel26.Visible = false;
            panel27.Visible = false;
            panel28.Visible = false;
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            panel18.Visible = false;
            panel19.Visible = false;
            panel20.Visible = false;
            panel21.Visible = false;
            panel22.Visible = false;
            panel23.Visible = false;
            panel24.Visible = true;
            panel25.Visible = false;
            panel26.Visible = false;
            panel27.Visible = false;
            panel28.Visible = false;
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            panel18.Visible = false;
            panel19.Visible = false;
            panel20.Visible = false;
            panel21.Visible = false;
            panel22.Visible = false;
            panel23.Visible = false;
            panel24.Visible = false;
            panel25.Visible = true;
            panel26.Visible = false;
            panel27.Visible = false;
            panel28.Visible = false;
        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
            panel18.Visible = false;
            panel19.Visible = false;
            panel20.Visible = false;
            panel21.Visible = false;
            panel22.Visible = false;
            panel23.Visible = false;
            panel24.Visible = false;
            panel25.Visible = false;
            panel26.Visible = true;
            panel27.Visible = false;
            panel28.Visible = false;
        }

        private void textBox10_Enter(object sender, EventArgs e)
        {
            panel18.Visible = false;
            panel19.Visible = false;
            panel20.Visible = false;
            panel21.Visible = false;
            panel22.Visible = false;
            panel23.Visible = false;
            panel24.Visible = false;
            panel25.Visible = false;
            panel26.Visible = false;
            panel27.Visible = true;
            panel28.Visible = false;
        }

        private void textBox11_Enter(object sender, EventArgs e)
        {
            panel18.Visible = false;
            panel19.Visible = false;
            panel20.Visible = false;
            panel21.Visible = false;
            panel22.Visible = false;
            panel23.Visible = false;
            panel24.Visible = false;
            panel25.Visible = false;
            panel26.Visible = false;
            panel27.Visible = false;
            panel28.Visible = true;
        }

        private void ctrl_keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox4.Text = textBox4.Text.Remove(textBox4.Text.Length - 1);
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox5.Text = textBox5.Text.Remove(textBox5.Text.Length - 1);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox6.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox6.Text = textBox6.Text.Remove(textBox6.Text.Length - 1);
            }
        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox7.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox7.Text = textBox7.Text.Remove(textBox7.Text.Length - 1);
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox8.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox8.Text = textBox8.Text.Remove(textBox8.Text.Length - 1);
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox11.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox11.Text = textBox11.Text.Remove(textBox11.Text.Length - 1);
            }
        }
    }
}
