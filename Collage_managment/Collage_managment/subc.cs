
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
    public partial class subc : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        public subc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sb = comboBox1.Text;
            int tid = 0;


            int count = 0;
            con.Open();
            cmd = new SqlCommand("select * from students ", con);
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                count++;
            }
            con.Close();
            int id = (count + 1);



            con.Open();
            cmd = new SqlCommand("select * from students ", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                tid = reader.GetInt32(0);
            }
            con.Close();

            string cs = comboBox2.Text;
            int cid = 0;

            con.Open();
            cmd = new SqlCommand("select * from class where class_name='" + cs + "' ", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                cid = reader.GetInt32(0);
            }
            con.Close();


            string fk = comboBox3.Text;
            int fid = 0;

            con.Open();
            cmd = new SqlCommand("select * from faculty where faculty_name='" + fk + "' ", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                fid = reader.GetInt32(0);
            }
            con.Close();
            con.Open();
            cmd = new SqlCommand("select * from students ", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                tid = reader.GetInt32(0);
            }
            con.Close();

            
            
            con.Open();
            cmd = new SqlCommand("insert into studclass Values('" + id + "','" + cid + "','" + tid + "','" + fid + "')", con);
            reader = cmd.ExecuteReader();
            MessageBox.Show("Successfuly Added");


            con.Close();
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void subc_Load(object sender, EventArgs e)
        {

            try
            {

                con = new SqlConnection(@"data source=LAPTOP-4U4PP0RU;initial catalog=College;integrated security=true");

                con.Open();
                cmd = new SqlCommand("select * from class ", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader.GetString(1));
                }
                con.Close();
                con.Open();
                cmd = new SqlCommand("select * from students", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString(1));
                }

                con.Close();

                con.Open();
                cmd = new SqlCommand("select * from faculty", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox3.Items.Add(reader.GetString(1));
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
    }
}