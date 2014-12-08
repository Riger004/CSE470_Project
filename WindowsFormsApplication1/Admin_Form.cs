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
        public partial class Admin_Form : Form
        {
            String Name;
            String email;
            String password;
            String type;
            SqlConnection test = new SqlConnection(global::WindowsFormsApplication1.Properties.Settings.Default.AdminConnectionString);

            public Admin_Form()
            {
                InitializeComponent();
            }
            public Admin_Form(String Name, String email, String password,String type)
            {
                this.Name = Name;
                this.email = email;
                this.password = password;
                this.type = type;
                InitializeComponent();
                
                /*try
                {

                    string data_input = "INSERT INTO [DataTable1] values('" + Name + "','" + email + "','" + password + "','" + type + "')";
                    SqlCommand exeSql = new SqlCommand(data_input, test);
                    test.Open();
                    exeSql.ExecuteNonQuery();
                }
                finally
                {
                    test.Close();
                }*/

            }

            private void Admin_Form_Load(object sender, EventArgs e)
            {

            }

            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

            private void button1_Click(object sender, EventArgs e)
            {
                dataGridView1.Show();

                string data_input = "INSERT INTO [DataTable1] values('" + Name + "','" + email + "','" + password + "','" + type + "')";
                 
                
                try
                {
                    SqlCommand exeSql = new SqlCommand(data_input, test);
                    test.Open();
                    DataTable data = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(exeSql);
                    adapter.Fill(data);
                    dataGridView1.DataSource = data;


                    //while(){}
                }
                catch (Exception en)
                {
                    MessageBox.Show(en.Message + "Parsing Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    test.Close();
                }
            }
        }
    }
