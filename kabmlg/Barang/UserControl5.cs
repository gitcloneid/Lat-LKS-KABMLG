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
using System.Data.Entity.Migrations;
using System.Security.Cryptography;

namespace kabmlg
{
    public partial class UserControl5 : UserControl
    {
        lathankabupatenEntities db = new lathankabupatenEntities();
        users user;
        devices dvi;
        public UserControl5(users user, devices dvi)
        {
            InitializeComponent();
            this.user = user;
            this.dvi = dvi;
        }

        private void UserControl5_Load(object sender, EventArgs e)
        {
            label7.Text = user.role;
            textBox3.Text = dvi.name;
            textBox1.Text = dvi.code;
            textBox4.Text = dvi.description;
            comboBox1.Text = dvi.status;
            MemoryStream ms = new MemoryStream(dvi.photo);
            pictureBox1.Image = Image.FromStream(ms);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text ) ||
                string.IsNullOrEmpty(textBox4.Text) ||
                string.IsNullOrEmpty(textBox3.Text) ||
                string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Mohon isi dengan benar");
                return;
            }

            if (pictureBox1.Image != null)
            {
                dvi.photo = imagetoarray(pictureBox1.Image);
            }

            if (dvi != null)
            {
                dvi.name = textBox3.Text;
                dvi.code = textBox1.Text;
                dvi.description = textBox4.Text;
                dvi.status = comboBox1.Text;
                dvi.photo = imagetoarray(pictureBox1.Image);

                db.devices.AddOrUpdate(dvi);
                db.SaveChanges();
                MessageBox.Show("Data Berhasil Diedit");
                UserControl2 control = new UserControl2(user, dvi);
                Form form = FindForm();
                if (form is Form2 fo)
                {
                    fo.ShowU(control);
                }
            }
        }

        private byte[] imagetoarray(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, image.RawFormat);
            return ms.ToArray();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (TextBox t in groupBox1.Controls.OfType<TextBox>())
            {
                t.Clear();
            }
            comboBox1.Text = string.Empty;
            pictureBox1.Image = null;
            UserControl2 control = new UserControl2(user, dvi);
            Form form = FindForm();
            if(form is Form2 fo)
            {
                fo.ShowU(control);
            }
        }
    }
}
