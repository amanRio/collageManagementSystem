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
    public partial class Login : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
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
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string pass = textBox2.Text;
            string role = "";
            int staus = 0;
            con.Open();
            cmd = new SqlCommand("select * from login", con);

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (username == reader.GetString(0) && pass == reader.GetString(1))
                {
                    role = reader.GetString(2);
                    staus = Convert.ToInt32(reader.GetInt32(4));

                }
            }
            if (role == "CollegeAdmin")
            {
                if (staus == 1)
                {
                    // MessageBox.Show("Logged In Successfuly");
                    this.Visible = false;
                    administrator admin = new administrator();
                    admin.Show();
                }
                else
                {
                    this.Visible = false;
                    Password pwd = new Password(username,role);
                    pwd.Show();

                }
            }
            else if (role == "FacultyDean")
            {
                if (staus == 1)
                {
                    // MessageBox.Show("Logged In Successfuly");
                    this.Visible = false;
                    Dean dean = new Dean();
                    dean.Show();
                }
                else
                {
                    this.Visible = false;
                    Password pwd = new Password(username,role);
                    pwd.Show();

                }
            }
            else if (role == "student")
            {
                if (staus == 1)
                {
                    // MessageBox.Show("Logged In Successfuly");
                    this.Visible = false;
                  // boro boro = new boro(username, role);

                    Student student = new Student(username, role);
                student.Show();
                }
                else
                {
                    this.Visible = false;
                    Password pwd = new Password(username,role);
                    pwd.Show();

                }
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
            con.Close();
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
