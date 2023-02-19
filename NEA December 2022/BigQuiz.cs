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
    public partial class BigQuiz : Form
    {
        public int id = 0;
        public BigQuiz(int ID)
        {
            id = ID;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new PlayMultiC(id);

            this.IsMdiContainer = true;
            
            form.MdiParent = this;
            form.Show();

          
            form.BackColor = this.BackColor;
            form.LoadQ("Why", 2, "dhasejilo", "fdfd", "3", "bob");
            
        }
    }
}
