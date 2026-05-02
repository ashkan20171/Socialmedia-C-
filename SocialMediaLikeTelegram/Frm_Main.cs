using SocialMediaLikeTelegram.Models.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialMediaLikeTelegram
{
    public partial class Frm_Main : /*DevComponents.DotNetBar.Metro.Metro*/Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimum_Click(object sender, EventArgs e)
        {

        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            PanelAddProfile.Visible = false;
            PanelActivationCode.Visible = false;
            PanelLogin.Visible = false;
            bunifuDropdown1.selectedIndex = 0;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            PanelLogin.Visible = true;
        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            if (bunifuDropdown1.selectedValue == "Iran (+98)")
            {
                txt_CountryCode.Text = "+98";
            }
            else if (bunifuDropdown1.selectedValue == "USA (+1)")
            {
                txt_CountryCode.Text = "+1";
            }
        }

        private void txt_CountryCode_OnValueChanged(object sender, EventArgs e)
        {
            if (txt_CountryCode.Text != "+1" && txt_CountryCode.Text != "+98")
                lbl_MobileError.Visible = true;
            else if (txt_PhoneNumber.Text.Length == 10)
                lbl_MobileError.Visible = false;
            else
                lbl_MobileError.Visible = true;
        }

        private void txt_PhoneNumber_OnValueChanged(object sender, EventArgs e)
        {
            if (txt_CountryCode.Text != "+1" && txt_CountryCode.Text != "+98")
                lbl_MobileError.Visible = true;
            else if (txt_PhoneNumber.Text.Length == 10)
                lbl_MobileError.Visible = false;
            else
                lbl_MobileError.Visible = true;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (!lbl_MobileError.Visible)
            {
                AdvanceMethod.SendTextMessage("Your Activation Code Is :" + Environment.NewLine + Rep_Users.ActivationCode(txt_CountryCode.Text + txt_PhoneNumber.Text), txt_CountryCode.Text + txt_PhoneNumber.Text);
                PanelActivationCode.Visible = true;
                timer1.Enabled = true;
            }
            else
                AdvanceMethod.AdvanceMessageBox("Please enter a corect phone number !");
        }
        int SendMessageCounter = 119;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (SendMessageCounter <= 0)
            {
                timer1.Enabled = false;
                AdvanceMethod.SendTextMessage(Rep_Users.GetLastActivationCode(txt_CountryCode.Text + txt_PhoneNumber.Text), txt_CountryCode.Text + txt_PhoneNumber.Text);
                AdvanceMethod.AdvanceMessageBox("the Activation message was resended !");
            }
            else
            {
                int Min = SendMessageCounter / 60;
                int Secend = SendMessageCounter % 60;
                lbl_ResendMessage.Text = "Telegram will send you a number in : " + Min.ToString("00") + ":" + Secend.ToString("00");
                SendMessageCounter--;
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (txt_ActivationCode.Text.Length == 5)
            {
                var Flag = Rep_Users.SetActiveActivationCode(txt_ActivationCode.Text);
                if (Flag)
                {
                    var User = Rep_Users.GetUserByPhoneNumber(txt_CountryCode.Text + txt_PhoneNumber.Text);
                    if (User != null)
                    {
                        Frm_Chats.User_id = User.id;
                        string SessionCode = Rep_Users.InsertSession(Frm_Chats.User_id);
                        Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\SocialMediaLikeTelegram");
                        Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "Chatbackground", "1");
                        Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "DesktopNotification", "true");
                        Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "NotificationCount", "3");
                        Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "NotificationPosition", "BottomRight");
                        Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "Session", SessionCode);
                        Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "ShowMessagePreviw", "true");
                        Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "ShowSenderName", "true");
                        Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "ShowTaskbarIcon", "true");
                        Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "Showtryicon", "true");
                        this.Hide();
                        new Frm_Chats().Show();
                    }
                    else
                        PanelAddProfile.Visible = true;
                    timer1.Enabled = false;
                }
                else
                    AdvanceMethod.AdvanceMessageBox("Your activation code is Expierd !");
            }
            else
                AdvanceMethod.AdvanceMessageBox("Your activation code is Expierd !");
        }
        private void PanelAddProfile_DragEnter(object sender, DragEventArgs e)
        {
            lbl_ChanegePhoto.Visible = false;
        }
        string ProfilePic = "";
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "*.jpg|*.jpg|*.png|*.png";
            op.Title = "Select Your First Profile Photo . . .";
            if (op.ShowDialog() == DialogResult.OK)
                ProfilePic = op.FileName;

        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_name.Text))
                lbl_name.Visible = true;
            else
                lbl_name.Visible = false;
        }

        private void txt_Bio_OnValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Bio.Text))
                lbl_Bio.Visible = true;
            else
                lbl_Bio.Visible = false;
        }

        private void txt_Email_OnValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Email.Text))
                lbl_Email.Visible = true;
            else
                lbl_Email.Visible = false;
        }

        private void txt_username_OnValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Email.Text))
            {
                lbl_Username.Text = "Username is required";
                lbl_Username.Visible = true;
            }
            else
            {
                if (!Rep_Users.ValidateUsername(txt_username.Text))
                {
                    lbl_Username.Text = "this username is allery Exist";
                    lbl_Username.Visible = true;
                }
                else
                    lbl_Username.Visible = false;
            }
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            if (!lbl_Bio.Visible && !lbl_name.Visible && !lbl_Email.Visible && !lbl_Username.Visible)
            {
                Frm_Chats.User_id = Rep_Users.InsertUser(txt_name.Text, txt_Lname.Text, txt_CountryCode.Text + txt_PhoneNumber.Text, txt_username.Text, txt_Bio.Text, txt_Email.Text, ProfilePic);
                string SessionCode = Rep_Users.InsertSession(Frm_Chats.User_id);
                Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\SocialMediaLikeTelegram");
                Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "Chatbackground", "1");
                Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "DesktopNotification", "true");
                Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "NotificationCount", "3");
                Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "NotificationPosition", "BottomRight");
                Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "Session", SessionCode);
                Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "ShowMessagePreviw", "true");
                Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "ShowSenderName", "true");
                Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "ShowTaskbarIcon", "true");
                Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "Showtryicon", "true");
                this.Hide();
                new Frm_Chats().Show();
            }
            else
                AdvanceMethod.AdvanceMessageBox("Please Fill Required filds");
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            lbl_ChanegePhoto.Visible = true;
        }

        private void PanelAddProfile_MouseEnter(object sender, EventArgs e)
        {
            lbl_ChanegePhoto.Visible = false;
        }
    }
}
