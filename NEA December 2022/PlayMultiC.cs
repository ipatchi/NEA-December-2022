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

namespace NEA_December_2022
{
    public partial class PlayMultiC : Form
    {
        public int id;
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
