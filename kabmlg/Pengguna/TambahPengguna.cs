using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kabmlg.Pengguna
{
    public partial class TambahPengguna : UserControl
    {
        users user;
        lathankabupatenEntities db = new lathankabupatenEntities();
        public TambahPengguna(users user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void TambahPengguna_Load(object sender, EventArgs e)
        {
            usersBindingSource.DataSource = db.users.Where(f => f.role == "Supervisor")
                .Select(f => f.full_name).ToList();
            bindingSource1.Clear();
            bindingSource1.AddNew();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (TextBox t in groupBox1.Controls.OfType<TextBox>())
            {
                if (string.IsNullOrEmpty(t.Text))
                {
                    MessageBox.Show("Mohon Isi Dengan Benar");
                    return;
                }
            }
            if(string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Mohon isi Role");
                return;
            }
            
            if(bindingSource1.Current is users dev)
            {
                db.users.Add(dev);
                db.SaveChanges();
                MessageBox.Show("Data berhasil ditambahkan");
                OnLoad(null);
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void usersBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
