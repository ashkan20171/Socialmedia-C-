using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SocialMediaLikeTelegram.Models.Repository;
using Components;
using Components.Bubble;
using SocialMediaLikeTelegram.Models;

namespace SocialMediaLikeTelegram
{
    public partial class Frm_Chats : MaterialForm
    {
        List<Components.ChatListItem> ChatLists;
        bool ShowDesktopNotification = true;
        public static List<long> NotificationMessages;
        public static long User_id { get; set; }
        private List<Point> MessagesLocation { get; set; }
        int PinMessageLocationIndex = 0;
        public int ChatListTop
        {
            get
            {
                if (ChatList.Controls.Count == 0)
                    return 0;
                else
                    return ChatList.Controls[ChatList.Controls.Count - 1].Bottom;
            }
        }
        public Frm_Chats()
        {
            InitializeComponent();
            ChatLists = new List<ChatListItem>();
            MessagesLocation = new List<Point>();
            NotificationMessages = new List<long>();
        }
        private void Frm_Chats_Load(object sender, EventArgs e)
        {
            try
            {
                var Q = Rep_Chats.GetChatLists(User_id);
                foreach (var item in Q)
                {
                    ChatListItem _chatlist = new ChatListItem();
                    _chatlist.Name = "ChatList_" + item.ChatType.ToString() + "_" + item.Chat_id;
                    _chatlist.ChatName = item.ChatName;
                    if (item.ChatType == ComponentsProperties.ChatType.PrivateChat)
                        if (Rep_Users.IsContact(User_id, Rep_PrivateChat.PrivateChatTarget(item.Chat_id, User_id).id))
                        {
                            long TargetUser_id = Rep_PrivateChat.PrivateChatTarget(item.Chat_id, User_id).id;
                            _chatlist.ChatName = Rep_Users.GetContactName(User_id, TargetUser_id);
                        }
                    _chatlist.ChatType = item.ChatType;
                    _chatlist.MessageType = item.LastMessageType;
                    _chatlist.LastMessage = item.LastMessage.Text;
                    _chatlist.LastMessageDate = item.Day + "" + AdvanceMethod.GetMonthString(item.Month);
                    if (item.LastMessageMode == ComponentsProperties.MessageMode.incoming && item.ChatType == ComponentsProperties.ChatType.Group)
                        _chatlist.LastMessageSender = item.LastMessageSender.Name;
                    else
                        _chatlist.LastMessageSender = "You";
                    _chatlist.Isseen = item.IsResive;
                    _chatlist.Profile_Pic = item.ProfilePic;
                    if (item.ChatType == ComponentsProperties.ChatType.Group && item.LastMessageSender.id == 3)
                        _chatlist.IsSeenArea = true;
                    else if (item.ChatType == ComponentsProperties.ChatType.PrivateChat && item.LastMessageMode == ComponentsProperties.MessageMode.outing)
                        _chatlist.IsSeenArea = true;
                    if (item.ChatType == ComponentsProperties.ChatType.PrivateChat)
                        _chatlist.IsSeenArea = !Rep_PrivateChat.IsSendigMessage(User_id, Rep_PrivateChat.GetPrivateChatMessage(item.Chat_id).id);
                    _chatlist.Chat_id = item.Chat_id;
                    _chatlist.Click += ChatListItemsClicked;
                    _chatlist.BadgeCount = item.BadgeCount;
                    _chatlist.Top = ChatListTop;
                    ChatList.Controls.Add(_chatlist);
                }
                #region ChangeChatBackground
                string R6 = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "Chatbackground", "").ToString();
                if (R6 == "")
                    ChatControl.BackColor = Color.WhiteSmoke;
                else if (R6.Contains("/"))
                    ChatControl.BackgroundImage = Image.FromFile(R6);
                else
                {
                    if (R6 == "1")
                        ChatControl.BackgroundImage = global::SocialMediaLikeTelegram.Properties.Resources._1;
                    else if (R6 == "2")
                        ChatControl.BackgroundImage = global::SocialMediaLikeTelegram.Properties.Resources._2;
                    else if (R6 == "3")
                        ChatControl.BackgroundImage = global::SocialMediaLikeTelegram.Properties.Resources._3;
                    else if (R6 == "6")
                        ChatControl.BackgroundImage = global::SocialMediaLikeTelegram.Properties.Resources._41;
                    else if (R6 == "5")
                        ChatControl.BackgroundImage = global::SocialMediaLikeTelegram.Properties.Resources._5;
                    else if (R6 == "4")
                        ChatControl.BackgroundImage = global::SocialMediaLikeTelegram.Properties.Resources._6;
                    else if (R6 == "7")
                        ChatControl.BackgroundImage = global::SocialMediaLikeTelegram.Properties.Resources._7;
                    else if (R6 == "8")
                        ChatControl.BackgroundImage = global::SocialMediaLikeTelegram.Properties.Resources._8;
                    else if (R6 == "9")
                        ChatControl.BackgroundImage = global::SocialMediaLikeTelegram.Properties.Resources._9;
                }
                if (ChatControl.BackgroundImage != null)
                    PanelUnderChatList.BackgroundImage = ChatControl.BackgroundImage;
                else
                    PanelUnderChatList.BackColor = ChatControl.BackColor;
                #endregion
                lbl_Menu_UserName.Text = Rep_Users.GetUser(User_id).Name + " " + Rep_Users.GetUser(User_id).Lname;
                lbl_Menu_Phone.Text = Rep_Users.GetUser(User_id).PhoneNumber;
                if (Rep_Users.GetUser(User_id).tbl_Pic != null)
                    Menu_Profile_Pic.ImageLocation = Rep_Users.GetUser(User_id).tbl_Pic.Pic_Url;
                ShowDesktopNotification = Convert.ToBoolean(Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "DesktopNotification", true));
                #region FillEmojiPanel
                var EmojiList = Rep_Chats.GetEmojiList();
                int EmojiListTop = -20;
                int EmojiListLeft = 5;
                for (int i = 0; i < EmojiList.Count; i++)
                {
                    if (i % 5 == 0)
                    {
                        EmojiListTop += 30;
                        EmojiListLeft = 5;
                    }
                    PictureBox Pic = new PictureBox();
                    Pic.Name = "Emoji_" + EmojiList.ToArray()[i].id;
                    Pic.SizeMode = PictureBoxSizeMode.Zoom;
                    Pic.Size = new Size(25, 25);
                    Pic.ImageLocation = EmojiList.ToArray()[i].Big_url;
                    Pic.Top = EmojiListTop;
                    Pic.Left = EmojiListLeft;
                    Pic.MouseEnter += pictureBox7_MouseEnter;
                    Pic.Click += EmojiClicked;
                    PanelEmoji.Controls.Add(Pic);
                    EmojiListLeft += 30;
                }
                #endregion
                foreach (Control item in panel2.Controls)
                {
                    if (item.Name != "pictureBox7" && item.Name != "PanelEmoji")
                        item.MouseEnter += PanelEmoji_MouseLeave;
                }
                var Notify = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "Showtryicon", false);
                if (Notify.ToString() == "True")
                {
                    notifyIcon1.Visible = true;
                    enableNotificationToolStripMenuItem.Text = "Disable Notification";
                }
                else
                    notifyIcon1.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void EmojiClicked(object sender, EventArgs e)
        {
            PictureBox Pic = (PictureBox)sender;
            var Emoji = Rep_Chats.GetEmoji(int.Parse(Pic.Name.Replace("Emoji_", "")));
            Clipboard.SetImage(Image.FromFile(Emoji.Tumb_url));
            txtSendText.Paste();
            txtSendText.Focus();
            txtSendText.Tag += "#" + Emoji.id + "#";
        }
        private void ChatListItemsClicked(object sender, EventArgs e)
        {
            PanelNotChannelAdmin.Visible = false;
            PanelUnderChatList.Visible = false;
            var ChatListItem = (Components.ChatListItem)(sender);
            #region Show ChatMessages
            ChatControl.RemoveAllMessages();
            ChatControl.ChatType = ChatListItem.ChatType;
            foreach (var item in ChatList.Controls)
                ((Components.ChatListItem)(item)).IsActive = false;
            ((Components.ChatListItem)(sender)).IsActive = true;
            ChatControl.Chat_id = ChatListItem.Chat_id;
            if (PinPanel.Visible)
            {
                ChatControl.Height += PinPanel.Height;
                ChatControl.Top = PinPanel.Top;
                PinPanel.Visible = false;
            }
            if (ChatListItem.ChatType == ComponentsProperties.ChatType.Channel)
            {
                pinToolStripMenuItem.Visible = true;
                ChatControl.AdminPermision = Rep_Channels.GetChannelAdminPermisions(ChatControl.Chat_id, User_id);
                var PinMessage = Rep_Channels.GetChannelPinMessage(ChatControl.Chat_id);
                foreach (var item in Rep_Channels.GetChannelMessageList(ChatListItem.Chat_id))
                {
                    RichTextBox r = new RichTextBox();
                    r.Text = item.tbl_Message.Text;
                    r.Rtf = GetEmojiRtfCode(r.Rtf);
                    string PicPath = "";
                    if (item.tbl_Message != null && item.tbl_Message.tbl_Pic != null)
                        PicPath = item.tbl_Message.tbl_Pic.Pic_Url;
                    ChatControl.ChatType = ComponentsProperties.ChatType.Channel;
                    ChatControl.SendMessage((Components.ComponentsProperties.MessageType)(item.tbl_Message.Type), ComponentsProperties.MessageMode.incoming
                        , r.Rtf, PicPath, item.tbl_Message.IsEdited.Value, item.tbl_Message.Time, item.tbl_Message.Date, item.Message_id_FK.Value, Rep_Channels.GetChannelName(item.Channel_id_FK.Value), true, Rep_Channels.ChannelPostsSeenCount(item.Message_id_FK.Value));
                    if (item.Message_id_FK == PinMessage.id)
                        PinMessageLocationIndex = ChatControl.Controls.Count - 1;
                }
            }
            else if (ChatListItem.ChatType == ComponentsProperties.ChatType.Group)
            {
                pinToolStripMenuItem.Visible = true;
                ChatControl.AdminPermision = Rep_Groups.GroupAdminPermision(ChatControl.Chat_id, User_id);
                var PinMessage = Rep_Groups.GetGroupPinMessage(ChatControl.Chat_id);
                if (PinMessage.Type != null)
                {
                    PinPanel.Visible = true;
                    ChatControl.Height -= PinPanel.Height;
                    ChatControl.Top = PinPanel.Bottom;
                    lbl_PinMessageText.Text = PinMessage.Text;
                }
                foreach (var item in Rep_Groups.GetGroupMessage(ChatListItem.Chat_id))
                {
                    string PicPath = "";
                    if (item.tbl_Message != null && item.tbl_Message.tbl_Pic != null)
                        PicPath = item.tbl_Message.tbl_Pic.Pic_Url;
                    ChatControl.ChatType = ComponentsProperties.ChatType.Group;
                    Components.ComponentsProperties.MessageMode _messagemode = ComponentsProperties.MessageMode.incoming;
                    if (Rep_Groups.IsSendigMessage(User_id, item.id))
                        _messagemode = ComponentsProperties.MessageMode.outing;
                    RichTextBox r = new RichTextBox();
                    r.Text = item.tbl_Message.Text;
                    r.Rtf = GetEmojiRtfCode(r.Rtf);
                    ChatControl.SendMessage((ComponentsProperties.MessageType)(item.tbl_Message.Type), _messagemode,
                        r.Rtf, PicPath, item.tbl_Message.IsEdited.Value, item.tbl_Message.Time, item.tbl_Message.Date, item.Message_id_FK.Value, item.tbl_Users.Name + " " + item.tbl_Users.Lname, item.IsRecive.Value, 0);
                    if (item.Message_id_FK == PinMessage.id)
                        PinMessageLocationIndex = ChatControl.Controls.Count - 1;
                }
            }
            else
            {
                pinToolStripMenuItem.Visible = false;
                foreach (var item in Rep_PrivateChat.PrivateChatMessages(ChatListItem.Chat_id))
                {
                    string PicPath = "";
                    if (item.tbl_Message.tbl_Pic != null)
                        PicPath = item.tbl_Message.tbl_Pic.Pic_Url;
                    ChatControl.ChatType = ComponentsProperties.ChatType.PrivateChat;
                    Components.ComponentsProperties.MessageMode _messagemode = ComponentsProperties.MessageMode.incoming;
                    if (Rep_PrivateChat.IsSendigMessage(User_id, item.id))
                        _messagemode = ComponentsProperties.MessageMode.outing;
                    RichTextBox r = new RichTextBox();
                    r.Text = item.tbl_Message.Text;
                    r.Rtf = GetEmojiRtfCode(r.Rtf);
                    ChatControl.SendMessage((Components.ComponentsProperties.MessageType)(item.tbl_Message.Type), _messagemode,
                        r.Rtf, PicPath, item.tbl_Message.IsEdited.Value, item.tbl_Message.Time, item.tbl_Message.Date, item.Message_id_FK.Value, "", item.IsRecive.Value, 0);
                }
            }
            SetRightMenuItemVisible();
            #endregion
            #region Seen Posts
            if (ChatListItem.ChatType == ComponentsProperties.ChatType.Channel)
                Rep_Channels.SeenChannelPosts(ChatListItem.Chat_id, User_id);
            else if (ChatListItem.ChatType == ComponentsProperties.ChatType.Group)
                Rep_Groups.SeenGroupPosts(ChatListItem.Chat_id);
            else
                Rep_PrivateChat.SeenPrivateChatPost(ChatListItem.Chat_id, User_id);
            #endregion
            #region ShowChatInformation
            if (ChatListItem.ChatType == ComponentsProperties.ChatType.Channel)
            {
                ProfilePicView.Image = Rep_Channels.GetChannelProfilePic(ChatListItem.Chat_id);
                lblLastSeenOrMemberCount.Text = Rep_Channels.GetChannelMemberCount(ChatListItem.Chat_id).ToString("n0");
                lbl_Name.Text = Rep_Channels.GetChannelName(ChatListItem.Chat_id);
            }
            else if (ChatListItem.ChatType == ComponentsProperties.ChatType.Group)
            {
                ProfilePicView.Image = Rep_Groups.GetGroupProfileImage(ChatListItem.Chat_id);
                lblLastSeenOrMemberCount.Text = Rep_Groups.GetGroupMemberCount(ChatListItem.Chat_id).ToString("n0");
                lbl_Name.Text = Rep_Groups.GetGroupName(ChatListItem.Chat_id);
            }
            else
            {
                ProfilePicView.Image = Rep_PrivateChat.GetProfilePic(ChatListItem.Chat_id, User_id);
                lbl_Name.Text = Rep_PrivateChat.GetPrivateChatName(ChatListItem.Chat_id, User_id);
                if (ChatListItem.ChatType == ComponentsProperties.ChatType.PrivateChat)
                    if (Rep_Users.IsContact(User_id, Rep_PrivateChat.PrivateChatTarget(ChatListItem.Chat_id, User_id).id))
                    {
                        long TargetUser_id = Rep_PrivateChat.PrivateChatTarget(ChatListItem.Chat_id, User_id).id;
                        lbl_Name.Text = Rep_Users.GetContactName(User_id, TargetUser_id);
                    }
                lblLastSeenOrMemberCount.Text = Rep_PrivateChat.UserLastSeen(Rep_PrivateChat.PrivateChatTarget(ChatListItem.Chat_id, User_id).id);
            }
            #endregion
            #region IsChannelAdmin And BlockUser
            if (ChatControl.ChatType == ComponentsProperties.ChatType.Channel)
            {
                if (!Rep_Channels.IsChannelAdmin(User_id, ChatListItem.Chat_id))
                {
                    PanelNotChannelAdmin.Visible = true;
                    if (Rep_Channels.IsChannelMember(ChatListItem.Chat_id, User_id))
                        btn_NotChannelAdminAction.Text = "Leave";
                    else
                        btn_NotChannelAdminAction.Text = "Join";
                }
            }
            else if (ChatControl.ChatType == ComponentsProperties.ChatType.PrivateChat)
            {
                if (Rep_Users.IsBlockUser(Rep_PrivateChat.PrivateChatTarget(ChatControl.Chat_id, User_id).id, User_id))
                {
                    PanelNotChannelAdmin.Visible = true;
                    btn_NotChannelAdminAction.Text = "UNBLOCK";
                }
            }
            #endregion
        }

