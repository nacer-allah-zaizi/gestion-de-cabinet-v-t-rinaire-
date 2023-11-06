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
using ZedGraph;

namespace EXAME
{
    public partial class Form10 : Form
    {
        Form3 form3;
        public Form10(Form3 f3)
        {
            InitializeComponent();
            this.form3 = f3;
           
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            actauliser();
            actauliser1();
        }

        public void actauliser()
        {

            guna2DataGridView1.Rows.Clear();
            string connstring = "server=localhost;uid=root;pwd=root;database=exam";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            string sql3 = "select * from rv where idc="+form3.id+";";
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);

            MySqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {


                guna2DataGridView1.Rows.Add(dr3["ID"], dr3["idv"], dr3["ida"], dr3["date"], dr3["heure"], dr3["lieu"], dr3["animal"], dr3["regl"]) ;
            }

            conn.Close();
        }
        public void actauliser1()
        {

            guna2DataGridView2.Rows.Clear();
            string connstring = "server=localhost;uid=root;pwd=root;database=exam";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            string sql3 = "select * from facture where idc="+ form3.id + ";";
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);

            MySqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                guna2DataGridView2.Rows.Add(dr3["ID"], dr3["date"], dr3["lieu"], dr3["total"]);


            }

            conn.Close();
        }
    }
}
