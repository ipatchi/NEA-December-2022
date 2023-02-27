using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA_December_2022
{
    public partial class PlayQA : Form
    {
        public PlayQA(int ID, int QID)
        {
            InitializeComponent();
            RealAnswerBox.Visible = false;
            button2.Visible = false;
            id = ID;
            Qid = QID;
        }

        public string answer = "";
        public int id;
        public int Qid;
        public int marks;

        public Form wherecamefrom;

        public void viewQA(string Question, string Answer, String QBG, String QFG,string ABGColour, string AFGColour, 
            string QFont, string AFont, string Marks, Form camefrom)
        {
            wherecamefrom = camefrom;
            NEAFonts s = new NEAFonts();
            OutputQ.Text = Question;
            OutputQ.BackColor = s.TranslateColour(QBG);
            OutputQ.ForeColor = s.TranslateColour(QFG);
            InputA.BackColor = s.TranslateColour(ABGColour);
            InputA.ForeColor = s.TranslateColour(AFGColour);
            RealAnswerBox.BackColor = s.TranslateColour(ABGColour);
            RealAnswerBox.ForeColor = s.TranslateColour(AFGColour);

            s.SetFont(QFont);
            OutputQ.Font = s.GetFontAsFont();

            s.SetFont(AFont);
            InputA.Font = s.GetFontAsFont();
            RealAnswerBox.Font = s.GetFontAsFont();

            answer = Answer;
            marks = Convert.ToInt32(Marks);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (InputA.Text.ToUpper().Trim() == answer.ToUpper().Trim())
            {
                MessageBox.Show("Congratulations!");

                //----------------------------------------------- Insert that it was correct   -------------------------------------
                List<string> IDs = new List<string>();

                string where = Directory.GetCurrentDirectory();
                where = where.Substring(0, where.Length - 24);
                SqliteConnection con = new SqliteConnection("Data Source = " + where + "/Revision.db;");
                //SqliteConnection con = new SqliteConnection("Data Source = Revision.db;");
                con.Open();
                string sql = "SELECT QuestionID FROM Completed WHERE QuestionID = '" + Qid + "' AND UserID = '" + id + "';";
                using var cmd = new SqliteCommand(sql, con);
                using SqliteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    IDs.Add(reader.GetString(0));
                }
                if (IDs.Count > 0)
                {
                    //Has already done question
                }

                con.Open();
                var command = con.CreateCommand();
                string sql2 = "INSERT into Completed (UserID, QuestionID, Score) VALUES ('" + id + "','" + Qid + "','" + marks + "');";
                command.CommandText = sql2;

                command.ExecuteNonQuery();

                con.Close();

                //-------------------------------------------------------------------------------------------------------------------



                Random random = new Random();
                wherecamefrom.Show();
                wherecamefrom.Text = Convert.ToString(marks) + Convert.ToString(marks) + Qid + random.Next();
            
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect");

                //----------------------------------------------- Insert that wasnt correct   -------------------------------------
                List<string> IDs = new List<string>();

                string where = Directory.GetCurrentDirectory();
                where = where.Substring(0, where.Length - 24);
                SqliteConnection con = new SqliteConnection("Data Source = " + where + "/Revision.db;");
                //SqliteConnection con = new SqliteConnection("Data Source = Revision.db;");
                con.Open();
                string sql = "SELECT QuestionID FROM Completed WHERE QuestionID = '" + Qid + "' AND UserID = '" + id + "';";
                using var cmd = new SqliteCommand(sql, con);
                using SqliteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    IDs.Add(reader.GetString(0));
                }
                if (IDs.Count > 0)
                {
                    //Has already done question
                }


                con.Open();
                var command = con.CreateCommand();
                string sql2 = "INSERT into Completed (UserID, QuestionID, Score) VALUES ('" + id + "','" + Qid + "','" + 0 + "');";
                command.CommandText = sql2;

                command.ExecuteNonQuery();

                con.Close();
                //-------------------------------------------------------------------------------------------------------------


                RealAnswerBox.Visible = true;
                button2.Visible = true;
                button1.Visible = false;
                RealAnswerBox.Text = answer;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            wherecamefrom.Show();
            wherecamefrom.Text = "0" + Convert.ToString(marks) + Qid + random.Next();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> IDs = new List<string>();
            string where = Directory.GetCurrentDirectory();
            where = where.Substring(0, where.Length - 24);
            SqliteConnection con = new SqliteConnection("Data Source = " + where + "/Revision.db;");
            //SqliteConnection con = new SqliteConnection("Data Source = Revision.db;");
            con.Open();
            string sql = "SELECT QuestionID FROM Completed WHERE QuestionID = '" + Qid + "' AND UserID = '" + id + "';";
            using var cmd = new SqliteCommand(sql, con);
            using SqliteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                IDs.Add(reader.GetString(0));
            }
            if (IDs.Count > 0)
            {
                //Has already done question
            }


            con.Open();
            var command = con.CreateCommand();
            string sql2 = "INSERT into Flagged (UserID, QuestionID) VALUES ('" + id + "','" + Qid + "');";
            command.CommandText = sql2;

            command.ExecuteNonQuery();
            MessageBox.Show("Question Successfully Flagged For You!");
            con.Close();

            //-------------------------------------------------------------------------------------------------------------
        }
    }
}
