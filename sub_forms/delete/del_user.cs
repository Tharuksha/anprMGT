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
    public partial class Form5 : Form
    {
        string computerip = login.computerip;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
           

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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string username = comboBoxUsername.Text;
            string SqlConnectionString = $"Server={computerip};Database=anpr;Uid=sa;Pwd=ant@1234";
            SqlConnection conn = new SqlConnection(SqlConnectionString);
            conn.Open();
            string deluser = $"DELETE FROM anpr_users WHERE username = @username";
            SqlCommand executeNoQueryAdd = new SqlCommand(deluser, conn);
            executeNoQueryAdd.Parameters.AddWithValue("@username", username);
            executeNoQueryAdd.ExecuteNonQuery();
            conn.Close();
            
            MessageBox.Show("Successfully removed");
        }
    }
}
