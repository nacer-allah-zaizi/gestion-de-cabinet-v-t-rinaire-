using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net.Mail;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace EXAME
{
    public partial class Form3 : Form
    {
        Form2 forme2;
        public int id;
     
        public Form3(Form2 f2)
        {
            InitializeComponent();
            this.forme2= f2;
          
        }

        

     

        private void label4_Click(object sender, EventArgs e)
        {
           
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            Form4 form4 = new Form4();
           
            form4.TopLevel = false;
            form4.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(form4);
           
            this.panel1.Tag = form4;
          Class1.AnimateWindow(form4.Handle, 500, Class1.HOR_Positive) ;
            form4.Show();
          

        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            Form8 form8= new Form8();
            form8.TopLevel = false;
            form8.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(form8);
            this.panel1.Tag = form8;
            Class1.AnimateWindow(form8.Handle, 500, Class1.HOR_Positive);
            form8.Show();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            Form6 form6 = new Form6();
            form6.TopLevel = false;
            form6.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(form6);
            this.panel1.Tag = form6;
            Class1.AnimateWindow(form6.Handle, 500, Class1.HOR_Positive);
            form6.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            Form5 form5 = new Form5();
            form5.TopLevel = false;
            form5.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(form5);
            this.panel1.Tag = form5;
            Class1.AnimateWindow(form5.Handle, 500, Class1.HOR_Positive);
            form5.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            Form7 form7 = new Form7();
            form7.TopLevel = false;
            form7.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(form7);
            this.panel1.Tag = form7;
           Class1.AnimateWindow(form7.Handle, 500, Class1.HOR_Positive);
            form7.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            

            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            Form11 form11 = new Form11();
            form11.TopLevel = false;
            form11.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(form11);
            this.panel1.Tag = form11;
            form11.Show();

            if (forme2.role == "admin")
            {
              
                panel4.Visible= true;
                panel5.Visible= true;
                panel6.Visible = true;

            }
            else if (forme2.role == "Receveur")
            {
              
                panel4.Visible = true;
                panel7.Visible = true;
                panel8.Visible = true;
                panel7.Location = new Point(6, 239);
                panel8.Location = new Point(6, 341);

            }
            else if (forme2.role == "Veterinaire")
            {
                panel4.Visible = true;
                label2.Visible=false;
                label7.Visible = true;
                label7.Location = new Point(81, 16);
                //////////
                string connstring = "server=localhost;uid=root;pwd=root;database=exam";
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connstring;
                conn.Open();
                string sql = "select * from exam.employe where email='"+forme2.ee+"'and pw='"+forme2.pw+"';";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    id = (int)dr["id"];
                }
                ///





            }
            else if (forme2.role == "Assistant")
            {
               panel1.Visible = true;
               
            }
            else
            {
               panel9.Visible= true;
                panel9.Location = new Point(8, 136);
                //////////
                string connstring = "server=localhost;uid=root;pwd=root;database=exam";
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connstring;
                conn.Open();
                string sql = "select * from exam.client where email='" + forme2.ee + "'and pw='" + forme2.pw + "';";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    id = (int)dr["id"];
                }
             

            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            Form9 form9 = new Form9(this);
            form9.TopLevel = false;
            form9.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(form9);
            this.panel1.Tag = form9;
           Class1.AnimateWindow(form9.Handle, 500, Class1.HOR_Positive);
            form9.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            Form11 form11 = new Form11();
            form11.TopLevel = false;
            form11.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(form11);
            this.panel1.Tag = form11;
           Class1.AnimateWindow(form11.Handle, 500, Class1.CENTER);
            form11.Show();
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            Form10 form10 = new Form10(this);
            form10.TopLevel = false;
            form10.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(form10);
            this.panel1.Tag = form10;
           Class1.AnimateWindow(form10.Handle, 500, Class1.HOR_Positive);
            form10.Show();
        }

        private void P3(object sender, MouseEventArgs e)
        {
            panel3.BackColor=Color.BlanchedAlmond;
        }

        private void P33(object sender, EventArgs e)
        {
            panel3.BackColor = Color.AliceBlue;
        }

        private void P44(object sender, EventArgs e)
        {
            panel4.BackColor = Color.AliceBlue;
        }

        private void P4(object sender, MouseEventArgs e)
        {
            panel4.BackColor = Color.BlanchedAlmond;
        }

        private void P55(object sender, EventArgs e)
        {
            panel5.BackColor = Color.AliceBlue;
        }

        private void P5(object sender, MouseEventArgs e)
        {
            panel5.BackColor = Color.BlanchedAlmond;
        }

        private void P66(object sender, EventArgs e)
        {
            panel6.BackColor = Color.AliceBlue;
        }

        private void P6(object sender, MouseEventArgs e)
        {
            panel6.BackColor = Color.BlanchedAlmond;
        }

        private void P77(object sender, EventArgs e)
        {
            panel7.BackColor = Color.AliceBlue;
        }

        private void P7(object sender, MouseEventArgs e)
        {
            panel7.BackColor = Color.BlanchedAlmond;
        }

        private void P88(object sender, EventArgs e)
        {
            panel8.BackColor = Color.AliceBlue;
        }

        private void P8(object sender, MouseEventArgs e)
        {
            panel8.BackColor = Color.BlanchedAlmond;
        }

        private void P99(object sender, EventArgs e)
        {
            panel9.BackColor = Color.AliceBlue;
        }

        private void P9(object sender, MouseEventArgs e)
        {
            panel9.BackColor = Color.BlanchedAlmond;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 form2 = new Form2();
            form2.Show();
          

        }
    }
}
