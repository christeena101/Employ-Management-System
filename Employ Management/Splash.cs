namespace Employ_Management
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }
        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            myProgress.Value = startpoint;
            if(myProgress.Value == 100)
            {
                myProgress.Value = 0;
                timer1.Stop();
                this.Hide();
                Login log = new Login();
                log.Show();
            }
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Start(); 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void myProgress_Click(object sender, EventArgs e)
        {

        }
    }
}