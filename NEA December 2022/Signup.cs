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
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (InputPassword1.Text == InputPassword2.Text)
            {
                if (!(string.IsNullOrEmpty(InputPassword2.Text) | string.IsNullOrEmpty(InputPassword1.Text) | string.IsNullOrEmpty(InputUsername.Text) | string.IsNullOrEmpty(InputName.Text)))
                {
                    List<string> usernames = new List<string>();

                    //---------------------------------------------------------------

                    string where = Directory.GetCurrentDirectory();
                    where = where.Substring(0, where.Length - 24);
                    SqliteConnection con = new SqliteConnection("Data Source = " + where + "/Revision.db;");

                    label1.Text = where;
                    //---------------------------------------------------------------

                    con.Open();
                    string sql = "SELECT ID FROM Users WHERE Username = '"+InputUsername.Text+"';";
                    using var cmd = new SqliteCommand(sql, con);
                    using SqliteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        usernames.Add(reader.GetString(0));
                    }
                    if (usernames.Count > 0)
                    {
                        MessageBox.Show("Username Is Taken - Please Try Something Else");
                    }
                    else
                    {
                        //Password Rules Here?

                        string name = InputName.Text;
                        string password = InputPassword1.Text;
                        string username = InputUsername.Text;
                        int age = Convert.ToInt32(InputAge.Value);

                        
                        con.Open();
                        var command = con.CreateCommand();
                        string sql2 = "INSERT into Users (Username, Password, Age, Name, BGColour) VALUES ('" + username + "','" + password + "','" + age + "','" + name + "', 'DEFAULT')";
                        command.CommandText = sql2;
                        command.ExecuteNonQuery();

                        con.Close();
                        MessageBox.Show("Account Created Successfully");

                        var Form = new Form1();
                        this.Hide();
                        Form.Show();
                        Form.BackColor = this.BackColor;
                    }

                }
                else
                {
                    MessageBox.Show("Please Fill In All Fields");
                }
            }
            else
            {
                MessageBox.Show("Passwords Do Not Match");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Form = new Form1();
            this.Hide();
            Form.Show();
            Form.BackColor = this.BackColor;
        }
    }
}
