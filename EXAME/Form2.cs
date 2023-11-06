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
using MySql.Data.MySqlClient;

namespace EXAME
{
    public partial class Form2 : Form
    {
        public string role;
        public string ee;
        public string pw;
        public int id;
        public Form2()
        {
            InitializeComponent();
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar= false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
           


            int i = 0;
            int a = 0;
            int b = 0;
            int c = 0;


            string email = textBox1.Text;
            string password = textBox2.Text;
          if(email.Equals(""))
            {
               
                a=1;
            }
          if(password.Equals(""))
            {
                
                b=2;

            }
            
            c = a + b;
            if(c==0) {
                string connstring = "server=localhost;uid=root;pwd=root;database=exam";
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connstring;
                conn.Open();
                string sql = "select * from exam.utilisateur";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (((string)dr["email"]) == email && ((string)dr["pw"] == password))
                    {

                        i++;
                        role = (string)dr["role"];
                        ee= (string)dr["email"];
                        pw= (string)dr["pw"];
                        break;
                    }
                }
                if (i != 0)
                {

                    Form3 form3 = new Form3(this);
                    form3.Show();
                    this.Hide();


                }
                else
                {
                    MessageBox.Show("erreur email ou password est incorrecte");

                }
            }
            else
            {
               
                if(a == 1)
                {
                    label6.Visible=true;
                    label6.Text = "Entrer s'il vous plait votre login!!";
                    panel1.BackColor = Color.Red;
                }
                if (b == 2)
                {
                    label7.Visible = true;
                    label7.Text = "Entrer s'il vous plait votre mot de passe !!";
                    panel2.BackColor = Color.Red;
                }
            }







        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void click(object sender, EventArgs e)
        {
            
                label6.Visible = false;
            textBox1.Clear();

          
        }

        private void click1(object sender, EventArgs e)
        {
            label7.Visible = false;
            textBox2.Clear();
        }
    }
}
