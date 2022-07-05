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
    public partial class addsuf : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        public addsuf()
        {
            InitializeComponent();
        }

        private void addsuf_Load(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(@"data source=LAPTOP-4U4PP0RU;initial catalog=College;integrated security=true");

                con.Open();
                cmd = new SqlCommand("select * from faculty ", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString(1));
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
            string fk = comboBox1.Text;
            int fid = 0;


            int count = 0;
            con.Open();
            cmd = new SqlCommand("select * from faculty_subjects ", con);
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                count++;
            }
            con.Close();
            int id = (count + 1);



            con.Open();
            cmd = new SqlCommand("select * from faculty ", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                fid = reader.GetInt32(0);
            }
            con.Close();

            string sb = comboBox2.Text;
            int sid = 0;

            con.Open();
            cmd = new SqlCommand("select * from subjects where subject_name='" + sb + "' ", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                sid = reader.GetInt32(0);
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("select * from faculty ", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                fid = reader.GetInt32(0);
            }
            con.Close();


            con.Open();
            cmd = new SqlCommand("insert into faculty_subjects Values('" + id + "','" + fid + "','" + sid + "')", con);
            reader = cmd.ExecuteReader();
            MessageBox.Show("Successfuly Added");


            con.Close();
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

    }
    }