        private void BtnSendMessage_Click(object sender, EventArgs e)
        {
            if (Rep_Users.IsBlockUser(User_id, Rep_PrivateChat.PrivateChatTarget(ChatControl.Chat_id, User_id).id))
                return;
            if ((string)Btn_BrowsePic.Tag != "")
            {
                Models.tbl_Message _Message = Rep_Message.InsertMessage(txtSendText.Tag.ToString(), AdvanceMethod.UploadPhoto((string)Btn_BrowsePic.Tag), ComponentsProperties.MessageType.PhotoMessage, User_id);
                long ChatMessage_id = 0;
                if (ChatControl.ChatType == ComponentsProperties.ChatType.Channel)
                {
                    ChatMessage_id = Rep_Channels.InsertChannelPost(_Message.id, ChatControl.Chat_id, User_id);
                    ChatControl.SendMessage(ComponentsProperties.MessageType.PhotoMessage, ComponentsProperties.MessageMode.outing,
                        txtSendText.Rtf, _Message.tbl_Pic.Pic_Url, false, _Message.Time, _Message.Date, _Message.id, "", true, Rep_Channels.ChannelPostsSeenCount(_Message.id));
                }
                else if (ChatControl.ChatType == ComponentsProperties.ChatType.Group)
                {
                    var Q = Rep_Groups.InsertGroupMessage(_Message.id, ChatControl.Chat_id, User_id);
                    ChatControl.SendMessage(ComponentsProperties.MessageType.PhotoMessage, ComponentsProperties.MessageMode.outing,
                        txtSendText.Rtf, _Message.tbl_Pic.Pic_Url, false, _Message.Time, _Message.Date, _Message.id, "", Q.IsRecive.Value, 0);
                }
                else
                {
                    var Q = Rep_PrivateChat.InsertPrivateChatMessage(_Message.id, ChatControl.Chat_id, User_id);
                    ChatControl.SendMessage(ComponentsProperties.MessageType.PhotoMessage, ComponentsProperties.MessageMode.outing,
                        txtSendText.Rtf, _Message.tbl_Pic.Pic_Url, false, _Message.Time, _Message.Date, _Message.id, "", Q.IsRecive.Value, 0);
                }
            }
            else
            {
                Models.tbl_Message _Message = Rep_Message.InsertMessage(txtSendText.Tag.ToString(), "", ComponentsProperties.MessageType.TextMessage, 0);
                if (ChatControl.ChatType == ComponentsProperties.ChatType.Channel)
                {
                    var Q = Rep_Channels.InsertChannelPost(_Message.id, ChatControl.Chat_id, User_id);
                    ChatControl.SendMessage(ComponentsProperties.MessageType.TextMessage, ComponentsProperties.MessageMode.outing,
                        txtSendText.Rtf, "", false, _Message.Time, _Message.Date, _Message.id, "", true, Rep_Channels.ChannelPostsSeenCount(_Message.id));
                }
                else if (ChatControl.ChatType == ComponentsProperties.ChatType.Group)
                {
                    var Q = Rep_Groups.InsertGroupMessage(_Message.id, ChatControl.Chat_id, User_id);
                    ChatControl.SendMessage(ComponentsProperties.MessageType.TextMessage, ComponentsProperties.MessageMode.outing,
                        txtSendText.Rtf, "", false, _Message.Time, _Message.Date, _Message.id, "", Q.IsRecive.Value, 0);
                }
                else
                {
                    var Q = Rep_PrivateChat.InsertPrivateChatMessage(_Message.id, ChatControl.Chat_id, User_id);
                    ChatControl.SendMessage(ComponentsProperties.MessageType.TextMessage, ComponentsProperties.MessageMode.outing,
                        txtSendText.Rtf, "", false, _Message.Time, _Message.Date, _Message.id, "", Q.IsRecive.Value, 0);
                }
            }
        }

