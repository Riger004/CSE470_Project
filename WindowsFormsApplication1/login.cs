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
            
           // try            {
           //     var sw = new System.IO.StreamWriter("C:\\"+ textBox1.Text + "\\User Name");
           //     sw.Write(textBox1.Text);
           //     sw.Close();
           //        }
           // catch(System.IO.DirectoryNotFoundException ex)            {
           //     MessageBox("Folder Not Found");
           //     System.IO.Directory.CreateDirectory("C:\\" + textBox1.Text);
           // }

        }
    }
}
