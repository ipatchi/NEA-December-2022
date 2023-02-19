using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace NEA_December_2022
{
    public partial class PlayMultiC : Form
    {
        public int id;
        public int Qid;
        public PlayMultiC(int ID)
        {
            id = ID;
            InitializeComponent();
        }

        public int RealQ = 1;


        public void LoadQ(string Question, int Marks, string RealOp, string op2, string op3, string op4)
        {
            InputQ.Text = Question;
            List<int> used = new List<int>();
            string[] strings = {RealOp, op2, op3, op4};

            //------------------------------------   Find Question ID   ----------------------------------------------
            List<string> IDs = new List<string>();

            string where = Directory.GetCurrentDirectory();
            where = where.Substring(0, where.Length - 24);
            SqliteConnection con = new SqliteConnection("Data Source = " + where + "/Revision.db;");
            //SqliteConnection con = new SqliteConnection("Data Source = Revision.db;");
            con.Open();
            string sql = "SELECT ID FROM Questions WHERE Question = '" + Question + "';";
            using var cmd = new SqliteCommand(sql, con);
            using SqliteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                IDs.Add(reader.GetString(0));
            }
            if (IDs.Count > 0)
            {
                Qid = Convert.ToInt32(IDs[0]);
            }


            //-------------------------------------------------------------------------------------------------------

            Random rnd = new Random();
            bool not_done = true;
            
            Dictionary<int, string> AllQuestions = new Dictionary<int, string>();
            while (not_done)
            {
                int num = rnd.Next(1, 5);
                //MessageBox.Show(Convert.ToString(used.Count()));
                if (!used.Contains(num))
                {
                    AllQuestions.Add(num, strings[used.Count]);
                    used.Add(num);
                    if (used.Count == 1)
                    {
                        RealQ = num;
                    }
                }
                if (used.Count == 4)
                {
                    not_done = false;
                }
            }
            Opt1.Text = AllQuestions[1];
            Opt2.Text = AllQuestions[2];
            Opt3.Text = AllQuestions[3];
            Opt4.Text = AllQuestions[4];
        }


        public void CheckAns(int C)
        {
            if (C == RealQ)
            {
                MessageBox.Show("Correct!");
                var f = new Explore(id);
                f.Show();
                this.Hide();
                f.BackColor = this.BackColor;


                List<string> IDs = new List<string>();

                string where = Directory.GetCurrentDirectory();
                where = where.Substring(0, where.Length - 24);
                SqliteConnection con = new SqliteConnection("Data Source = " + where + "/Revision.db;");
                //SqliteConnection con = new SqliteConnection("Data Source = Revision.db;");
                con.Open();
                string sql = "SELECT QuestionID FROM Completed WHERE QuestionID = '" + Qid + "' AND UserID = '"+ id +"';";
                using var cmd = new SqliteCommand(sql, con);
                using SqliteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    IDs.Add(reader.GetString(0));
                }
                if (IDs.Count > 0)
                {
                    MessageBox.Show("You have already done this question");
                }
                else
                {
                    
                    con.Open();
                    var command = con.CreateCommand();
                    string sql2 = "INSERT into Completed (UserID, QuestionID, Score) VALUES ('" + id + "','" + Qid + "','" + 1 + "');";
                    command.CommandText = sql2;
                    MessageBox.Show(sql2);
                    command.ExecuteNonQuery();

                    con.Close();
                    MessageBox.Show("Score Registered Successfully");

                    var Form = new Form1();
                    this.Hide();
                    Form.Show();
                    Form.BackColor = this.BackColor;
                }


            }
            else
            {
                MessageBox.Show("The correct answer was option" + RealQ, "Incorrect");
                var f = new Explore(id);
                f.Show();
                this.Hide();
                f.BackColor = this.BackColor;
            }
        }

        private void Opt2_Click(object sender, EventArgs e)
        {
            CheckAns(2);
        }

        private void Opt3_Click(object sender, EventArgs e)
        {
            CheckAns(3);
        }

        private void Opt4_Click(object sender, EventArgs e)
        {
            CheckAns(4);
        }

        private void Opt1_Click(object sender, EventArgs e)
        {
            CheckAns(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new Explore(id);
            f.Show();
            this.Hide();
            f.BackColor = this.BackColor;
        }
    }
}
