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
    public partial class Frm_ManageBlockedUsers : Form
    {
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
        public Frm_ManageBlockedUsers()
        {
            InitializeComponent();
        }
        private void ColorChanging(object sender, MouseEventArgs e)
        {
            foreach (Components.BlockUsersListItem item in panel2.Controls)
            {
                if (e.X >= item.Location.X || e.Y > item.Location.Y)
                {
                    item.BackColor = Color.White;
                    item.RemoveLinkVisible = false;
                }
            }
        }
        public int BlockListItemTop
        {
            get
            {
                if (panel2.Controls.Count > 0)
                    return panel2.Controls[panel2.Controls.Count - 1].Bottom;
                else
                    return 0;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_ManageBlockedUsers_Load(object sender, EventArgs e)
        {
            foreach (var item in Rep_Users.GetUserBlockList(Frm_Chats.User_id))
            {
                Components.BlockUsersListItem _blockuserlistitem = new Components.BlockUsersListItem();
                _blockuserlistitem.LastSeen = Rep_PrivateChat.UserLastSeen(item.id);
                _blockuserlistitem.User_Name = item.Name + " " + item.Lname;
                _blockuserlistitem.ProfilePic = item.tbl_Pic.Pic_Url;
                _blockuserlistitem.BlockedId = item.id;
                _blockuserlistitem.Top = BlockListItemTop;
                _blockuserlistitem.UnblockClicked += UnblockClicked;
                this.panel2.Controls.Add(_blockuserlistitem);
            }
        }
        private void DeleteAllBlockedList()
        {
            foreach (Control item in panel2.Controls)
                panel2.Controls.Remove(item);
            if (panel2.Controls.Count > 0)
                panel2.Controls.RemoveAt(0);
        }
        private void UnblockClicked(object sender, EventArgs e)
        {
            var Blocked = (Components.BlockUsersListItem)sender;
            Rep_Users.UnblockUser(Blocked.BlockedId);
            DeleteAllBlockedList();
            Frm_ManageBlockedUsers_Load(null, null);
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            new Setting.Frm_BlockUser().ShowDialog(this);
            DeleteAllBlockedList();
            Frm_ManageBlockedUsers_Load(null, null);
        }
    }
}
