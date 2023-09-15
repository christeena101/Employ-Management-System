using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Employ_Management
{
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chris\OneDrive\Documents\MyEmployeeDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void fetchempdata()
        {
            if (EmpIdTb.Text == "")
            {
                MessageBox.Show("Enter Employee Id");
            }
            else
            {
                Con.Open();
                string query = "select * from EmployeeTbl where ID='" + EmpIdTb.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    EmpNameTb.Text = dr["Name"].ToString();
                    EmpPosTb.Text = dr["Position"].ToString();
                }
                Con.Close();
            }
        }

        int DailyBase;
        int total;
        private void button2_Click(object sender, EventArgs e)
        {
            if(EmpPosTb.Text == "")
            {
                MessageBox.Show("Select An Employee");
            }
            else if(WorkedTb.Text == "" || Convert.ToInt32(WorkedTb.Text)>28)
            {
                MessageBox.Show("Enter A Valid Number of Days");
            }else
            {
                if(EmpPosTb.Text == "Manager")
                {
                    DailyBase = 250;
                }else if(EmpPosTb.Text == "Entry")
                {
                    DailyBase = 230;
                }else if(EmpPosTb.Text == "Senior")
                {
                    DailyBase = 200;
                }else
                {
                    DailyBase = 150; 
                }
                total = DailyBase * Convert.ToInt32(WorkedTb.Text);
                SalarySlip.Text = "Employee ID:  "+ EmpIdTb.Text + "\n" + "Emloyee Name: " + EmpNameTb.Text + "\n" + "Employee Position:  "+ EmpPosTb.Text + "\n" + "Worked Days:  " + WorkedTb.Text + "\n" + "Daily Salary:  " + DailyBase + "\n" + "Total Salary:  " + total;
            }
        }

        private void Salary_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fetchempdata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Define font styles
            Font titleFont = new Font("Century Gothic", 25, FontStyle.Bold);
            Font contentFont = new Font("Century Gothic", 25, FontStyle.Regular);
            Brush titleBrush = Brushes.Black;
            Brush contentBrush = Brushes.MediumVioletRed;

            // Get the center of the screen
            int centerX = e.PageBounds.Width / 2;
            int centerY = e.PageBounds.Height / 2;

            // Draw the title "Salary Slip" in the center
            string salarySlipTitle = "=========Salary Slip============";
            SizeF salarySlipTitleSize = e.Graphics.MeasureString(salarySlipTitle, titleFont);
            float salarySlipTitleX = centerX - salarySlipTitleSize.Width / 2;
            e.Graphics.DrawString(salarySlipTitle, titleFont, titleBrush, new PointF(salarySlipTitleX, centerY - 180));

            // Draw employee details
            e.Graphics.DrawString("Employee ID: " + EmpIdTb.Text, contentFont, contentBrush, new PointF(centerX - 300, centerY - 100));
            e.Graphics.DrawString("Employee Name: " + EmpNameTb.Text, contentFont, contentBrush, new PointF(centerX - 300, centerY - 60));
            e.Graphics.DrawString("Employee Position: " + EmpPosTb.Text, contentFont, contentBrush, new PointF(centerX - 300, centerY - 20));
            e.Graphics.DrawString("Employee Worked Days: " + WorkedTb.Text, contentFont, contentBrush, new PointF(centerX - 300, centerY + 20));
            e.Graphics.DrawString("Employee Daily Salary: " + DailyBase, contentFont, contentBrush, new PointF(centerX - 300, centerY + 60));
            e.Graphics.DrawString("Employee Total Salary: " + total, contentFont, contentBrush, new PointF(centerX - 300, centerY + 100));

            // Draw the title "JobyTech" in the center
            string jobyTechTitle = "=========JobyTech============";
            SizeF jobyTechTitleSize = e.Graphics.MeasureString(jobyTechTitle, titleFont);
            float jobyTechTitleX = centerX - jobyTechTitleSize.Width / 2;
            e.Graphics.DrawString(jobyTechTitle, titleFont, titleBrush, new PointF(jobyTechTitleX, centerY + 140));
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            fetchempdata();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if(EmpPosTb.Text == "")
            {
                MessageBox.Show("Select An Employee");
            }
            else if(WorkedTb.Text == "" || Convert.ToInt32(WorkedTb.Text) > 28)
            {
                MessageBox.Show("Enter A Valid Number od Days");
            }else
            {
                if(EmpPosTb.Text == "Manager")
                {
                    DailyBase = 520;

                }else if (EmpPosTb.Text == "Senior")
                {
                DailyBase = 400;

            }else if (EmpPosTb.Text == "Entry")
                {
                    DailyBase = 240;

                }
                else
                {
                    DailyBase = 120;
                }
                total = DailyBase * Convert.ToInt32(WorkedTb.Text);
                SalarySlip.Text = "=========Salary Slip============" + "\n" + "Employee ID:  " + EmpIdTb.Text + "\n" + "Emloyee Name: " + EmpNameTb.Text + "\n" + "Employee Position:  " + EmpPosTb.Text + "\n" + "Worked Days:  " + WorkedTb.Text + "\n" + "Daily Salary:  " + DailyBase + "\n" + "Total Salary:  " + total;

            }


        }

        private void SalarySlip_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
