using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kabmlg.Peminjaman
{
    public partial class AjukanPeminjaman : UserControl
    {
        users user;
        lathankabupatenEntities db = new lathankabupatenEntities();
        public AjukanPeminjaman(users user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void AjukanPeminjaman_Load(object sender, EventArgs e)
        {
            textBox1.Text = $"{user.role} - {user.full_name}";
            devicesBindingSource.DataSource = db.devices.ToList();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (user.role == "Admin")
            {
                MessageBox.Show("Admin tidak bisa melakukan peminjaman.");
                return;
            }

            var status = user.role == "Karyawan" || user.role == "Supervisor" ? "Menunggu approval admin" : "";

            var data = new borrowing_record
            {
                borrower_id = user.id,
                device_id = Convert.ToInt32(comboBox1.SelectedValue),
                description = "",
                start_date = dateTimePicker1.Value,
                end_date = dateTimePicker2.Value,
                status = status
            };

            db.borrowing_record.Add(data);
            db.SaveChanges();
            MessageBox.Show("Peminjaman berhasil diajukan.");
        }
    }
}
