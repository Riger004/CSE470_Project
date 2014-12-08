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
using System.Collections;
namespace WindowsFormsApplication1
{
    public partial class Doctor_s_Form : Form
    {
        SqlConnection con = new SqlConnection(global::WindowsFormsApplication1.Properties.Settings.Default.inside_470ConnectionString);
        string text_id_doc = "";
        int doc_id = -1;
        public Doctor_s_Form(string val)
        {
            InitializeComponent();
            auto_complete_text();
            label1.Text = "Welcome Doc " + val + " have a nice time";
            text_id_doc = val;

            string sql_data_for_doc_id = "SELECT doc_id from [doc_info] where f_doc_user_id='" + text_id_doc + "'";

            try
            {
                SqlCommand exe_doc_id = new SqlCommand(sql_data_for_doc_id, con);
                con.Open();
                SqlDataReader reader = exe_doc_id.ExecuteReader();
                while (reader.Read())
                {
                    doc_id = reader.GetInt32(0);
                }
                reader.Close();

            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message + "facing error in parsing data from doc_info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }


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
            dataGridView1.Show();
            string sql_data_from_appoint = "SELECT f_patient_id from [appointment_info] where f_doc_id=" + doc_id + "";
            ArrayList array = new ArrayList();
            try {
                SqlCommand exe = new SqlCommand(sql_data_from_appoint, con);
                con.Open();
                SqlDataReader reader = exe.ExecuteReader();
                while(reader.Read()){
                    array.Add(reader.GetInt32(0));
                }
                reader.Close();
            }
            catch (Exception en) {
                MessageBox.Show(en.Message + " Error in getting patient_id from appointment_info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally {
                con.Close();
            }

            string sql_data_from_patient_info = "SELECT name,age,weight,past_med_hist,contact_num from [patient_info] where patient_id =" + array[0] + "";
            for (int i = 1; i < array.Count; i++) {
                sql_data_from_patient_info = sql_data_from_patient_info + "OR patient_id=" + array[1] + "";
            }

            try {
                SqlCommand exe = new SqlCommand(sql_data_from_patient_info, con);
                con.Open();
                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(exe);
                adapter.Fill(data);
                dataGridView1.DataSource = data;
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message + " Error in getting patient_id from patient_info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally {
                con.Close();
            }

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

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
            string date = DateTime.Today.ToString("yyyy-MM-dd");
            label2.Text = date;
            string sql_data_form_appoint = "SELECT * from [appointment_info] where f_doc_id =" + doc_id + " AND date='"+date+"'";
            try {
                SqlCommand exe = new SqlCommand(sql_data_form_appoint, con);
                con.Open();
                DataTable data=new DataTable();
                SqlDataAdapter adapter=new SqlDataAdapter(exe);
                adapter.Fill(data);
                dataGridView1.DataSource = data;

               
                //while(){}
            }
            catch (Exception en) {
                MessageBox.Show(en.Message + "facing error in parsing data from appointment_info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            doctor_profile form = new doctor_profile(text_id_doc);
            form.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*string sql_data_form_appoint = "SELECT * from [appointment_info] where f_doc_id =" + doc_id + "";
            try {
                SqlCommand exe = new SqlCommand(sql_data_form_appoint, con);
                //dataGridView1 conn = new dataGridView1(global::WindowsFormsApplication1.Properties.Settings);
                con.Open();
                SqlDataReader reader = exe.ExecuteReader();
                //while(){}
            }
            catch (Exception en) {
                MessageBox.Show(en.Message + "facing error in parsing data from appointment_info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                con.Close();
            }*/

        }


        private void auto_complete_text() {
            textBox1.AutoCompleteMode = AutoCompleteMode.Append;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            string sql_name_search_for_patient = "SELECT name from [patient_info]";

            try {
                SqlCommand exe = new SqlCommand(sql_name_search_for_patient, con);
                con.Open();
                SqlDataReader reader = exe.ExecuteReader();
                while(reader.Read()){
                    coll.Add(reader.GetString(0));
                }
                textBox1.AutoCompleteCustomSource = coll;
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message + " error in autocomplete searching", " ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                con.Close();
            }

          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Show();
            //for searching the name of the patient
            string sql_data_from_appoint = "SELECT f_patient_id from [appointment_info] where f_doc_id=" + doc_id + "";
            ArrayList array = new ArrayList();
            try
            {
                SqlCommand exe = new SqlCommand(sql_data_from_appoint, con);
                con.Open();
                SqlDataReader reader = exe.ExecuteReader();
                while (reader.Read())
                {
                    array.Add(reader.GetInt32(0));
                }
                reader.Close();
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message + " Error in searching 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                con.Close();
            }

            string sql_data_from_patient_info = "SELECT name,age,weight,past_med_hist,contact_num from [patient_info] where patient_id =" + array[0] + " AND name LIKE '%"+textBox1.Text+"'";
            for (int i = 1; i < array.Count; i++)
            {
                sql_data_from_patient_info = sql_data_from_patient_info + "OR patient_id=" + array[i] + " AND name LIKE '%" + textBox1.Text + "'";
            }

            try
            {
                SqlCommand exe = new SqlCommand(sql_data_from_patient_info, con);
                con.Open();
                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(exe);
                adapter.Fill(data);
                dataGridView1.DataSource = data;
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message + " Error in searching 2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                con.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sql_for_sending_transaction_data_from_appointment="SELECT f_patient_id from [appointment_info] where f_doc_id=" + doc_id + "";
            int patient_id=-1;
            try {
                SqlCommand exe = new SqlCommand(sql_for_sending_transaction_data_from_appointment, con);
                con.Open();
                SqlDataReader reader = exe.ExecuteReader();
                while(reader.Read()){
                    patient_id = reader.GetInt32(0);
                }  
            }
            catch (Exception en) {
                MessageBox.Show(en.Message + "error in finding patient_id from appointment table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                con.Close();
            }
            if (patient_id == -1) {
                    MessageBox.Show("This patient didnot make any appointment", "no", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            else{
                prescription form = new prescription(patient_id + " "+ doc_id);
                form.Show();
                this.Hide();

            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            login newForm = new login();
            this.Close();
            newForm.Show();
        }
    }
}


