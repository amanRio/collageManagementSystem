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
    public partial class Returns : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        public Returns()
        {
            InitializeComponent();
            
        }

        

        private void Returns_Load(object sender, EventArgs e)
        {
            Loadt();

        }





        public void Loadt()
        {

            int count = 0;
            con = new SqlConnection(@"data source=LAPTOP-4U4PP0RU;initial catalog=College;integrated security=true");

            con.Open();
            cmd = new SqlCommand("select * from returns", con);
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
                if (reader.GetString(4).Equals("O"))
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





        private void button1_Click(object sender, EventArgs e)
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
                if (reader.GetString(1) == book_name && reader.GetString(4).Equals("O"))
                    book_id = reader.GetInt32(0);


            }
            con.Close();


            int studentid = Convert.ToInt32(textBox1.Text);
           
            con.Open();
            cmd.CommandText = "insert into returns values(" + transactionid + "," + book_id + "," + studentid + ",'" + date_borrowed + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            con.Open();
            cmd.CommandText = "update  books set avilability = 'A' where book_id = '" + book_id + "'";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Book Returned Successfuly");
            comboBox1.Text = "";
            Loadt();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            string book_name = comboBox1.Text;
            int book_id = 0;
            con.Open();
            
            cmd.CommandText = "select * from books where book_name = '"+book_name+"'";
            reader = cmd.ExecuteReader();

            
                if (reader.Read())
            { 
                    book_id = reader.GetInt32(0);


            }
            con.Close();

            
            con.Open();
            

            cmd.CommandText = "select * from transactions where book_id = '" + book_id + "'";
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
               textBox1.Text = reader.GetInt32(2).ToString();


            }
            con.Close();



        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}