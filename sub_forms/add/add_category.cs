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
    public partial class Form6 : Form
    {
        string computerip = login.computerip;
        public Form6()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string catname = textBoxName.Text;
            string catdesc = textBoxDesc.Text;
            
            if (string.IsNullOrEmpty(catname) || string.IsNullOrEmpty(catdesc))
            {
                labelStatus.Text = "Both fields must be required";
            }
            else
            {
                string SqlConnectionString = $"Server={computerip};Database=anpr;Uid=sa;Pwd=ant@1234";
                try
                {
                    SqlConnection conn = new SqlConnection(SqlConnectionString);
                    conn.Open();
                    string adduser = $"INSERT INTO anpr_cat (catname, catdesc) VALUES (@catname, @catdesc)";
                    SqlCommand executeNoQueryAdd = new SqlCommand(adduser, conn);
                    executeNoQueryAdd.Parameters.AddWithValue("@catname", catname);
                    executeNoQueryAdd.Parameters.AddWithValue("@catdesc", catdesc);
                    executeNoQueryAdd.ExecuteNonQuery();
                    conn.Close();
                    textBoxName.Text = "";
                    textBoxDesc.Text = "";
                    MessageBox.Show("Successfully added");
                    labelStatus.Text = "";
                }
                catch (SqlException ex)
                {
                    labelStatus.Text = "The category exists";
                }
              
            }


        }
    }
}
