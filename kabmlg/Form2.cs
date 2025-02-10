using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kabmlg.Pengguna;

namespace kabmlg
{
    public partial class Form2 : Form
    {
        lathankabupatenEntities db = new lathankabupatenEntities();
        users user;
        
        public Form2(users user)
        {
            this.user = user;
            InitializeComponent();
        }

        public void ShowU(UserControl uc)
        {
            panel1.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panel1.Controls.Add(uc);
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ShowU(new UserControl1(user));
        }

        private void barangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowU(new UserControl2(user, db.devices.FirstOrDefault()));
        }

        private void peminjamanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowU(new UserControl1(user));
        }

        private void penggunaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowU(new PenggunaList(user));
        }
    }
}
