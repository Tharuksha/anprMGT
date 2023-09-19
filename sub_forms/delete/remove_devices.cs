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
    public partial class remove_devices : Form
    {
        
        public remove_devices()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            string computerip = login.computerip;

            Dictionary<string, string> comboDevices = new Dictionary<string, string>();
            string SqlConnectionString = $"Server={computerip};Database=anpr;Uid=sa;Pwd=ant@1234";
            SqlConnection conn = new SqlConnection(SqlConnectionString);
            conn.Open();
            string getdevices = $"SELECT dname FROM anpr_devices";
            SqlCommand executeQuery = new SqlCommand(getdevices, conn);
            SqlDataReader readerusers = executeQuery.ExecuteReader();
            //readercamnames.Read();
            //comboSourceCamera.Add("All", "All cameras");
            while (readerusers.Read())
            {
                comboDevices.Add(readerusers[0].ToString(), readerusers[0].ToString());

            }

            comboBoxDevice.DataSource = new BindingSource(comboDevices, null);
            comboBoxDevice.DisplayMember = "Value";
            comboBoxDevice.ValueMember = "Key";
            readerusers.Close();
            conn.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string computerip = login.computerip;
            string devicename = comboBoxDevice.Text;
            string SqlConnectionString = $"Server={computerip};Database=anpr;Uid=sa;Pwd=ant@1234";
            SqlConnection conn = new SqlConnection(SqlConnectionString);
            conn.Open();
            string deluser = $"DELETE FROM anpr_devices WHERE dname = @devicename";
            SqlCommand executeNoQueryAdd = new SqlCommand(deluser, conn);
            executeNoQueryAdd.Parameters.AddWithValue("@devicename", devicename);
            executeNoQueryAdd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Successfully removed");
        }
    }
}
