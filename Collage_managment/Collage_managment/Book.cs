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
    public partial class Book : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        public Book()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int bookid = Convert.ToInt32(textBox1.Text);
            string bookname = textBox2.Text;
            string author = textBox3.Text;
            string publisher = textBox4.Text;


            //   saving data in table
            con.Open();
            string query = "insert into books VALUES (" + bookid + ",'" + bookname + "','" + author + "','" + publisher + "','A')";
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Book Registered Successfuly");
            con.Close();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void Book_Load(object sender, EventArgs e)
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
