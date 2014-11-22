using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApplication1
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form3 newForm = new Form3();
            newForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblLink1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            registration newForm = new registration();
            newForm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            registration form = new registration();
            form.Show();
        }
    }
}
