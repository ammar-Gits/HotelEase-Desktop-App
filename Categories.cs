using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HotelEase
{
    public partial class Categories : Form
    {
        SqlConnection Conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ammar\Documents\Hotel Manager.mdf;Integrated Security=True;Connect Timeout=30");
        public Categories()
        {
            InitializeComponent();
            LoadCategoriesData();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Rooms rooms = new Rooms();
            rooms.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bookings are available for users only..");
        }
        private void LoadCategoriesData()
        {
             try
             {
                Conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT num, name, cost FROM categories", Conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    guna2DataGridView1.DataSource = null;
                    guna2DataGridView1.Columns.Clear();
                    return; // Exit the method if there are no rows in the DataTable
                }

                if (dt.Rows.Count > 0)
                {
                    guna2DataGridView1.Columns.Clear();
                    guna2DataGridView1.Columns.Add("Num", "Num");
                    guna2DataGridView1.Columns.Add("Name", "Name");
                    guna2DataGridView1.Columns.Add("Cost", "Cost");

                    // Map DataTable columns to DataGridView columns
                    guna2DataGridView1.Columns["Num"].DataPropertyName = "num";
                    guna2DataGridView1.Columns["Name"].DataPropertyName = "name";
                    guna2DataGridView1.Columns["Cost"].DataPropertyName = "cost";
                    guna2DataGridView1.Columns["Num"].Width = 50;
                    guna2DataGridView1.Columns["Name"].Width = 410;
                    guna2DataGridView1.Columns["Cost"].Width = 350;

                    // Set DataSource
                    guna2DataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                Conn.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO categories (name, cost) VALUES (@name, @cost)", Conn);
                    cmd.Parameters.AddWithValue("@name", guna2TextBox1.Text);
                    cmd.Parameters.AddWithValue("@cost", guna2TextBox2.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category Successfully Added");
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
                LoadCategoriesData();

            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "")
            {
                MessageBox.Show("Please write category name to be deleted", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string categoryNameToDelete = guna2TextBox1.Text; // Set the name of the category to delete here

                    Conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM categories WHERE name = @Name", Conn);
                    cmd.Parameters.AddWithValue("@Name", categoryNameToDelete);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Category deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Category with the specified name not found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    Conn.Close();
                }
            }
            LoadCategoriesData();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            guna2TextBox2.Clear();
            guna2TextBox2.Clear();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
