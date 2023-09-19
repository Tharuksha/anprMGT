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
    public partial class Form7 : Form
    {
        string computerip = login.computerip;
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> comboCat = new Dictionary<string, string>();
            string SqlConnectionString = $"Server={computerip};Database=anpr;Uid=sa;Pwd=ant@1234";
            SqlConnection conn = new SqlConnection(SqlConnectionString);
            conn.Open();
            string getcat = $"SELECT catname FROM anpr_cat";
            SqlCommand executeQuery = new SqlCommand(getcat, conn);
            SqlDataReader readercat = executeQuery.ExecuteReader();
            //readercamnames.Read();
            //comboSourceCamera.Add("All", "All cameras");
            while (readercat.Read())
            {
                comboCat.Add(readercat[0].ToString(), readercat[0].ToString());

            }

            comboBoxCategory.DataSource = new BindingSource(comboCat, null);
            comboBoxCategory.DisplayMember = "Value";
            comboBoxCategory.ValueMember = "Key";
            readercat.Close();
            conn.Close();
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string catname = comboBoxCategory.Text;
                       
            string SqlConnectionString = $"Server={computerip};Database=anpr;Uid=sa;Pwd=ant@1234";
            SqlConnection conn = new SqlConnection(SqlConnectionString);
            conn.Open();
            string delcat = $"DELETE FROM anpr_cat WHERE catname = @catname";
            SqlCommand executeNoQuerydelete = new SqlCommand(delcat, conn);
            executeNoQuerydelete.Parameters.AddWithValue("@catname", catname);
            executeNoQuerydelete.ExecuteNonQuery();

            string delplates = $"DELETE FROM anpr_match_list WHERE category = @catname";
            SqlCommand executeNoQuerydelplates = new SqlCommand(delplates, conn);
            executeNoQuerydelplates.Parameters.AddWithValue("@catname", catname);
            executeNoQuerydelplates.ExecuteNonQuery();

            conn.Close();



            MessageBox.Show("Successfully removed");

        }
    }
}
