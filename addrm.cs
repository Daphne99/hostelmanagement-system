using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;


namespace HMSystemfainal
{
    public partial class addrm : Form
    {
        public addrm()
        {
            InitializeComponent();
            textBox1.Focus();
        }
        string connetionString = null;


        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\DB\\mydb.mdb;Jet OLEDB:Database Password=@2019madvartutsho;");
        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();



                OleDbCommand ins = con.CreateCommand();
                ins.Connection = con;

                string find = "select count(*) from room where roomno=" + textBox1.Text + "";

                ins.CommandText = find;

                i = (int)ins.ExecuteScalar();
                if (i == 0)
                {

                    string insc = "INSERT INTO room(roomno,vacancy) values('" + textBox1.Text + "','" + textBox2.Text + "')";
                    ins.CommandText = insc;
                    ins.ExecuteNonQuery();
                    MessageBox.Show("NEW ROOM ADDED! CLICK ON AVAILABLE ROOMS TO VERIFY.");
                }
                else
                {
                    MessageBox.Show("ROOM ALREADY EXISTS! YOU CAN UPDATE IT'S VACANCY.");
                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("SOMETHING WENT WRONG");
            }


        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();



                OleDbCommand cmd = con.CreateCommand();
                cmd.Connection = con;
                string query = "UPDATE room SET vacancy='" + textBox4.Text + "'  WHERE roomno=" + textBox3.Text + "";
                cmd.CommandText = query;

