using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using Microsoft.Data.Sqlite;

namespace NEA_December_2022
{
    public partial class Settings : Form
    {
        public Settings(int ID2)
        {
            InitializeComponent();
            ID = ID2;
        }

        public int ID;

        private void HomeButton_Click(object sender, EventArgs e)
        {
            var form = new MainMenu(ID);
            form.Show();
            this.Hide();
            form.BackColor = this.BackColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            this.BackColor = colorDialog1.Color;

            string where = Directory.GetCurrentDirectory();
            where = where.Substring(0, where.Length - 24);
            SqliteConnection con = new SqliteConnection("Data Source = " + where + "/Revision.db;");

            con.Open();
            var command = con.CreateCommand();
            string sql = "UPDATE Users SET BGColour = '"+colorDialog1.Color+"' WHERE ID = '" + ID + "';";
            command.CommandText = sql;
           
            
            command.ExecuteNonQuery();

            con.Close();
        }
    }
}
