using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialMediaLikeTelegram.Channels
{
    public partial class Frm_AddChannelName : Form
    {
        public static string ProfilePic = "";
        public static string Channel_name = "";
        public static string Channel_Des = "";
        public Frm_AddChannelName()
        {
            InitializeComponent();
        }

        private void Frm_AddChannelName_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Multiselect = false;
            op.Title = "Please select channel profile photo . . .";
            op.Filter = "*.jpg|*.jpg|*.png|*.png";
            if (op.ShowDialog() == DialogResult.OK)
                ProfilePic = op.FileName;
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(bunifuMaterialTextbox1.Text))
            {
                Channel_name = bunifuMaterialTextbox1.Text;
                Channel_Des = bunifuMaterialTextbox2.Text;
                this.Hide();
                new Frm_AddChannelChannelType().ShowDialog(this.Owner);
            }
            else AdvanceMethod.AdvanceMessageBox("please enter channel name!");
        }
    }
}
