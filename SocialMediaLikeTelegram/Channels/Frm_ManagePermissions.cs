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

namespace SocialMediaLikeTelegram.Channels
{
    public partial class Frm_ManagePermissions : Form
    {
        public static Components.ComponentsProperties.ChatType ChatType = Components.ComponentsProperties.ChatType.Channel;
        public static long AdminChat_id = 0;
        #region FormShadow
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
         );
        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);
        private bool m_aeroEnabled = true;                     // variables for box shadow
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;
        public struct MARGINS                           // struct for box shadow
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:                        // box shadow
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 1,
                            rightWidth = 1,
                            topHeight = 1
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);

                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }
        #endregion
        public Frm_ManagePermissions()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_ManagePermissions_Load(object sender, EventArgs e)
        {
            if (ChatType == Components.ComponentsProperties.ChatType.Channel)
            {
                var Q = Rep_Channels.GetChannelAdmin(AdminChat_id);
                swch_Delete.Value = Q.CanDelete.Value;
                swch_Edit.Value = Q.CanEdit.Value;
                swch_Pin.Value = Q.CanPin.Value;
                pictureBox2.ImageLocation = Q.tbl_Users.tbl_Pic.Pic_Url;
                lbl_LastSeen.Text = Rep_PrivateChat.UserLastSeen(Q.User_id_FK.Value);
                lbl_Name.Text = Q.tbl_Users.Name + " " + Q.tbl_Users.Lname;
                if (Rep_Channels.GetAdminPrometor(Q.Channel_id_FK.Value, Frm_Chats.User_id) != "Creator")
                {
                    swch_Pin.Enabled = false;
                    swch_Edit.Enabled = false;
                    swch_Delete.Enabled = false;
                    materialFlatButton1.Visible = false;
                }
            }
            else
            {
                var Q = Rep_Groups.GetGroupAdmin(AdminChat_id);
                swch_Delete.Value = Q.CanDelete.Value;
                swch_Edit.Value = Q.CanBanMember.Value;
                swch_Pin.Value = Q.CanPin.Value;
                pictureBox2.ImageLocation = Q.tbl_Users.tbl_Pic.Pic_Url;
                lbl_LastSeen.Text = Rep_PrivateChat.UserLastSeen(Q.User_id_FK.Value);
                lbl_Name.Text = Q.tbl_Users.Name + " " + Q.tbl_Users.Lname;
                label3.Text = "ban member's";
                if (Rep_Groups.GetAdminPrometer(Q.Group_id_FK.Value, Frm_Chats.User_id) != "Creator")
                {
                    swch_Pin.Enabled = false;
                    swch_Edit.Enabled = false;
                    swch_Delete.Enabled = false;
                    materialFlatButton1.Visible = false;
                }
            }
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            if (ChatType == Components.ComponentsProperties.ChatType.Channel)
                Rep_Channels.EditChannelAdminPermition(AdminChat_id, swch_Edit.Value, swch_Delete.Value, swch_Pin.Value);
            else
                Rep_Groups.EditGroupAdminPermition(AdminChat_id, swch_Edit.Value, swch_Delete.Value, swch_Pin.Value);
            this.Close();
        }
    }
}
