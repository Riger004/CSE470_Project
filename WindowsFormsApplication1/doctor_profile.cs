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
        SqlConnection con2 = new SqlConnection(global::WindowsFormsApplication1.Properties.Settings.Default.inside_470ConnectionString);
        SqlConnection con3 = new SqlConnection(global::WindowsFormsApplication1.Properties.Settings.Default.inside_470ConnectionString);
        bool checking = false;
        bool time = false;
        public doctor_profile(string value)
        {
            InitializeComponent();
            userTextBox.Text = value;
        }



        private void doctor_profile_Load(object sender, EventArgs e)
        {
            Random ran = new Random();
            int num = ran.Next(1, 500);
            //something has to be done
            string sql = "SELECT * from [doc_info] where f_doc_user_id='" + userTextBox.Text + "'";
            string kk = userTextBox.Text;
            try
            {
                SqlCommand exeSql = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = exeSql.ExecuteReader();

                while (reader.Read())
                {

                    if (num == reader.GetInt32(0))
                    {

                        num = ran.Next(1, 500);
                    }
                    if (userTextBox.Text.Equals(reader.GetString(1)))
                    {
                        checking = true;

                        label10.Text = reader.GetInt32(0) + "";
                        textBox2.Text = reader.GetString(2);

                        textBox3.Text = reader.GetInt32(3) + "";
                        comboBox2.Text = reader.GetString(4);
                        richTextBox1.Text = reader.GetString(5);
                        textBox4.Text = reader.GetInt32(6) + "";
                        textBox5.Text = reader.GetString(7);
                    }

                    // reader.Close();
                }
                if (checking == true)
                {

                    string sql_time_check = "SELECT f_doc_id from [time_for_doc] where f_doc_id=" +label10.Text + "";
                    con3.Open();
                    SqlCommand time_check = new SqlCommand(sql_time_check, con3);
                    SqlDataReader reader_time = time_check.ExecuteReader();
                    time = false;
                    while (reader_time.Read())
                    {
                        if (Convert.ToInt32(label10.Text) == reader_time.GetInt32(0))
                        {
                            time = true;
                        }
                    }

                    if (time)
                    {
                        label11.Text = "if you want you can change your time schedual ";
                    }
                    else
                    {
                        label11.Text = "you have to fix your time schedual ";
                    }

                }
                if (checking == false)
                {
                    label10.Text = num + "";
                    // MessageBox.Show("something is wrong ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message + kk + " from here ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
                con3.Close();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checking == false)
            {
                int id = Convert.ToInt32(label10.Text);
                string f_user_id = userTextBox.Text;
                string name = textBox2.Text;
                int age = Convert.ToInt32(textBox3.Text);
                string sex = comboBox2.Text;
                string quali = richTextBox1.Text;
                int phone = Convert.ToInt32(textBox4.Text);
                string special = textBox5.Text;


                string sql = "INSERT INTO [doc_info] values (" + id + ",'" + f_user_id + "','" + name + "'," + age + ",'" + sex + "','" + quali + "'," + phone + ",'" + special + "')";
                try
                {
                    SqlCommand exeSql = new SqlCommand(sql, con);
                    con.Open();
                    exeSql.ExecuteNonQuery();

                    {
                        MessageBox.Show("Saved", "Congrats", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Doctor_s_Form newForm = new Doctor_s_Form(f_user_id);
                        newForm.Show();
                        this.Hide();
                    }

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
            else
            {
                int id = Convert.ToInt32(label10.Text);
                string f_user_id = userTextBox.Text;
                string name = textBox2.Text;
                int age = Convert.ToInt32(textBox3.Text);
                string sex = comboBox2.Text;
                string quali = richTextBox1.Text;
                int phone = Convert.ToInt32(textBox4.Text);
                string special = textBox5.Text;


                string sql = "UPDATE [doc_info] set  name='" + name + "',age=" + age + ",sex='" + sex + "',qualification='" + quali + "',phone_num=" + phone + ",specialities='" + special + "' where doc_id="+id+"";
                try
                {
                    SqlCommand exeSql = new SqlCommand(sql, con);
                    con.Open();
                    exeSql.ExecuteNonQuery();

                    {
                        MessageBox.Show("updated", "Congrats", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Doctor_s_Form newForm = new Doctor_s_Form(f_user_id);
                        newForm.Show();
                        this.Hide();
                    }

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

        private void userTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //something has to be done
            string sql = "SELECT * from [time_for_doc]";
            try
            {
                SqlCommand exeSql = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = exeSql.ExecuteReader();
                string val = "";
                Random ran = new Random();

                while (reader.Read())
                {

                    val = val + reader.GetInt32(0).ToString() + " " + reader.GetInt32(8).ToString()+" "+ reader.GetBoolean(1)+" "+reader.GetBoolean(2).ToString();
                }
                if (checking == true)
                {
                    MessageBox.Show(val, "Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
            if (!time)
            {

                Random ran = new Random();
                int num = ran.Next(1, 500);

                int sunday = 0;
                int monday = 0;
                int tuesday = 0;
                int wednesday = 0;
                int thursday = 0;
                int saturday = 0;

                if (checkBox1.Checked)
                {
                    sunday = 1;
                }

                if (checkBox2.Checked)
                {
                    monday = 1;
                }

                if (checkBox3.Checked)
                {
                    tuesday = 1;
                }

                if (checkBox4.Checked)
                {
                    wednesday = 1;
                }

                if (checkBox5.Checked)
                {
                    thursday = 1;
                }

                if (checkBox6.Checked)
                {
                    saturday = 1;
                }

                string combo = comboBox1.Text;
                string sql1 = "INSERT INTO [time_for_doc]  values (" + num + "," + sunday + "," + monday + "," + tuesday + "," + wednesday + "," + thursday + "," + saturday + ",'" + combo + "', " + label10.Text + ")";
                try
                {
                    SqlCommand exe = new SqlCommand(sql1, con2);
                    con2.Open();
                    exe.ExecuteNonQuery();
                    MessageBox.Show("your schedual has been set", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception en)
                {

                    MessageBox.Show(en.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    con2.Close();
                }
            }
            else {

                int sunday = 0;
                int monday = 0;
                int tuesday = 0;
                int wednesday = 0;
                int thursday = 0;
                int saturday = 0;

                if (checkBox1.Checked)
                {
                    sunday = 1;
                }

                if (checkBox2.Checked)
                {
                    monday = 1;
                }

                if (checkBox3.Checked)
                {
                    tuesday = 1;
                }

                if (checkBox4.Checked)
                {
                    wednesday = 1;
                }

                if (checkBox5.Checked)
                {
                    thursday = 1;
                }

                if (checkBox6.Checked)
                {
                    saturday = 1;
                }

                string combo = comboBox1.Text;
                string sql1 = "UPDATE [time_for_doc]  set sunday=" + sunday + ", monday=" + monday + ",tuesday=" + tuesday + ",wednesday=" + wednesday + ",thursday=" + thursday + ",saturday=" + saturday + ",time_allocate='" + combo + "', f_doc_id=" + label10.Text + "";
                try
                {
                    SqlCommand exe = new SqlCommand(sql1, con2);
                    con2.Open();
                    exe.ExecuteNonQuery();
                    MessageBox.Show("updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception en)
                {

                    MessageBox.Show(en.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    con2.Close();
                }


            }
        }

    }
}

