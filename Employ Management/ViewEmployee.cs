using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Employ_Management
{
    public partial class ViewEmployee : Form
    {
        public ViewEmployee()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chris\OneDrive\Documents\MyEmployeeDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void fetchempdata()
        {
            Con.Open();
            string query = "select * from EmployeeTbl where ID='" + EmpIdTb.Text + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                EmpIdlbl.Text = dr["ID"].ToString();
                empnamelbl.Text = dr["Name"].ToString();
                empaddlbl.Text = dr["Address"].ToString();
                empposlbl.Text = dr["Position"].ToString();
                empphone.Text = dr["Phone"].ToString();
                empedulbl.Text = dr["Education"].ToString();
                empgenlbl.Text = dr["Gender"].ToString();
                empdob.Text = dr["DOB"].ToString();
                EmpIdlbl.Visible = true;
                empnamelbl.Visible = true;
                empaddlbl.Visible = true;
                empphone.Visible = true;
                empposlbl.Visible = true;
                EmpIdlbl.Visible = true;
                empedulbl.Visible = true;
                empgenlbl.Visible = true;
                empdob.Visible = true;
            }
            Con.Close();
        }

        private void ViewEmployee_Load(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmpIdTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            fetchempdata();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }   
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {     // Define font styles
            Font titleFont = new Font("Century Gothic", 25, FontStyle.Bold);
            Font contentFont = new Font("Century Gothic", 25, FontStyle.Regular);
            Brush titleBrush = Brushes.Black;
            Brush contentBrush = Brushes.MediumVioletRed;

            // Get the center of the page
            int centerX = e.PageBounds.Width / 2;

            // Draw the title "EMPLOYEE SUMMARY" in the center
            string employeeSummaryTitle = "=========EMPLOYEE SUMMARY============";
            SizeF employeeSummaryTitleSize = e.Graphics.MeasureString(employeeSummaryTitle, titleFont);
            float employeeSummaryTitleX = centerX - employeeSummaryTitleSize.Width / 2;
            e.Graphics.DrawString(employeeSummaryTitle, titleFont, titleBrush, new PointF(employeeSummaryTitleX, 100));

            // Draw employee details under each other
            float startY = 180;
            float lineHeight = contentFont.GetHeight(e.Graphics);

            e.Graphics.DrawString("Employee ID: " + EmpIdlbl.Text, contentFont, contentBrush, new PointF(10, startY));
            startY += lineHeight;

            e.Graphics.DrawString("Employee Name: " + empnamelbl.Text, contentFont, contentBrush, new PointF(10, startY));
            startY += lineHeight;

            e.Graphics.DrawString("Employee Address: " + empaddlbl.Text, contentFont, contentBrush, new PointF(10, startY));
            startY += lineHeight;

            e.Graphics.DrawString("Employee Phone: " + empphone.Text, contentFont, contentBrush, new PointF(10, startY));
            startY += lineHeight;

            e.Graphics.DrawString("Employee Education: " + empedulbl.Text, contentFont, contentBrush, new PointF(10, startY));
            startY += lineHeight;

            e.Graphics.DrawString("Employee Position: " + empposlbl.Text, contentFont, contentBrush, new PointF(10, startY));
            startY += lineHeight;

            e.Graphics.DrawString("Employee DOB: " + empdob.Text, contentFont, contentBrush, new PointF(10, startY));
            startY += lineHeight;

            e.Graphics.DrawString("Employee Gender: " + empgenlbl.Text, contentFont, contentBrush, new PointF(10, startY));
            startY += lineHeight;

            // Draw the title "JobyTech" in the center
            string jobyTitle = "=========JobyTech============";
            SizeF jobyTitleSize = e.Graphics.MeasureString(jobyTitle, titleFont);
            float jobyTitleX = centerX - jobyTitleSize.Width / 2;
            e.Graphics.DrawString(jobyTitle, titleFont, titleBrush, new PointF(jobyTitleX, startY + 20));
        }

        private void EmpIdTb_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
}
