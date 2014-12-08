using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Admin_Checker : Form
    {
        public Admin_Checker()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user_name = textBox1.Text;
            string pass = textBox2.Text;

            if (user_name.Equals("admin") && pass.Equals("admin"))
            {
                Admin form = new Admin();
                form.Show();
                this.Hide();
            }
            else {
                MessageBox.Show("Sorry you don't have the permission to access the admin panel", "OPS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            login newForm = new login();
            this.Hide();
            newForm.Show();
        }
    }
}
