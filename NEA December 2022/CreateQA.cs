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
    public partial class CreateQA : Form
    {
        public int id;
        public CreateQA(int ID)
        {
            id = ID;
            InitializeComponent();
        }

        //---------------------------------------Answer Box-------------------------------
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            InputAns.BackColor = colorDialog1.Color;
        }

        
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            int newSize = Convert.ToInt32(InputAns.Font.Size) + 4;
            InputAns.Font = new Font(InputAns.Font.FontFamily, newSize);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            int newSize = Convert.ToInt32(InputAns.Font.Size) - 4;
            if (newSize > 8)
            {
                InputAns.Font = new Font(InputAns.Font.FontFamily, newSize);
            }
            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
            InputAns.ForeColor = colorDialog2.Color;
        }

        //-------------------------QuestionBox------------------------------------
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            colorDialog3.ShowDialog();
            InputQ.BackColor = colorDialog3.Color;
        }

        private void toolStripButton6_Click_1(object sender, EventArgs e)
        {
            colorDialog4.ShowDialog();
            InputQ.ForeColor = colorDialog4.Color;
        }

        private void toolStripButton7_Click_1(object sender, EventArgs e)
        {
            int newSize = Convert.ToInt32(InputQ.Font.Size) + 4;
            InputQ.Font = new Font(InputQ.Font.FontFamily, newSize);
        }

        private void toolStripButton8_Click_1(object sender, EventArgs e)
        {
            int newSize = Convert.ToInt32(InputQ.Font.Size) - 4;
            if (newSize > 8)
            {
                InputQ.Font = new Font(InputQ.Font.FontFamily, newSize);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(InputQ.Text) | string.IsNullOrEmpty(InputAns.Text)))
            {
                

                //---------------------------------------------------------------

                string where = Directory.GetCurrentDirectory();
                where = where.Substring(0, where.Length - 24);
                SqliteConnection con = new SqliteConnection("Data Source = " + where + "/Revision.db;");

                string Question = InputQ.Text;
                string Answer = InputAns.Text;
                string QuestionBGColour = Convert.ToString(InputQ.BackColor);
                string QuestionFGColour = Convert.ToString(InputQ.ForeColor);
                string AnswerBGColour = Convert.ToString(InputAns.BackColor);
                string AnswerFGColour = Convert.ToString(InputAns.ForeColor);

                NEAFonts s = new NEAFonts();

                string QuestionFont = s.MakeFontString(InputQ.Font);
                string AnswerFont = s.MakeFontString(InputAns.Font);

                DateTime now = DateTime.Now;
                string Modified = Convert.ToString(now);

                int CID = id;
                int Marks = Convert.ToInt16(MarksInp.Value);



                con.Open();
                var command = con.CreateCommand();
                string sql2 = "INSERT into Flashcards (Question, Answer, Modified, CreatorID, Marks, QuestionBG, QuestionFG, AnswerBG, AnswerFG, AFont, QFont) " +
                    "VALUES ('" + Question + "','" + Answer + "','" + Modified + "','" + CID + "','" + Marks + "','" + QuestionBGColour + "','"
                    + QuestionFGColour + "','" + AnswerBGColour + "','" + AnswerFGColour + "','" + QuestionFont + "','" + AnswerFont + "');";
                command.CommandText = sql2;
                command.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Question Created Successfully");

                var Form = new Create(id);
                this.Hide();
                Form.Show();
                Form.BackColor = this.BackColor;
                

            }
            else
            {
                MessageBox.Show("Please Fill In All Fields");
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            InputAns.Font = fontDialog1.Font;
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            fontDialog2.ShowDialog();
            InputQ.Font = fontDialog2.Font;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var Form = new Create(id);
            this.Hide();
            Form.Show();
            Form.BackColor = this.BackColor;
        }
    }
    
}
