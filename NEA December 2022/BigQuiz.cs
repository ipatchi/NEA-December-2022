using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic.ApplicationServices;
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

    public record QuestionRec(int ID, int Average, int UserAvg, bool Flagged, string Subtopic);

    public partial class BigQuiz : Form
    {
        public int userid = 0;
        public string DIFF;
        public BigQuiz(int ID, string difficulty)
        {
            userid = ID;
            DIFF = difficulty;
            InitializeComponent();

        }

        public int[] playlist = new int[5];
        public int[] Scores = new int[5];
        public int i = 0;


        public void nextQ()
        {
       
            string where = Directory.GetCurrentDirectory();
            where = where.Substring(0, where.Length - 24);
            SqliteConnection con = new SqliteConnection("Data Source = " + where + "/Revision.db;");
            con.Open();

            string sql0 = "SELECT type FROM Questions WHERE ID = '" + playlist[i] + " ';";
            using var cmd0 = new SqliteCommand(sql0, con);
            using SqliteDataReader reader0 = cmd0.ExecuteReader();
            reader0.Read();
            int type = Convert.ToInt16(reader0.GetValue(0));

            if (type == 1)
            {
                string sql = "SELECT Question,Answer,QuestionBG,QuestionFG,AnswerBG,AnswerFG,QFont,AFont,Marks FROM flashcards WHERE ID = '" + playlist[i] + " ';";
                using var cmd = new SqliteCommand(sql, con);
                using SqliteDataReader reader = cmd.ExecuteReader();
                string Question = "";
                string Answer = "";
                string BGColour = "";
                string FGColour = "";
                string ABGColour = "";
                string AFGColour = "";
                string QFont = "";
                string AFont = "";
                string Marks = "";

                while (reader.Read())
                {
                    Question = reader.GetString(0);
                    Answer = reader.GetString(1);
                    BGColour = reader.GetString(2);
                    FGColour = reader.GetString(3);
                    ABGColour = reader.GetString(4);
                    AFGColour = reader.GetString(5);
                    QFont = reader.GetString(6);
                    AFont = reader.GetString(7);
                    Marks = reader.GetString(8);
                }
                var form = new PlayQA(userid, playlist[i]);

                form.TopLevel = false;
                LoadFormPanel.Controls.Add(form);
                form.FormBorderStyle = FormBorderStyle.None;

                form.Show();
                form.BackColor = this.BackColor;
                form.viewQA(Question, Answer, BGColour, FGColour, ABGColour, AFGColour, QFont, AFont, Marks, this);

            }
            else if (type == 2)
            {
                string sql = "SELECT Question, Marks, RealOpt, Opt2, Opt3, Opt4 FROM MultiChoices WHERE ID = '" + playlist[i] + " ';";
                using var cmd = new SqliteCommand(sql, con);
                using SqliteDataReader reader = cmd.ExecuteReader();
                string Question = "";
                string RealOpt = "";
                string Opt2 = "";
                string Opt3 = "";
                string Opt4 = "";
                int Marks = 0;

                while (reader.Read())
                {
                    Question = reader.GetString(0);
                    RealOpt = reader.GetString(2);
                    Opt2 = reader.GetString(3);
                    Opt3 = reader.GetString(4);
                    Opt4 = reader.GetString(5);
                    Marks = Convert.ToInt32(reader.GetValue(1));
                }
                var form = new PlayMultiC(userid, playlist[i]);
                form.TopLevel = false;
                LoadFormPanel.Controls.Add(form);
                form.FormBorderStyle = FormBorderStyle.None;

                form.Show();
                form.BackColor = this.BackColor;
                form.LoadQ(Question, Marks, RealOpt, Opt2, Opt3, Opt4, this);
                
            }
            
        }
        public void registerScore(int score)
        {
            Scores[i - 1] = score;
            start_next_q();
        }

        public void start_next_q()
        {
            NEASortSearch S = new NEASortSearch();
            label1.Text = S.PrintArray(Scores);
            if (i < playlist.Length)
            {
                nextQ();
                i = i + 1;
                progressBar1.Value = progressBar1.Value + (100 / playlist.Length);
            }
            else
            {
                MessageBox.Show("Quiz Completed");
                var f = new MainMenu(userid);
                f.Show();
                f.BackColor = this.BackColor;
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();

            

            //Get all average scores for each question
        
          

            string where = Directory.GetCurrentDirectory();
            where = where.Substring(0, where.Length - 24);
            SqliteConnection con = new SqliteConnection("Data Source = " + where + "/Revision.db;");

            con.Open();

            string sql = "SELECT ID,Subtopic FROM Questions;";
            using var cmd = new SqliteCommand(sql, con);
            using SqliteDataReader reader = cmd.ExecuteReader();

            List<int> IDs = new List<int>();
            List<double> OverallAverages = new List<double>();
            List<double> OverallVariances = new List<double>();
            List<double> UserAverages = new List<double>();

            while (reader.Read())
            {
                IDs.Add(reader.GetInt32(0));
            }

            foreach (int TID in IDs) //---------------------------- Get Question Overall Averages ----------------------
            {
                string sql2 = "SELECT Score FROM Completed WHERE QuestionID = '"+TID+"';";
                using var cmd2 = new SqliteCommand(sql2, con);
                using SqliteDataReader reader2 = cmd2.ExecuteReader();
                List<double> EveryScore = new List<double>();
                while (reader2.Read())
                {
                    EveryScore.Add(Convert.ToInt32(reader2.GetString(0)));
                }
                if (EveryScore.Count > 0)
                {
                    NEASortSearch s = new NEASortSearch();
                    NEAQStats sTa = new NEAQStats();
                    OverallAverages.Add(s.doubleaverage(EveryScore.ToArray()));
                    OverallVariances.Add(sTa.Variance(EveryScore.ToArray()));
                }
                else
                {
                    OverallAverages.Add(0);
                    OverallAverages.Add(0);
                }
            }

            foreach (int TID in IDs) //-------------------- Get User Averages --------------------------------
            {
                string sql3 = "SELECT Score FROM Completed WHERE QuestionID = '" + TID + "' AND UserID = '"+userid+"';";
                using var cmd3 = new SqliteCommand(sql3, con);
                using SqliteDataReader reader3 = cmd3.ExecuteReader();
                List<double> EveryScore = new List<double>();
                while (reader3.Read())
                {
                    EveryScore.Add(Convert.ToInt32(reader3.GetString(0)));
                }
                if (EveryScore.Count > 0)
                {
                    NEASortSearch s = new NEASortSearch();
                    UserAverages.Add(s.doubleaverage(EveryScore.ToArray()));
                }
                else
                {
                    UserAverages.Add(0);
                }
            }

            List<double> Difficulties = new List<double>();

            NEAQStats stat = new NEAQStats();

            for (int i = 0; i < IDs.Count; i++)
            {
                string s = "Averages:" + OverallAverages[i] + " Variances:" + OverallVariances[i] + " Useravgs: " + UserAverages[i] + " Hence Difficulty: " + stat.Difficulty(OverallAverages[i] + 0.1, OverallVariances[i], UserAverages[i], false);
                //MessageBox.Show(s);
                Difficulties.Add(stat.Difficulty(OverallAverages[i] + 0.1, OverallVariances[i], UserAverages[i], false));
            }

            var QuestionTree = new BinaryTree<int>();
            Random r = new Random();
            int x = r.Next(0,IDs.Count);
            NEASortSearch snew = new NEASortSearch();
            //MessageBox.Show(snew.PrintDubArray(Difficulties.ToArray()));
            QuestionTree.Add(IDs[x], Convert.ToInt32(Difficulties[x])); 

            
            for (int i = 0; i < IDs.Count; i++)
            {
                if (i != x)
                {
                    QuestionTree.Add(IDs[i], Convert.ToInt32(Difficulties[i]));
                }
            }
            
            List<int> ReadFromTree = new List<int>();
            QuestionTree.TraverseInOrder(ReadFromTree.Add);
            if (DIFF == "Easy")
            {
                playlist[0] = ReadFromTree[0];
                playlist[1] = ReadFromTree[1];
                playlist[2] = ReadFromTree[2];
                playlist[3] = ReadFromTree[3];
                playlist[4] = ReadFromTree[4];
            }
            if (DIFF == "Challenge")
            {
                int n = ReadFromTree.Count();
                playlist[0] = ReadFromTree[n - 1];
                playlist[1] = ReadFromTree[n - 2];
                playlist[2] = ReadFromTree[n - 3];
                playlist[3] = ReadFromTree[n - 4];
                playlist[4] = ReadFromTree[n - 5];
            }
            if (DIFF == "Revision")
            {
                ReadFromTree.RemoveAll(x => x > 0);
                QuestionTree.TraversePostOrder(ReadFromTree.Add);
                int n = ReadFromTree.Count();
                playlist[0] = ReadFromTree[n - 1];
                playlist[1] = ReadFromTree[n - 2];
                playlist[2] = ReadFromTree[n - 3];
                playlist[3] = ReadFromTree[n - 4];
                playlist[4] = ReadFromTree[n - 5];
            }

            //int i = 0;

            start_next_q();
            
            
            
      
            
        }
       



        private void BigQuiz_TextChanged(object sender, EventArgs e)
        {
            if (!(this.Text == "NEA Big Quiz"))
            {
                registerScore(Convert.ToInt32(this.Text[0]) - 48);
                this.Text = "NEA Big Quiz";
            }
        
        }
    }
}
