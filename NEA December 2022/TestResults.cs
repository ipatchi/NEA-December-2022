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
        public int[] allscores;
        public int[] Tmarks;
        public TestResults(int id, int[] Scores, int[] Marks)
        {
            InitializeComponent();
            userid = id;
            allscores = Scores;
            Tmarks = Marks;
            NEASortSearch f = new NEASortSearch();

            ShowTable();
          
        }

        public void ShowTable()
        {
            DataTable table = new DataTable();
            DataColumn dtcolumn;
            DataRow mydatarow;

            dtcolumn = new DataColumn();
            dtcolumn.ColumnName = "Number";
            table.Columns.Add(dtcolumn);

            dtcolumn = new DataColumn();
            dtcolumn.ColumnName = "Score";
            table.Columns.Add(dtcolumn);

            dtcolumn = new DataColumn();
            dtcolumn.ColumnName = "Availiable";
            table.Columns.Add(dtcolumn);

            NEAQStats s = new NEAQStats();
            


            for (int i = 0; i < 5; i++)
            {
                mydatarow = table.NewRow();
                mydatarow["Number"] = i + 1;
                mydatarow["Score"] = allscores[i];
                mydatarow["Availiable"] = Tmarks[i];
               
                table.Rows.Add(mydatarow);
            }

            double ts = s.SumIntArray(allscores); 
            double tm = s.SumIntArray(Tmarks);

            mydatarow = table.NewRow();
            mydatarow["Number"] = "Total:";
            mydatarow["Score"] = ts;
            mydatarow["Availiable"] = tm;

            double pc = ((ts * 100) / (tm * 100)) * 100;
            pc = Math.Floor(pc);
            table.Rows.Add(mydatarow);


            dataGridView1.BackgroundColor = this.BackColor;
            dataGridView1.DataSource = table;

            string say = "";
            say += Convert.ToString(pc) + "%";
            if (pc < 50)
            {
                say += " - Better Luck Next Time!";
            }
            else if (pc < 70)
            {
                say += " - Good Effort!";
            }
            else if (pc < 90)
            {
                say += " - Wow!";
            }
            else
            {
                say += " - WOAH! Congratulations!";
            }
            label2.Text = say;

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
