using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kabmlg.Peminjaman;

namespace kabmlg
{
    public partial class UserControl1 : UserControl
    {
        lathankabupatenEntities db = new lathankabupatenEntities();
        users user;
        public UserControl1(users user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            loaddatapeminjaman();
            label2.Text = user.role;
        }

        
        private void loaddatapeminjaman()
        {
            var data = (from br in db.borrowing_record
                        join d in db.devices on br.device_id equals d.id
                        join u in db.users on br.users.id equals u.id
                        select new
                        {
                            Id = br.id,
                            Photo = d.photo,
                            DeviceName = d.name,
                            Peminjam = u.full_name,
                            TanggalPinjam = br.start_date,
                            DeadlinePengembalian = br.end_date,
                            TanggalPengembalian = (DateTime?)null,
                            Status = br.status
                        }).ToList();

            BindingSource bs = new BindingSource();
            bs.DataSource = data;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns["Id"].Visible = false;
            //set menjadi stretch
            DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)dataGridView1.Columns["Photo"];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AjukanPeminjaman control = new AjukanPeminjaman(user);
            Form form = FindForm();
            if(form is Form2 fro)
            {
                fro.ShowU(control);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Photo")
            {
                var selectedRow = dataGridView1.Rows[e.RowIndex];
                var detailData = new
                {
                    ID = selectedRow.Cells["ID"].Value,
                    Photo = (byte[])selectedRow.Cells["Photo"].Value,
                    DeviceName = selectedRow.Cells["DeviceName"].Value.ToString(),
                    Peminjam = selectedRow.Cells["Peminjam"].Value.ToString(),
                    TanggalPinjam = (DateTime)selectedRow.Cells["TanggalPinjam"].Value,
                    DeadlinePengembalian = (DateTime)selectedRow.Cells["DeadlinePengembalian"].Value,
                    Status = selectedRow.Cells["Status"].Value.ToString()
                };

                DetailPeminjaman control = new DetailPeminjaman(user);
                control.SetDetailData(detailData);
                Form form = FindForm();
                if (form is Form2 dorr)
                {
                    dorr.ShowU(control);
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var data = (from br in db.borrowing_record
                        join d in db.devices on br.device_id equals d.id
                        join u in db.users on br.users.id equals u.id
                        where d.name.ToLower().Contains(textBox1.Text) ||
                        u.full_name.ToLower().Contains(textBox1.Text) ||
                        br.status.ToLower().Contains(textBox1.Text)
                        select new
                        {
                            Photo = d.photo,
                            DeviceName = d.name,
                            Peminjam = u.full_name,
                            TanggalPinjam = br.start_date,
                            DeadlinePengembalian = br.end_date,
                            TanggalPengembalian = (DateTime?)null,
                            Status = br.status
                        }).ToList();

            BindingSource bs = new BindingSource();
            bs.DataSource = data;
            dataGridView1.DataSource = bs;
            //set menjadi stretch
            DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)dataGridView1.Columns["Photo"];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
    }
}
