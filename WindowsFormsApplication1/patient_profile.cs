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
    public partial class patient_profile : Form
    {
        SqlConnection con = new SqlConnection(global::WindowsFormsApplication1.Properties.Settings.Default.inside_470ConnectionString);
        public patient_profile(string val)
        {
            InitializeComponent();
            label9.Text = val;

            string sql = "SELECT patient_id from [patient_info]";
            Random ran=new Random();
            int num=ran.Next(1,500);
            try {
                SqlCommand exe = new SqlCommand(sql,con);
                con.Open();
                SqlDataReader reader= exe.ExecuteReader();
                while(reader.Read()){
                    if (num == reader.GetInt32(0)) {
                        num = ran.Next(1, 500);
                    }
                }
                reader.Close();
                label8.Text = num+"";
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally {
                con.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int patient_id = Convert.ToInt32(label8.Text);
            string user_id = label9.Text;
            string name = textBox1.Text;
            int age = Convert.ToInt32(textBox2.Text);
            int weight = Convert.ToInt32(textBox3.Text);
            string past_med_hist = richTextBox1.Text;
            int contact_num = Convert.ToInt32(textBox4.Text);

            string sql = "INSERT into [patient_info] values("+patient_id+",'"+user_id+"','"+name+"',"+age+","+weight+",'"+past_med_hist+"',"+contact_num+")";
          
            try
            {
                SqlCommand exe = new SqlCommand(sql, con);
                con.Open();
                exe.ExecuteNonQuery();
                MessageBox.Show("Patient record saved", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                con.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * from [patient_info]";

            try
            {
                SqlCommand exe = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = exe.ExecuteReader();
                string val = "";
                while (reader.Read())
                {
                    val = val + reader.GetString(2).ToString()+" ";
                }
                reader.Close();
                MessageBox.Show(val, "data", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button3_Click(object sender, EventArgs e)
        {
            string user_id = label9.Text;
            string sql = "SELECT user_id from [log_info] where  (user_id ='"+user_id+"')";
            try
            {
                SqlCommand exe = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = exe.ExecuteReader();

                bool contain = false;

                while(reader.Read()){
                    if (user_id.Equals(reader.GetString(0))) {
                        contain = true;
                    }
                }

                if (contain)
                {
                    con.Close();
                    string sql2 = "SELECT patient_id from [patient_info] where  (f_user_id ='" + user_id + "')";
                    exe = new SqlCommand(sql2, con);
                    con.Open();
                    reader = exe.ExecuteReader();
                    int num = 0;

                    while (reader.Read())
                    {
                        num = reader.GetInt32(0);
                    }
                    if (num != 0)
                    {
                        Appointment form = new Appointment(num+"");
                        form.Show();
                        this.Hide();
                    }
                    else {
                        MessageBox.Show("Please Create your profile before making an appointment", "Contain", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else {
                    MessageBox.Show("Please Create your profile before making an appointment", "Contain", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
               

            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message + "sorry your patient id doesn't exist you have to create you profile", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            login newForm = new login();
            newForm.Show();
        }
    }
}
