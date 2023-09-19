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
    public partial class Form8 : Form
    {
        string computerip = Form1.computerip;
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string categoryname = comboBoxCategory.Text;
            string plate = textBoxNumber.Text;

            if (string.IsNullOrEmpty(plate))
            {
                labelStatus.Text = "Number field should not be empty";
            }
            else
            {
                string SqlConnectionString = $"Server={computerip};Database=anpr;Uid=sa;Pwd=ant@1234";

                try
                {
                    SqlConnection conn = new SqlConnection(SqlConnectionString);
                    conn.Open();
                    string addplate = $"INSERT INTO anpr_match_list (category, plates) VALUES (@cat, @plate)";
                    SqlCommand executeNoQueryAdd = new SqlCommand(addplate, conn);
                    executeNoQueryAdd.Parameters.AddWithValue("@cat", categoryname);
                    executeNoQueryAdd.Parameters.AddWithValue("@plate", plate);
                    executeNoQueryAdd.ExecuteNonQuery();
                    conn.Close();
                    textBoxNumber.Text = "";

                    MessageBox.Show("Successfully added");
                }
                catch (SqlException ex)
                {
                    labelStatus.Text = "Duplicate number found";
                }
                
            }
        }
    }
    
}
