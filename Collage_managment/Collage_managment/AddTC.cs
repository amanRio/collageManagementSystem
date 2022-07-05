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
    public partial class AddTC : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        public AddTC()
        {
            InitializeComponent();
       
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string teacher = comboBox2.Text;
            int tid = 0;


            int count = 0;
            con.Open();
            cmd = new SqlCommand("select * from teacherClass", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                count++;
            }
            con.Close();
            int id = (count + 1);



            con.Open();
            cmd = new SqlCommand("select * from employee where employee_name='" + teacher + "' ", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                tid = reader.GetInt32(0);
            }
            con.Close();

            string cs = comboBox1.Text;
            int cid = 0;

            con.Open();
            cmd = new SqlCommand("select * from class where class_name='" + cs + "' ", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                cid = reader.GetInt32(0);
            }
            con.Close();



            con.Open();
            cmd = new SqlCommand("insert into teacherClass Values('" + id + "','" + tid + "','" + cid + "')", con);
            reader = cmd.ExecuteReader();
            MessageBox.Show("Successfuly Added");


            con.Close();
        }

        private void AddTC_Load(object sender, EventArgs e)
        {
            string rol = "Lecturer";
            try
            {
                con = new SqlConnection(@"data source=LAPTOP-4U4PP0RU;initial catalog=College;integrated security=true");
                
                con.Open();
                int employeeid= 0;
                cmd = new SqlCommand("select * from employee where role='"+rol+"'", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader.GetString(1));
                    employeeid = reader.GetInt32(0);
                }
                con.Close();

                con.Open();
                
                cmd = new SqlCommand("select * from class ", con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    comboBox1.Items.Add(reader.GetString(1));
                    
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
