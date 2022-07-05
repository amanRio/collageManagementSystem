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
    public partial class Show : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        public Show(string username)
        {
            InitializeComponent();
            label4.Text = username;
        }

        private void Show_Load(object sender, EventArgs e)
        {   
            string us = label4.Text;
            
            int student_id = 0;
            int class_id = 0;
            string class_name = label1.Text;
            try
            {
                con = new SqlConnection(@"data source=LAPTOP-4U4PP0RU;initial catalog=College;integrated security=true");

                con.Open();
                cmd = new SqlCommand("SELECT student_id FROM students where email = '"+us+"'",con);
                reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    student_id = reader.GetInt32(0);
                    //comboBox1.Items.Add(reader.GetString(1));

                }
                con.Close();

                
               
                con.Open();
                
                cmd = new SqlCommand("SELECT * FROM class where class_id = '"+class_id+"' ", con);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                  
                    label1.Text = reader.GetString(1);
                    //comboBox1.Items.Add(reader.GetString(1));

                }
                con.Close();

                con.Open();
                cmd = new SqlCommand("SELECT  * from studclass " , con);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    student_id = reader.GetInt32(0);
                    class_id = reader.GetInt32(1);
                    //comboBox1.Items.Add(reader.GetString(1));

                }
                con.Close();
              


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView1.Rows.Add(label1.Text,us,us);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            int class_id = 0;
            cmd = new SqlCommand("SELECT * FROM class where class_id = '" + class_id + "' ", con);
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {

                label1.Text = reader.GetString(1);
                //comboBox1.Items.Add(reader.GetString(1));

            }
            con.Close();
        }
    }
}
