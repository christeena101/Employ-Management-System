using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; 
namespace Employ_Management
{
    public partial class Emloyee : Form
    {
        public Emloyee()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chris\OneDrive\Documents\MyEmployeeDb.mdf;Integrated Security=True;Connect Timeout=30");     
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (EmpIdTb.Text == "" || EmpNameTb.Text == "" || EmpPhoneTb.Text == "" || EmpAddTb.Text == "")
            {
                MessageBox.Show("Missing Information"); 
            }
            else
            {
                try {
                    Con.Open();
                    string query = "insert into EmployeeTbl (ID, Name, Address, Position, DOB, Phone, Education, Gender) values('" + EmpIdTb.Text + "','" + EmpNameTb.Text + "','" + EmpAddTb.Text + "','" + EmpPosCb.SelectedItem.ToString() + "','" + EmpDob.Value.Date + "','" + EmpPhoneTb.Text + "','" + EmpEduCb.SelectedItem.ToString() + "','" + EmpGenCb.SelectedItem.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Successfully Added");
                    Con.Close();
                    populate();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmpDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Emloyee_Load(object sender, EventArgs e)
        {
             populate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(EmpIdTb.Text == "")
            {
                MessageBox.Show("Enter the Employer ID");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from EmployeeTbl where ID='" + EmpIdTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Deleted Successfully");
                    Con.Close();
                    populate();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EmpDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = EmpDGV.Rows[e.RowIndex];
                EmpIdTb.Text = row.Cells["ID"].Value.ToString();
                EmpNameTb.Text = row.Cells["Name"].Value.ToString();
                EmpAddTb.Text = row.Cells["Address"].Value.ToString();
                EmpEduCb.SelectedItem = row.Cells["Education"].Value.ToString();
                EmpPosCb.SelectedItem = row.Cells["Position"].Value.ToString();
                EmpPhoneTb.Text = row.Cells["Phone"].Value.ToString();
                EmpGenCb.SelectedItem = row.Cells["Gender"].Value.ToString();
            }
            }

            private void button2_Click(object sender, EventArgs e)
        {
            if (EmpIdTb.Text == "" || EmpNameTb.Text == "" || EmpPhoneTb.Text == "" || EmpAddTb.Text == "")
            {
                MessageBox.Show("Missing Information");

            }else
            {
                try
                {
                    Con.Open();
                    string query = "update EmployeeTbl set Name='" + EmpNameTb.Text + "', Address='" + EmpAddTb.Text + "', Position='" + EmpPosCb.SelectedItem.ToString() + "', DOB='" + EmpDob.Value.Date + "', Phone='" + EmpPhoneTb.Text + "', Education='" + EmpEduCb.SelectedItem.ToString() + "', Gender='" + EmpGenCb.SelectedItem.ToString() + "' where ID='" + EmpIdTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Updated Successfully");
                    Con.Close();
                    populate();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide(); 
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
;
