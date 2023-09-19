using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Data.SqlClient;

namespace anprMGT
{
    public partial class login : Form
    {
        public static string computerip = "";
        public login()
        {
            InitializeComponent();

        }

        private void textBoxComputer_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelStatus.Text = "⏳ Waiting...";
        }

        private async void buttonConnect_Click_1(object sender, EventArgs e)
        {
            computerip = textBoxComputer.Text;
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();

            labelStatus.Text = "⏳ Connecting... ";
            await Task.Delay(2000);

            if (string.IsNullOrEmpty(computerip) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                labelStatus.Text = "✒️ Fill The Fields..";
                await Task.Delay(2000);
                labelStatus.Text = "⏳ Waiting... "; 
            }
            else
            {
                string SqlConnectionString = $"Server={computerip};Database=anpr;Uid=sa;Pwd=ant@1234";
                try
                {
                    SqlConnection conn = new SqlConnection(SqlConnectionString);
                    conn.Open();
                    string chkuser = $"SELECT * FROM anpr_users WHERE username = @username AND password = @password";
                    SqlCommand executeQuery = new SqlCommand(chkuser, conn);
                    executeQuery.Parameters.AddWithValue("@username", username);
                    executeQuery.Parameters.AddWithValue("@password", password);
                    SqlDataReader MyReader = executeQuery.ExecuteReader();
                    MyReader.Read();
                    if (MyReader.HasRows)
                    {
                        MyReader.Close();
                        conn.Close();


                        labelStatus.Text = "✅ Connected";
                        await Task.Delay(1000);
                        dashboard form2 = new dashboard();
                        form2.Show();
                        form2 = null;
                        this.Hide();


                    }
                    else
                    {
                        labelStatus.Text = "❌ Incorrect Username or Password  ";
                        await Task.Delay(2000);
                        labelStatus.Text = "⏳ Waiting... ";
                    }


                }
                catch (SqlException ex)
                {
                    labelStatus.Text = "🔌" + ex.Message;
                    await Task.Delay(2000);
                    labelStatus.Text = "⏳ Waiting... ";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