        private void Btn_BrowsePic_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Choose a Photo to Send ...";
            op.Filter = "Jpg Files|*.jpg|Png Files|*.PNG";
            if (op.ShowDialog(this) == DialogResult.OK)
                Btn_BrowsePic.Tag = op.FileName;
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (ChatControl.TargetControlRightClick.GetType().Name == "PhotoMessageBubble")
            {
                PhotoMessageBubble PhotoMessage = (PhotoMessageBubble)(ChatControl.TargetControlRightClick);
                if (PhotoMessage.ChatType == ComponentsProperties.ChatType.Channel)
                {
                    Rep_Channels.DeleteChannelMessage(ChatControl.Chat_id, PhotoMessage.Message_id);
                }
                else if (PhotoMessage.ChatType == ComponentsProperties.ChatType.Group)
                {
                    Rep_Groups.DeleteGroupMessage(PhotoMessage.Message_id, ChatControl.Chat_id);
                }
                else
                {
                    Rep_PrivateChat.DeletePrivateChatMessage(ChatControl.Chat_id, PhotoMessage.Message_id, User_id);
                }
                Rep_Message.DeleteMessage(PhotoMessage.Message_id);
            }
            else
            {
                TextMessageBubble TextMessage = (TextMessageBubble)(ChatControl.TargetControlRightClick);
                if (TextMessage.ChatType == ComponentsProperties.ChatType.Channel)
                {
                    Rep_Channels.DeleteChannelMessage(ChatControl.Chat_id, TextMessage.Message_id);
                }
                else if (TextMessage.ChatType == ComponentsProperties.ChatType.Group)
                {
                    Rep_Groups.DeleteGroupMessage(TextMessage.Message_id, ChatControl.Chat_id);
                }
                else
                {
                    Rep_PrivateChat.DeletePrivateChatMessage(ChatControl.Chat_id, TextMessage.Message_id, User_id);
                }
                Rep_Message.DeleteMessage(TextMessage.Message_id);
            }
            ChatControl.RemoveAllMessages();
            #region ReSendMessage
            if (ChatControl.ChatType == ComponentsProperties.ChatType.Channel)
            {
                pinToolStripMenuItem.Visible = true;
                foreach (var item in Rep_Channels.GetChannelMessageList(ChatControl.Chat_id))
                {
                    string PicPath = "";
                    if (item.tbl_Message != null && item.tbl_Message.tbl_Pic != null)
                        PicPath = item.tbl_Message.tbl_Pic.Pic_Url;
                    ChatControl.ChatType = ComponentsProperties.ChatType.Channel;
                    RichTextBox r = new RichTextBox();
                    r.Text = item.tbl_Message.Text;
                    r.Rtf = GetEmojiRtfCode(r.Rtf);
                    ChatControl.SendMessage((Components.ComponentsProperties.MessageType)(item.tbl_Message.Type), ComponentsProperties.MessageMode.incoming
                        , r.Rtf, PicPath, item.tbl_Message.IsEdited.Value, item.tbl_Message.Time, item.tbl_Message.Date, item.Message_id_FK.Value, Rep_Channels.GetChannelName(item.Channel_id_FK.Value), true, Rep_Channels.ChannelPostsSeenCount(item.Message_id_FK.Value));
                }
            }
            else if (ChatControl.ChatType == ComponentsProperties.ChatType.Group)
            {
                pinToolStripMenuItem.Visible = true;
                foreach (var item in Rep_Groups.GetGroupMessage(ChatControl.Chat_id))
                {
                    string PicPath = "";
                    if (item.tbl_Message != null && item.tbl_Message.tbl_Pic != null)
                        PicPath = item.tbl_Message.tbl_Pic.Pic_Url;
                    ChatControl.ChatType = ComponentsProperties.ChatType.Group;
                    Components.ComponentsProperties.MessageMode _messagemode = ComponentsProperties.MessageMode.incoming;
                    if (Rep_Groups.IsSendigMessage(User_id, item.id))
                        _messagemode = ComponentsProperties.MessageMode.outing;
                    RichTextBox r = new RichTextBox();
                    r.Text = item.tbl_Message.Text;
                    r.Rtf = GetEmojiRtfCode(r.Rtf);
                    ChatControl.SendMessage((ComponentsProperties.MessageType)(item.tbl_Message.Type), _messagemode,
                        r.Rtf, PicPath, item.tbl_Message.IsEdited.Value, item.tbl_Message.Time, item.tbl_Message.Date, item.Message_id_FK.Value, item.tbl_Users.Name + " " + item.tbl_Users.Lname, item.IsRecive.Value, 0);
                }
            }
            else
            {
                pinToolStripMenuItem.Visible = false;
                foreach (var item in Rep_PrivateChat.PrivateChatMessages(ChatControl.Chat_id))
                {
                    string PicPath = "";
                    if (item.tbl_Message.tbl_Pic != null)
                        PicPath = item.tbl_Message.tbl_Pic.Pic_Url;
                    ChatControl.ChatType = ComponentsProperties.ChatType.PrivateChat;
                    Components.ComponentsProperties.MessageMode _messagemode = ComponentsProperties.MessageMode.incoming;
                    if (Rep_PrivateChat.IsSendigMessage(User_id, item.id))
                        _messagemode = ComponentsProperties.MessageMode.outing;
                    RichTextBox r = new RichTextBox();
                    r.Text = item.tbl_Message.Text;
                    r.Rtf = GetEmojiRtfCode(r.Rtf);
                    ChatControl.SendMessage((Components.ComponentsProperties.MessageType)(item.tbl_Message.Type), _messagemode,
                        r.Rtf, PicPath, item.tbl_Message.IsEdited.Value, item.tbl_Message.Time, item.tbl_Message.Date, item.Message_id_FK.Value, "", item.IsRecive.Value, 0);
                }
            }
            #endregion
        }
        private void SetRightMenuItemVisible()
        {
            if (ChatControl.ChatType != ComponentsProperties.ChatType.PrivateChat)
            {
                if (!ChatControl.AdminPermision.CanDeleteMessages)
                    RightClickMenu.Items[0].Visible = false;
                else
                    RightClickMenu.Items[0].Visible = true;
                if (!ChatControl.AdminPermision.CanEditMessages)
                    RightClickMenu.Items[1].Visible = false;
                else
                    RightClickMenu.Items[1].Visible = true;
                if (!ChatControl.AdminPermision.CanPinMessages)
                    RightClickMenu.Items[2].Visible = false;
                else
                    RightClickMenu.Items[2].Visible = true;
            }
            else
            {
                RightClickMenu.Items[0].Visible = true;
                RightClickMenu.Items[1].Visible = true;
                RightClickMenu.Items[2].Visible = false;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ChatControl.TargetControlRightClick.GetType().Name == "PhotoMessageBubble")
            {
                PhotoMessageBubble PhotoMessage = ((PhotoMessageBubble)ChatControl.TargetControlRightClick);
                Frm_EditMessages.MessageText = PhotoMessage.PhotoCaption;
                new Frm_EditMessages().ShowDialog(this);
                if (Frm_EditMessages.IsEdited)
                {
                    Rep_Message.EdditMessage(PhotoMessage.Message_id, Frm_EditMessages.MessageText);
                    PhotoMessage.PhotoCaption = Frm_EditMessages.MessageText;
                    PhotoMessage.IsEdited = true;
                }
            }
            else
            {
                TextMessageBubble TextMessage = ((TextMessageBubble)ChatControl.TargetControlRightClick);
                Frm_EditMessages.MessageText = TextMessage.MessageText;
                new Frm_EditMessages().ShowDialog(this);
                if (Frm_EditMessages.IsEdited)
                {
                    Rep_Message.EdditMessage(TextMessage.Message_id, Frm_EditMessages.MessageText);
                    TextMessage.MessageText = Frm_EditMessages.MessageText;
                    TextMessage.IsEdit = true;
                }
            }
        }

        private void pinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ChatControl.TargetControlRightClick.GetType().Name == "PhotoMessageBubble")
            {
                PhotoMessageBubble PhotoMessage = ((PhotoMessageBubble)ChatControl.TargetControlRightClick);
                if (ChatControl.ChatType == ComponentsProperties.ChatType.Channel)
                {
                    Rep_Channels.PinMessage(PhotoMessage.Message_id, ChatControl.Chat_id);
                    PinPanel.Visible = true;
                    ChatControl.Height -= PinPanel.Height;
                    ChatControl.Top = PinPanel.Bottom;
                    lbl_PinMessageText.Text = PhotoMessage.PhotoCaption;
                    PinMessageLocationIndex = GetControlIndexInChatControl(PhotoMessage);
                }
                else if (ChatControl.ChatType == ComponentsProperties.ChatType.Group)
                {
                    Rep_Groups.PinMessage(PhotoMessage.Message_id, ChatControl.Chat_id);
                    PinPanel.Visible = true;
                    ChatControl.Height -= PinPanel.Height;
                    ChatControl.Top = PinPanel.Bottom;
                    lbl_PinMessageText.Text = PhotoMessage.PhotoCaption;
                    PinMessageLocationIndex = GetControlIndexInChatControl(PhotoMessage);
                }
            }
            else
            {
                TextMessageBubble TextMessage = ((TextMessageBubble)ChatControl.TargetControlRightClick);
                if (ChatControl.ChatType == ComponentsProperties.ChatType.Channel)
                {
                    Rep_Channels.PinMessage(TextMessage.Message_id, ChatControl.Chat_id);
                    PinPanel.Visible = true;
                    ChatControl.Height -= PinPanel.Height;
                    ChatControl.Top = PinPanel.Bottom;
                    lbl_PinMessageText.Text = TextMessage.MessageText;
                    PinMessageLocationIndex = GetControlIndexInChatControl(TextMessage);
                }
                else if (ChatControl.ChatType == ComponentsProperties.ChatType.Group)
                {
                    Rep_Groups.PinMessage(TextMessage.Message_id, ChatControl.Chat_id);
                    PinPanel.Visible = true;
                    ChatControl.Height -= PinPanel.Height;
                    ChatControl.Top = PinPanel.Bottom;
                    lbl_PinMessageText.Text = TextMessage.MessageText;
                    PinMessageLocationIndex = GetControlIndexInChatControl(TextMessage);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (ChatControl.ChatType == ComponentsProperties.ChatType.Channel)
            {
                var Per = Rep_Channels.GetChannelAdminPermisions(ChatControl.Chat_id, User_id);
                if (Per.CanPinMessages)
                {
                    Rep_Channels.DeletePinMessage(ChatControl.Chat_id);
                    ChatControl.Height += PinPanel.Height;
                    ChatControl.Top = PinPanel.Top;
                    PinPanel.Visible = false;
                }
            }
            else if (ChatControl.ChatType == ComponentsProperties.ChatType.Group)
            {
                var Per = Rep_Groups.GroupAdminPermision(ChatControl.Chat_id, User_id);
                if (Per.CanPinMessages)
                {
                    Rep_Groups.DeletePinMessage(ChatControl.Chat_id);
                    ChatControl.Height += PinPanel.Height;
                    ChatControl.Top = PinPanel.Top;
                    PinPanel.Visible = false;
                }
            }
        }

        private void lbl_PinMessageText_Click(object sender, EventArgs e)
        {
            ChatControl.AutoScrollPosition = MessagesLocation.ToArray()[PinMessageLocationIndex];
        }

        private void ChatControl_ControlAdded(object sender, ControlEventArgs e)
        {
            MessagesLocation.Add(e.Control.Location);
        }
        private int GetControlIndexInChatControl(Control c)
        {
            int i = 0;
            for (; i < this.ChatControl.Controls.Count; i++)
                if (ChatControl.Controls[i].Name == c.Name)
                    break;
            return i;
        }

        private void PanelProfileView_Click(object sender, EventArgs e)
        {
            if (ChatControl.ChatType == ComponentsProperties.ChatType.Channel)
            {
                Profiles.Frm_ChannelInfo.Channel_id = ChatControl.Chat_id;
                new Profiles.Frm_ChannelInfo().ShowDialog(this);
            }
            else if (ChatControl.ChatType == ComponentsProperties.ChatType.Group)
            {
                Profiles.Frm_GroupInfo.Group_id = ChatControl.Chat_id;
                new Profiles.Frm_GroupInfo().ShowDialog(this);
            }
            else
            {
                Profiles.Frm_UserInfo.User_id = Rep_PrivateChat.PrivateChatTarget(ChatControl.Chat_id, User_id).id;
                new Profiles.Frm_UserInfo().ShowDialog(this);
            }
        }
        public void ShowChat(long Chat_id)
        {
            foreach (Control item in ChatList.Controls)
            {
                if (item.Name == "ChatList_PrivateChat_" + Chat_id)
                    ChatListItemsClicked(item, null);
            }
        }
        public void UpdateChatList()
        {
            foreach (var item in ChatLists)
                ChatList.Controls.Remove(item);
            Frm_Chats_Load(null, null);
        }
        public void InsertChatListItem(Components.ComponentsProperties.ChatType ChatType, tbl_PrivateChat PrivateChat)
        {
            var item = new ChatListItems()
            {
                ChatType = ChatType,
                BadgeCount = 0,
                ChatName = Rep_PrivateChat.PrivateChatTarget(PrivateChat.id, User_id).Name + " " + Rep_PrivateChat.PrivateChatTarget(PrivateChat.id, User_id).Lname,
                Chat_id = PrivateChat.id,
                Day = 0,
                Hour = 0,
                IsResive = false,
                LastMessage = Rep_Message.GetMessage(1),
                LastMessageMode = ComponentsProperties.MessageMode.incoming,
                LastMessageSender = Rep_Users.GetUser(User_id),
                ProfilePic = Image.FromFile(Rep_PrivateChat.PrivateChatTarget(PrivateChat.id, User_id).tbl_Pic.Pic_Url),
                LastMessageType = ComponentsProperties.MessageType.PhotoMessage,
                Minuts = 0,
                Month = 0,
                Year = 0
            };
            ChatListItem _chatlist = new ChatListItem();
            _chatlist.Name = "ChatList_" + item.ChatType.ToString() + "_" + item.Chat_id;
            _chatlist.ChatName = item.ChatName;
            if (item.ChatType == ComponentsProperties.ChatType.PrivateChat)
                if (Rep_Users.IsContact(User_id, Rep_PrivateChat.PrivateChatTarget(item.Chat_id, User_id).id))
                {
                    long TargetUser_id = Rep_PrivateChat.PrivateChatTarget(item.Chat_id, User_id).id;
                    _chatlist.ChatName = Rep_Users.GetContactName(User_id, TargetUser_id);
                }
            _chatlist.ChatType = item.ChatType;
            _chatlist.MessageType = item.LastMessageType;
            _chatlist.LastMessage = item.LastMessage.Text;
            _chatlist.LastMessageDate = item.Day + "" + AdvanceMethod.GetMonthString(item.Month);
            if (item.LastMessageMode == ComponentsProperties.MessageMode.incoming && item.ChatType == ComponentsProperties.ChatType.Group)
                _chatlist.LastMessageSender = item.LastMessageSender.Name;
            else
                _chatlist.LastMessageSender = "You";
            _chatlist.Isseen = item.IsResive;
            _chatlist.Profile_Pic = item.ProfilePic;
            _chatlist.Chat_id = item.Chat_id;
            _chatlist.Click += ChatListItemsClicked;
            _chatlist.BadgeCount = item.BadgeCount;
            _chatlist.Top = ChatListTop;
            ChatList.Controls.Add(_chatlist);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Profiles.Frm_UserInfo.User_id = 4;
            new Profiles.Frm_UserInfo().ShowDialog(this);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new Frm_AddGroupName().ShowDialog(this);
            UpdateChatList();
        }

        private void btn_NotChannelAdminAction_Click(object sender, EventArgs e)
        {
            if (btn_NotChannelAdminAction.Text == "UNBLOCK")
            {
                Rep_Users.UnblockUser(Rep_PrivateChat.PrivateChatTarget(ChatControl.Chat_id, User_id).id);
                PanelNotChannelAdmin.Visible = false;
            }
            else if (btn_NotChannelAdminAction.Text == "Leave")
            {
                Rep_Channels.DeleteChannelMember(ChatControl.Chat_id, User_id);
                UpdateChatList();
                PanelUnderChatList.Visible = true;
            }
        }

        private void ChatControl_PhotoBubbleClicked(object sender, EventArgs e)
        {
            Pics.Frm_ShowChatPics.ChatType = ChatControl.ChatType;
            Pics.Frm_ShowChatPics.Chat_id = ChatControl.Chat_id;
            Pics.Frm_ShowChatPics.Pic_Url = ChatControl.PhotoBubblePicUrl;
            new Pics.Frm_ShowChatPics().ShowDialog(this);
        }

        private void ChatList_ControlAdded(object sender, ControlEventArgs e)
        {
            ChatLists.Add((Components.ChatListItem)e.Control);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Setting.Frm_IDFinder().ShowDialog(this);
        }

        private void NotificationTimer_Tick(object sender, EventArgs e)
        {
            if (ShowDesktopNotification)
            {
                var NotificationList = Rep_Chats.Notifications();
                if (NotificationList.Count > 0)
                {
                    int NotificationCount = int.Parse(Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "NotificationCount", 3).ToString());
                    string Position = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "NotificationPosition", "BottomRight").ToString();
                    if (Position == "TopLeft")
                    {
                        int NotifiTop = 0;
                        foreach (var item in NotificationList)
                        {
                            if (GetShowNotification().Length >= NotificationCount)
                                GetShowNotification()[0].Close();
                            ShowNotification(item, NotifiTop, 0);
                            NotifiTop += new Setting.Frm_Notification().Height + 5;
                        }
                    }
                    else if (Position == "TopRight")
                    {
                        int NotifiTop = 0;
                        foreach (var item in NotificationList)
                        {
                            if (GetShowNotification().Length >= NotificationCount)
                                GetShowNotification()[0].Close();
                            ShowNotification(item, NotifiTop, Screen.PrimaryScreen.Bounds.Width - new Setting.Frm_Notification().Width);
                            NotifiTop += new Setting.Frm_Notification().Height + 5;
                        }
                    }
                    else if (Position == "BottomLeft")
                    {
                        int NotifiTop = Screen.PrimaryScreen.WorkingArea.Height - 63;
                        foreach (var item in NotificationList)
                        {
                            if (GetShowNotification().Length >= NotificationCount)
                                GetShowNotification()[0].Close();
                            ShowNotification(item, NotifiTop, 0);
                            NotifiTop -= (new Setting.Frm_Notification().Height + 5);
                        }
                    }
                    else if (Position == "BottomRight")
                    {
                        int NotifiTop = Screen.PrimaryScreen.WorkingArea.Height - 63;
                        foreach (var item in NotificationList)
                        {
                            if (GetShowNotification().Length >= NotificationCount)
                                GetShowNotification()[0].Close();
                            ShowNotification(item, NotifiTop, Screen.PrimaryScreen.Bounds.Width - new Setting.Frm_Notification().Width);
                            NotifiTop -= (new Setting.Frm_Notification().Height + 5);
                        }
                    }
                }
            }
        }
        private Setting.Frm_Notification[] GetShowNotification()
        {
            List<Setting.Frm_Notification> Frm = new List<Setting.Frm_Notification>();
            foreach (var item in this.OwnedForms)
                if (item.GetType().Name == "Frm_Notification")
                    Frm.Add((Setting.Frm_Notification)item);
            return Frm.ToArray();
        }
        private void ShowNotification(Models.Repository.NotificationResult _Result, int NotifiTop, int NotifiLeft)
        {
            Setting.Frm_Notification Notifi = new Setting.Frm_Notification();
            string _Message = "";
            if ((Components.ComponentsProperties.MessageType)_Result.Message.Type == ComponentsProperties.MessageType.PhotoMessage)
                _Message = "PhotoMessage ";
            _Message += _Result.Message.Text;
            Notifi.Message = _Message;
            if (_Result.ChatType == ComponentsProperties.ChatType.Channel)
                Notifi.ChatName = _Result.tbl_Channel.Name;
            else if (_Result.ChatType == ComponentsProperties.ChatType.Group)
                Notifi.ChatName = _Result.tbl_Group.Name;
            else if (_Result.ChatType == ComponentsProperties.ChatType.PrivateChat)
                Notifi.ChatName = Rep_PrivateChat.PrivateChatTarget(_Result.tbl_PrivateChat.id, Frm_Chats.User_id).Name + " " + Rep_PrivateChat.PrivateChatTarget(_Result.tbl_PrivateChat.id, Frm_Chats.User_id).Lname;
            Notifi.Top = NotifiTop;
            Notifi.Left = NotifiLeft;
            Notifi.Show(this);
        }

        private void panel10_MouseEnter(object sender, EventArgs e)
        {
            Panel P = (Panel)sender;
            P.BackColor = Color.FromArgb(241, 241, 241);
        }

        private void panel10_MouseLeave(object sender, EventArgs e)
        {
            Panel P = (Panel)sender;
            P.BackColor = Color.White;
        }

        private void panel10_MouseDown(object sender, MouseEventArgs e)
        {
            Panel P = (Panel)sender;
            P.BackColor = Color.FromArgb(205, 205, 205);
        }

        private void panel10_MouseUp(object sender, MouseEventArgs e)
        {
            Panel P = (Panel)sender;
            P.BackColor = Color.FromArgb(241, 241, 241);
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            Panel P = (Panel)((Control)sender).Parent;
            P.BackColor = Color.FromArgb(205, 205, 205);
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            Panel P = (Panel)((Control)sender).Parent;
            P.BackColor = Color.FromArgb(241, 241, 241);
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            Panel P = (Panel)((Control)sender).Parent;
            P.BackColor = Color.FromArgb(241, 241, 241);
        }

        private void btn_Menu_Click(object sender, EventArgs e)
        {
            bunifuTransition1.Show(PanelMenu);
            semiTransparentPanel1.Visible = true;
        }
        private void semiTransparentPanel1_Click(object sender, EventArgs e)
        {
            semiTransparentPanel1.Visible = false;
            bunifuTransition1.Hide(PanelMenu);
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            new Channels.Frm_AddChannelName().ShowDialog(this);
            UpdateChatList();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new Frm_AddGroupName().ShowDialog(this);
            UpdateChatList();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            new Frm_ContactList().ShowDialog(this);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new Setting.Frm_IDFinder().ShowDialog(this);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            new Frm_Setting().ShowDialog(this);
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            PanelEmoji.BringToFront();
            PanelEmoji.Visible = true;
        }

        private void PanelEmoji_MouseLeave(object sender, EventArgs e)
        {
            PanelEmoji.Visible = false;
        }

        private void txtSendText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete || e.KeyData == Keys.Back)
                txtSendText.Tag = txtSendText.Tag.ToString().Remove(txtSendText.Tag.ToString().Length - 1, 1);
            else
                if (txtSendText.Tag != null)
                txtSendText.Tag = txtSendText.Tag.ToString() + (char)(e.KeyValue);
            else
                txtSendText.Tag = (char)(e.KeyValue);
        }
        private string GetEmojiRtfCode(string Rtf)
        {
            foreach (var item in Rep_Chats.GetEmojiList())
            {
                Rtf = Rtf.Replace("#" + item.id + "#", item.RTF);
            }
            return Rtf;
        }

        private void enableNotificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Q = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "DesktopNotification", false);
            if (Q.ToString() == "True")
            {
                Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "DesktopNotification", false);
                enableNotificationToolStripMenuItem.Text = "Enable Notification";
            }
            else
            {
                Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "DesktopNotification", true);
                enableNotificationToolStripMenuItem.Text = "Disable Notification";
            }
        }

        private void quitTelegramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openTelegramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void Frm_Chats_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            var Q = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "Showtryicon", false);
            if (Q != null)
                if (Q.ToString() == "true")
                    this.Hide();
                else
                    e.Cancel = false;
            else
                e.Cancel = false;
        }
    }
}
