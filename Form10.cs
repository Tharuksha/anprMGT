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
    public partial class Form10 : Form
    {
        
        public Form10()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string computerip = Form1.computerip;

            string devicename = textBoxDname.Text;
            string deviceip = textBoxIp.Text;
            string deviceusername = textBoxUsername.Text;
            string devicepassword = textBoxPassword.Text;

            if (string.IsNullOrEmpty(devicename) || string.IsNullOrEmpty(deviceip) || string.IsNullOrEmpty(deviceusername) || string.IsNullOrEmpty(devicepassword))
            {
                labelStatus.Text = "All fields must be filled";
            
            }
            else
            {
                string SqlConnectionString = $"Server={computerip};Database=anpr;Uid=sa;Pwd=ant@1234";

                SqlConnection conn = new SqlConnection(SqlConnectionString);
                conn.Open();
                string adddevice = $"INSERT INTO anpr_devices (dname, dip, dusername, dpassword) VALUES (@dname, @dip, @dusername, @dpassword)";
                SqlCommand executeNoQueryAdd = new SqlCommand(adddevice, conn);
                executeNoQueryAdd.Parameters.AddWithValue("@dname", devicename);
                executeNoQueryAdd.Parameters.AddWithValue("@dip", deviceip);
                executeNoQueryAdd.Parameters.AddWithValue("@dusername", deviceusername);
                executeNoQueryAdd.Parameters.AddWithValue("@dpassword", devicepassword);
                executeNoQueryAdd.ExecuteNonQuery();
                conn.Close();
                textBoxDname.Text = "";
                textBoxIp.Text = "";
                textBoxUsername.Text = "";
                textBoxPassword.Text = "";
                labelStatus.Text = "";
                MessageBox.Show("Successfully added");
            }

        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }
    }
}
