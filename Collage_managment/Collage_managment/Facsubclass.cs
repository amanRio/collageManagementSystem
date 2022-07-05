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
    public partial class Facsubclass : Form
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        public Facsubclass()
        {
            InitializeComponent();
        }

        private void Facsubclass_Load(object sender, EventArgs e)
        {
            
            try
            {
                con = new SqlConnection(@"data source=LAPTOP-4U4PP0RU;initial catalog=College;integrated security=true");

                con.Open();
                cmd = new SqlCommand("select * from class", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString(1));
                   
                }
                con.Close();

                con.Open();

                cmd = new SqlCommand("select * from faculty ", con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    comboBox3.Items.Add(reader.GetString(1));

                }
                con.Close();

                con.Open();

                cmd = new SqlCommand("select * from subjects", con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    comboBox2.Items.Add(reader.GetString(1));

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            con.Open();
            cmd = new SqlCommand("select * from facsubclass", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                count++;
            }
            con.Close();
            int fscid = (count + 1);

            string class_name = comboBox1.Text;
            int class_id = 0;
            con.Open();
            
            cmd = new SqlCommand("select * from class where class_name = '"+class_name+"'", con);
            reader = cmd.ExecuteReader();
           if(reader.Read())
            {
                class_id = reader.GetInt32(0);
            }


            con.Close();

            string faculty_name = comboBox3.Text;
            int faculty_id = 0;
            con.Open();

            cmd = new SqlCommand("select * from faculty where faculty_name = '" + faculty_name + "'", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                faculty_id = reader.GetInt32(0);
            }


            con.Close();

            string subject_name = comboBox2.Text;
            int subject_id = 0;
            con.Open();

            cmd = new SqlCommand("select * from subjects where subject_name = '" + subject_name + "'", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
            subject_id = reader.GetInt32(0);
            }


            con.Close();

            con.Open();
            cmd = new SqlCommand("insert into facsubclass Values('" + fscid + "','" + class_id + "','" + faculty_id + "','" + subject_id + "')", con);
            reader = cmd.ExecuteReader();
            MessageBox.Show("Successfuly Added");


            con.Close();
        }
    }
}
