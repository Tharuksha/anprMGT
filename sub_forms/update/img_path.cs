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
    public partial class img_path : Form
    {
        public img_path()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            string computerip = login.computerip;
            string SqlConnectionString = $"Server={computerip};Database=anpr;Uid=sa;Pwd=ant@1234";
            SqlConnection conn = new SqlConnection(SqlConnectionString);
            conn.Open();
            string getipath = $"SELECT imgpath FROM anpr_ipath";
            SqlCommand executeQuery = new SqlCommand(getipath, conn);
            SqlDataReader readipath = executeQuery.ExecuteReader();
            if (readipath.Read())
            {
                textBoxImagepath.Text = readipath.GetValue(0).ToString();

            }
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            string computerip = login.computerip;
            string ipath = textBoxImagepath.Text;


            string SqlConnectionString = $"Server={computerip};Database=anpr;Uid=sa;Pwd=ant@1234";
            SqlConnection conn = new SqlConnection(SqlConnectionString);
            conn.Open();
            string setipath = $"UPDATE anpr_ipath SET imgpath = @ipath";
            SqlCommand executeNoQueryAdd = new SqlCommand(setipath, conn);
            executeNoQueryAdd.Parameters.AddWithValue("@ipath", ipath);

            executeNoQueryAdd.ExecuteNonQuery();
            conn.Close();


            MessageBox.Show("Image store has been changed");

        }
    }
}
