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
    public partial class doc_secure_code : Form
    {
        private string sec_code = "55525";
        private string cap_val = "";
        public doc_secure_code(string val)
        {
            InitializeComponent();
            cap_val = val;
            label1.Text = "dear " + cap_val + " you have been given a security code by the server admistrator" ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(sec_code))
            {
                doctor_profile form = new doctor_profile(cap_val);
                form.Show();
                this.Hide();
            }
            else {
                MessageBox.Show("you have entered the wrong code", "validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
