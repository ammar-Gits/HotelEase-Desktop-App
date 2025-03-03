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
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please Login through Admin");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please Login through Admin");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please Login through Admin");
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bookings bookings1 = new Bookings();
            bookings1.Show();
        }
    }
}
