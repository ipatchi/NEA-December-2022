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
    public partial class PlayQA : Form
    {
        public PlayQA(int ID)
        {
            InitializeComponent();
            RealAnswerBox.Visible = false;
            id = ID;
        }

        public string answer = "";
        public int id;

        public void viewQA(string Question, string Answer, String QBG, String QFG,string ABGColour, string AFGColour, 
            string QFont, string AFont, string Marks)
        {
            NEAString s = new NEAString();
            OutputQ.Text = Question;
            OutputQ.BackColor = s.TranslateColour(QBG);
            OutputQ.ForeColor = s.TranslateColour(QFG);
            InputA.BackColor = s.TranslateColour(ABGColour);
            InputA.ForeColor = s.TranslateColour(AFGColour);

            answer = Answer;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (InputA.Text.ToUpper().Trim() == answer.ToUpper().Trim())
            {
                MessageBox.Show("Congratulations!");
                var form = new Explore(id);
                form.BackColor = this.BackColor;
                form.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect");
                RealAnswerBox.Visible = true;
                RealAnswerBox.Text = answer;

            }
        }
    }
}
