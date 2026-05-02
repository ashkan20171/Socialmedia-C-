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
using SocialMediaLikeTelegram.Models;

namespace SocialMediaLikeTelegram.Channels
{
    public partial class Frm_AddChannelAddMember : Form
    {
        int TokenEditorLastHeight;
        List<tbl_Users> NewMemberList;
        private int AdminListItemTop
        {
            get
            {
                return panel3.Controls[panel3.Controls.Count - 1].Bottom;
            }
        }
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
        public Frm_AddChannelAddMember()
        {
            InitializeComponent();
            NewMemberList = new List<tbl_Users>();
            NewMemberList.Add(Rep_Users.GetUser(Frm_Chats.User_id));
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_AddMember_Load(object sender, EventArgs e)
        {
            foreach (var item in Rep_Users.GetUserContactList(Frm_Chats.User_id))
            {
                Components.ContactListItem _contactlistitem = new Components.ContactListItem();
                _contactlistitem.Top = AdminListItemTop;
                _contactlistitem.User_id = item.id;
                _contactlistitem.ProfilePic = item.tbl_Pic.Pic_Url;
                _contactlistitem.ContactName = item.Name + " " + item.Lname;
                _contactlistitem.LastSeen = Rep_PrivateChat.UserLastSeen(item.id);
                _contactlistitem.IsActive = false;
                _contactlistitem.Click += ContactListItemClidked;
                PictureBox PicOk = new PictureBox()
                {
                    Tag = item.id,
                    Image = global::SocialMediaLikeTelegram.Properties.Resources.select,
                    Size = new Size(25, 25),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Location = new Point(_contactlistitem.Right - 30, _contactlistitem.Top + 12),
                    Visible = false,
                    BackColor = Color.WhiteSmoke
                };
                panel3.Controls.Add(PicOk);
                PicOk.BringToFront();
                panel3.Controls.Add(_contactlistitem);
            }
            TokenEditorLastHeight = txt_AdminsList.Height;
        }
        private int GetContactPicOk(long User_id)
        {
            int i = 0;
            for (; i < panel3.Controls.Count; i++)
                if (panel3.Controls[i].Tag != null)
                    if ((long)panel3.Controls[i].Tag == User_id)
                        break;
            return i;
        }
        private void ContactListItemClidked(object sender, EventArgs e)
        {
            var Contact = (Components.ContactListItem)sender;
            if (Contact.IsActive)
            {
                Contact.IsActive = false;
                panel3.Controls[GetContactPicOk(Contact.User_id)].Visible = false;
                NewMemberList.Remove(Rep_Users.GetUser(Contact.User_id));
                List<string> AdminsNameList = txt_AdminsList.Text.Split(',').ToList();
                AdminsNameList.Remove(Contact.ContactName);
                txt_AdminsList.Text = "";
                foreach (var item in AdminsNameList)
                {
                    txt_AdminsList.Tokens.Add(new DevComponents.DotNetBar.Controls.EditToken(item));
                    txt_AdminsList.SelectedTokens.Add(txt_AdminsList.Tokens.Last());
                }
            }
            else
            {
                Contact.IsActive = true;
                panel3.Controls[GetContactPicOk(Contact.User_id)].Visible = true;
                NewMemberList.Add(Rep_Users.GetUser(Contact.User_id));
                txt_AdminsList.Tokens.Add(new DevComponents.DotNetBar.Controls.EditToken(Contact.ContactName));
                txt_AdminsList.SelectedTokens.Add(txt_AdminsList.Tokens.Last());
            }
        }

        private void txt_AdminsList_SizeChanged(object sender, EventArgs e)
        {
            if (txt_AdminsList.Height >= 72)
                txt_AdminsList.AutoSizeHeight = false;
            else
            {
                foreach (Control item in panel3.Controls)
                    if (item.Name != "txt_AdminsList")
                        item.Top += TokenEditorLastHeight;
            }
            TokenEditorLastHeight = txt_AdminsList.Height;
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            Models.SocialMediaDBEntities db = new SocialMediaDBEntities();
            int ChannelType = 0;
            if (Frm_AddChannelChannelType.ChannelType == "Public")
                ChannelType = 0;
            else
                ChannelType = 1;
            db.CreateChannel(Frm_AddChannelName.Channel_name, ChannelType, Frm_AddChannelChannelType.Channel_id, Frm_AddChannelChannelType.InviteLink, Rep_Pic.InsertPhoto(Frm_AddChannelName.ProfilePic), Frm_AddChannelName.Channel_Des, Frm_Chats.User_id);
            long Channel_id = Rep_Channels.GetLastChannelID();
            Rep_Channels.AddChannelAdmin(Frm_Chats.User_id, Channel_id);
            foreach (var item in NewMemberList)
                Rep_Channels.AddChannelMember(item.id, Channel_id);
            this.Close();
        }
    }
}
