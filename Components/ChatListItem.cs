using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Components
{
    public partial class ChatListItem : UserControl
    {
        public ChatListItem()
        {
            InitializeComponent();
            BadgeCount = 0;
            HoverColor = Color.FromArgb(241, 241, 241);
            ClickedColor = Color.FromArgb(65, 159, 217);
        }
        #region Hover Color Change
        public Color HoverColor { get; set; }
        public Color ClickedColor { get; set; }
        public long Chat_id { get; set; }
        private void ChatListItem_MouseEnter(object sender, EventArgs e)
        {
            if (!IsActive)
                this.BackColor = HoverColor;
        }

        private void ChatListItem_MouseLeave(object sender, EventArgs e)
        {
            if (!IsActive)
                this.BackColor = Color.White;
        }

        private void ChatListItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (!IsActive)
                if (e.Button == MouseButtons.Left)
                    ActiveMode();
        }

        private void ChatListItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (!IsActive)
                if (this.BackColor == ClickedColor)
                    DeActiveMode();
        }
        #endregion
        #region ChatListItem Properties
        public string ChatName { get { return lblChatName.Text; } set { lblChatName.Text = value; } }
        private bool _isActive = false;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                if (value)
                    ActiveMode();
                else
                    DeActiveMode();
            }
        }
        private int _badge = 0;
        public int BadgeCount
        {
            get { return _badge; }
            set
            {
                _badge = value;
                if (value == 0)
                    lblBadge.Visible = false;
                else
                {
                    lblBadge.Visible = true;
                    lblBadge.Text = " " + value.ToString() + " ";
                }
            }
        }
        private ComponentsProperties.ChatType _chatType;
        public ComponentsProperties.ChatType ChatType
        {
            get { return _chatType; }
            set
            {
                IsSeen.Visible = true;
                _chatType = value;
                if (value == ComponentsProperties.ChatType.Channel)
                {
                    pic_ChatType.Image = global::Components.Properties.Resources._18_feedback;
                    lblLastMessageSenderName.Visible = false;
                    lblLastMessage.Left = lblLastMessageSenderName.Left;
                    lblLastMessage.Width += lblLastMessageSenderName.Width;
                    IsSeen.Visible = false;
                }
                else if (value == ComponentsProperties.ChatType.Group)
                {
                    lblLastMessage.ForeColor = Color.FromArgb(109, 109, 109);
                    pic_ChatType.Image = global::Components.Properties.Resources._18_users;
                    lblLastMessage.Left = lblLastMessageSenderName.Right;
                    lblLastMessage.Width = lblBadge.Left - lblLastMessageSenderName.Right;
                    lblLastMessageSenderName.Visible = true;
                }
                else
                {
                    pic_ChatType.Visible = false;
                    lblLastMessageSenderName.Visible = false;
                    lblLastMessage.Left = lblLastMessageSenderName.Left;
                    lblLastMessage.Width += lblLastMessageSenderName.Width;
                }
            }
        }
        private static ComponentsProperties.MessageType _messageType;
        public ComponentsProperties.MessageType MessageType
        {
            get
            {
                return _messageType;
            }
            set
            {
                _messageType = value;
                if (value == ComponentsProperties.MessageType.PhotoMessage)
                {
                    lblLastMessage.Text = "Photo Message";
                    lblLastMessage.ForeColor = lblLastMessageSenderName.ForeColor;
                }
                else
                {
                    lblLastMessage.Text = LastMessage;
                    lblLastMessage.ForeColor = Color.FromArgb(109, 109, 109);
                }
            }
        }
        public string LastMessage
        {
            get { return lblLastMessage.Text; }
            set { lblLastMessage.Text = value; }
        }
        public string LastMessageSender
        {
            get { return lblLastMessageSenderName.Text; }
            set
            {
                lblLastMessageSenderName.Text = value;
                if (ChatType == ComponentsProperties.ChatType.Group)
                {
                    lblLastMessage.ForeColor = Color.FromArgb(109, 109, 109);
                    pic_ChatType.Image = global::Components.Properties.Resources._18_users;
                    lblLastMessage.Left = lblLastMessageSenderName.Right;
                    lblLastMessage.Width = lblBadge.Left - lblLastMessageSenderName.Right;
                    lblLastMessageSenderName.Visible = true;
                }
            }
        }
        public string LastMessageDate
        {
            get { return lblDate.Text; }
            set { lblDate.Text = value; }
        }
        private static bool _isseen = false;
        public bool Isseen
        {
            get { return _isseen; }
            set
            {
                _isseen = value;
                if (value)
                    IsSeen.Image = global::Components.Properties.Resources.double_tick;
                else
                    IsSeen.Image = global::Components.Properties.Resources.single_tick;
            }
        }
        public Image Profile_Pic { get { return ProfilePic.Image; } set { ProfilePic.Image = value; } }
        private static bool _isSeenArea = false;
        public bool IsSeenArea { get { return _isSeenArea; } set { IsSeen.Visible = value; _isSeenArea = value; } }
        #endregion
        private void ActiveMode()
        {
            IsSeen.Visible = false;
            if (ChatType == ComponentsProperties.ChatType.Channel)
                pic_ChatType.Image = global::Components.Properties.Resources._18_feedback_w;
            else if (ChatType == ComponentsProperties.ChatType.Group)
                pic_ChatType.Image = global::Components.Properties.Resources._18_users_w;
            else
                pic_ChatType.Visible = false;
            BadgeCount = 0;
            lblChatName.ForeColor = Color.White;
            lblLastMessage.ForeColor = Color.White;
            lblLastMessageSenderName.ForeColor = Color.White;
            lblDate.ForeColor = Color.White;
            this.BackColor = ClickedColor;
        }
        private void DeActiveMode()
        {
            if (ChatType != ComponentsProperties.ChatType.Channel && IsSeenArea)
                IsSeen.Visible = true;
            if (ChatType == ComponentsProperties.ChatType.Channel)
                pic_ChatType.Image = global::Components.Properties.Resources._18_feedback;
            else if (ChatType == ComponentsProperties.ChatType.Group)
                pic_ChatType.Image = global::Components.Properties.Resources._18_users;
            else
                pic_ChatType.Visible = false;
            lblChatName.ForeColor = Color.FromArgb(68, 68, 68);
            lblLastMessage.ForeColor = Color.FromArgb(109, 109, 109);
            lblLastMessageSenderName.ForeColor = Color.FromArgb(66, 163, 244);
            lblDate.ForeColor = Color.FromArgb(105, 105, 105); ;
            this.BackColor = Color.White;
        }
    }
}
