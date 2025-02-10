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
    public partial class UserControl6 : UserControl
    {
        devices dev;
        users user;
        lathankabupatenEntities db = new lathankabupatenEntities();
        public UserControl6(users user,devices dev)
        {
            this.user = user;
            this.dev = dev;
            InitializeComponent();
        }

        private void UserControl6_Load(object sender, EventArgs e)
        {
            label1.Text = $"History Peminjaman {dev.name}";
            Loadata(dev.id);
        }

        void Loadata(int deviceid)
        {
            var data = db.borrowing_record.Where(f => f.device_id == deviceid)
               .Select(f => new 
               {
                   f.start_date,
                   f.end_date,
                   f.users.role,
                   f.users.username,
                   f.users.full_name,
                   f.users.supervisor

               }).ToList();
            if(data.Any())
            {
                dataGridView1.DataSource = data;
            }
            else
            {
               if (MessageBox.Show("Tidak ada data peminjaman", "Kosong", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    UserControl2 control = new UserControl2(user, dev);
                    Form form = FindForm();
                    if(form is Form2 fordd)
                    {
                        fordd.ShowU(control);
                    }
                }
            }
        }
    }
}