                cmd.ExecuteNonQuery();
                MessageBox.Show("ROOM VACANCY UPDATED!");
            }
            catch (Exception)
            {
                MessageBox.Show("Check your input and Room no exist or not!");
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                OleDbCommand mon = con.CreateCommand();
                mon.Connection = con;
                //string query = "SELECT Members.[mamount], Members.[due], [mamount]+[due] AS  FROM Members";
                string qu = "UPDATE Members SET [due] = ([due]+[mamount])";
                //mon.CommandText = query;

                // mon.ExecuteNonQuery();


                mon.CommandText = qu;
                mon.ExecuteNonQuery();

                MessageBox.Show("A NEW MONTH ADDED! STUDENT DUE WILL BE UPDATED");
                con.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("SORRY! CONTACT PROVIDER");
            }
            button3.Enabled = false;
            button3.ForeColor = Color.DimGray;
        }

        private void addrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mydbDataSet.Members' table. You can move, or remove it, as needed.
            button3.Enabled = false;
            button3.ForeColor = Color.DimGray;

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)

        {
            try
            {
                if (textBox6.Text == string.Empty)
                {
                    MessageBox.Show("Enter ID First");
                }
                else
                {

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    OleDbCommand cmd = con.CreateCommand();
                    string name = "UPDATE Members SET name='" + textBox7.Text + "' WHERE ID=" + textBox6.Text + "";
                    string fname = "UPDATE Members SET fname='" + textBox7.Text + "' WHERE ID=" + textBox6.Text + "";
                    string address = "UPDATE Members SET address='" + textBox7.Text + "' WHERE ID=" + textBox6.Text + "";
                    string mobile = "UPDATE Members SET mobile='" + textBox7.Text + "' WHERE ID=" + textBox6.Text + "";
                    string emergency = "UPDATE Members SET emergency='" + textBox7.Text + "' WHERE ID=" + textBox6.Text + "";
                    string afee = "UPDATE Members SET afee='" + textBox7.Text + "' WHERE ID=" + textBox6.Text + "";
                    string mamount = "UPDATE Members SET mamount='" + textBox7.Text + "' WHERE ID=" + textBox6.Text + "";
                    string deposit = "UPDATE Members SET deposit='" + textBox7.Text + "' WHERE ID=" + textBox6.Text + "";
                    string room = "UPDATE Members SET room='" + textBox7.Text + "' WHERE ID=" + textBox6.Text + "";

                    if (comboBox1.Text == "NAME")
                    {

                        cmd.CommandText = name;
                        cmd.ExecuteNonQuery();

                    }







                    if (comboBox1.Text == "FATHER NAME")
                    {

                        cmd.CommandText = fname;
                        cmd.ExecuteNonQuery();

                    }

                    if (comboBox1.Text == "ADDRESS")
                    {

                        cmd.CommandText = address;
                        cmd.ExecuteNonQuery();

                    }

                    if (comboBox1.Text == "MOBILE")
                    {

                        cmd.CommandText = mobile;
                        cmd.ExecuteNonQuery();

                    }

                    if (comboBox1.Text == "EMENGENCY")
                    {

                        cmd.CommandText = emergency;
                        cmd.ExecuteNonQuery();

                    }

                    if (comboBox1.Text == "MONTHLY AMOUNT")
                    {
                        cmd.CommandText = mamount;
                        cmd.ExecuteNonQuery();

                    }
                    if (comboBox1.Text == "ADMISSION FEE")
                    {

                        cmd.CommandText = afee;
                        cmd.ExecuteNonQuery();

                    }


                    if (comboBox1.Text == "DEPOSIT")
                    {

                        cmd.CommandText = deposit;
                        cmd.ExecuteNonQuery();

                    }
                    if (comboBox1.Text == "ROOM")
                    {
                        decimal v = 0;

                        OleDbCommand xyz = con.CreateCommand();


                        OleDbDataReader reader = null;  // This is OleDb Reader
                        string duec = "SELECT room FROM Members WHERE ID=" + textBox6.Text + "";

                        xyz.CommandText = duec;
                        reader = xyz.ExecuteReader();
                        while (reader.Read())
                        {
                            string r = reader["room"].ToString();
                            v = decimal.Parse(r);

                        }
                        string upd = "UPDATE room SET [inrooled]=[inrooled]-1 WHERE roomno=" + v.ToString() + "";
                        string cpd = "UPDATE room SET [inrooled]=[inrooled]+1 WHERE roomno=" + textBox7.Text + "";
                        decimal p = decimal.Parse(textBox7.Text);

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();
                        OleDbCommand doit = con.CreateCommand();

                        if (v == p)
                        {
                            MessageBox.Show("Same room");
                        }

                        else
                        {
                            doit.CommandText = upd;
                            doit.ExecuteNonQuery();
                            doit.CommandText = cpd;
                            doit.ExecuteNonQuery();
                            doit.CommandText = room;
                            doit.ExecuteNonQuery();
                            MessageBox.Show("Room no updated!");

                        }


                    }



                    MessageBox.Show("successfull", "Congrats");

                    con.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check your inputs!!");
            }

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string key = null;
            bool connection = NetworkInterface.GetIsNetworkAvailable();
            if (connection == false)
            {
                MessageBox.Show("Please Check your Internet connection!");

            }
            if (textBox5.Text == "0" || textBox5.Text == string.Empty || connection == false)

            {
                panel9.BackColor = Color.Red;
            }
            else
            {
                try
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();



                    OleDbCommand rkey = con.CreateCommand();


                    OleDbDataReader rw = null;  // This is OleDb Reader
                    string dfg = "SELECT rkey FROM hostelinfo WHERE hid=0";

                    rkey.CommandText = dfg;
                    rw = rkey.ExecuteReader();
                    while (rw.Read())
                    {
                        key = rw["rkey"].ToString();


                    }
                    con.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("error");
                }



                try
                {

                    connetionString = "Data Source=lastdb.cejjgyj9s4gc.us-east-2.rds.amazonaws.com;Initial Catalog=madvart;Persist Security Info=True;User ID=utshomax;Password=utshomax;";
                    string vac;
                    decimal v = 0;
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = connetionString;
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Open();
                    SqlCommand get = conn.CreateCommand();
                    SqlCommand set = conn.CreateCommand();
                    string del = "UPDATE max SET [scode]=0 WHERE rid='" + key + "'";

                    SqlDataReader reader = null;  // This is OleDb Reader
                    string duec = "SELECT scode from max WHERE rid='" + key + "'";

                    get.CommandText = duec;
                    reader = get.ExecuteReader();
                    while (reader.Read())
                    {
                        vac = reader["scode"].ToString();
                        try
                        {
                            v = decimal.Parse(vac);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("please input scode");
                        }
                    }
                    reader.Close();
                    if (textBox5.Text == v.ToString())
                    {
                        button3.ForeColor = Color.Green;
                        button3.Enabled = true;
                    }
                    else
                    {
                        panel9.BackColor = Color.Red;
                    }
                    reader.Close();
                    set.CommandText = del;
                    set.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please check your internet connection!");
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            panel9.BackColor = Color.Green;
        }
    }
}
