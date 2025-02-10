using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kabmlg.Pengguna
{
    public partial class PenggunaList : UserControl
    {
        users user;
        lathankabupatenEntities db = new lathankabupatenEntities();
        public PenggunaList(users user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void PenggunaList_Load(object sender, EventArgs e)
        {
            if(user.role == "Karyawan")
            {
                button1.Enabled = false;
            }
            label2.Text = user.role;
            usersBindingSource.DataSource = db.users.Where(f=>f.username.Contains(textBox1.Text)).ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OnLoad(null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TambahPengguna control = new TambahPengguna(user);
            Form form = FindForm();
            if(form is Form2 fo)
            {
                fo.ShowU(control);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(user.role == "Karyawan")
            {
                return;
            }
            if(usersBindingSource.Current is users usr)
            {
                if (e.ColumnIndex == roleDataGridViewTextBoxColumn.Index)
                {
                    var datadetail = usr;
                    DetailPengguna control = new DetailPengguna(usr);
                    Form form = FindForm();
                    if (form is Form2 da)
                    {
                        da.ShowU(control);
                    }
                }
                else if(e.ColumnIndex == colEdit.Index)
                {
                    var dataedit = usr;
                    EditPengguna control = new EditPengguna(usr);
                    Form form = FindForm();
                    if (form is Form2 da)
                    {
                        da.ShowU(control);
                    }
                }
                else if (e.ColumnIndex == colDelete.Index)
                {
                    if(MessageBox.Show($"Apakah anda ingin menghapus {usr.username} dari database?", "Hapus", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        db.users.Remove(usr);
                        db.SaveChanges();
                        OnLoad(null);
                    }
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is users userr)
            {
                if (e.ColumnIndex == passwordDataGridViewTextBoxColumn.Index)
                {
                    e.Value = new string('*', userr.password.Length);
                }
            }
        }
    }
}
