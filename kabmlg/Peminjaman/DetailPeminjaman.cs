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
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace kabmlg.Peminjaman
{
    public partial class DetailPeminjaman : UserControl
    {
        lathankabupatenEntities db = new lathankabupatenEntities();
        private readonly users userr;
        private dynamic detaildta;
        public DetailPeminjaman(users userr)
        {
            this.userr = userr;
            InitializeComponent();
        }

        public void SetDetailData(dynamic detailData)
        {
            label1.Text = $"Detail Peminjaman {detailData.DeviceName}";
            label6.Text = detailData.DeviceName;
            label7.Text = detailData.Peminjam;
            label8.Text = detailData.TanggalPinjam.ToString("dd/MM/yyyy");
            label9.Text = detailData.DeadlinePengembalian.ToString("dd/MM/yyyy");
            label13.Text = "";
            label12.Text = detailData.Status;
            if (detailData.Photo != null)
            {
                pictureBox1.Image = Image.FromStream(new System.IO.MemoryStream(detailData.Photo));
            }
            else
            {
                pictureBox1.Image = null;
            }
            this.detaildta = detailData;
        }

        private void DetailPeminjaman_Load(object sender, EventArgs e)
        {
            if (userr.role == "Karyawan")
            {
                button1.Visible = false;
                button2.Visible = false;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string reason = Interaction.InputBox("Masukkan alasan penolakan:", "Alasan Penolakan", "");
            if (!string.IsNullOrEmpty(reason))
            {
                borrowing_record_status newStatus = new borrowing_record_status
                {
                    borrowing_record_id = detaildta.ID,
                    from_status = detaildta.Status,
                    to_status = "Ditolak",
                    notes = reason,
                    user_id = userr.id,
                };

                db.borrowing_record_status.Add(newStatus);
                db.SaveChanges();

                detaildta = new
                {
                    detaildta.ID,
                    detaildta.DeviceName,
                    detaildta.Peminjam,
                    detaildta.TanggalPinjam,
                    detaildta.DeadlinePengembalian,
                    detaildta.Photo,
                    Status = "Ditolak"
                };

                var borrowingRecord = db.borrowing_record.Find(detaildta.ID);
                if (borrowingRecord != null)
                {
                    borrowingRecord.status = "Ditolak";
                    db.borrowing_record.AddOrUpdate((borrowing_record)borrowingRecord);
                    db.SaveChanges();
                }

                label12.Text = "Ditolak";
                MessageBox.Show("Status peminjaman telah diubah menjadi Ditolak.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            borrowing_record_status newStatus = new borrowing_record_status
            {
                borrowing_record_id = detaildta.ID,
                from_status = detaildta.Status,
                to_status = "Disetujui",
                notes = "Disetujui oleh " + userr.full_name,
                user_id = userr.id,
            };

            db.borrowing_record_status.Add(newStatus);
            db.SaveChanges();

            detaildta = new
            {
                detaildta.ID,
                detaildta.DeviceName,
                detaildta.Peminjam,
                detaildta.TanggalPinjam,
                detaildta.DeadlinePengembalian,
                detaildta.Photo,
                Status = "Disetujui"
            };

            var borrowingRecord = db.borrowing_record.Find(detaildta.ID);
            if (borrowingRecord != null)
            {
                borrowingRecord.status = "Disetujui";
                db.borrowing_record.AddOrUpdate((borrowing_record)borrowingRecord);
                db.SaveChanges();
            }

            label12.Text = "Disetujui";
            MessageBox.Show("Status peminjaman telah diubah menjadi Disetujui.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
