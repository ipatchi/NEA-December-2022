using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace NEA_December_2022
{
    public partial class Explore : Form
    {

        

        public Explore()
        {
            List<string> Questions = new List<string>();
            List<int> IDs = new List<int>();
            List<int> CIDs = new List<int>();
            
            string where = Directory.GetCurrentDirectory();
            where = where.Substring(0, where.Length - 24);
            SqliteConnection con = new SqliteConnection("Data Source = " + where + "/Revision.db;");

            con.Open();

            string sql = "SELECT Question,ID,CreatorID FROM flashcards;";
            using var cmd = new SqliteCommand(sql, con);
            using SqliteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Questions.Add(reader.GetString(0));
                IDs.Add(reader.GetInt32(1));
                CIDs.Add(reader.GetInt32(2));
            }

            ShowQuestions(Questions, IDs, CIDs);

            

        }

        public void ShowQuestions(List<string> Questions, List<int> IDs, List<int> CreatorIDs)
        {
            DataTable table = new DataTable();
            DataColumn dtcolumn;
            DataRow mydatarow;

            dtcolumn = new DataColumn();
            dtcolumn.ColumnName = "Question";
            table.Columns.Add(dtcolumn);

            dtcolumn = new DataColumn();
            dtcolumn.ColumnName = "ID";
            table.Columns.Add(dtcolumn);

            dtcolumn = new DataColumn();
            dtcolumn.ColumnName = "Creator ID";
            table.Columns.Add(dtcolumn);


           for (int i = 0; i < Questions.Count; i++)
            {
                mydatarow = table.NewRow();
                mydatarow["Question"] = Questions[i];
                mydatarow["ID"] = IDs[i];
                mydatarow["Creator ID"] = CreatorIDs[i];
                table.Rows.Add(mydatarow);
            }
            
           label1.Text = IDs.Count.ToString();

            //dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}
