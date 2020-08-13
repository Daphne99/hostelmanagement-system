using System;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;

namespace HMSystemfainal
{

    public partial class tran : Form
    {
        public tran()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\DB\\mydb.mdb;Jet OLEDB:Database Password=@2019madvartutsho;");

        private void textBox1_TextChanged(object sender, EventArgs e)

        {
            try
            {


                int parsedValue;

                if (!int.TryParse(textBox1.Text, out parsedValue))
                {
                    panel8.BackColor = panel9.BackColor;
                }
                else
                {
                    panel8.BackColor = panel1.BackColor;
                }

                OleDbDataAdapter oda = new OleDbDataAdapter("SELECT ID, name, room, mobile, mamount, deposit,afee FROM Members WHERE ID lIKE '" + textBox1.Text + "%'", con);

                DataTable data = new DataTable();
                oda.Fill(data);
                dataGridView1.DataSource = data;

            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }


        }
        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "Zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " Million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {

                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    textBox2.Text = row.Cells[0].Value.ToString();
                    textBox3.Text = row.Cells[1].Value.ToString();
                    textBox4.Text = row.Cells[2].Value.ToString();
                    textBox5.Text = row.Cells[3].Value.ToString();
                    textBox6.Text = row.Cells[4].Value.ToString();
                    textBox7.Text = row.Cells[5].Value.ToString();



                    OleDbCommand cmd = con.CreateCommand();

                    con.Open();
                    cmd.Connection = con;
                    OleDbDataReader reader = null;  // This is OleDb Reader
                    string duec = "SELECT due from Members WHERE ID=" + textBox2.Text + "";
                    cmd.CommandText = duec;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        textBox8.Text = reader["due"].ToString();

                    }

                }



                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("SOMETHING WENT WRONG.");
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridViewCell cell = null;
                foreach (DataGridViewCell selectedcell in dataGridView1.SelectedCells)
                {
                    cell = selectedcell;
                    break;
                }
                if (cell != null)
                {

                    DataGridViewRow row = cell.OwningRow;
                    textBox2.Text = row.Cells[0].Value.ToString();
                    textBox3.Text = row.Cells[1].Value.ToString();
                    textBox4.Text = row.Cells[2].Value.ToString();
                    textBox5.Text = row.Cells[3].Value.ToString();
                    textBox6.Text = row.Cells[4].Value.ToString();
                    textBox7.Text = row.Cells[5].Value.ToString();

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }


                    OleDbCommand cmd = con.CreateCommand();

