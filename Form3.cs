using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace anprMGT
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string computerip = Form1.computerip;
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            string rpassword = textBoxRpassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(rpassword))
            {
                labelStatus.Text = "All fields must be filled";
            }
            else if (password != rpassword)
            {
                labelStatus.Text = "Password does not match";
            }
            else
            {
                try
                {
                    string SqlConnectionString = $"Server={computerip};Database=anpr;Uid=sa;Pwd=ant@1234";

                    SqlConnection conn = new SqlConnection(SqlConnectionString);
                    conn.Open();
                    string adduser = $"INSERT INTO anpr_users (username, password) VALUES (@username, @password)";
                    SqlCommand executeNoQueryAdd = new SqlCommand(adduser, conn);
                    executeNoQueryAdd.Parameters.AddWithValue("@username", username);
                    executeNoQueryAdd.Parameters.AddWithValue("@password", password);
                    executeNoQueryAdd.ExecuteNonQuery();
                    conn.Close();
                    textBoxUsername.Text = "";
                    textBoxPassword.Text = "";
                    textBoxRpassword.Text = "";
                    labelStatus.Text = "";
                    MessageBox.Show("Successfully added");
                }
                catch(SqlException ex)
                {
                    labelStatus.Text = "Username already exist";
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
