using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXAME
{ 
    public partial class Form9 : Form
    {
        public int total=0;
        public int total1 = 0;
        public int total2 = 0;
        public string l;
        public int idd;
        public int idc;
        public int idp;
        public int qua;

        Form3 form3;
        public Form9(Form3 f3)
        {
            InitializeComponent();
            form3 = f3;
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            timer1.Start();
            string connstring1 = "server=localhost;uid=root;pwd=root;database=exam";
            MySqlConnection conn1 = new MySqlConnection();
            conn1.ConnectionString = connstring1;
            conn1.Open();
            string sql4 = "select * from produit ";
            MySqlCommand cmd4 = new MySqlCommand(sql4, conn1);

            MySqlDataReader dr4 = cmd4.ExecuteReader();
            while (dr4.Read())
            {
                comboBox2.Items.Add(dr4["ID"] + "," + dr4["art"]);

            }
            conn1.Close();

            actauliser3();
            actauliser();
        }
        public void actauliser3()
        {
            

            guna2DataGridView1.Rows.Clear();
            string connstring = "server=localhost;uid=root;pwd=root;database=exam";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            string sql3 = "select * from rv where idv="+form3.id+" and status='non termine';";
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);

            MySqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                guna2DataGridView1.Rows.Add(dr3["ID"], dr3["idc"], dr3["ida"], dr3["date"], dr3["lieu"], dr3["regl"]);


            }

            conn.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            actauliser3();
            actauliser();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible= false;
           if(l.Equals("Cabinet")) {
               
                string connstring = "server=localhost;uid=root;pwd=root;database=exam";
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connstring;
                conn.Open();
                string sql2 = "update  exam.rv SET status ='termine' where id ='" + idd + "';";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                cmd2.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("bien recus");
                guna2DataGridView1.Enabled = true;

            }
            else
            {
                total = 1500;
                textBox2.Text = total.ToString();
                panel1.Visible = true;

            }

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
               guna2DataGridView1.Enabled= false;
              
                pictureBox1.Visible = true;
                pictureBox4.Visible= true;

                int ll = e.RowIndex;
                   
                object o = guna2DataGridView1.Rows[ll].Cells[4].Value;
                 l = o.ToString();
                object o1 = guna2DataGridView1.Rows[ll].Cells[0].Value;
                idd = int.Parse(o1.ToString());
                object o2 = guna2DataGridView1.Rows[ll].Cells[1].Value;
                idc = int.Parse(o2.ToString());




            }
        }
        public void actauliser1()
        {
            string[] ct = comboBox2.Text.Split(',');
            idp = int.Parse(ct[0]);

            string connstring = "server=localhost;uid=root;pwd=root;database=exam";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            string sql3 = "select * from produit where id=" + idp + ";";
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);

            MySqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {


                textBox1.Text = (string)dr3["pr"] + "[" + (string)dr3["qt"] + "]";
                qua = int.Parse((string)dr3["qt"]);

            }

            conn.Close();
        }
        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string[] ct = textBox1.Text.Split('[');
            int g = int.Parse(ct[0]);
            if (int.Parse(numericUpDown1.Text) <= qua)
            {
                total1 = total1 + (g * int.Parse(numericUpDown1.Text));
                textBox3.Text = total1.ToString();
            }
            else
                MessageBox.Show("impossible vous avez depasse la quantite de stocke");
        }

     

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible= false;
            guna2DataGridView1.Enabled = true;
            pictureBox4.Visible = false;
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                row.Cells["STATUS"].Value = false;
            }
        
        }
        public void actauliser()
        {

            guna2DataGridView2.Rows.Clear();
            string connstring = "server=localhost;uid=root;pwd=root;database=exam";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            string sql3 = "select * from facture";
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);

            MySqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                guna2DataGridView2.Rows.Add(dr3["ID"], dr3["idc"], dr3["date"], dr3["lieu"], dr3["total"]);


            }

            conn.Close();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            string[] ct = comboBox2.Text.Split(',');
            idp = int.Parse(ct[0]);

            string connstring = "server=localhost;uid=root;pwd=root;database=exam";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            string sql3 = "select * from produit where id=" + idp + ";";
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);

            MySqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {


                textBox1.Text = (string)dr3["pr"] + "[" + (string)dr3["qt"] + "]";
                qua = int.Parse((string)dr3["qt"]);

            }

            conn.Close();
        }

        

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            actauliser1();
            string[] ct = textBox1.Text.Split('[');
            int g = int.Parse(ct[0]);
            if (int.Parse(numericUpDown1.Text) <= qua)
            {
                total1 = total1 + (g * int.Parse(numericUpDown1.Text));
                textBox3.Text = total1.ToString();
            }
            else
                MessageBox.Show("impossible vous avez depasse la quantite de stocke");
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
           
            total2 = total1 + total;
            string connstring = "server=localhost;uid=root;pwd=root;database=exam";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;

            conn.Open();
            string sql1 = "INSERT INTO exam.facture(date,lieu,total,idc) VALUES('" + DateTime.Now.ToString() + "','" + l + "','" + total2 + "','" + idc + "');";
            MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("facture regle!!!!!!!!"+ idp+idd );
            conn.Close();

            conn.Open();
            string sql2 = "update  exam.produit SET qt ='" + (qua - int.Parse(numericUpDown1.Text)) + "' where id ='" + idp + "';";
            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
            cmd2.ExecuteNonQuery();
            conn.Close();
            conn.Open();
            string sql3 = "update  exam.rv SET regl ='paye',status='termine' where id ='" + idd + "';";
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
            cmd3.ExecuteNonQuery();
            conn.Close();
        }
    }
}
