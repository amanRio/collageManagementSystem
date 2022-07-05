using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collage_managment
{
    public partial class Faculty : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;

        public Faculty()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           int facultyid = Convert.ToInt32(textBox1.Text);
            string facultyname = textBox2.Text;
            con.Open();
            string query = "insert into faculty values (" + facultyid + ",'" + facultyname + "')";
            cmd = new SqlCommand(query, con);
           
            reader = cmd.ExecuteReader();
            con.Close();
            MessageBox.Show("Faculty Registered Successfully");


            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void Faculty_Load(object sender, EventArgs e)
        {

            try
            {
                con = new SqlConnection(@"data source=LAPTOP-4U4PP0RU;initial catalog=College;integrated security=true");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
