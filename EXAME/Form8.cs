using Guna.UI2.WinForms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EXAME
{
    public partial class Form8 : Form
    {
        public int total=0;
        public int total1 = 0;
        public int total2 = 0;
        public int id = 0;
        public int idd = 0;
        public int qua = 0;
        public Form8()
        {
            InitializeComponent();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {


                int ll = e.RowIndex;
                object o = guna2DataGridView1.Rows[ll].Cells[5].Value;
                string l = o.ToString();
                object o1 = guna2DataGridView1.Rows[ll].Cells[6].Value;
                string l1 = o1.ToString();

                if (l == "non paye" && l1 == "termine")
                {
                    total = 700;
                    pictureBox1.Visible = true;
                }
                else
                    MessageBox.Show("impppppp!!!!!!!!!!!");
       
            }
        }
        public void actauliser()
        {
            string[] ct = comboBox1.Text.Split(',');
             id = int.Parse(ct[0]);
            guna2DataGridView1.Rows.Clear();
            string connstring = "server=localhost;uid=root;pwd=root;database=exam";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            string sql3 = "select * from rv where idc="+id +";";
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);

            MySqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
              

                guna2DataGridView1.Rows.Add(dr3["ID"], dr3["idv"], dr3["ida"], dr3["date"], dr3["lieu"], dr3["regl"], dr3["status"]);
            }

            conn.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {
           actauliser3();
            //////////////////////////
            string connstring = "server=localhost;uid=root;pwd=root;database=exam";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            string sql3 = "select * from client";
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);

            MySqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                comboBox1.Items.Add(dr3["ID"] + "," + dr3["NOM"] + "," + dr3["PRENOM"]);

            }
            conn.Close();
            ///////////////////////////

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
        }

        private void label2_Click(object sender, EventArgs e)
        {
            actauliser();
        }

        public void actauliser1()
        {
            string[] ct = comboBox2.Text.Split(',');
           idd= int.Parse(ct[0]);
           
            string connstring = "server=localhost;uid=root;pwd=root;database=exam";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            string sql3 = "select * from produit where id=" + idd + ";";
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);

            MySqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {


                textBox1.Text = (string)dr3["pr"]+"["+ (string)dr3["qt"]+"]";
                qua=int.Parse((string)dr3["qt"]) ;

            }

            conn.Close();
        }
        private void label3_Click(object sender, EventArgs e)
        {
            actauliser1();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox2.Text = total.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string[] ct = textBox1.Text.Split('[');
            int g = int.Parse(ct[0]);
            if (int.Parse(numericUpDown1.Text) <= qua)
            {
                total1 = total1 + (g* int.Parse(numericUpDown1.Text));
                textBox3.Text = total1.ToString();
            }
            else
                MessageBox.Show("impossible vous avez depasse la quantite de stocke");
          
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
            
            if (id != 0)
            {
               
                total2 = total1 + total;
                string connstring = "server=localhost;uid=root;pwd=root;database=exam";
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connstring;

                conn.Open();
                string sql1 = "INSERT INTO exam.facture(date,lieu,total,idc) VALUES('" + DateTime.Now.ToString() + "','" + "Cabinet" + "','" + total2 + "','" + id + "');";
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("produit a ete ajoute");
                conn.Close();

                conn.Open();
                string sql2 = "update  exam.produit SET qt ='" + (qua - int.Parse(numericUpDown1.Text)) + "' where id ='" + idd + "';";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                cmd2.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                string sql3 = "update  exam.rv SET regl ='paye' where idc ='" + id + "'and status='termine';";
                MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
                cmd3.ExecuteNonQuery();
                conn.Close();
                actauliser3();
            }
            else
                MessageBox.Show("selectionez une client!!!!");

        }
        public void actauliser3()
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("gg");
            MessageBox.Show(guna2DataGridView2.SelectedRows.Count.ToString());
            if (guna2DataGridView2.SelectedRows.Count > 0)
            {
                MessageBox.Show("gg");
                // create a new PDF document
                var doc = new iTextSharp.text.Document();
                var output = new FileStream("C:\\Users\\ORIGINAL SHOP\\Desktop\\facture.pdf", FileMode.Create);
                var writer = PdfWriter.GetInstance(doc, output);

                doc.Open();

                Paragraph paragraph = new Paragraph("facture N°");
                paragraph.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                doc.Add(paragraph);


                // add a table to the PDF document
                var table = new PdfPTable(guna2DataGridView2.SelectedRows[0].Cells.Count);
                for (int j = 0; j < guna2DataGridView2.SelectedRows[0].Cells.Count; j++)
                {
                    table.AddCell(new Phrase(guna2DataGridView2.Columns[j].HeaderText));
                }
                // table.AddCell("\n");
                // add the selected row's data to the table
                for (int i = 0; i < guna2DataGridView2.SelectedRows[0].Cells.Count; i++)
                {
                    table.AddCell(new Phrase(guna2DataGridView2.SelectedRows[0].Cells[i].Value.ToString()));
                }

                // add the table to the PDF document
                doc.Add(table);
                doc.Close();

            }
        }
    }
}
