using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace NEA_December_2022
{
    public partial class MainMenu : Form
    {
        public MainMenu(int ID2)
        {
            InitializeComponent();
            ID = ID2;
        }

        public int ID;
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            
            var form = new Settings(ID);
            form.Show();
            this.Hide();
            form.BackColor = this.BackColor;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new Create(ID);
            form.Show();
            this.Hide();
            form.BackColor = this.BackColor;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new Explore(ID);
            form.Show();
            this.Hide();
            form.BackColor = this.BackColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new QuizStartScreen(ID);
            form.Show();
            this.Hide();
            form.BackColor = this.BackColor;
        }
    }
}
