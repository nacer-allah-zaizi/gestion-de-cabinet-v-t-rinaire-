using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace EXAME
{
    public partial class Form6 : Form
    {
        public int idd;
        public Form6()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
         
            string categorie =comboBox1.Text;
            string article = textBox1.Text;
            string rf = textBox2.Text;
            string qua = numericUpDown1.Text;
            string pr = textBox5.Text;
            string pattern1 = @"^\d+$";
            bool isValid = Regex.IsMatch(pr, pattern1);
            if (!categorie.Equals("") && !article.Equals("") && !rf.Equals("") && !qua.Equals("") && !pr.Equals(""))
            {
                int quai = int.Parse(numericUpDown1.Text);
                if (quai >0 && isValid)
                {
                    string connstring = "server=localhost;uid=root;pwd=root;database=exam";
                    MySqlConnection conn = new MySqlConnection();
                    conn.ConnectionString = connstring;
                    conn.Open();
                    string sql1 = "INSERT INTO exam.produit(cat,art,ref,qt,pr) VALUES('" + categorie + "','" + article + "','" + rf + "','" + qua + "','" + pr + "');";
                    MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("produit a ete ajoute");
                    conn.Close();
                    comboBox1.Text= "";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox5.Text = "";
                    actauliser();
                }
                else
                    MessageBox.Show("erruer format errone de prix ou quantite!!!!");
                 }
                else
                    MessageBox.Show("ATTENTION vous douvez remplire toutes les champs");
 
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {


                int ll = e.RowIndex;

                object o0 = guna2DataGridView1.Rows[ll].Cells[0].Value;
                idd = int.Parse(o0.ToString());
                object o = guna2DataGridView1.Rows[ll].Cells[1].Value;
                comboBox1.Text= o.ToString();
                object o1 = guna2DataGridView1.Rows[ll].Cells[2].Value;
                textBox1.Text = o1.ToString();
                object o2 = guna2DataGridView1.Rows[ll].Cells[3].Value;
                textBox2.Text = o2.ToString();
                object o3 = guna2DataGridView1.Rows[ll].Cells[4].Value;
                numericUpDown1.Text = o3.ToString();
                object o5 = guna2DataGridView1.Rows[ll].Cells[5].Value;
                textBox5.Text = o5.ToString();

                pictureBox1.Visible= true;
                guna2GradientButton1.Enabled= false;



            }
            if (e.ColumnIndex == 7)
            {
                if (MessageBox.Show("etes vous sur de cette suppression ?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string connstring = "server=localhost;uid=root;pwd=root;database=exam";
                    MySqlConnection conn = new MySqlConnection();
                    conn.ConnectionString = connstring;
                    conn.Open();
                    int c = 0;
                    int l = e.RowIndex;
                    object o = guna2DataGridView1.Rows[l].Cells[c].Value;
                    int i = int.Parse(o.ToString());
                    string sql4 = "delete from produit where id=" + i + "";
                    MySqlCommand cmd4 = new MySqlCommand(sql4, conn);
                  
                    MySqlDataReader dr3 = cmd4.ExecuteReader();
                    conn.Close();
                    actauliser();

                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string categorie = comboBox1.Text;
            string article = textBox1.Text;
            string rf = textBox2.Text;
            string qua = numericUpDown1.Text;
            string pr = textBox5.Text;
            string pattern1 = @"^\d+$";
            bool isValid = Regex.IsMatch(pr, pattern1);
            if (!categorie.Equals("") && !article.Equals("") && !rf.Equals("") && !qua.Equals("") && !pr.Equals(""))
            {
                int quai = int.Parse(numericUpDown1.Text);
                if (quai > 0 && isValid)
                {
                    string connstring = "server=localhost;uid=root;pwd=root;database=exam";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            string sql3 = "update  exam.produit SET cat ='" + comboBox1.Text + "',art='" + textBox1.Text + " ',ref=' " + textBox2.Text + "',qt='" + numericUpDown1.Text + "',pr='" + textBox5.Text + "' where id ='" + idd + "';";
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
            MySqlDataReader dr3 = cmd3.ExecuteReader();
            conn.Close();
            pictureBox1.Visible = false;
                    comboBox1.Text = "";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox5.Text = "";
                    guna2GradientButton1.Enabled = true;
                    actauliser();
                }
                else
                    MessageBox.Show("erruer format errone de prix ou quantite!!!!");
            }
            else
                MessageBox.Show("ATTENTION vous douvez remplire toutes les champs");

        }
        public void actauliser()
        {
            guna2DataGridView1.Rows.Clear();
            string connstring = "server=localhost;uid=root;pwd=root;database=exam";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            string sql3 = "select * from produit";
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);

            MySqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                guna2DataGridView1.Rows.Add(dr3["ID"], dr3["cat"], dr3["art"], dr3["ref"], dr3["qt"], dr3["pr"]);
            }

            conn.Close();
        }

      

        private void Form6_Load(object sender, EventArgs e)
        {
            actauliser();
        }
        private void SearchInDataGridView(string searchValue)
        {

            // Clear any previous highlighting


            // Loop through each row in the DataGridView
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                // Loop through each cell in the row
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // Check if the cell value matches the search value

                    if (cell.Value != null && cell.Value.ToString().Equals(searchValue))
                    {
                        // Select the row

                        row.DefaultCellStyle.BackColor = Color.Orange;
                        // Exit the loop
                        break;
                    }
                }
            }
        }
        private void txtchg(object sender, EventArgs e)
        {
            string s = textBox7.Text;
            if (s.Length > 0)
            {
                SearchInDataGridView(s);
            }
            else
            {
                foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                {
                    // Loop through each cell in the row
                    foreach (DataGridViewCell cell in row.Cells)
                    {

                        row.DefaultCellStyle.BackColor = Color.White;

                    }
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("gg");
            MessageBox.Show(guna2DataGridView1.SelectedRows.Count.ToString());
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                MessageBox.Show("gg");
                // create a new PDF document
                var doc = new iTextSharp.text.Document();
                var output = new FileStream("C:\\Users\\ORIGINAL SHOP\\Desktop\\promed.pdf", FileMode.Create);
                var writer = PdfWriter.GetInstance(doc, output);

                doc.Open();

                Paragraph paragraph = new Paragraph("prod_med N°");
                paragraph.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                doc.Add(paragraph);


                // add a table to the PDF document
                var table = new PdfPTable(guna2DataGridView1.SelectedRows[0].Cells.Count);
                for (int j = 0; j < guna2DataGridView1.SelectedRows[0].Cells.Count; j++)
                {
                    table.AddCell(new Phrase(guna2DataGridView1.Columns[j].HeaderText));
                }
                // table.AddCell("\n");
                // add the selected row's data to the table
                for (int i = 0; i < guna2DataGridView1.SelectedRows[0].Cells.Count; i++)
                {
                    table.AddCell(new Phrase(guna2DataGridView1.SelectedRows[0].Cells[i].Value.ToString()));
                }

                // add the table to the PDF document
                doc.Add(table);
                doc.Close();

            }
        }
    }
}
