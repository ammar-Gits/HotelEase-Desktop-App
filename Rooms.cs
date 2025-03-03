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
    public partial class Rooms : Form
    {
        SqlConnection Conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ammar\Documents\Hotel Manager.mdf;Integrated Security=True;Connect Timeout=30");
        public Rooms()
        {
            InitializeComponent();
            LoadRoomData();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Categories categories = new Categories();
            categories.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadRoomData()
        {
            try
            {
                Conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT num, name, type, status FROM Rooms", Conn);
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
                    guna2DataGridView1.Columns.Add("Type", "Type");
                    guna2DataGridView1.Columns.Add("Status", "Status");
                    // Map DataTable columns to DataGridView columns
                    guna2DataGridView1.Columns["Num"].DataPropertyName = "num";
                    guna2DataGridView1.Columns["Name"].DataPropertyName = "name";
                    guna2DataGridView1.Columns["Type"].DataPropertyName = "type";
                    guna2DataGridView1.Columns["Status"].DataPropertyName = "status";
                    guna2DataGridView1.Columns["Num"].Width = 50;
                    guna2DataGridView1.Columns["Name"].Width = 250;
                    guna2DataGridView1.Columns["Type"].Width = 250;
                    guna2DataGridView1.Columns["Status"].Width = 250;
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
            if (guna2TextBox1.Text == "" || guna2ComboBox1.Text == "" || guna2ComboBox2.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Rooms (name, type, status) VALUES (@name, @type, @status)", Conn);
                    cmd.Parameters.AddWithValue("@name", guna2TextBox1.Text);
                    cmd.Parameters.AddWithValue("@type", guna2ComboBox1.Text);
                    cmd.Parameters.AddWithValue("@status", guna2ComboBox2.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Room Successfully Added");
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
                LoadRoomData();

            }
        }
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "")
            {
                MessageBox.Show("Please write room name to be deleted", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string categoryNameToDelete = guna2TextBox1.Text; // Set the name of the category to delete here

                    Conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Rooms WHERE name = @Name", Conn);
                    cmd.Parameters.AddWithValue("@Name", categoryNameToDelete);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Room deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Room with the specified name not found.");
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
            LoadRoomData();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bookings are available for users only..");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Clear();

        }

        private void guna2guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customers customers = new Customers();
            customers.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();  
            dashboard.Show();
        }
    }
}
