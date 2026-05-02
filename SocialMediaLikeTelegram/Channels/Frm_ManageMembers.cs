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
    public partial class Frm_ManageMembers : Form
    {
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
        public Frm_ManageMembers()
        {
            InitializeComponent();
        }

        private void ColorChanging(object sender, MouseEventArgs e)
        {
            foreach (Components.BanUsersListItem item in panel2.Controls)
            {
                if (e.X >= item.Location.X || e.Y > item.Location.Y)
                {
                    item.BackColor = Color.White;
                    if (item.RemoveVisible)
                        item.RemoveLinkVisible = false;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public int MemberListItemTop
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
            if (Rep_Channels.GetAdminPrometor(Chat_id, Frm_Chats.User_id) != "Creator")
                materialFlatButton1.Visible = false;
            foreach (var item in Rep_Channels.GetChannelMember(Chat_id))
            {
                Components.BanUsersListItem _banuserlistitem = new Components.BanUsersListItem();
                _banuserlistitem.Top = MemberListItemTop;
                _banuserlistitem.ProfilePic = item.tbl_Pic.Pic_Url;
                _banuserlistitem.LastSeen = Rep_PrivateChat.UserLastSeen(item.id);
                _banuserlistitem.User_Name = item.Name + " " + item.Lname;
                _banuserlistitem.User_id = item.id;
                _banuserlistitem.Click += MemberListClicked;
                _banuserlistitem.RemoveLinkClicked += RemoveLinkClicked;
                if (Rep_Channels.IsChannelAdmin(item.id, Chat_id))
                    _banuserlistitem.RemoveVisible = false;
                else
                    _banuserlistitem.RemoveVisible = true;
                panel2.Controls.Add(_banuserlistitem);
            }
        }
        private void MemberListClicked(object sender, EventArgs e)
        {
            Profiles.Frm_UserInfo.User_id = ((Components.BanUsersListItem)sender).User_id;
            new Profiles.Frm_UserInfo().ShowDialog(this);
        }
        private void RemoveLinkClicked(object sender, EventArgs e)
        {
            if (AdvanceMethod.AdvanceMessageBox("Are you sure to remove this member from channel ?") == DialogResult.OK)
            {
                var member = ((Components.BanUsersListItem)sender);
                Rep_Channels.DeleteChannelMember(Chat_id, member.User_id);
                ((Frm_Chats)this.Owner.Owner).lblLastSeenOrMemberCount.Text = Rep_Channels.GetChannelMemberCount(Chat_id).ToString();
                ((Profiles.Frm_ChannelInfo)this.Owner).lbl_MemberCount.Text = Rep_Channels.GetChannelMemberCount(Chat_id).ToString();
                panel2.Controls.Remove(member);
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
            Frm_AddMember.ChatType = Components.ComponentsProperties.ChatType.Channel;
            Frm_AddMember.Chat_id = Chat_id;
            new Frm_AddMember().ShowDialog(this);
            Frm_ManageAdministrator_Load(null, null);
        }
    }
}
