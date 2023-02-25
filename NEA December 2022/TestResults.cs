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
    public partial class TestResults : Form
    {
        public int userid;
        public TestResults(int id)
        {
            InitializeComponent();
            userid = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var F = new MainMenu(userid);
            F.Show();
            F.BackColor = this.BackColor;
            this.Close();
        }
    }
}
