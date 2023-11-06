using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Guna.UI2.WinForms;
using OxyPlot.Axes;
using ZedGraph;

namespace EXAME
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            timer3.Start();
            fon1();
            fon2();


           
            ///

           
        }

        private void fon1()
        {
            //////////////////
           var liste = new List<dynamic>();
            string connstring = "server=localhost;uid=root;pwd=root;database=exam";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            string sql3 = "select role,count(*) from utilisateur where role != 'client' group by role ";
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);

            MySqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                liste.Add(new { Role = dr3.GetString(0), Count = dr3.GetInt32(1) });

            }
            conn.Close();
            /////////////////
            var plotModel = new PlotModel { Title = "Employes" };
            var series = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };
          
            foreach (var g in liste)
            {
                series.Slices.Add(new PieSlice(g.Role, g.Count) { IsExploded = false });
            }
            plotModel.Series.Add(series);
            this.plotView1.Model = plotModel;
            /////////////////////
        }
        private void fon2()
        {
            //////////////////
            var liste = new List<dynamic>();
            string connstring = "server=localhost;uid=root;pwd=root;database=exam";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            string sql3 = "select animal,count(*) from rv group by animal ";
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);

            MySqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                liste.Add(new { Role = dr3.GetString(0), Count = dr3.GetInt32(1) });

            }
            conn.Close();
            /////////////////
            var plotModel = new PlotModel { Title = "animaux" };
            var series = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };

            foreach (var g in liste)
            {
                series.Slices.Add(new PieSlice(g.Role, g.Count) { IsExploded = false });
            }
            plotModel.Series.Add(series);
            this.plotView2.Model = plotModel;
            /////////////////////
        }


        private void plotView1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        int a = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
           int x = 0;
            string connstring = "server=localhost;uid=root;pwd=root;database=exam";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            string sql3 = "select * from client";
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);

            MySqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                x++;

            }
          

            conn.Close();
            a = a + 1;
            guna2CircleProgressBar1.Value = a;
            label2.Text = a+" clients" ;
            if (guna2CircleProgressBar1.Value == x)
            {
                guna2CircleProgressBar1.Value = x;
                timer1.Stop();
               

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        int a1 = 0;
        private void timer2_Tick(object sender, EventArgs e)
        { 
            int x = 0;
            int v = 0;
            string connstring = "server=localhost;uid=root;pwd=root;database=exam";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            string sql3 = "select sum(total) from facture";
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);

            MySqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                x=x+dr3.GetInt32(0);

            }
            if (x != 0)
            {
              v= x / 10;
            }
           
           
            conn.Close();
            a1 = a1 + v;
            guna2CircleProgressBar2.Value = a1;
            label4.Text = a1 + " DH";
            if (guna2CircleProgressBar2.Value == x)
            {
                guna2CircleProgressBar2.Value = x;
                timer2.Stop();
              

            }

        }
        int a2 = 0;

        private void timer3_Tick(object sender, EventArgs e)
        {
            int x = 0;
            string connstring = "server=localhost;uid=root;pwd=root;database=exam";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            string sql3 = "select * from utilisateur where role != 'client'";
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);

            MySqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                x++;

            }
           

            conn.Close();
            a2 = a2 + 1;
            guna2CircleProgressBar3.Value = a2;
            label6.Text = a2 + " employes";
            if (guna2CircleProgressBar3.Value == x)
            {
                guna2CircleProgressBar3.Value = x;
                timer3.Stop();
             

            }

        }

        private void plotView2_Click(object sender, EventArgs e)
        {

        }
    }
}
