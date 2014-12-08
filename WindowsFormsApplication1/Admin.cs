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
    public partial class Admin : Form
    {
        SqlConnection con = new SqlConnection(global::WindowsFormsApplication1.Properties.Settings.Default.inside_470ConnectionString);
        public Admin()
        {
            InitializeComponent();
            auto_complete();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Drug_profile form = new Drug_profile();
            form.Show();
            this.Hide();
        }


        private void auto_complete()
        {

            textBox1.AutoCompleteMode = AutoCompleteMode.Append;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            string sql_name_search_for_patient = "SELECT name from [patient_info]";

            try
            {
                SqlCommand exe = new SqlCommand(sql_name_search_for_patient, con);
                con.Open();
                SqlDataReader reader = exe.ExecuteReader();
                while (reader.Read())
                {
                    coll.Add(reader.GetString(0));
                }
                textBox1.AutoCompleteCustomSource = coll;
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message + " error in autocomplete searching in patient_info", " ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

            string sql_name_search_for_doctor = "SELECT name from [doc_info]";

            try
            {
                SqlCommand exe = new SqlCommand(sql_name_search_for_doctor, con);
                con.Open();
                SqlDataReader reader = exe.ExecuteReader();
                while (reader.Read())
                {
                    coll.Add(reader.GetString(0));
                }
                textBox1.AutoCompleteCustomSource = coll;
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message + " error in autocomplete searching in doc_info", " ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

            string sql_name_search_for_drugs = "SELECT name from [drug_info]";

            try
            {
                SqlCommand exe = new SqlCommand(sql_name_search_for_drugs, con);
                con.Open();
                SqlDataReader reader = exe.ExecuteReader();
                while (reader.Read())
                {
                    coll.Add(reader.GetString(0));
                }
                textBox1.AutoCompleteCustomSource = coll;
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message + " error in autocomplete searching in drug_info", " ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }




        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                string sql_search_for_patient = "SELECT * from [patient_info] where name LIKE '%" + textBox1.Text + "'";

                try
                {
                    SqlCommand exe = new SqlCommand(sql_search_for_patient, con);
                    con.Open();
                    DataTable data = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(exe);
                    adapter.Fill(data);
                    dataGridView1.DataSource = data;
                }
                catch (Exception en)
                {
                    MessageBox.Show(en.Message + " not getting the name from patient_info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
            if (checkBox2.Checked)
            {
                string sql_search_for_doc = "SELECT * from [doc_info] where name LIKE '%" + textBox1.Text + "'";

                try
                {
                    SqlCommand exe = new SqlCommand(sql_search_for_doc, con);
                    con.Open();
                    DataTable data = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(exe);
                    adapter.Fill(data);
                    dataGridView1.DataSource = data;
                }
                catch (Exception en)
                {
                    MessageBox.Show(en.Message + " not getting the name from doc_info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }

            if (checkBox3.Checked)
            {
                string sql_search_for_drug = "SELECT * from [drug_info] where name LIKE '%" + textBox1.Text + "'";

                try
                {
                    SqlCommand exe = new SqlCommand(sql_search_for_drug, con);
                    con.Open();
                    DataTable data = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(exe);
                    adapter.Fill(data);
                    dataGridView1.DataSource = data;
                }
                catch (Exception en)
                {
                    MessageBox.Show(en.Message + " not getting the name from doc_info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql_statement_for_transaction_info = "SELECT * from [transaction_info]";
            try {
                SqlCommand exe = new SqlCommand(sql_statement_for_transaction_info, con);
                con.Open();
                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(exe);
                adapter.Fill(data);
                dataGridView1.DataSource = data;
            }
            catch(Exception en){
                MessageBox.Show(en.Message + " error in transaction_info", " ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally{
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql_statement_for_appointments = "SELECT * from [appointment_info]";
            try
            {
                SqlCommand exe = new SqlCommand(sql_statement_for_appointments, con);
                con.Open();
                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(exe);
                adapter.Fill(data);
                dataGridView1.DataSource = data;
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message + " error in transaction_info", " ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new_doc_reg form = new new_doc_reg();
            form.Show();
        }

    }
}
