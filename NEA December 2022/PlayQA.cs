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
        public PlayQA()
        {
            InitializeComponent();
        }

        public void viewQA(string Question, string Answer, String QBG, String QFG)
        {
            NEAString s = new NEAString();
            OutputQ.Text = Question;
            OutputQ.BackColor = s.TranslateColour(QBG);
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
