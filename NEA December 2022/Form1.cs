using Microsoft.Data.Sqlite;
namespace NEA_December_2022
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            //Get Log In Details
            string password = InputPassword.Text;
            string username = InputUsername.Text;
            List <string> passwords = new List<string>();

            string where = Directory.GetCurrentDirectory();
            where = where.Substring(0, where.Length - 24);
            SqliteConnection con = new SqliteConnection("Data Source = "+ where +"/Revision.db;");
            //SqliteConnection con = new SqliteConnection("Data Source = Revision.db;");




            con.Open();
            string sql = "SELECT password FROM users WHERE username = '" + username +"';";
            using var cmd = new SqliteCommand(sql, con);
            using SqliteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                passwords.Add(reader.GetString(0));
            }
            //Try login
            if (passwords.Count > 0)
            {
                if (passwords[0] == password)
                {
                    //Password is correct so gains access:

                    // - Get the Users ID (Useful in parts of the program)
                    List<string> IDs = new List<string>();
                    string sql2 = "SELECT ID FROM users WHERE username = '" + username + "' AND password = '"+password+"';";
                    using var cmd2 = new SqliteCommand(sql2, con);
                    using SqliteDataReader reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {
                        IDs.Add(reader2.GetString(0));
                    }
                    int ID = Convert.ToInt32(IDs[0]);


                    // - Get the users Background colour using this ID
                    List<string> colours = new List<string>();

                    where = Directory.GetCurrentDirectory();
                    where = where.Substring(0, where.Length - 24);
                    SqliteConnection con3 = new SqliteConnection("Data Source = " + where + "/Revision.db;");

                    con3.Open();
                    string sql3 = "SELECT BGColour FROM users WHERE ID = '" + ID + "';";
                    using var cmd3 = new SqliteCommand(sql3, con3);
                    using SqliteDataReader reader3 = cmd3.ExecuteReader();
                    while (reader3.Read())
                    {
                        colours.Add(reader3.GetString(0));
                    }

                    //Find what background colour type they use, and manipulate the background colour into this
                    if (colours[0] != "DEFAULT")
                    {
                        bool argbformat = false;
                        foreach (char character in colours[0])
                        {
                            if (character == ',')
                            {
                                argbformat = true;
                            }
                        }
                        if (argbformat)
                        {
                            string colourstring = colours[0];

                            colourstring = colourstring.Substring(7, colourstring.Length - 8);
                            label1.Text = colourstring;

                            string[] parts = new string[4];
                            parts = colourstring.Split(',');

                            for (int i = 0; i < parts.Length; i++)
                            {
                                parts[i] = parts[i].Substring(3, parts[i].Length - 3);
                            }

                            this.BackColor = Color.FromArgb(255, Convert.ToInt32(parts[1]),
                                Convert.ToInt32(parts[2]), Convert.ToInt32(parts[3]));
                        }
                        else
                        {
                            string colourstring = colours[0];

                            colourstring = colourstring.Substring(7, colourstring.Length - 8);
                            label1.Text = colourstring;
                            this.BackColor = ColorTranslator.FromHtml(colourstring);
                        }

                    }
                    con3.Close();

                    
                    var Form = new MainMenu(ID);
                    this.Hide();
                    Form.Show();
                    Form.BackColor = this.BackColor;
                    
                   
                }
                else
                {
                    MessageBox.Show("Incorrect Password");
                }
            }
            else
            {
                MessageBox.Show("Incorrect Login Details - User Not Found");
            }
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Form = new Signup();
            this.Hide();
            Form.Show();
            Form.BackColor = this.BackColor;
            

        }
    }
}