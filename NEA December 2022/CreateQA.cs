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
        public CreateQA()
        {
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

        }
    }
}
