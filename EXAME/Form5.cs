using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace EXAME
{
    public partial class Form5 : Form
    {
        public int idd;
        public string ee;
        public string p;    
        public Form5()
        {
            InitializeComponent();
            
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            actauliser();
            
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            int i = 0;
            string nom = textBox1.Text;
            string prenom = textBox2.Text;
            string tel = textBox3.Text;
            string email = textBox4.Text;
            string password = textBox5.Text;
            string address = textBox6.Text;
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            string pattern1 = @"^\d{8}$";
            string pattern2 = @"^[a-zA-Z]+( [a-zA-Z]+)*$";
            bool isValid = Regex.IsMatch(email, pattern);
            bool isValid1 = Regex.IsMatch(tel, pattern1);
            bool isValid2 = Regex.IsMatch(nom, pattern2);
            bool isValid3 = Regex.IsMatch(prenom, pattern2);
            if (!nom.Equals("") && !prenom.Equals("") && !tel.Equals("") && !email.Equals("") && !password.Equals("") && !address.Equals(""))
            {
                
                if (isValid && isValid1 && isValid2 && isValid3)
                {
                    string connstring = "server=localhost;uid=root;pwd=root;database=exam";
                    MySqlConnection conn = new MySqlConnection();
                    conn.ConnectionString = connstring;
                    conn.Open();
                    string sql = "select * from client";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (((string)dr["email"]) == email)
                        {
                            i++;
                        }
                    }
                    conn.Close();
                    if (i == 0)
                    {
                        conn.Open();
                        string sql1 = "INSERT INTO exam.client(nom,prenom,tel,email,pw,adr) VALUES('" + nom + "','" + prenom + "','" + tel + "','" + email + "','" + password + "','" + address + "');";
                        MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("client a ete ajoute");
                        conn.Close();
                        /////////////////
                        conn.Open();
                        string sql5 = "INSERT INTO exam.utilisateur(email,pw,role) VALUES('" + email + "','" + password + "','client');";
                        MySqlCommand cmd5 = new MySqlCommand(sql5, conn);
                        cmd5.ExecuteNonQuery();
                        conn.Close();
                        ///////////////////

                        
                        MailMessage mail = new MailMessage("Veterinaire18@gmail.com", email, "Code de connexion", "WELCOME TO OUR APPLICATION HERE IS YOUR CODE : " + password);
                        SmtpClient client = new SmtpClient("smtp.gmail.com");
                        client.Port = 587;
                        client.Credentials = new System.Net.NetworkCredential("Veterinaire18@gmail.com", "zzslynbrdezwhzju");
                        client.EnableSsl = true;

                        client.Send(mail);
                        MessageBox.Show("email envoye");
                        ///////////////////////
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        actauliser();
                    }
                    else
                        MessageBox.Show("erreur email deja existe");
                }
                else
                    MessageBox.Show(" erreur:email ,tel ou nom et prenom  sont  errones!!!!!!!!!!");
            }
            else
                MessageBox.Show("ATTENTION vous douvez remplire toutes les champs");




        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {


                int ll = e.RowIndex;

                object o0 = guna2DataGridView1.Rows[ll].Cells[0].Value;
                idd = int.Parse(o0.ToString());
                object o = guna2DataGridView1.Rows[ll].Cells[1].Value;
                textBox1.Text = o.ToString();
                object o1 = guna2DataGridView1.Rows[ll].Cells[2].Value;
                textBox2.Text = o1.ToString();
                object o2 = guna2DataGridView1.Rows[ll].Cells[3].Value;
                textBox3.Text = o2.ToString();
                object o3 = guna2DataGridView1.Rows[ll].Cells[4].Value;
                textBox4.Text = o3.ToString();
                ee= o3.ToString();
                object o4 = guna2DataGridView1.Rows[ll].Cells[5].Value;
                textBox5.Text = o4.ToString();
                p= o4.ToString();
                object o5 = guna2DataGridView1.Rows[ll].Cells[6].Value;
                textBox6.Text = o5.ToString();

                pictureBox1.Visible = true;
                guna2GradientButton1.Enabled = false;





            }
            if (e.ColumnIndex == 8)
            {
                if (MessageBox.Show("etes vous sur de cette suppression ?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    int ll = e.RowIndex;
                    object o3 = guna2DataGridView1.Rows[ll].Cells[4].Value;

                    ee = o3.ToString();
                    object o4 = guna2DataGridView1.Rows[ll].Cells[5].Value;

                    p = o4.ToString();
                    string connstring = "server=localhost;uid=root;pwd=root;database=exam";
                    MySqlConnection conn = new MySqlConnection();
                    conn.ConnectionString = connstring;
                    conn.Open();
                    int c = 0;
                    int l = e.RowIndex;
                    object o = guna2DataGridView1.Rows[l].Cells[c].Value;
                    int i = int.Parse(o.ToString());
                    string sql4 = "delete from client where id=" + i + "";
                    MySqlCommand cmd4 = new MySqlCommand(sql4, conn);
                    // MySqlDataAdapter adp= new MySqlDataAdapter(cmd3);
                    MySqlDataReader dr3 = cmd4.ExecuteReader();
                    conn.Close();
                    ///////////////////////////

                    conn.Open();
                    string sql5 = "delete from exam.utilisateur  where email ='" + ee + "' and pw='" + p + "';";
                    MySqlCommand cmd5 = new MySqlCommand(sql5, conn);
                    MySqlDataReader dr5 = cmd5.ExecuteReader();
                    conn.Close();
                    actauliser();
                    ///////////////////////

                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string nom = textBox1.Text;
            string prenom = textBox2.Text;
            string tel = textBox3.Text;
            string email = textBox4.Text;
            string password = textBox5.Text;
            string address = textBox6.Text;
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            string pattern1 = @"^\d{8}$";
            string pattern2 = @"^[a-zA-Z]+( [a-zA-Z]+)*$";
            bool isValid = true;
            bool isValid1 = true;
            bool isValid2 = true;
            bool isValid3 = true;
            isValid = Regex.IsMatch(email, pattern);
           isValid1 = Regex.IsMatch(tel, pattern1);
           isValid2 = Regex.IsMatch(nom, pattern2);
             isValid3 = Regex.IsMatch(prenom, pattern2);
    
            if (!nom.Equals("") && !prenom.Equals("") && !tel.Equals("") && !email.Equals("") && !password.Equals("") && !address.Equals(""))
            {
               
               
                if (isValid && isValid1 && isValid2 && isValid3)
                {
                    string connstring = "server=localhost;uid=root;pwd=root;database=exam";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            string sql3 = "update  exam.client SET nom ='" + textBox1.Text + "',prenom='" + textBox2.Text + "',tel='" + textBox3.Text + "',email='" + textBox4.Text + "',pw='" + textBox5.Text + "',adr='" + textBox6.Text + "' where id ='" + idd + "';";
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
            MySqlDataReader dr3 = cmd3.ExecuteReader();
            conn.Close();
            ///////////////////////////

            conn.Open();
            string sql4 = "update  exam.utilisateur SET email ='" + textBox4.Text + "',pw='" + textBox5.Text + "',role='client' where email ='" + ee + "' and pw='" + p + "';";
            MySqlCommand cmd4 = new MySqlCommand(sql4, conn);
            MySqlDataReader dr4 = cmd4.ExecuteReader();
            conn.Close();
            ///////////////////////
            
            MailMessage mail = new MailMessage("Veterinaire18@gmail.com", textBox4.Text, "Code de connexion", "WELCOME TO OUR APPLICATION WE ARE SO SORRY TO DISTURBE YOU BUT YOUR CODE HAS CHANGED SO HERE IS YOUR NEW  CODE : " + textBox5.Text);
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("Veterinaire18@gmail.com", "zzslynbrdezwhzju");
            client.EnableSsl = true;

            client.Send(mail);
            MessageBox.Show("email envoye");
                    /////////////////////////////////
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            pictureBox1.Visible = false;
         guna2GradientButton1.Enabled = true;
                    actauliser();
                } else
             MessageBox.Show(" erreur:email ,tel ou nom et prenom  sont  errones!");
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
            string sql3 = "select * from client";
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);

            MySqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                guna2DataGridView1.Rows.Add(dr3["ID"], dr3["NOM"], dr3["PRENOM"], dr3["TEL"], dr3["EMAIL"], dr3["PW"], dr3["adr"]);
            }

            conn.Close();
        }

       

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            byte[] randomBytes = new byte[4];
            new RNGCryptoServiceProvider().GetBytes(randomBytes);
            int randomNumber = BitConverter.ToInt32(randomBytes, 0);

            // Génère un mot de passe aléatoire de 8 caractères
            string password = "";
            for (int i = 0; i < 6; i++)
            {
                // Ajoute un caractère aléatoire au mot de passe
                char c = (char)random.Next(33, 125);
                password += c;
            }
            textBox5.Text = password;
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
                var output = new FileStream("C:\\Users\\ORIGINAL SHOP\\Desktop\\clients.pdf", FileMode.Create);
                var writer = PdfWriter.GetInstance(doc, output);

                doc.Open();

                Paragraph paragraph = new Paragraph("client N°");
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
