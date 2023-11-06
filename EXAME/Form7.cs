using iTextSharp.text.pdf;
using iTextSharp.text;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EXAME
{
    public partial class Form7 : Form
    {
        public int idd;
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            actauliser();

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
                comboBox1.Items.Add(dr3["ID"]+"__"+dr3["NOM"]+"__"+dr3["PRENOM"]);
              
            }
            conn.Close();
            ///////////////////////////
       
            string connstring1 = "server=localhost;uid=root;pwd=root;database=exam";
            MySqlConnection conn1 = new MySqlConnection();
            conn1.ConnectionString = connstring1;
            conn1.Open();
            string sql4 = "select * from employe where service='veterinaire' ";
            MySqlCommand cmd4 = new MySqlCommand(sql4, conn1);

            MySqlDataReader dr4 = cmd4.ExecuteReader();
            while (dr4.Read())
            {
                comboBox2.Items.Add(dr4["ID"] + "__" + dr4["NOM"] + "__" + dr4["PRENOM"]);

            }
            conn.Close();
            ///////////////////////////
            string connstring2 = "server=localhost;uid=root;pwd=root;database=exam";
            MySqlConnection conn2 = new MySqlConnection();
            conn2.ConnectionString = connstring2;
            conn2.Open();
            string sql5 = "select * from employe where service='assistant' ";
            MySqlCommand cmd5 = new MySqlCommand(sql5, conn2);

            MySqlDataReader dr5 = cmd5.ExecuteReader();
            while (dr5.Read())
            {
                comboBox3.Items.Add(dr5["ID"] + "__" + dr5["NOM"] + "__" + dr5["PRENOM"]);

            }
            conn.Close();
            ///////////////////////////


        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (!comboBox1.Text.Equals("") && !comboBox2.Equals("") && !comboBox3.Equals("") && !comboBox5.Equals("") && !comboBox4.Equals(""))
            {
                string[] ct = comboBox1.Text.Split("__");
                int idc = int.Parse(ct[0]);
                string[] vt = comboBox2.Text.Split("__");
                int idv = int.Parse(vt[0]);
                string[] ass = comboBox3.Text.Split("__");
                int ida = int.Parse(ass[0]);
                string d = guna2DateTimePicker1.Text;
                string h = comboBox5.Text;
                string l = comboBox4.Text;
                string animal = comboBox6.Text;

                int r = 0;



                ////////////////////////////////

                string connstring1 = "server=localhost;uid=root;pwd=root;database=exam";
                MySqlConnection conn1 = new MySqlConnection();
                conn1.ConnectionString = connstring1;
                conn1.Open();
                string sql2 = "select * from rv where (idv=" + idv + " or ida=" + ida + ") and (date like'" + d + "' and heure like '" + h + "');";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn1);
                MySqlDataReader dr3 = cmd2.ExecuteReader();
                while (dr3.Read())
                {
                    r++;
                }
                conn1.Close();

                /////////////////////////

                if (r == 0)
                {
                    string connstring = "server=localhost;uid=root;pwd=root;database=exam";
                    MySqlConnection conn = new MySqlConnection();
                    conn.ConnectionString = connstring;
                    ///////////
                    if (l.Equals("Deplacement"))
                    {
                        conn.Open();
                        string sql3 = "select * from client where id=" + idc + ";";
                        MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
                        MySqlDataReader dr4 = cmd3.ExecuteReader();
                        while (dr4.Read())
                        {
                            l = dr4["adr"].ToString();
                        };

                        conn.Close();
                    }
                    /////////////////
                    conn.Open();
                    string sql1 = "INSERT INTO exam.rv(date,heure,lieu,animal,idc,idv,ida) VALUES('" + d + "','" + h + "','" + l + "','" + animal + "','" + idc + "','" + idv + "','" + ida + "');";
                    MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("rendez-vous a ete ajoute");
                    conn.Close();
                    comboBox1.SelectedIndex = -1;
                    comboBox2.SelectedIndex = -1;
                    comboBox3.SelectedIndex = -1;
                    comboBox4.SelectedIndex = -1;
                    comboBox5.SelectedIndex = -1;
                    comboBox6.SelectedIndex = -1;
                    actauliser();
                }
                else
                    MessageBox.Show("impossible !!!!!!!!!!!!!!!!! ");
            }
            else
                MessageBox.Show("ATTENTION vous douvez remplire toutes les champs");

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {


                int ll = e.RowIndex;
             
                object o0 = guna2DataGridView1.Rows[ll].Cells[0].Value;
                idd = int.Parse(o0.ToString());
                object o = guna2DataGridView1.Rows[ll].Cells[1].Value;
                comboBox1.Text = o.ToString();
               
                object o1 = guna2DataGridView1.Rows[ll].Cells[2].Value;
                comboBox2.Text = o1.ToString();
                object o2 = guna2DataGridView1.Rows[ll].Cells[3].Value;
                comboBox3.Text = o2.ToString();
                object o3 = guna2DataGridView1.Rows[ll].Cells[4].Value;
                guna2DateTimePicker1.Text = o3.ToString();
                object o5 = guna2DataGridView1.Rows[ll].Cells[5].Value;
                comboBox5.Text = o5.ToString();
                object o6 = guna2DataGridView1.Rows[ll].Cells[6].Value;
                if (o6.ToString().Equals("Cabinet"))
                {
                    comboBox4.Text = o6.ToString();
                }else
                    comboBox4.Text ="Deplacement";
                object o7 = guna2DataGridView1.Rows[ll].Cells[7].Value;
                comboBox6.Text = o7.ToString();
               
                pictureBox1.Visible = true;
                guna2GradientButton1.Enabled = false;





            }
            if (e.ColumnIndex == 9)
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
                    string sql4 = "delete from rv where id=" + i + "";
                    MySqlCommand cmd4 = new MySqlCommand(sql4, conn);

                    MySqlDataReader dr3 = cmd4.ExecuteReader();
                    conn.Close();
                    actauliser();

                }

            }
        }
        public void actauliser()
        {
            
            guna2DataGridView1.Rows.Clear();
            string connstring = "server=localhost;uid=root;pwd=root;database=exam";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            string sql3 = "select * from rv";
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);

            MySqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
          

                guna2DataGridView1.Rows.Add(dr3["ID"], recherchec((int)dr3["idc"]), recherche((int)dr3["idv"]), recherche((int)dr3["ida"]) , dr3["date"], dr3["heure"], dr3["lieu"], dr3["animal"]);
            }

            conn.Close();
        }
        public string recherche(int i)
        {
           
            string connstring = "server=localhost;uid=root;pwd=root;database=exam";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            string sql3 = "select * from employe where id="+ i + ";";
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
            string a=null;
            string b=null;
            string c = null;
            MySqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                a = dr3["id"].ToString()  ;
                b = dr3["nom"].ToString() ;
                c = dr3["prenom"].ToString();
                    
            }
           
            conn.Close();
            return a + "__" + b + "__" + c;

        }
        public string recherchec(int i)
        {

            string connstring = "server=localhost;uid=root;pwd=root;database=exam";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            string sql3 = "select * from client where id=" + i + ";";
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);

            MySqlDataReader dr3 = cmd3.ExecuteReader();
            string a = null;
            string b = null;
            string c = null;
            while (dr3.Read())
            {
                a = dr3["id"].ToString();
                b = dr3["nom"].ToString();
                c = dr3["prenom"].ToString();
            }
          
            conn.Close();
            return a + "__" + b + "__" + c;
          

        }

       

        private void label6_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text=="Cabinet")
            {
                comboBox5.Items.Clear();


                comboBox5.Items.Add("08:00");
                comboBox5.Items.Add("08:30");
                comboBox5.Items.Add("09:00");
                comboBox5.Items.Add("09:30");
                comboBox5.Items.Add("10:00");
                comboBox5.Items.Add("10:30");
                comboBox5.Items.Add("11:00");
                comboBox5.Items.Add("11:30");
                comboBox5.Items.Add("14:00");
                comboBox5.Items.Add("14:30");
                comboBox5.Items.Add("15:00");
                comboBox5.Items.Add("15:30");
                comboBox5.Items.Add("16:00");
                comboBox5.Items.Add("16:30");
                comboBox5.Items.Add("17:00");
                comboBox5.Items.Add("17:30");





            }
            else
            {
                comboBox5.Items.Clear();
                comboBox5.Items.Add("08:00");
                comboBox5.Items.Add("10:00");
                comboBox5.Items.Add("14:00");
                comboBox5.Items.Add("16:00");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!comboBox1.Text.Equals("") && !comboBox2.Equals("") && !comboBox3.Equals("") && !comboBox5.Equals("") && !comboBox4.Equals(""))
            {
                string[] ct = comboBox1.Text.Split("__");
                int idc = int.Parse(ct[0]);
                string[] vt = comboBox2.Text.Split("__");
                int idv = int.Parse(vt[0]);
                string[] ass = comboBox3.Text.Split("__");
                int ida = int.Parse(ass[0]);
                string l = comboBox4.Text;
                string d = guna2DateTimePicker1.Text;
                string h = comboBox5.Text;
                int r = 0;

                ////////////////////////////////

                string connstring1 = "server=localhost;uid=root;pwd=root;database=exam";
                MySqlConnection conn1 = new MySqlConnection();
                conn1.ConnectionString = connstring1;
                conn1.Open();
                MessageBox.Show(idd + "");
                string sql2 = "select * from rv where (idv=" + idv + " or ida=" + ida + ") and (date like'" + d + "' and heure like '" + h + "' and id !="+idd+" );";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn1);
                MySqlDataReader dr4 = cmd2.ExecuteReader();
                while (dr4.Read())
                {
                    r++;
                }
                conn1.Close();

                /////////////////////////

                if (r == 0)
                {
                    string connstring = "server=localhost;uid=root;pwd=root;database=exam";
                    MySqlConnection conn = new MySqlConnection();
                    conn.ConnectionString = connstring;
                    conn.Open();
                    string sql3 = "update  exam.rv SET date ='" + guna2DateTimePicker1.Text + "',heure='" + comboBox5.Text + "',lieu='" + comboBox4.Text + "',animal='" + comboBox6.Text + "',idc='" + idc + "',idv='" + idv + "',ida='" + ida + "' where id ='" + idd + "';";
                    MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
                    MySqlDataReader dr3 = cmd3.ExecuteReader();
                    conn.Close();
                    pictureBox1.Visible = false;
                    comboBox1.SelectedIndex = -1;
                    comboBox2.SelectedIndex = -1;
                    comboBox3.SelectedIndex = -1;
                    comboBox4.SelectedIndex = -1;
                    comboBox5.SelectedIndex = -1;
                    comboBox6.SelectedIndex = -1;
                    guna2GradientButton1.Enabled= true;
                    actauliser();
                }
                else
                    MessageBox.Show("impossible !!!!!!!!!!!!!!!!! ");
            }
            else
                MessageBox.Show("ATTENTION vous douvez remplire toutes les champs");


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
                var output = new FileStream("C:\\Users\\ORIGINAL SHOP\\Desktop\\rendez_vous.pdf", FileMode.Create);
                var writer = PdfWriter.GetInstance(doc, output);

                doc.Open();

                Paragraph paragraph = new Paragraph("rendez_vous N°");
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
