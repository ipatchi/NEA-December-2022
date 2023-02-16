using Microsoft.Data.Sqlite;
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
    public partial class CreateMultiC : Form
    {
        public int id = 0;
        public CreateMultiC(int ID)
        {
            id = ID;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(InputQ.Text) | string.IsNullOrEmpty(CorrectOpt.Text) | string.IsNullOrEmpty(Opt2.Text)
                | string.IsNullOrEmpty(Opt3.Text) | string.IsNullOrEmpty(Opt4.Text)))
            {


                //---------------------------------------------------------------

                string where = Directory.GetCurrentDirectory();
                where = where.Substring(0, where.Length - 24);
                SqliteConnection con = new SqliteConnection("Data Source = " + where + "/Revision.db;");

                string Question = InputQ.Text;
                string RealOpt = CorrectOpt.Text;
                string opt2 = Opt2.Text;
                string opt3 = Opt3.Text;
                string opt4 = Opt4.Text;

                int CID = id;
                int Marks = Convert.ToInt16(MarksInp.Value);
                int type = 2;


                con.Open();

                var command1 = con.CreateCommand();
                string sql1 = "INSERT into Questions (CreatorID, Type, Question)VALUES ('" + CID + "','" + type + "','" + Question + "');";
                command1.CommandText = sql1;
                command1.ExecuteNonQuery();


                var command = con.CreateCommand();


                string sql2 = "UPDATE MultiChoices SET RealOpt = '" + RealOpt + "', Marks = '" + Marks + "', " +
                    "Opt2 = '" + opt2 + "', Opt3 = '" + opt3 + "', Opt4 = '" + opt4 + "' WHERE Question = '" + Question + "';";


                command.CommandText = sql2;
                command.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Question Created Successfully");

                var Form = new Create(id);
                this.Hide();
                Form.Show();
                Form.BackColor = this.BackColor;


            }
            else
            {
                MessageBox.Show("Please Fill In All Fields");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Form = new Create(id);
            this.Hide();
            Form.Show();
            Form.BackColor = this.BackColor;
        }
    }
}
