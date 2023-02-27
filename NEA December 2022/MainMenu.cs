using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace NEA_December_2022
{
    public partial class MainMenu : Form
    {
        public MainMenu(int ID2)
        {
            InitializeComponent();
            ID = ID2;

            GetFact();
            CheckLogin();
            
        }

        public void CheckLogin()
        {
            string where = Directory.GetCurrentDirectory();
            where = where.Substring(0, where.Length - 24);
            SqliteConnection con = new SqliteConnection("Data Source = " + where + "/Revision.db;");
            //SqliteConnection con = new SqliteConnection("Data Source = Revision.db;");

            con.Open();
            string sql = "SELECT LastLogin FROM users WHERE ID = '" + ID + "';";
            using var cmd = new SqliteCommand(sql, con);
            using SqliteDataReader reader = cmd.ExecuteReader();
            List<string> Times = new List<string>();
            while (reader.Read())
            {
                try
                {
                    Times.Add(reader.GetString(0));
                }
                catch
                {
                    //
                }
                
            }
            if (Times.Count > 0)
            {
                var dt = DateTime.Now;
                var dt2 = DateTime.Parse(Times[0]);

                var T = dt.Subtract(dt2);
                label2.Text = "You haven't revised in " + T.TotalSeconds + " Seconds!";

                var command = con.CreateCommand();
                

                string sql2 = "UPDATE Users SET LastLogin = '" + Convert.ToString(dt) + "'WHERE ID = '" + ID + "';";
                command.CommandText = sql2;
                command.ExecuteNonQuery();

                con.Close();
            }
            else
            {
                var command = con.CreateCommand();
                var dt = DateTime.Now;

                string sql2 = "UPDATE Users SET LastLogin = '"+ Convert.ToString(dt) +"'WHERE ID = '"+ID+"';";
                command.CommandText = sql2;
                command.ExecuteNonQuery();

                con.Close();
            }
        }


        public async void GetFact()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://numbersapi.com/random");
            var fact = await response.Content.ReadAsStringAsync();
            label1.Text = fact;
        }

        public int ID;
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            
            var form = new Settings(ID);
            form.Show();
            this.Hide();
            form.BackColor = this.BackColor;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new Create(ID);
            form.Show();
            this.Hide();
            form.BackColor = this.BackColor;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new Explore(ID);
            form.Show();
            this.Hide();
            form.BackColor = this.BackColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new QuizStartScreen(ID);
            form.Show();
            this.Hide();
            form.BackColor = this.BackColor;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            GetFact();
        }
    }
}
