using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kabmlg
{
    public partial class UserControl3 : UserControl
    {
        lathankabupatenEntities db = new lathankabupatenEntities();
        users user;
        public UserControl3(users user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void UserControl3_Load(object sender, EventArgs e)
        {
            bindingSource1.Clear();
            bindingSource1.AddNew();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text) ||
                string.IsNullOrEmpty(textBox3.Text) ||
                string.IsNullOrEmpty(textBox4.Text) || 
                string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Mohon isi terlebih daluhu");
                return;
            }
            try
            {
                if (bindingSource1.Current is devices dev)
                {
                    db.devices.Add(dev);
                    db.SaveChanges();
                    MessageBox.Show("Data Telah Ditambahkan");
                    OnLoad(null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private byte[] ConvertToByteArray(string filePath)
        {
            return File.ReadAllBytes(filePath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image | *.jpg;*.png;*.jpeg;*.gif";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open.FileName);
                byte[] imagedata = ConvertToByteArray(open.FileName);
                if(bindingSource1.Current is devices dev)
                {
                    dev.photo = imagedata;
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
               !char.IsDigit(e.KeyChar) &&
               !(e.KeyChar >= 'A' && e.KeyChar <= 'Z'))
                e.Handled = true;
        }
    }
}
