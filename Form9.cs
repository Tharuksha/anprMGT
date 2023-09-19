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
    public partial class Form9 : Form
    {
        string computerip = Form1.computerip;
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
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
            string category = comboBoxCategory.Text;

            Dictionary<string, string> comboPlates = new Dictionary<string, string>();
            string SqlConnectionString = $"Server={computerip};Database=anpr;Uid=sa;Pwd=ant@1234";
            SqlConnection conn = new SqlConnection(SqlConnectionString);
            conn.Open();
            string getplates = $"SELECT plates FROM anpr_match_list WHERE category = @cat";
            SqlCommand executeQuery = new SqlCommand(getplates, conn);
            executeQuery.Parameters.AddWithValue("@cat", category);
            SqlDataReader readerplates = executeQuery.ExecuteReader();
            //readercamnames.Read();
            //comboSourceCamera.Add("All", "All cameras");
            while (readerplates.Read())
            {
                comboPlates.Add(readerplates[0].ToString(), readerplates[0].ToString());

            }

            comboBoxNumber.DataSource = new BindingSource(comboPlates, null);
            comboBoxNumber.DisplayMember = "Value";
// comboBoxNumber.ValueMember = "Key";
            readerplates.Close();
            conn.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string plate = comboBoxNumber.Text;
            string SqlConnectionString = $"Server={computerip};Database=anpr;Uid=sa;Pwd=ant@1234";
            SqlConnection conn = new SqlConnection(SqlConnectionString);
            conn.Open();
            string delplate = $"DELETE FROM anpr_match_list WHERE plates = @plates";
            SqlCommand executeNoQuerydelete = new SqlCommand(delplate, conn);
            executeNoQuerydelete.Parameters.AddWithValue("@plates", plate);
            executeNoQuerydelete.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Successfully removed");
        }
    }
}
