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
    public partial class Drug_profile : Form
    {
        SqlConnection con = new SqlConnection(global::WindowsFormsApplication1.Properties.Settings.Default.inside_470ConnectionString);
        private int drug_id = -1;
        public Drug_profile()
        {
            InitializeComponent();
            Random ran = new Random();
             drug_id = ran.Next(1, 2550);

            string sql_check_for_drug_id = "SELECT drug_id from [drug_info]";

            try
            {
                SqlCommand exe = new SqlCommand(sql_check_for_drug_id, con);
                con.Open();
                SqlDataReader reader = exe.ExecuteReader();
                while (reader.Read())
                {
                    if (drug_id == reader.GetInt32(0))
                    {
                        drug_id = ran.Next(1, 2550);
                    }
                }
                label5.Text = drug_id + "";
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message + " problem parsing the data from drug_info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin form = new Admin();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string drug_name=textBox3.Text;
            double money=Convert.ToDouble(textBox2.Text);
            string type = textBox4.Text;

            string sql_data_saving_into_drug_info = "INSERT into [drug_info] values("+drug_id+",'"+drug_name+"',"+money+",'"+type+"')";
            try {
                SqlCommand exe = new SqlCommand(sql_data_saving_into_drug_info, con);
                con.Open();
                exe.ExecuteNonQuery();
                MessageBox.Show("data has been saved", "saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception en){
                MessageBox.Show(en.Message + " problem saving data into drug_info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally{
                con.Close();
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            String checking_data_is_stored = "SELECT * from [drug_info]";
            try {
                SqlCommand exe = new SqlCommand(checking_data_is_stored, con);
                con.Open();
                SqlDataReader reader = exe.ExecuteReader();
                string data="";
                while(reader.Read()){
                    data = reader.GetString(1) + " " + reader.GetDecimal(2);
                }
                MessageBox.Show(data, "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception en){
                MessageBox.Show(en.Message + "data was not saved into drug_info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally{
                con.Close();
            }
        }
    }
}
