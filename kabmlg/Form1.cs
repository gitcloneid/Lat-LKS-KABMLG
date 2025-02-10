using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kabmlg
{
    public partial class Form1 : Form
    {
        lathankabupatenEntities db = new lathankabupatenEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = db.users.FirstOrDefault(f => f.username == textBox1.Text && f.password == textBox2.Text);
            if(user == null)
            {
                MessageBox.Show("Username Not found");
                return;
            }
            if(user != null)
            {
                new Form2(user).Show();
                this.Hide();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "havidabdilah";
            textBox2.Text = "havidabdilah";
        }
    }
}
