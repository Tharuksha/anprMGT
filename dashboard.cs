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
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void devicesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void matchListsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_user add_User = new add_user();
            add_User.Show();
        }

        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            change_pass change_pass = new change_pass();
            change_pass.Show();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            del_user del_user = new del_user();
            del_user.Show();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_category add_category = new add_category();
            add_category.Show();
        }

        private void deleteToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            del_category del_category = new del_category();
            del_category.Show();
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            add_numbers add_numbers = new add_numbers();
            add_numbers.Show();
        }

        private void deleteToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            del_numbers del_numbers = new del_numbers();
            del_numbers.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
        private void Form2_FormClosing(object sender, EventArgs e)
        {
           
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            Application.Exit();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            add_devices add_devices = new add_devices();
            add_devices.Show();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            remove_devices remove_devices = new remove_devices();
            remove_devices.Show();
        }

        private void retentionTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            retention_time retention_time = new retention_time();
            retention_time.Show();
        }

        private void imageStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            img_path img_path = new img_path();
            img_path.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
