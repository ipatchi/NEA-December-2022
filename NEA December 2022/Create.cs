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
    public partial class Create : Form
    {

        public int id = 0;
        public Create(int ID)
        {
            id = ID;
            InitializeComponent();
            
        }
     

        private void Create_Load(object sender, EventArgs e)
        {

                    }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new CreateQA(id);
            form.Show();
            this.Hide();
            form.BackColor = this.BackColor;
        

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new MainMenu(id);
            form.Show();
            this.Hide();
            form.BackColor = this.BackColor;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new CreateMultiC(id);
            form.Show();
            this.Hide();
            form.BackColor = this.BackColor;
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form = new CreateTest(id);
            form.Show();
            this.Hide();
            form.BackColor = this.BackColor;
        }
    }
}
