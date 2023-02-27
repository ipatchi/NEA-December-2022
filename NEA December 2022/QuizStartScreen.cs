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
    public partial class QuizStartScreen : Form
    {
        public int userid;
        public int[] playlist = new int[5];
        public QuizStartScreen(int id)
        {
            InitializeComponent();
            userid = id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!(comboBox1.Text == ""))
            {
                var form = new BigQuiz(userid, comboBox1.Text);
                form.Show();
                this.Hide();
                form.BackColor = this.BackColor;
            }
            else
            {
                MessageBox.Show("Please Select A Difficulty");
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            if (o.ShowDialog() == DialogResult.OK)
            {
                string[] readText = File.ReadAllLines(o.FileName);
                for (int i = 0; i < 5; i++)
                {
                    playlist[i] = Convert.ToInt32(readText[i]);
                }
            }

            var form = new BigQuiz(userid, "NEAFILEUPLOAD",playlist);
            form.Show();
            this.Hide();
            form.BackColor = this.BackColor;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var f = new MainMenu(userid);
            f.Show();
            f.BackColor = this.BackColor;
            this.Close();
        }
    }
}
