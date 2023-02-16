using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace NEA_December_2022
{
    public partial class Explore : Form
    {
        public int id;
        public Explore(int ID)
        {
            InitializeComponent();
            id = ID;


            List<string> Questions = new List<string>();
            List<int> IDs = new List<int>();
            List<int> CIDs = new List<int>();

            string where = Directory.GetCurrentDirectory();
            where = where.Substring(0, where.Length - 24);
            SqliteConnection con = new SqliteConnection("Data Source = " + where + "/Revision.db;");

            con.Open();

            string sql = "SELECT Question,ID,CreatorID FROM Questions;";
            using var cmd = new SqliteCommand(sql, con);
            using SqliteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Questions.Add(reader.GetString(0));
                IDs.Add(reader.GetInt32(1));
                CIDs.Add(reader.GetInt32(2));
            }


            ShowQuestions(Questions, IDs, CIDs);


        }

        public void SearchID(String[] Questions1, int[] IDs1, int[] CreatorIDs1)
        {
            NEASortSearch s = new NEASortSearch();
            string[] Questions = Questions1.ToArray();
            int[] IDs = IDs1.ToArray();
            int[] CreatorIDs = CreatorIDs1.ToArray();

            int searchfor = Convert.ToInt32(numericUpDown1.Value);
            s.SetArray(IDs);
            s.RunMerge();
            int value = s.SearchArray(searchfor, s.GetArray());
            if (value == -1)
            {
                MessageBox.Show("Question ID Does Not Exist");
            }
            else
            {
                MessageBox.Show("Question ID Exists At Index: " + value);
                OpenQ(IDs[value]);



            }

        }

        public string[] Questions;
        public int[] IDs;
        public int[] CIDs;




        public void ShowQuestions(List<string> Questions1, List<int> IDs1, List<int> CreatorIDs1)
        {

            Questions = Questions1.ToArray();
            IDs = IDs1.ToArray();
            CIDs = CreatorIDs1.ToArray();

            DataTable table = new DataTable();
            DataColumn dtcolumn;
            DataRow mydatarow;

            dtcolumn = new DataColumn();
            dtcolumn.ColumnName = "Question";
            table.Columns.Add(dtcolumn);

            dtcolumn = new DataColumn();
            dtcolumn.ColumnName = "ID";
            table.Columns.Add(dtcolumn);

            dtcolumn = new DataColumn();
            dtcolumn.ColumnName = "Creator ID";
            table.Columns.Add(dtcolumn);


            for (int i = 0; i < Questions.Length; i++)
            {
                mydatarow = table.NewRow();
                mydatarow["Question"] = Questions[i];
                mydatarow["ID"] = IDs[i];
                mydatarow["Creator ID"] = CIDs[i];
                table.Rows.Add(mydatarow);
            }
            dataGridView1.BackgroundColor = this.BackColor;
            dataGridView1.DataSource = table;
        }

        public void OpenQ(int QID)
        {
            int ID = QID;
            string where = Directory.GetCurrentDirectory();
            where = where.Substring(0, where.Length - 24);
            SqliteConnection con = new SqliteConnection("Data Source = " + where + "/Revision.db;");

            con.Open();

            string sql0 = "SELECT type FROM Questions WHERE ID = '" + ID + " ';";
            using var cmd0 = new SqliteCommand(sql0, con);
            using SqliteDataReader reader0 = cmd0.ExecuteReader();
            reader0.Read();
            int type = Convert.ToInt16(reader0.GetValue(0));

            if (type == 1)
            {
                string sql = "SELECT Question,Answer,QuestionBG,QuestionFG,AnswerBG,AnswerFG,QFont,AFont,Marks FROM flashcards WHERE ID = '" + ID + " ';";
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
                var form = new PlayQA(ID);
                form.Show();
                form.BackColor = this.BackColor;
                form.viewQA(Question, Answer, BGColour, FGColour, ABGColour, AFGColour, QFont, AFont, Marks);
                this.Close();
            }
            else if (type == 2)
            {
                string sql = "SELECT Question, Marks, RealOpt, Opt2, Opt3, Opt4 FROM MultiChoices WHERE ID = '" + ID + " ';";
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
                var form = new PlayMultiC(ID);
                form.Show();
                form.BackColor = this.BackColor;
                form.LoadQ(Question, Marks, RealOpt, Opt2, Opt3, Opt4);
                this.Close();
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 0) return;


            int ID = Convert.ToInt16(dataGridView1[e.ColumnIndex + 2, e.RowIndex].FormattedValue);
            OpenQ(ID);
            
        }





        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new MainMenu(id);
            form.Show();
            form.BackColor = this.BackColor;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchID(Questions, IDs, CIDs);


        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            string where = Directory.GetCurrentDirectory();
            where = where.Substring(0, where.Length - 24);
            SqliteConnection con = new SqliteConnection("Data Source = " + where + "/Revision.db;");

            con.Open();



            NEASortSearch s = new NEASortSearch();
            string text = textBox1.Text;
            int gn = 0;
            var h = s.multi_run_linear_string(text, Questions);
            gn = h.Item1;

            if (gn == 1)
            {
                string word = h.Item2;
                DialogResult dialogResult = MessageBox.Show("Did you mean: " + word + "?", "Search For Question", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string sql0 = "SELECT ID FROM Questions WHERE Question = '" + word + "';";
                    using var cmd0 = new SqliteCommand(sql0, con);
                    using SqliteDataReader reader0 = cmd0.ExecuteReader();
                    reader0.Read();
                    int ID = Convert.ToInt16(reader0.GetValue(0));
                    OpenQ(ID);
                }


            }
        }

    }
}
