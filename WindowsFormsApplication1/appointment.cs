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
    public partial class Appointment : Form
    {
        SqlConnection con = new SqlConnection(global::WindowsFormsApplication1.Properties.Settings.Default.inside_470ConnectionString);
        SqlConnection con2 = new SqlConnection(global::WindowsFormsApplication1.Properties.Settings.Default.inside_470ConnectionString);
        public Appointment(string patient_id)
        {
            InitializeComponent();
            textBox2.Text = patient_id;

            string doc_info = "SELECT name,qualification from [doc_info]";

            try {
                SqlCommand exe = new SqlCommand(doc_info, con);
                con.Open();
                SqlDataReader reader = exe.ExecuteReader();
                string val = "";
                while(reader.Read()){
                    comboBox1.Items.Add(reader.GetString(0));
                    richTextBox2.Text = reader.GetString(1);
                }
               
                reader.Close();
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message, "error in parsing doc name in appo_form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                con.Close();
            }
            int id=Convert.ToInt32(patient_id);
            doc_info = "SELECT name from [patient_info] where patient_id=" + id + "";
            try
            {
                SqlCommand exe = new SqlCommand(doc_info, con2);
                con2.Open();
                SqlDataReader reader=exe.ExecuteReader();
                string val = "";
                while(reader.Read()){
                    val= reader.GetString(0);
                }
                reader.Close();
                textBox1.Text = val;
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message, "error in parsing patient name in appo_form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                con2.Close();
            }
        }



    }
}
