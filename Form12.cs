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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();

        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            string computerip = Form1.computerip;
            string rettime = textBoxRetention.Text;
            
            if(string.IsNullOrEmpty(rettime))
            {
                labelStatus.Text = "Retention time not be empty or 0";
            }
            else
            {
                int crettime = Int32.Parse(rettime);
                string SqlConnectionString = $"Server={computerip};Database=anpr;Uid=sa;Pwd=ant@1234";
                SqlConnection conn = new SqlConnection(SqlConnectionString);
                conn.Open();
                string setrtime = $"UPDATE anpr_config SET rtime = @rtime";
                SqlCommand executeNoQueryAdd = new SqlCommand(setrtime, conn);
                executeNoQueryAdd.Parameters.AddWithValue("@rtime", crettime);
               
                executeNoQueryAdd.ExecuteNonQuery();
                conn.Close();
                
                labelStatus.Text = "";
                MessageBox.Show("Retention time has been set");
            }

        }

        private void Form12_Load(object sender, EventArgs e)
        {
            //textBoxRetention.Text = "30";
            string computerip = Form1.computerip;
            string SqlConnectionString = $"Server={computerip};Database=anpr;Uid=sa;Pwd=ant@1234";
            SqlConnection conn = new SqlConnection(SqlConnectionString);
            conn.Open();
            string getrettime = $"SELECT rtime FROM anpr_config";
            SqlCommand executeQuery = new SqlCommand(getrettime, conn);
            SqlDataReader readerret = executeQuery.ExecuteReader();
            if (readerret.Read())
            {
                textBoxRetention.Text = readerret.GetValue(0).ToString();
                textBoxRetention.Focus();
                textBoxRetention.SelectAll();
            }

        }
    }
}
