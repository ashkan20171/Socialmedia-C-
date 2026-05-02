using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialMediaLikeTelegram.Setting
{
    public partial class Frm_Notification : Form
    {
        int Counter = 0;
        public string Message { get { return lbl_Message.Text; } set { lbl_Message.Text = value; } }
        public string ChatName { get { return lbl_ChatName.Text; } set { lbl_ChatName.Text = value; } }
        public Image ProfilePic { get { return pictureBox1.Image; } set { pictureBox1.Image = value; } }
        public Frm_Notification()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Counter >= 10)
            {
                timer1.Enabled = false;
                this.Close();
            }
            else
                Counter++;
        }

        private void Frm_Notification_Load(object sender, EventArgs e)
        {
            bool ShowSenderName = Convert.ToBoolean(Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "ShowSenderName", false));
            bool MessagePreview = Convert.ToBoolean(Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "ShowMessagePreviw", false));
            if (!ShowSenderName)
                lbl_ChatName.Text = "No Preview";
            if (!MessagePreview)
                lbl_Message.Text = "No Preview";
        }
    }
}
