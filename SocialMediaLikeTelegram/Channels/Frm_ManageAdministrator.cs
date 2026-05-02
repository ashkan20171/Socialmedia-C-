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
    public partial class Frm_ManageAdministrator : Form
    {
        public static Components.ComponentsProperties.ChatType ChatType = Components.ComponentsProperties.ChatType.Channel;
        public static long Chat_id = 0;
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
        public Frm_ManageAdministrator()
        {
            InitializeComponent();
        }

        private void ColorChanging(object sender, MouseEventArgs e)
        {
            foreach (Components.AdminListItem item in panel2.Controls)
            {
                if (e.X >= item.Location.X || e.Y > item.Location.Y)
                {
                    item.BackColor = Color.White;
                    if (item.IsShowRemoveLink)
                        item.RemoveLinkVisible = false;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public int AdminListItemTop
        {
            get
            {
                if (panel2.Controls.Count > 0)
                    return panel2.Controls[panel2.Controls.Count - 1].Bottom;
                else
                    return 0;
            }
        }
        private void Frm_ManageAdministrator_Load(object sender, EventArgs e)
        {
            foreach (Control item in panel2.Controls)
                panel2.Controls.Remove(item);
            if (panel2.Controls.Count > 0)
                panel2.Controls.RemoveAt(0);
            if (ChatType == Components.ComponentsProperties.ChatType.Channel)
            {
                foreach (var item in Rep_Channels.GetChannelAdminList(Chat_id))
                {
                    Components.AdminListItem _adminlistitem = new Components.AdminListItem();
                    _adminlistitem.Prometer = Rep_Channels.GetAdminPrometor(Chat_id, item.User_id_FK.Value);
                    _adminlistitem.ProfilePic = item.tbl_Users.tbl_Pic.Pic_Url;
                    _adminlistitem.AdminName = item.tbl_Users.Name + " " + item.tbl_Users.Lname;
                    _adminlistitem.AdminChatId = item.id;
                    _adminlistitem.ChatType = ChatType;
                    _adminlistitem.ChatId = Chat_id;
                    _adminlistitem.Top = AdminListItemTop;
                    _adminlistitem.Left = 0;
                    if (Rep_Channels.GetAdminPrometor(Chat_id, Frm_Chats.User_id) == "Creator")
                        _adminlistitem.IsShowRemoveLink = true;
                    else
                        _adminlistitem.IsShowRemoveLink = false;
                    _adminlistitem.RemoveLinkClicked += RemoveLinkClicked;
                    _adminlistitem.Click += AdminListItemClicked;
                    panel2.Controls.Add(_adminlistitem);
                }
                if (Rep_Channels.GetAdminPrometor(Chat_id, Frm_Chats.User_id) != "Creator")
                    materialFlatButton1.Visible = false;
                else
                    materialFlatButton1.Visible = true;
            }
            else
            {
                foreach (var item in Rep_Groups.GetGroupAdminList(Chat_id))
                {
                    Components.AdminListItem _adminlistitem = new Components.AdminListItem();
                    _adminlistitem.Prometer = Rep_Groups.GetAdminPrometer(Chat_id, item.User_id_FK.Value);
                    _adminlistitem.ProfilePic = item.tbl_Users.tbl_Pic.Pic_Url;
                    _adminlistitem.AdminName = item.tbl_Users.Name + " " + item.tbl_Users.Lname;
                    _adminlistitem.AdminChatId = item.id;
                    _adminlistitem.ChatType = ChatType;
                    _adminlistitem.ChatId = Chat_id;
                    _adminlistitem.Top = AdminListItemTop;
                    _adminlistitem.Left = 0;
                    if (Rep_Groups.GetAdminPrometer(Chat_id, Frm_Chats.User_id) == "Creator")
                        _adminlistitem.IsShowRemoveLink = true;
                    else
                        _adminlistitem.IsShowRemoveLink = false;
                    _adminlistitem.RemoveLinkClicked += RemoveLinkClicked;
                    _adminlistitem.Click += AdminListItemClicked;
                    panel2.Controls.Add(_adminlistitem);
                }
                if (Rep_Groups.GetAdminPrometer(Chat_id, Frm_Chats.User_id) != "Creator")
                    materialFlatButton1.Visible = false;
                else
                    materialFlatButton1.Visible = true;
            }
        }
        private void AdminListItemClicked(object sender, EventArgs e)
        {
            Frm_ManagePermissions.ChatType = ChatType;
            Frm_ManagePermissions.AdminChat_id = ((Components.AdminListItem)sender).AdminChatId;
            new Frm_ManagePermissions().ShowDialog(this);
        }
        private void RemoveLinkClicked(object sender, EventArgs e)
        {
            Components.AdminListItem _adminlistitem = (Components.AdminListItem)(sender);
            if (AdvanceMethod.AdvanceMessageBox("Are sure to remove this admin ?") == DialogResult.OK)
            {
                if (ChatType == Components.ComponentsProperties.ChatType.Channel)
                    Rep_Channels.RemoveChannelAdmin(_adminlistitem.AdminChatId);
                else
                    Rep_Groups.DeleteGroupAdmin(_adminlistitem.AdminChatId);
                panel2.Controls.Remove(_adminlistitem);
                panel2.Controls.RemoveAt(0);
                Frm_ManageAdministrator_Load(null, null);
            }
        }
        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            Frm_AddAdmin.ChatType = ChatType;
            Frm_AddAdmin.Chat_id = Chat_id;
            new Frm_AddAdmin().ShowDialog();
            Frm_ManageAdministrator_Load(null, null);
        }
    }
}
