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
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection(global::WindowsFormsApplication1.Properties.Settings.Default.inside_470ConnectionString);

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                string pass=textBox3.Text;
                string user_id=textBox2.Text;

                string sql = "SELECT * from [log_info] where (user_id='"+user_id+"' AND password='"+pass+"')";
                //string sql = "SELECT * from [log_info] ";
                SqlCommand exeSql = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = exeSql.ExecuteReader();
                bool contain=false;
                string val = "";
                while(reader.Read()){
                    if (reader.GetString(0) == user_id && reader.GetString(2)==pass) {
                        contain = true;
                        val = val + reader.GetString(3);
                    }
                    
                }

                if (contain)
                {
                    MessageBox.Show("success", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (val.Equals("Doctor"))
                    {
                        Doctor_s_Form newForm = new Doctor_s_Form(user_id);
                        newForm.Show();
                        this.Hide();
                    }
                    else {
                        patient_profile form = new patient_profile(user_id);
                        form.Show();
                        this.Hide();

                    }
                }
                else {
                    MessageBox.Show("Not-Success", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                con.Close();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * from [log_info] ";
            try
            {
                SqlCommand exe = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = exe.ExecuteReader();

                string val = "";
                while (reader.Read())
                {
                    val = val + reader.GetString(0) + " "+ reader.GetString(1)+" "+reader.GetString(2);
                }
                MessageBox.Show(val, "info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                con.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            login newform = new login();
            this.Hide();
            newform.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
