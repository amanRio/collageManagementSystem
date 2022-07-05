using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Design;


namespace Collage_managment
{
    public partial class administrator : Form
    {
        Form administratorForm;
        public administrator()
        {
            InitializeComponent();
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int w = Width >= screen.Width ? screen.Width : (screen.Width + Width) / 2;
            int h = Height >= screen.Height ? screen.Height : (screen.Height + Height) / 2;
            this.Location = new Point((screen.Width - w) / 2, (screen.Height - h) / 2);
            this.Size = new Size(w, h);
        }
        public void loadform(Form f)
        {
           

          
            if (this.panel3.Controls.Count > 0)
                this.panel3.Controls.RemoveAt(0);
            administratorForm = f;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel3.Controls.Add(f);
            this.panel3.Tag = f;
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadform(new Regester());


        }

        private void button5_Click(object sender, EventArgs e)
        {
            loadform(new Faculty());
        }

        private void administrator_Load(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadform(new Employee());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadform(new Book());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            loadform(new Class());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            loadform(new Subject());
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void X_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
