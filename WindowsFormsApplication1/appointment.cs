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
using System.Text.RegularExpressions;
using System.Globalization;


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


            string doc_info = "SELECT doc_id,name from [doc_info]";

            try
            {
                SqlCommand exe = new SqlCommand(doc_info, con);
                con.Open();
                SqlDataReader reader = exe.ExecuteReader();

                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetInt32(0) + " " + reader.GetString(1));

                }

                reader.Close();
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message, "error in parsing doc name in appo_form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            int id = Convert.ToInt32(patient_id);
            doc_info = "SELECT name, past_med_hist from [patient_info] where patient_id=" + id + "";
            try
            {
                SqlCommand exe = new SqlCommand(doc_info, con2);
                con2.Open();
                SqlDataReader reader = exe.ExecuteReader();
                string val1 = "";
                string val2 = "";
                while (reader.Read())
                {
                    val1 = reader.GetString(0);
                    val2 = reader.GetString(1);
                }
                reader.Close();
                textBox1.Text = val1;
                richTextBox1.Text = val2;
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message, "error in parsing patient name in appo_form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con2.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //here is problem
            DateTime dateVale = monthCalendar1.SelectionStart.Date;

            string resultString = comboBox1.Text;
            resultString = Regex.Replace(resultString, "[^0-9]+", string.Empty);
            int doc_quali_id = Convert.ToInt32(resultString);

            string sql_date_time_doc = "SELECT * from[date_appoin] where date='" + textBox3.Text + "' AND f_doc_id=" + doc_quali_id + "";

            bool exist_doc_date = false;
            try
            {
                SqlCommand exe = new SqlCommand(sql_date_time_doc, con);
                con.Open();
                SqlDataReader reader = exe.ExecuteReader();
                int array = 0;
                while (reader.Read())
                {
                    if (doc_quali_id == reader.GetInt32(2))
                    {
                        exist_doc_date = true;
                    }
                    array = array + reader.GetInt32(1);
                }
                reader.Close();

                if (exist_doc_date)
                {
                    //label7.Text = array + "";
                    if (array + 1 <= 20)
                    {

                        string update_sql = "UPDATE [date_appoin] SET date='" + textBox3.Text + "',number_of_appointments=" + (++array) + ",f_doc_id=" + doc_quali_id + "";

                        try
                        {
                            SqlCommand exe_update_date_appoin = new SqlCommand(update_sql, con2);
                            con2.Open();
                            exe_update_date_appoin.ExecuteNonQuery();
                            MessageBox.Show("updated", "saved data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception en)
                        {
                            MessageBox.Show(en.Message, "facing problem while updating the date_appoin table", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            con2.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("sorry all the appointments taken", "ops", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {

                    string sql_insert_for_date_appoin = "INSERT into [date_appoin] values ('" + textBox3.Text + "'," + 1 + "," + Convert.ToInt32(resultString) + ")";
                    try
                    {
                        SqlCommand exe_insert = new SqlCommand(sql_insert_for_date_appoin, con2);
                        con2.Open();
                        exe_insert.ExecuteNonQuery();
                        MessageBox.Show("alright", "no prob writing time and doc_id into date_appoin table", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception en)
                    {
                        MessageBox.Show(en.Message, "prob writing time and doc_id into date_appoin table", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        con2.Close();
                    }
                }
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message, "Error getting the time and doc_id from date_appoin table", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
                con2.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string resultString = comboBox1.Text;
            resultString = Regex.Replace(resultString, "[^0-9]+", string.Empty);
            int doc_quali_id = Convert.ToInt32(resultString);

            string sql_doc_quali = "SELECT qualification from [doc_info] where doc_id=" + doc_quali_id + "";

            try
            {
                SqlCommand exe_doc_quali = new SqlCommand(sql_doc_quali, con);
                con.Open();
                SqlDataReader reader = exe_doc_quali.ExecuteReader();
                string quali = "";

                while (reader.Read())
                {
                    quali = quali + reader.GetString(0);
                }
                reader.Close();
                richTextBox2.Text = quali;
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message + " Error getting the qualification of doc", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

            string sql_time_for_doc = "SELECT sunday, monday,tuesday, wednesday,thursday,saturday, time_allocate from [time_for_doc] where f_doc_id=" + doc_quali_id + "";

            try
            {
                SqlCommand exe_doc_quali = new SqlCommand(sql_time_for_doc, con);
                con.Open();
                SqlDataReader reader = exe_doc_quali.ExecuteReader();


                bool sunday = false;
                bool monday = false;
                bool tuesday = false;
                bool wednesday = false;
                bool thursday = false;
                bool saturday = false;
                string time_allocate = "";
                while (reader.Read())
                {
                    if (reader.GetBoolean(0))
                    {
                        sunday = true;
                    }
                    if (reader.GetBoolean(1))
                    {
                        monday = true;
                    }
                    if (reader.GetBoolean(2))
                    {
                        tuesday = true;
                    }
                    if (reader.GetBoolean(3))
                    {
                        wednesday = true;
                    }
                    if (reader.GetBoolean(4))
                    {
                        thursday = true;
                    }
                    if (reader.GetBoolean(5))
                    {
                        saturday = true;
                    }
                    time_allocate = reader.GetString(6);
                }

                reader.Close();

                if (sunday)
                {
                    comboBox2.Items.Add("sunday at " + time_allocate);
                }
                if (monday)
                {
                    comboBox2.Items.Add("monday at " + time_allocate);
                }
                if (tuesday)
                {
                    comboBox2.Items.Add("tuesday at " + time_allocate);
                }
                if (wednesday)
                {
                    comboBox2.Items.Add("wednesday at " + time_allocate);
                }
                if (thursday)
                {
                    comboBox2.Items.Add("thursday at " + time_allocate);
                }
                if (saturday)
                {
                    comboBox2.Items.Add("saturday at " + time_allocate);
                }
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message + " Error getting the time of doc", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox3.Text = monthCalendar1.SelectionStart.ToString("yyyy-MM-dd");
            DateTime dateValue;
            dateValue = monthCalendar1.SelectionStart;
            // label8.Text = (int)dateValue.DayOfWeek + "";

            int value_of_sunday = 0;
            int value_of_monday = 1;
            int value_of_tuesday = 2;
            int value_of_wednesday = 3;
            int value_of_thursday = 4;
            int value_of_saturday = 6;

            string patient_choosen_date = comboBox2.Text;
            string[] ssize = patient_choosen_date.Split(null);

            if ((int)dateValue.DayOfWeek == value_of_sunday)
            {
                if (ssize[0].Equals("sunday"))
                    label8.Text = "sunday ";
                else
                    MessageBox.Show("please choose the specific day specified by doctor", "error in parsing doc name in appo_form", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            if ((int)dateValue.DayOfWeek == value_of_monday)
            {
                if (ssize[0].Equals("monday"))
                    label8.Text = "monday";
                else
                    MessageBox.Show("please choose the specific day specified by doctor", "error in parsing doc name in appo_form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if ((int)dateValue.DayOfWeek == value_of_tuesday)
            {
                if (ssize[0].Equals("tuesday"))
                    label8.Text = "tuesday";
                else
                    MessageBox.Show("please choose the specific day specified by doctor", "error in parsing doc name in appo_form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if ((int)dateValue.DayOfWeek == value_of_wednesday)
            {
                if (ssize[0].Equals("wednesday"))
                    label8.Text = "wednesday";
                else
                    MessageBox.Show("please choose the specific day specified by doctor", "error in parsing doc name in appo_form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if ((int)dateValue.DayOfWeek == value_of_thursday)
            {
                if (ssize[0].Equals("thursday"))
                    label8.Text = "thursday ";
                else
                    MessageBox.Show("please choose the specific day specified by doctor", "error in parsing doc name in appo_form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if ((int)dateValue.DayOfWeek == value_of_saturday)
            {
                if (ssize[0].Equals("saturday"))
                    label8.Text = "saturday ";
                else
                    MessageBox.Show("please choose the specific day specified by doctor", "error in parsing doc name in appo_form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();



        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql_show_app = "SELECT * from [date_appoin]";
            try
            {
                SqlCommand exe = new SqlCommand(sql_show_app, con);
                con.Open();
                SqlDataReader reader = exe.ExecuteReader();
                string val = "";
                while (reader.Read())
                {
                    val = val + reader.GetString(0) + " number= " + reader.GetInt32(1) + " " + reader.GetInt32(2);
                }
                MessageBox.Show(val, "successful in stroing data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message, "error in parsing doc name in appo_form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
        private void button4_Click_1(object sender, EventArgs e)
        {

            Random ran = new Random();
            int num = ran.Next(1, 500);

            string sql_for_appointment = "SELECT app_id from [appointment_info]";

            try
            {
                SqlCommand exe_checking = new SqlCommand(sql_for_appointment, con);
                con.Open();
                SqlDataReader reader = exe_checking.ExecuteReader();

                while (reader.Read())
                {
                    if (num == reader.GetInt32(0))
                    {
                        num = ran.Next(1, 500);
                    }
                }
                reader.Close();
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message + " problem in getting proper app_id in appointment_info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

            int f_patient_id = Convert.ToInt32(textBox2.Text);
            string resultString = comboBox1.Text;
            resultString = Regex.Replace(resultString, "[^0-9]+", string.Empty);
            int f_doc_id = Convert.ToInt32(resultString);
            string problem = richTextBox3.Text;
            string date = textBox3.Text;

            sql_for_appointment="INSERT into [appointment_info] values ("+num+","+f_patient_id+","+f_doc_id+",'"+problem+"','"+date+"',"+0+")";

            try {
                SqlCommand exe_for_appintment = new SqlCommand(sql_for_appointment, con);
                con.Open();
                exe_for_appintment.ExecuteNonQuery();
                MessageBox.Show("saved data in the appointment_info table", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message + "problem in saving data in the appiontment_info table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                con.Close();
            }
        }

      /*  private void button5_Click(object sender, EventArgs e)
        {
            string appint_info = "SELECT * from [appointment_info]";
            try {
                SqlCommand exe_info = new SqlCommand(appint_info, con);
                con.Open();
                SqlDataReader reader = exe_info.ExecuteReader();
                string val = "";
                while(reader.Read()){
                    val = val + " "+reader.GetInt32(1) +" "+reader.GetInt32(2)+" " + reader.GetString(3) + " " + reader.GetString(4);
                }
                reader.Close();
                MessageBox.Show(val, "showing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception en) {
                MessageBox.Show(en.Message + " no data was saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                con.Close();
            }
        }*/
    }
}