                    con.Open();
                    cmd.Connection = con;
                    OleDbDataReader reader = null;  // This is OleDb Reader
                    string duec = "SELECT due from Members WHERE ID=" + textBox2.Text + "";
                    cmd.CommandText = duec;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        textBox8.Text = reader["due"].ToString();

                    }
                    con.Close();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("CHECK YOUR INPUTS");
            }

        }
        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            panel4.BackColor = panel1.BackColor;
            panel5.BackColor = panel1.BackColor;
            try
            {

                int a = 0;
                if (textBox14.Text == string.Empty)
                {
                    textBox14.Text = a.ToString();
                }
                if (textBox15.Text == string.Empty)
                {
                    textBox15.Text = a.ToString();
                }
                if (textBox16.Text == string.Empty)
                {
                    textBox16.Text = a.ToString();
                }
                decimal am = decimal.Parse(textBox14.Text);

                decimal af = decimal.Parse(textBox15.Text);

                decimal de = decimal.Parse(textBox16.Text);

                decimal to = am + af + de;
                textBox10.Text = to.ToString();


            }
            catch (Exception)
            {
                panel4.BackColor = panel9.BackColor;
            }

        }
        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            panel5.BackColor = panel1.BackColor;
            try
            {
                int a = 0;
                if (textBox14.Text == string.Empty)
                {
                    textBox14.Text = a.ToString();
                }
                if (textBox15.Text == string.Empty)
                {
                    textBox15.Text = a.ToString();
                }
                if (textBox16.Text == string.Empty)
                {
                    textBox16.Text = a.ToString();
                }
                decimal am = decimal.Parse(textBox14.Text);

                decimal af = decimal.Parse(textBox15.Text);

                decimal de = decimal.Parse(textBox16.Text);

                decimal to = am + af + de;
                textBox10.Text = to.ToString();

            }
            catch (Exception)
            {
                panel5.BackColor = panel9.BackColor;
            }
        }
        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            panel6.BackColor = panel1.BackColor;
            try
            {
                int a = 0;
                if (textBox14.Text == string.Empty)
                {
                    textBox14.Text = a.ToString();
                }
                if (textBox15.Text == string.Empty)
                {
                    textBox15.Text = a.ToString();
                }
                if (textBox16.Text == string.Empty)
                {
                    textBox16.Text = a.ToString();
                }
                decimal am = decimal.Parse(textBox14.Text);

                decimal af = decimal.Parse(textBox15.Text);

                decimal de = decimal.Parse(textBox16.Text);

                decimal to = am + af + de;
                textBox10.Text = to.ToString();

            }
            catch (Exception)
            {
                panel6.BackColor = panel9.BackColor;
            }
        }
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox11.Text = NumberToWords(Convert.ToInt32(textBox10.Text));
            }
            catch (Exception)
            {
                textBox11.Text = "too lerge amount";
            }

        }
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        public string RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, false));
            builder.Append(RandomNumber(10000, 99999));

            return builder.ToString();

        }








        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == string.Empty || comboBox2.Text == string.Empty)
            {
                MessageBox.Show("Enter a vaid value from popup menu!");
            }


            else
            {

                try
                {

                    decimal pay = decimal.Parse(textBox8.Text);


                    decimal amo = decimal.Parse(textBox10.Text);
                    decimal du = pay - amo;
                    textBox8.Text = du.ToString();
                    int c = 1;
                    textBox17.Text = c.ToString();
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\DB\\mydb.mdb;Jet OLEDB:Database Password=@2019madvartutsho;");
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();




                    string refid = RandomPassword();
                    OleDbCommand cmd = con.CreateCommand();
                    cmd.Connection = con;
                    int i = 1;
                    while (i > 0)
                    {

                        string refcmd = "select count(*) from lastpays where [ReceiptID]='" + refid + "'";
                        cmd.CommandText = refcmd;
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();

                        }
                        i = (int)cmd.ExecuteScalar();
                        con.Close();


                        refid = RandomPassword();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();

                    }
                    textBox18.Text = refid;

                    con.Open();
                    string tnxs = "UPDATE printing SET ref='" + textBox18.Text + "',amount='" + textBox10.Text + "',mode='" + comboBox2.Text + "',oid='" + textBox2.Text + "',due='" + textBox8.Text + "',mamount='" + textBox14.Text + "',scharge='" + textBox15.Text + "',sname='" + textBox3.Text + "',room='" + textBox4.Text + "',inword='" + textBox11.Text + "',mname='" + comboBox1.Text + "',datee='" + dateTimePicker1.Value.ToString() + "',npatdate='" + dateTimePicker2.Value.ToString() + "' WHERE ID=1";
                    string history = "Insert into lastpays (ID,Name,Room,Paid,Due,Dateofpayment,ReceiptID) values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox10.Text + "','" + textBox8.Text + "','" + dateTimePicker1.Value.ToString() + "','" + textBox18.Text + "')";
                    string query = "UPDATE Members SET amount='" + textBox10.Text + "',due='" + textBox8.Text + "'  WHERE ID=" + textBox2.Text + "";
                    string print = "UPDATE printing SET ref='" + textBox18.Text + "',amount='" + textBox10.Text + "',tnx='" + textBox9.Text + "',mode='" + comboBox2.Text + "',oid='" + textBox2.Text + "',due='" + textBox8.Text + "',mamount='" + textBox14.Text + "',scharge='" + textBox15.Text + "',sname='" + textBox3.Text + "',room='" + textBox4.Text + "',inword='" + textBox11.Text + "',mname='" + comboBox1.Text + "',datee='" + dateTimePicker1.Value.ToString() + "',npatdate='" + dateTimePicker2.Value.ToString() + "' WHERE ID=1";
                    if (textBox9.Text == string.Empty)
                    {
                        print = tnxs;
                    }
                    cmd.CommandText = query;

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = print;

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = history;

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("last paid amount is " + textBox10.Text + "", "Congrats");

                    con.Close();
                    button2.PerformClick();

                }
                catch (Exception)
                {

                    MessageBox.Show("Please check your Inputs");
                }


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            print a = new print();
            a.Show();


        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void tran_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label11.Text = "TXN. (optional)";

            if (comboBox2.Text == "CASH")

            {
                label11.Text = "Ref (if any)";
            }
        }

        private void keyuo(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            label11.Text = "TXN. (optional)";

            if (comboBox2.Text == "CASH")

            {
                label11.Text = "Ref (if any)";
            }
        }



    }
}
