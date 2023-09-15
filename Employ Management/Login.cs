using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employ_Management
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (USIdTb.Text == "" || PassTb.Text == "")
            {
                MessageBox.Show("Enter User Name or User Password");
            }
            else if (USIdTb.Text == "Admin" && PassTb.Text == "Password")
            {
                this.Hide();
                Home home = new Home();
                home.Show();
            }
            else
            {
                MessageBox.Show("Incorrect User Name or Password");
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void USIdTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
