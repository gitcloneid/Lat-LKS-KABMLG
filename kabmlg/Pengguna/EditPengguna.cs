using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kabmlg.Pengguna
{
    public partial class EditPengguna : UserControl
    {
        lathankabupatenEntities db = new lathankabupatenEntities();
        users usr;

        public EditPengguna(users usr)
        {
            this.usr = usr;
            InitializeComponent();
        }

        private void EditPengguna_Load(object sender, EventArgs e)
        {
            usersBindingSource.DataSource = db.users.Where(f => f.role == "Supervisor")
                .Select(f => f.full_name).ToList();
            comboBox1.Text = usr.role;
            if(usr.supervisor != null)
            {
                comboBox2.Text = usr.supervisor;
            }
            else
            {
                comboBox2.Controls.Clear();
            }
            textBox1.Text = usr.username;
            textBox2.Text = usr.full_name;
            textBox3.Text = usr.password;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (TextBox t in groupBox1.Controls.OfType<TextBox>())
            {
                if (string.IsNullOrEmpty(t.Text))
                {
                    MessageBox.Show("Mohon isi dengan benar");
                    return;
                }
            }
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Mohon isi Role");
                return;
            }

            // new objetx 
            usr.role = comboBox1.Text;
            usr.supervisor = comboBox2.Text;
            usr.username = textBox1.Text;
            usr.full_name = textBox2.Text;
            usr.password = textBox3.Text;

            db.users.AddOrUpdate(usr);
            db.SaveChanges();
            MessageBox.Show("Data berhasil diedit");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (TextBox t in groupBox1.Controls.OfType<TextBox>())
            {
                t.Clear();
            }
            comboBox1.Controls.Clear();
            comboBox2.Controls.Clear();
        }
    }
}
