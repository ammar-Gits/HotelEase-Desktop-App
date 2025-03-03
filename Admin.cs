using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelEase
{
    public partial class Admin : Form
    {
        Rooms rooms = new Rooms();
        public Admin()
        {
            InitializeComponent();
        }
        private void label4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                guna2TextBox2.UseSystemPasswordChar = false;
            }
            else
            {
                guna2TextBox2.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text.ToLower() == "ammar")
            {
                if (guna2TextBox2.Text == "Ammar2058")
                {
                    this.Hide();
                    rooms.Show();
                }
                else
                {
                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();

                    this.Refresh();
                }
            }
            else if (guna2TextBox1.Text.ToLower() == "huzaifa")
            {
                if (guna2TextBox2.Text == "Huzaifa2058")
                {
                    this.Hide();
                    rooms.Show();
                }
                else
                {
                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();
                    MessageBox.Show("Wrong Username Or Password");
                    this.Refresh();
                }
            }
            else if (guna2TextBox1.Text.ToLower() == "hamza")
            {
                if (guna2TextBox2.Text == "Hamza2058")
                {
                    this.Hide();
                    rooms.Show();
                }
                else
                {
                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();
                    MessageBox.Show("Wrong Username Or Password");
                    this.Refresh();
                }
            }
            else
            {
                guna2TextBox1.Clear();
                guna2TextBox2.Clear();
                MessageBox.Show("Wrong Username Or Password");
                this.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
