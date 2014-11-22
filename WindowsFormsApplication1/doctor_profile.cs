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
    public partial class doctor_profile : Form
    {
        SqlConnection con = new SqlConnection(global::WindowsFormsApplication1.Properties.Settings.Default.inside_470ConnectionString);

        public doctor_profile(string value)
        {
            InitializeComponent();
            userTextBox.Text = value;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void doctor_profile_Load(object sender, EventArgs e)
        {
            Random ran = new Random();
            int num = ran.Next(1, 500);
            //something has to be done
            string sql = "SELECT doc_id from [doc_info] ";
            try {
                SqlCommand exeSql = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = exeSql.ExecuteReader();
                

                while(reader.Read()){
                    if (num == reader.GetInt32(0)) {
                        num = ran.Next(1, 500);
                    }
                    
                }

                label10.Text = num+"";
            }
            catch (Exception en) {
                MessageBox.Show(en.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                con.Close();
            }  
        }

        private void label10_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(label10.Text);
            string f_user_id = userTextBox.Text;
            string name = textBox2.Text;
            int age = Convert.ToInt32(textBox3.Text);
            string sex = comboBox2.Text;
            string quali = richTextBox1.Text;
            int phone = Convert.ToInt32(textBox4.Text);
            string special = textBox5.Text;

            string sql = "INSERT INTO [doc_info] values ("+id+",'"+f_user_id+"','"+name+"',"+age+",'"+sex+"','"+quali+"',"+phone+",'"+special+"')";
            try
            {
                SqlCommand exeSql = new SqlCommand(sql, con);
                con.Open();
                exeSql.ExecuteNonQuery();
                MessageBox.Show("Saved", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Doctor_s_Form newForm = new Doctor_s_Form(name);
                newForm.Show();
                this.Hide(); 
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }


        }

        private void userTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //something has to be done
            string sql = "SELECT * from [doc_info]";
            try
            {
                SqlCommand exeSql = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = exeSql.ExecuteReader();
                string val = "";
                Random ran = new Random();
                
                while (reader.Read())
                {

                    val = val + reader.GetInt32(0).ToString() + " "+reader.GetString(1).ToString();
                }

                MessageBox.Show(val, "Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }  
        }
    }
}
