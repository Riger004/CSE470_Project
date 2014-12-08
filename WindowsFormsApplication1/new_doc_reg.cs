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
    public partial class new_doc_reg : Form
    {
        SqlConnection con = new SqlConnection(global::WindowsFormsApplication1.Properties.Settings.Default.inside_470ConnectionString);
        public new_doc_reg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string user_name = textBox1.Text;
                string email = textBox2.Text;
                string pass = textBox3.Text;
                string dou_pass = textBox4.Text;
                string type = label6.Text;

                if (!pass.Equals(dou_pass))
                {
                    MessageBox.Show("password mismatched", "pass_error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string sql = "INSERT INTO [log_info] values('" + user_name + "','" + email + "','" + pass + "','" + type + "')";
                    SqlCommand exeSql = new SqlCommand(sql, con);
                    con.Open();
                    exeSql.ExecuteNonQuery();

                    MessageBox.Show("saved", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void button8_Click(object sender, EventArgs e)
        {
            registration newForm = new registration();
            this.Hide();
            newForm.Show();
        }
    }
}
