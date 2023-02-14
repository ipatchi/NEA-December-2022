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
            button2.Visible = false;
            id = ID;
        }

        public string answer = "";
        public int id;

        public void viewQA(string Question, string Answer, String QBG, String QFG,string ABGColour, string AFGColour, 
            string QFont, string AFont, string Marks)
        {
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
                button2.Visible = true;
                button1.Visible = false;
                RealAnswerBox.Text = answer;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new Explore(id);
            form.BackColor = this.BackColor;
            form.Show();
            this.Close();
        }
    }
}
