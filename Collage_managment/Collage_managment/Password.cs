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
    public partial class Password : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;

        public Password()
        {
        }

        public Password( string user , string role)
        {
            InitializeComponent();
            label3.Text = user;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pass = textBox1.Text;
            string conf = textBox2.Text;
            string us = label3.Text;
            if (pass == conf)
            {
                con.Open();
                cmd = new SqlCommand("update login set password='" + pass + "',status='" + 1 + "' where username='" + us + "' ", con);
                cmd = new SqlCommand("update login set password='" + conf + "',status='" + 1 + "' where username='" + us + "' ", con);


                reader = cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Passwords Updated Successfuly");
                administrator a = new administrator();
                this.Visible = false;
                a.Show();
            }
            else
            {
                MessageBox.Show("Passwords dont match");
            }
        }

        private void Password_Load(object sender, EventArgs e)
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
