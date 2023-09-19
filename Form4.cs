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
    public partial class Form4 : Form
    {
        string computerip = Form1.computerip;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string computerip = Form1.computerip;

            Dictionary<string, string> comboUsers = new Dictionary<string, string>();
            string SqlConnectionString = $"Server={computerip};Database=anpr;Uid=sa;Pwd=ant@1234";
            SqlConnection conn = new SqlConnection(SqlConnectionString);
            conn.Open();
            string getusers = $"SELECT username FROM anpr_users";
            SqlCommand executeQuery = new SqlCommand(getusers, conn);
            SqlDataReader readerusers = executeQuery.ExecuteReader();
            //readercamnames.Read();
            //comboSourceCamera.Add("All", "All cameras");
            while (readerusers.Read())
            {
                comboUsers.Add(readerusers[0].ToString(), readerusers[0].ToString());
                
            }

            comboBoxUsername.DataSource = new BindingSource(comboUsers, null);
            comboBoxUsername.DisplayMember = "Value";
            comboBoxUsername.ValueMember = "Key";
            readerusers.Close();
            conn.Close();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            string password = textBoxPassword.Text;
            string rpassword = textBoxRpassword.Text;
            string username = comboBoxUsername.Text;
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(rpassword))
            {
                labelStatus.Text = "Both password fileds must required";
            }
            else if (password != rpassword)
            {
                labelStatus.Text = "Password does not match";
            }
            else
            {
                string SqlConnectionString = $"Server={computerip};Database=anpr;Uid=sa;Pwd=ant@1234";
                SqlConnection conn = new SqlConnection(SqlConnectionString);
                conn.Open();
                string adduser = $"UPDATE anpr_users SET password = @password WHERE username = @username";
                SqlCommand executeNoQueryAdd = new SqlCommand(adduser, conn);
                executeNoQueryAdd.Parameters.AddWithValue("@password", password);
                executeNoQueryAdd.Parameters.AddWithValue("@username", username);
                executeNoQueryAdd.ExecuteNonQuery();
                conn.Close();
                textBoxPassword.Text = "";
                textBoxRpassword.Text = "";
                labelStatus.Text = "";
                MessageBox.Show("Password has been changed");
            }
        }
    }
}
