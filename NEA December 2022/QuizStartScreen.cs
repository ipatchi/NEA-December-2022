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
        public QuizStartScreen(int id)
        {
            InitializeComponent();
            userid = id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new BigQuiz(userid, comboBox1.Text);
            form.Show();
            this.Hide();
            form.BackColor = this.BackColor;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
