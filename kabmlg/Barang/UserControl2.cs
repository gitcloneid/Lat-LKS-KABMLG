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
    public partial class UserControl2 : UserControl
    {
        lathankabupatenEntities db = new lathankabupatenEntities();
        users user;
        public UserControl2(users user, devices dvi)
        {
            InitializeComponent();
            this.user = user;
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
            if (user.role == "Karyawan")
            {
                button1.Enabled = false;
            }
            label2.Text = user.role;
            devicesBindingSource.DataSource = db.devices.Where(f=>f.name.Contains(textBox1.Text)).ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OnLoad(null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserControl3 control = new UserControl3(user);
            Form form = FindForm();
            if ( form is Form2 dash)
            {
               dash.ShowU(control);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (user.role == "Karyawan")
            {
                return; 
            }

            if (devicesBindingSource.Current is devices dv)
            {
                if (e.ColumnIndex == photoDataGridViewImageColumn.Index)
                {
                    UserControl4 control = new UserControl4(user, dv);
                    Form form = FindForm();
                    if (form is Form2 dash)
                    {
                        dash.ShowU(control);
                    }
                }
                else if (e.ColumnIndex == colEdit.Index)
                {
                    var datadevice = dv;
                    UserControl5 control = new UserControl5(user, datadevice);
                    Form form = FindForm();
                    if (form is Form2 dash)
                    {
                        dash.ShowU(control);
                    }
                }
                else if (e.ColumnIndex == colDelete.Index)
                {
                    if (MessageBox.Show($"Apakah anda ingin menghapus barang {dv.name} dari database?", "Hapus", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        db.devices.Remove(dv);
                        db.SaveChanges();
                        OnLoad(null);
                    }
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (dataGridView1.Rows[e.RowIndex].DataBoundItem is devices dv)
            //{
            //    if (e.ColumnIndex == colEdit.Index) e.Value = "Edit";
            //    if (e.ColumnIndex == colDelete.Index) e.Value = "Delete";
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
           if(devicesBindingSource.Current is devices dev)
            {
                UserControl6 control = new UserControl6(user, dev);
                Form form = FindForm();
                if(form is Form2 dash)
                {
                    dash.ShowU(control);
                }
            }
        }
    }
}
