using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SocialMediaLikeTelegram.Models.Repository;

namespace SocialMediaLikeTelegram
{
    public partial class Frm_Setting : Form
    {
        public Frm_Setting()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue400, Primary.Grey500, Primary.Grey700, Accent.LightBlue400, TextShade.WHITE);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_Setting_Load(object sender, EventArgs e)
        {
            var User = Rep_Users.GetUser(Frm_Chats.User_id);
            lblName.Text = User.Name + " " + User.Lname;
            ProfilePic.ImageLocation = User.tbl_Pic.Pic_Url;
            lbl_PhoneNumber.Text = User.PhoneNumber;
            lbl_Username.Text = User.Username;
            lbl_Bio.Text = User.Biography;
            /////
            string R1 = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "DesktopNotification", 0).ToString();
            string R2 = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "ShowMessagePreviw", 0).ToString();
            string R3 = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "ShowSenderName", 0).ToString();
            string R4 = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "Showtryicon", 0).ToString();
            string R5 = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "ShowTaskbarIcon", 0).ToString();
            string R6 = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "Chatbackground", "").ToString();
            chk_DesktopNotification.Checked = Convert.ToBoolean(R1);
            chk_MessagePreviw.Checked = Convert.ToBoolean(R2);
            chk_SenderName.Checked = Convert.ToBoolean(R3);
            chk_tryicon.Checked = Convert.ToBoolean(R4);
            chk_taskbaricon.Checked = Convert.ToBoolean(R5);
            if (Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", "TelegramDemo", "") != "")
                chk_AutoRun.Checked = true;
            else
                chk_AutoRun.Checked = false;
            if (R6 == "")
                chatBackground.BackColor = Color.WhiteSmoke;
            else if (R6.Contains("/"))
                chatBackground.ImageLocation = R6;
            else
            {
                if (R6 == "1")
                    chatBackground.Image = global::SocialMediaLikeTelegram.Properties.Resources._1;
                else if (R6 == "2")
                    chatBackground.Image = global::SocialMediaLikeTelegram.Properties.Resources._2;
                else if (R6 == "3")
                    chatBackground.Image = global::SocialMediaLikeTelegram.Properties.Resources._3;
                else if (R6 == "6")
                    chatBackground.Image = global::SocialMediaLikeTelegram.Properties.Resources._41;
                else if (R6 == "5")
                    chatBackground.Image = global::SocialMediaLikeTelegram.Properties.Resources._5;
                else if (R6 == "4")
                    chatBackground.Image = global::SocialMediaLikeTelegram.Properties.Resources._6;
                else if (R6 == "7")
                    chatBackground.Image = global::SocialMediaLikeTelegram.Properties.Resources._7;
                else if (R6 == "8")
                    chatBackground.Image = global::SocialMediaLikeTelegram.Properties.Resources._8;
                else if (R6 == "9")
                    chatBackground.Image = global::SocialMediaLikeTelegram.Properties.Resources._9;
            }
        }

        private void chk_DesktopNotification_CheckedChanged(object sender, EventArgs e)
        {
            Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "DesktopNotification", chk_DesktopNotification.Checked);
        }

        private void chk_SenderName_CheckedChanged(object sender, EventArgs e)
        {
            Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "ShowSenderName", chk_SenderName.Checked);
        }

        private void chk_MessagePreviw_CheckedChanged(object sender, EventArgs e)
        {
            Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "ShowMessagePreviw", chk_MessagePreviw.Checked);
        }

        private void chk_tryicon_CheckedChanged(object sender, EventArgs e)
        {
            Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "Showtryicon", chk_tryicon.Checked);
        }

        private void chk_taskbaricon_CheckedChanged(object sender, EventArgs e)
        {
            Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "ShowTaskbarIcon", chk_taskbaricon.Checked);
        }

        private void chk_AutoRun_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_AutoRun.Checked)
                Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", "TelegramDemo", Application.StartupPath);
            else
                Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", "TelegramDemo", "");
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            new Setting.Frm_EditName().ShowDialog(this);
            Frm_Setting_Load(null, null);
        }

        private void lbl_Bio_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Setting.Frm_EditBio().ShowDialog(this);
            Frm_Setting_Load(null, null);
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Frm_LastSeenPrivacy().ShowDialog(this);
        }

        private void lbl_Username_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Setting.Frm_EditUsername().ShowDialog(this);
            Frm_Setting_Load(null, null);
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Choose a Photo to Set on profile ...";
                op.Filter = "Jpg Files|*.jpg|Png Files|*.PNG";
                if (op.ShowDialog(this) == DialogResult.OK)
                {
                    var user = Rep_Users.GetUser(Frm_Chats.User_id);
                    user.Pic_id_FK = Rep_Pic.InsertPhoto(AdvanceMethod.UploadPhoto(op.FileName));
                    user.Pic_Log += "," + user.Pic_id_FK;
                    Rep_Users.EditUser(user);
                    Frm_Setting_Load(null, null);
                }
            }
            catch { }
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Choose a Photo to Set on profile ...";
                op.Filter = "Jpg Files|*.jpg|Png Files|*.PNG";
                if (op.ShowDialog(this) == DialogResult.OK)
                {
                    Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "Chatbackground", op.FileName);
                }
            }
            catch { }
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Setting.Frm_ChatBackgroundLibrary().ShowDialog(this);
            Frm_Setting_Load(null, null);
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Frm_ManageBlockedUsers().ShowDialog(this);
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Setting.Frm_ManageLocalStotage().ShowDialog(this);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Setting.Frm_NotificationPositionAndCount().ShowDialog(this);
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Setting.Frm_Session().ShowDialog(this);
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (AdvanceMethod.AdvanceMessageBox("Are you sure to Log Out from this PC ?") == DialogResult.OK)
            {
                var Code = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "Session", null);
                Rep_Users.DeleteSession(Code.ToString());
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKey(@"Software\SocialMediaLikeTelegram\");
                Application.Exit();
            }
        }
    }
}
