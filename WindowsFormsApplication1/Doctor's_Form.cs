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
namespace WindowsFormsApplication1
{
    public partial class Doctor_s_Form : Form
    {
        public Doctor_s_Form(string val)
        {
            InitializeComponent();
            label1.Text = "Welcome Doc "+val+" have a nice time";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Doctor_s_Form_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inside_470DataSet.patient_info' table. You can move, or remove it, as needed.
            this.patient_infoTableAdapter.Fill(this.inside_470DataSet.patient_info);

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
               
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Show();
            comboBox2.Show();
            comboBox3.Show();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Show();
        }
        }
    }


