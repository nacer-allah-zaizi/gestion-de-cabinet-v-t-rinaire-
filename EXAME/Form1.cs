namespace EXAME
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
        int a = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            a= a + 1;
            guna2CircleProgressBar1.Value = a;
            label2.Text = a + "%";
            if(guna2CircleProgressBar1.Value==100)
            {
                guna2CircleProgressBar1.Value=0;
                timer1.Stop();
                Form2 form2= new Form2();
                form2.Show();
                this.Hide();
               
            }


        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            this.timer1.Start();
        }
    }
}