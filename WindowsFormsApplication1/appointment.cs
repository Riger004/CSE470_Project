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
    public partial class appointment : Form
    {
        SqlConnection con = new SqlConnection(global::WindowsFormsApplication1.Properties.Settings.Default.inside_470ConnectionString);
        public appointment()
        {
            InitializeComponent();

            string sql = "SELECT app_id from [appointment_info]";
            Random ran = new Random();
            int num = ran.Next(1, 500);
            try
            {
                SqlCommand exe = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = exe.ExecuteReader();
                while (reader.Read())
                {
                    if (num == reader.GetInt32(0))
                    {
                        num = ran.Next(1, 500);
                    }
                }
                reader.Close();
                textBox1.Text = num + "";
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                con.Close();
            }

            //connecting to patient id
            sql = "SELECT patient_id from [patient_info]";
            
            try
            {
                SqlCommand exe = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = exe.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString(0));
                }
                reader.Close();
                
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                con.Close();
            }
            

            //connecting to Doc

            //connecting to patient id
            sql = "SELECT doc_id from [doc_info]";

            try
            {
                SqlCommand exe = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = exe.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader.GetString(0));
                }
                reader.Close();

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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox5.Text = monthCalendar1.SelectionStart.DayOfYear.ToString();
            textBox6.Text = monthCalendar1.SelectionStart.TimeOfDay.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int app_id = Convert.ToInt32(textBox1.Text);
            int patient_id = Convert.ToInt32(comboBox1.Text);
            int doc_id = Convert.ToInt32(comboBox2.Text);
            string problem = richTextBox1.Text;
            string date = textBox5.Text;
            string time = textBox6.Text;

            string sql = "INSERT INTO [appointment_info] values("+app_id+","+patient_id+","+doc_id+",'"+problem+"','"+date+"','"+time+"')";
            try {

                SqlCommand exe = new SqlCommand(sql, con);
                con.Open();
                exe.ExecuteNonQuery();
                MessageBox.Show("Success", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally {
                con.Close();
            }
        }
    }
}
