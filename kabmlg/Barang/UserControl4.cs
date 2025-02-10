using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kabmlg
{
    public partial class UserControl4 : UserControl
    {
        lathankabupatenEntities db = new lathankabupatenEntities();
        users user;
        devices dvi;
        public UserControl4(users user, devices device)
        {
            this.dvi = device;
            this.user = user;
            InitializeComponent();
        }

        private void UserControl4_Load(object sender, EventArgs e)
        {
            if(dvi != null)
            {
                label1.Text = $"Detail {dvi.name}";
                label6.Text = dvi.name;
                label7.Text = dvi.code;
                label8.Text = dvi.description;
                label9.Text = dvi.status;
                DisplayImage(dvi.photo);
            }
            else
            label1.Text = "Detail not available";
        }

        private Image byteArrayToImage(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            return Image.FromStream(ms);
        }

        private  void DisplayImage(byte[] imgdata)
        {
            if(imgdata != null && imgdata.Length > 0)
            {
                pictureBox1.Image = byteArrayToImage(imgdata);
            } 
            else
            {
                pictureBox1.Image = null;
            }
        }
    }
}
