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
            add_user form3 = new add_user();
            form3.Show();
        }

        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            change_pass form4 = new change_pass();
            form4.Show();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            del_user form5 = new del_user();
            form5.Show();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_category form6 = new add_category();
            form6.Show();
        }

        private void deleteToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            del_category form7 = new del_category();
            form7.Show();
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            add_numbers form8 = new add_numbers();
            form8.Show();
        }

        private void deleteToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            del_numbers form9 = new del_numbers();
            form9.Show();
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
            add_devices form10 = new add_devices();
            form10.Show();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            remove_devices form11 = new remove_devices();
            form11.Show();
        }

        private void retentionTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            retention_time form12 = new retention_time();
            form12.Show();
        }

        private void imageStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            img_path form13 = new img_path();
            form13.Show();
        }
    }
}
