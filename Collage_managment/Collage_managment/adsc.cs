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

    public partial class adsc : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        public adsc()
        {
            InitializeComponent();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void adsc_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(@"data source=LAPTOP-4U4PP0RU;initial catalog=College;integrated security=true");


                con.Open();

                cmd = new SqlCommand("select * from class ", con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    comboBox1.Items.Add(reader.GetString(1));

                }
                con.Close();


                con.Open();
                cmd = new SqlCommand("select * from subjects ", con);
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

        private void button1_Click_1(object sender, EventArgs e)
        {

            string sb = comboBox2.Text;
            int tid = 0;


            int count = 0;
            con.Open();
            cmd = new SqlCommand("select * from subclass ", con);
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                count++;
            }
            con.Close();
            int id = (count + 1);



            con.Open();
            cmd = new SqlCommand("select * from subjects  where subject_name='" + sb + "'", con);
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
            cmd = new SqlCommand("insert into subclass Values('" + id + "','" + cid + "','" + tid + "')", con);
            reader = cmd.ExecuteReader();
            MessageBox.Show("Successfuly Added");


            con.Close();
            comboBox1.Text = "";
            comboBox2.Text = "";
        }
    }
}
