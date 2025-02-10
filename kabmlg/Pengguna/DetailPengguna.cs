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
    public partial class DetailPengguna : UserControl
    {
        users usr;
        public DetailPengguna(users usr)
        {
            InitializeComponent();
            this.usr = usr;
        }

        private void DetailPengguna_Load(object sender, EventArgs e)
        {
            label2.Text = usr.role;
            label3.Text = usr.username;
            label4.Text = usr.full_name;
            label5.Text = new string('*', usr.password.Length);
            label6.Text = usr.supervisor;

        }
    }
}
