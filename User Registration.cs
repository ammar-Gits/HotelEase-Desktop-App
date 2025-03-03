using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;

namespace HotelEase
{
    public partial class User_Registration : Form
    {
        Form1 Form1 = new Form1();
        SqlConnection Conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ammar\Documents\Hotel Manager.mdf;Integrated Security=True;Connect Timeout=30");
        public User_Registration()
        {
            InitializeComponent();
        }
        
        
     
    

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (guna2TextBox3.Text == "" || guna2TextBox1.Text == ""
                || guna2TextBox2.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Conn.Open();

                    // Check if the phone number already exists
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM customers WHERE phone = @Phone", Conn);
                    checkCmd.Parameters.AddWithValue("@Phone", guna2TextBox4.Text);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Error: User with this phone number already exists.");
                        return; // Exit the method
                    }

                    // If phone number is unique, proceed with insertion
                    SqlCommand cmd = new SqlCommand("INSERT INTO customers (phone, username, password, email) VALUES (@Phone, @Username, @Password, @Email)", Conn);
                    cmd.Parameters.AddWithValue("@Username", guna2TextBox1.Text);
                    cmd.Parameters.AddWithValue("@Email", guna2TextBox3.Text);
                    cmd.Parameters.AddWithValue("@Password", guna2TextBox2.Text);
                    cmd.Parameters.AddWithValue("@Phone", guna2TextBox4.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Successfully Added");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                    }
                }


            }
        }

        private void guna2TextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1.Show();
        }

        private void checkBox1_CheckedChanged_2(object sender, EventArgs e)
        {
           
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
