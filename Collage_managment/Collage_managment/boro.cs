using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Collage_managment
{
    public partial class boro : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        public boro(string user, string role)
        {
            InitializeComponent();
            label10.Text = user;
        }

        public boro()
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void borro_Load(object sender, EventArgs e)
        {
            Loadt();
            
        }

       

        

    public void Loadt()
        {

            int count = 0;
            con = new SqlConnection(@"data source=LAPTOP-4U4PP0RU;initial catalog=College;integrated security=true");

            con.Open();
            cmd = new SqlCommand("select * from transactions", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                count++;
            }
            con.Close();
            label3.Text = (count + 1).ToString();
            label5.Text = "Date:" + DateTime.Now.ToString();


            con.Open();
            cmd.CommandText = "select * from books";
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader.GetString(4).Equals("A"))
                    comboBox1.Items.Add(reader.GetString(1));


            }
            con.Close();




            con.Open();
            int bookid = 0;
            string book = comboBox1.Text;
            cmd = new SqlCommand("select * FROM books where book_name ='" + book + "' ", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                bookid = reader.GetInt32(0);
            }
            con.Close();
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            int transactionid = Convert.ToInt32(label3.Text);
      
            string date_borrowed = label5.Text;
            
            int book_id = 0;
            string book_name = comboBox1.Text;
            con.Open();
            cmd.CommandText = "select * from books";
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader.GetString(1) == book_name && reader.GetString(4).Equals("A"))
                    book_id = reader.GetInt32(0);


            }
            con.Close();
           

            con.Open();
            int studentid = 0;
            string email = label10.Text;
            cmd = new SqlCommand("select student_id FROM students where email ='" + email + "'", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                studentid = reader.GetInt32(0);
            }
            con.Close();

            con.Open();
            cmd.CommandText = "insert into transactions values(" + transactionid + "," + book_id + "," + studentid + ",'" + date_borrowed + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            con.Open();
            cmd.CommandText = "update  books set avilability = 'O' where book_id = '" + book_id+"'";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Book Borrowed Successfuly");
            comboBox1.Text = "";
            Loadt();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
