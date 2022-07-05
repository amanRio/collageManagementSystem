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
    public partial class Employee : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        public Employee()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            con.Open();
            cmd = new SqlCommand("select * from employee", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                count++;
            }
            con.Close();
            int employeeid = (count + 1);
            string employee_name = textBox1.Text;
            string contact = textBox3.Text;
            string email = textBox4.Text;
            string address = textBox2.Text;
            string role = comboBox1.Text;

            con.Open();
            cmd.CommandText = "insert into employee values (" + employeeid + ",'" + employee_name + "','" + contact + "','" + email + "','" + address + "','" + role + "')";
            reader = cmd.ExecuteReader();
            con.Close();
            con.Open();
            cmd.CommandText = "insert into login values ('" + email + "','" + email + "','" + role + "','"+0+ "','" + employeeid + "')";
                reader = cmd.ExecuteReader(); 
            con.Close();
            MessageBox.Show("Employee registered successfully");


            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void Employee_Load(object sender, EventArgs e)
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
