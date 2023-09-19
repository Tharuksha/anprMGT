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
    public partial class Form1 : Form
    {
        public static string computerip = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            computerip = textBoxComputer.Text;
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();

            labelStatus.Text = computerip;

            if (string.IsNullOrEmpty(computerip) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                labelStatus.Text = "Connection to the server failed";
            }
            else
            {
                string SqlConnectionString = $"Server={computerip};Database=anpr;Uid=sa;Pwd=ant@1234";
                try
                {
                    SqlConnection conn = new SqlConnection(SqlConnectionString);
                    conn.Open();
                    labelStatus.Text = "Connected to server";
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
                       
                        
                        
                        Form2 form2 = new Form2();
                        form2.Show();
                        form2 = null;
                        this.Hide();
                      

                    }
                    else
                    {
                        labelStatus.Text = "Username or password incorrect";
                    }


                }
                catch (SqlException ex)
                {
                    labelStatus.Text = "Connection to the server faild";
                }





            }


        }

        private void textBoxComputer_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
