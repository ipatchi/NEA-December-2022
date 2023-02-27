using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA_December_2022
{
    public partial class CreateTest : Form
    {
        public int userid;
        public CreateTest(int id)
        {
            userid = id;
            InitializeComponent();

            string where = Directory.GetCurrentDirectory();
            where = where.Substring(0, where.Length - 24);
            SqliteConnection con = new SqliteConnection("Data Source = " + where + "/Revision.db;");

            //---------------------------------------------------------------

            con.Open();
            string sql = "SELECT Question FROM QUESTIONS;";
            using var cmd = new SqliteCommand(sql, con);
            using SqliteDataReader reader = cmd.ExecuteReader();
            List<string> subtopics = new List<string>();
            while (reader.Read())
            {
                string s = reader.GetString(0);
                if (!(subtopics.Contains(s)))
                {
                    subtopics.Add(s);
                }

            }
            comboBox1.DataSource = subtopics.ToArray();
            comboBox2.DataSource = subtopics.ToArray();
            comboBox3.DataSource = subtopics.ToArray();
            comboBox4.DataSource = subtopics.ToArray();
            comboBox5.DataSource = subtopics.ToArray();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f = new MainMenu(userid);
            f.Show();
            f.BackColor = this.BackColor;
            this.Close();
        }

        public int GetID(string q)
        {
            string where = Directory.GetCurrentDirectory();
            where = where.Substring(0, where.Length - 24);
            SqliteConnection con = new SqliteConnection("Data Source = " + where + "/Revision.db;");

            //---------------------------------------------------------------

            con.Open();
            string sql = "SELECT ID FROM QUESTIONS WHERE Question = '"+ q +"';";
            using var cmd = new SqliteCommand(sql, con);
            using SqliteDataReader reader = cmd.ExecuteReader();
            int s = 0;
            while (reader.Read())
            {
                s = reader.GetInt32(0);
            }
            return s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NEAQueue n = new NEAQueue();
            NEASortSearch s = new NEASortSearch();
            n.Enqueue(GetID(comboBox1.Text));
            n.Enqueue(GetID(comboBox2.Text));
            n.Enqueue(GetID(comboBox3.Text));
            n.Enqueue(GetID(comboBox4.Text));
            n.Enqueue(GetID(comboBox5.Text));
            int[] ar = n.GetQueue();
            bool canrun = true;
            List<int> br = new List<int>();
            foreach (int i in ar)
            {
                if (!br.Contains(i)){
                    br.Add(i);
                }
                else
                {
                    canrun = false;
                }
            }
            if (canrun)
            {
               
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Text File|*.txt";
                saveFileDialog1.Title = "Save an Image File";
         
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog1.FileName;
                    string extesion = Path.GetExtension(fileName);
                    switch (extesion)
                    {
                        case ".txt":
                            using (StreamWriter writer = new StreamWriter(fileName))
                            {
                                foreach (int i in ar)
                                {
                                    writer.WriteLine(i);
                                }
            
                            }
                            break;
                        
                        default:
                            break;
                    }
                }

            }
            else
            {
                MessageBox.Show("Please select 5 UNIQUE Questions");
            }
            
        }
    }
}
