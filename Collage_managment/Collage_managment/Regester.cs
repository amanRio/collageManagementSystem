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
    public partial class Regester : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        public Regester()
        {
            InitializeComponent();
        }

        private void Regester_Load(object sender, EventArgs e)
        {
            try {
                con = new SqlConnection(@"data source=LAPTOP-4U4PP0RU;initial catalog=College;integrated security=true");

            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
         }
     

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int count = 0;
            con.Open();
            cmd = new SqlCommand("select * from students", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                count++;
            }
            con.Close();
            int studentid = (count + 1);
            string student_name = textBox1.Text;
            string dob = dateTimePicker1.Text;
            string gender = comboBox1.Text;
            string contact = textBox2.Text;
            string address = textBox3.Text;
            string gpa = textBox5.Text;
            string email = textBox4.Text;
            string role = "student";

            if (Convert.ToDouble(gpa) > 3)
            {
                con.Open();
                cmd.CommandText = "insert into students values (" + studentid + ",'" + student_name + "','" + dob + "','" + gender + "','" + contact + "','" + address + "','" + email + "','" + gpa + "','Q')";
                reader = cmd.ExecuteReader();
                con.Close();
                con.Open();
                cmd.CommandText = "insert into login values ('" + email + "','" + email + "','" + role + "','" + 0 + "','" + studentid + "')";
                reader = cmd.ExecuteReader();
                con.Close();

                MessageBox.Show("You qulaify for enrollment your student number is" + studentid.ToString());

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                comboBox1.Text = "";
               
            }
            else
            {
                MessageBox.Show("You do not qulaify for enrollment");
            }
        }
    }
}
