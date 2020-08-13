using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HMSystemfainal
{
    public partial class god : Form
    {
        public god()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\DB\\mydb.mdb;Jet OLEDB:Database Password=@2019madvartutsho;");
        OleDbCommand cmd = new OleDbCommand();
        String sql3;
        OpenFileDialog ofd = new OpenFileDialog();
        string connetionString = null;
        string sql = null;
        string constring;
        string sql1;

        private void saveImage(string sql3)
        {
            try
            {
                con.Open();
                string path = ofd.FileName;
                byte[] imageData;

                cmd = new OleDbCommand();

                cmd.Connection = con;
                cmd.CommandText = sql3;
                imageData = System.IO.File.ReadAllBytes(@path);
                cmd.Parameters.AddWithValue("@IM", imageData);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void god_Load(object sender, EventArgs e)
        {

        }
        private void button7_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty)
            {
                MessageBox.Show("PLEASE CHECK YOUR INPUTS");
            }
            else
            {
                connetionString = "Data Source=lastdb.cejjgyj9s4gc.us-east-2.rds.amazonaws.com;Initial Catalog=madvart;Persist Security Info=True;User ID=utshomax;Password=utshomax;";
                constring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\DB\\mydb.mdb;Jet OLEDB:Database Password=@2019madvartutsho;";


                sql = "insert into max ([rid],[hname]) values(@first,@name)";

                sql1 = "UPDATE hostelinfo SET [rkey]=@val,[hname]=@name1,[address]=@add WHERE hid=0";


                try
                {


                    using (SqlConnection cnn = new SqlConnection(connetionString))
                    {
                        cnn.Open();
                        using (SqlCommand cmd = new SqlCommand(sql, cnn))
                        {

                            cmd.Parameters.Add("@first", SqlDbType.NVarChar).Value = textBox3.Text;
                            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = textBox1.Text;


                            cmd.ExecuteNonQuery();

                            cnn.Close();

                        }
                    }

                    using (OleDbConnection con1 = new OleDbConnection(constring))
                    {
                        con1.Open();
                        using (OleDbCommand cmd1 = new OleDbCommand(sql1, con1))
                        {
                            cmd1.Parameters.Add("@val", OleDbType.VarChar).Value = textBox3.Text;
                            cmd1.Parameters.Add("@name1", OleDbType.VarChar).Value = textBox1.Text;
                            cmd1.Parameters.Add("@add", OleDbType.VarChar).Value = textBox2.Text;
                            cmd1.ExecuteNonQuery();

                        }
                        con1.Close();
                    }


                    MessageBox.Show("THIS SOFTWERE IS SUCCESSFULLY REGISTERED." +
                        "RKEY= " + textBox3.Text + "");


                }
                catch (Exception ex)
                {

                    MessageBox.Show("ERROR:" + ex.Message);
                }


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            //'CHECK THE SELECTED FILE IF IT EXIST OTHERWISE THE DIALOG BOX WILL DISPLAY A WARNING.
            ofd.CheckFileExists = true;

            //'CHECK THE SELECTED PATH IF IT EXIST OTHERWISE THE DIALOG BOX WILL DISPLAY A WARNING.
            ofd.CheckPathExists = true;

            //'GET AND SET THE DEFAULT EXTENSION
            ofd.DefaultExt = "jpg";

            //'RETURN THE FILE LINKED TO THE LNK FILE
            ofd.DereferenceLinks = true;

            //'SET THE FILE NAME TO EMPTY 
            ofd.FileName = ".jpg";

            //'FILTERING THE FILES
            ofd.Filter = "(*.jpg)|*.jpg|(*.png)|*.png|(*.jpg)|*.jpg|All files|*.*";
            //'SET THIS FOR ONE FILE SELECTION ONLY.
            ofd.Multiselect = false;

            //'SET THIS TO PUT THE CURRENT FOLDER BACK TO WHERE IT HAS STARTED.
            ofd.RestoreDirectory = true;

            //'SET THE TITLE OF THE DIALOG BOX.
            ofd.Title = "Select a file to open";

            //'ACCEPT ONLY THE VALID WIN32 FILE NAMES.
            ofd.ValidateNames = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }




        }


        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == string.Empty || textBox8.Text == string.Empty || textBox9.Text == string.Empty || textBox6.Text == string.Empty || textBox4.Text == string.Empty)
            {
                MessageBox.Show("PLEASE CHECK YOUR INPUTS");
            }
            else
            {
                sql3 = "UPDATE Users SET [pic]=@IM,[users]='" + textBox7.Text + "',[password]='" + textBox6.Text + "',[name]='" + textBox8.Text + "',[job]='" + textBox4.Text + "',[phoneno]='" + textBox9.Text + "' WHERE id=1";
                saveImage(sql3);
                MessageBox.Show("USER HAS BEEN UPDATED");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            main a = new main();
            this.Hide();
            a.Show();
        }
    }
}
