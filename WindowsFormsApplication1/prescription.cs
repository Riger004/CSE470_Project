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
    public partial class prescription : Form
    {
        SqlConnection con = new SqlConnection(global::WindowsFormsApplication1.Properties.Settings.Default.inside_470ConnectionString);
        private int transaction_id=-1;
        public prescription(string val)
        {
            InitializeComponent();
            auto_complete_text();
            string[] array = val.Split(null);
            label4.Text = array[0];
            label6.Text = array[1];
            label11.Text = DateTime.Now.ToString("d/MM/yyyy");
            Random ran = new Random();
            transaction_id = ran.Next(1, 500);
            string sql_for_transaction_id="SELECT transaction_id from [transaction_info] ";
            try{
            SqlCommand cmd = new SqlCommand(sql_for_transaction_id, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                if (transaction_id == reader.GetInt32(0)) 
                {
                    transaction_id = ran.Next(1, 500);
                }
            }
            }
            catch(Exception en){
                 MessageBox.Show(en.Message + "facing error in setting the transaction_id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally{
                con.Close();
            }
            label2.Text=transaction_id+"";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int patient_id=Convert.ToInt32(label4.Text);
            string sql_data_saved_into_patient_info = "SELECT past_med_hist from [patient_info] where patient_id= " + patient_id + "";
            string past_hist = "";
            try {
                SqlCommand exe = new SqlCommand(sql_data_saved_into_patient_info, con);
                con.Open();
                SqlDataReader reader = exe.ExecuteReader();
                while(reader.Read()){
                    past_hist = reader.GetString(0);
                }
            }
            catch (Exception en) {
                MessageBox.Show(en.Message + "facing error getting past_history from patient record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                con.Close();
            }

            past_hist = past_hist + "\nDoc_Id = " + Convert.ToInt32(label6.Text) + "\npescribed : " + richTextBox1.Text + "";
            past_hist = past_hist.Replace("\n", "\n" + System.Environment.NewLine);
            string sql_past_history="UPDATE [patient_info] set past_med_hist='"+past_hist+"' where patient_id = "+patient_id+"";
            try {
                SqlCommand exe = new SqlCommand(sql_past_history, con);
                con.Open();
                exe.ExecuteNonQuery();
                MessageBox.Show("Record updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception en){
                MessageBox.Show(en.Message + "facing error in updating the past_history in patient_info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally{
                con.Close();
            }
        }

        private void prescription_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inside_470DataSet.drug_info' table. You can move, or remove it, as needed.
            this.drug_infoTableAdapter.Fill(this.inside_470DataSet.drug_info);
           

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string sql_for_drug_info = "SELECT drug_id,name,price,type from [drug_info] where name LIKE '%"+textBox2.Text+"'";
            try {
                SqlCommand exe = new SqlCommand(sql_for_drug_info, con);
                con.Open();
                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(exe);
                adapter.Fill(data);
                dataGridView1.DataSource = data;
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message + "facing error in getting data from drug_info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                con.Close();
            }
        }

        private void auto_complete_text()
        {
            textBox2.AutoCompleteMode = AutoCompleteMode.Append;
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            string sql_name_search_for_patient = "SELECT name from [drug_info]";

            try
            {
                SqlCommand exe = new SqlCommand(sql_name_search_for_patient, con);
                con.Open();
                SqlDataReader reader = exe.ExecuteReader();
                while (reader.Read())
                {
                    coll.Add(reader.GetString(0));
                }
                textBox2.AutoCompleteCustomSource = coll;
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message + " error in autocomplete searching", " ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cash = textBox1.Text;
            if (cash.Length == 0)
            {
                MessageBox.Show("You sure you don't wanna charge this particular patient", "Watch it!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            int transaction_id = Convert.ToInt32(label2.Text);
            int f_patient = Convert.ToInt32(label4.Text);
            int f_doc = Convert.ToInt32(label6.Text);
            string prescription = richTextBox1.Text;
            int c_cash = Convert.ToInt32(cash);
            string date = label11.Text;

            string sql_data_saved_into_transaction_info = "INSERT into [transaction_info] values ("+transaction_id+","+f_patient+","+f_doc+",'"+prescription+"',"+c_cash+",'"+date+"') ";

            try {
                SqlCommand exe = new SqlCommand(sql_data_saved_into_transaction_info,con);
                con.Open();
                exe.ExecuteNonQuery();
                MessageBox.Show("data has been saved into transaction_info", "Saved!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception en){
                MessageBox.Show(en.Message+ " problem is saving data into transaction_info", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally{
                con.Close();
            }

            string fo_updating_appoint_info = "UPDATE [appointment_info] set checked_out =" + 1 + " where f_patient_id=" + f_patient + " AND f_doc_id=" + f_doc + "";
            try {
                SqlCommand exe = new SqlCommand(fo_updating_appoint_info,con);
                con.Open();
                exe.ExecuteNonQuery();
            }
            catch(Exception en){
                MessageBox.Show(en.Message + " prbolem in updating checked_out in appiointment_info", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally{
                con.Close();
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql_show_data = "SELECT * from [transaction_info]";

            try {
                SqlCommand exe = new SqlCommand(sql_show_data, con);
                con.Open();
                SqlDataReader reader = exe.ExecuteReader();
                string name = "";
                while(reader.Read()){
                    name = reader.GetString(3);
                }
                MessageBox.Show(name , "Data!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception en){
                MessageBox.Show(en.Message + " problem is saving data into transaction_info", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally{
                con.Close();
            }
        }
    }
}
