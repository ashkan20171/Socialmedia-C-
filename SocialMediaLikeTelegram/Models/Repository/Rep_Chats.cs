using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaLikeTelegram.Models.Repository
{
    class Rep_Chats
    {
        private static SocialMediaDBEntities db = new SocialMediaDBEntities();
        public static List<ChatListItems> GetChatLists(long User_id)
        {
            List<ChatListItems> ChatListItems = new List<ChatListItems>();
            foreach (var item in Rep_Channels.GetUserChannels(User_id))
            {
                DateTime SendDate = DateTime.Now;
                if (Rep_Channels.LastMessage(item.id) != null)
                    SendDate = DateTime.Parse(Rep_Channels.LastMessage(item.id).Date + " " + Rep_Channels.LastMessage(item.id).Time);
                Repository.ChatListItems _chatlistitem = new ChatListItems();
                _chatlistitem.ChatType = Components.ComponentsProperties.ChatType.Channel;
                _chatlistitem.LastMessageMode = Components.ComponentsProperties.MessageMode.incoming;
                _chatlistitem.ChatName = item.Name;
                _chatlistitem.Chat_id = item.id;
                _chatlistitem.LastMessage = Rep_Channels.LastMessage(item.id);
                if (Rep_Channels.LastMessage(item.id) != null)
                    _chatlistitem.LastMessageType = (Components.ComponentsProperties.MessageType)(Rep_Channels.LastMessage(item.id).Type);
                else
                    _chatlistitem.LastMessageType = Components.ComponentsProperties.MessageType.NoMessage;
                _chatlistitem.Year = SendDate.Year;
                _chatlistitem.Month = SendDate.Month;
                _chatlistitem.Day = SendDate.Day;
                _chatlistitem.Hour = SendDate.Hour;
                _chatlistitem.Minuts = SendDate.Minute;
                _chatlistitem.LastMessageSender = (from a in db.tbl_Users where a.id == User_id select a).FirstOrDefault();
                string Path = @"F:\C# Project\SocialMediaLikeTelegram\SocialMediaLikeTelegram\bin\Debug\fake.png";
                if (item.tbl_Pic != null)
                    Path = item.tbl_Pic.Pic_Url;
                _chatlistitem.ProfilePic = Image.FromFile(Path);
                _chatlistitem.BadgeCount = Rep_Channels.BadgeCount(item.id, User_id);
                ChatListItems.Add(_chatlistitem);
            }
            foreach (var item in Rep_Groups.UserGroupsList(User_id))
            {
                DateTime SendDate = DateTime.Parse(Rep_Groups.LastMessage(item.id).Date + " " + Rep_Groups.LastMessage(item.id).Time);
                Repository.ChatListItems _chatlistitem = new Repository.ChatListItems();
                _chatlistitem.ChatType = Components.ComponentsProperties.ChatType.Group;
                _chatlistitem.LastMessageMode = Rep_Groups.GetLastMessageMode(item.id, User_id);
                _chatlistitem.ChatName = item.Name;
                _chatlistitem.Chat_id = item.id;
                _chatlistitem.LastMessage = Rep_Groups.LastMessage(item.id);
                _chatlistitem.LastMessageType = (Components.ComponentsProperties.MessageType)(Rep_Groups.LastMessage(item.id).Type);
                _chatlistitem.Year = SendDate.Year;
                _chatlistitem.Month = SendDate.Month;
                _chatlistitem.Day = SendDate.Day;
                _chatlistitem.Hour = SendDate.Hour;
                _chatlistitem.Minuts = SendDate.Minute;
                _chatlistitem.LastMessageSender = Rep_Groups.LastMessageSender(item.id);
                _chatlistitem.IsResive = Rep_Groups.IsResiveLastMessage(item.id);
                string Path = @"G:\C# Project\SocialMediaLikeTelegram\SocialMediaLikeTelegram\bin\Debug\fake.png";
                if (item.tbl_Pic != null)
                    Path = item.tbl_Pic.Pic_Url;
                _chatlistitem.ProfilePic = Image.FromFile(Path);
                _chatlistitem.BadgeCount = Rep_Groups.BadgeCount(item.id, User_id);
                ChatListItems.Add(_chatlistitem);
            }
            foreach (var item in Rep_PrivateChat.UserPrivateChatList(User_id))
            {
                var LastMessage = Rep_PrivateChat.LastMessage(item.id);
                if (LastMessage == null)
                    LastMessage = Rep_Message.GetMessage(1);
                DateTime SendDate = DateTime.Parse(LastMessage.Date + " " + LastMessage.Time);
                ChatListItems.Add(new ChatListItems
                {
                    ChatType = Components.ComponentsProperties.ChatType.PrivateChat,
                    LastMessageMode = Rep_PrivateChat.GetLastMessageMode(item.id, User_id),
                    ChatName = Rep_PrivateChat.PrivateChatTarget(item.id, User_id).Name + " " + Rep_PrivateChat.PrivateChatTarget(item.id, User_id).Lname,
                    Chat_id = item.id,
                    LastMessage = LastMessage,
                    LastMessageType = (Components.ComponentsProperties.MessageType)(LastMessage.Type),
                    Year = SendDate.Year,
                    Month = SendDate.Month,
                    Day = SendDate.Day,
                    Hour = SendDate.Hour,
                    Minuts = SendDate.Minute,
                    IsResive = Rep_PrivateChat.IsResiveLastMessage(item.id),
                    ProfilePic = Image.FromFile(Rep_PrivateChat.PrivateChatTarget(item.id, User_id).tbl_Pic.Pic_Url),
                    BadgeCount = Rep_PrivateChat.BadgeCount(item.id, User_id)
                });
            }
            ChatListItems.Reverse();
            return ChatListItems;
        }
        public static IdFinderResult FindId(string Id)
        {
            var Channel_id = (from a in db.tbl_Channels where a.Username == Id select a);
            var User_id = (from a in db.tbl_Users where a.Username == Id select a);
            var Channel_Invitelink = (from a in db.tbl_Channels where a.InviteLink == Id select a);
            var Group_Invitelink = (from a in db.tbl_Groups where a.InviteLink == Id select a);
            if (Channel_id.Count() == 1)
                return new IdFinderResult() { ChatType = Components.ComponentsProperties.ChatType.Channel, Chat_id = Channel_id.FirstOrDefault().id };
            else if (User_id.Count() == 1)
                return new IdFinderResult() { ChatType = Components.ComponentsProperties.ChatType.PrivateChat, Chat_id = User_id.FirstOrDefault().id };
            else if (Channel_Invitelink.Count() == 1)
                return new IdFinderResult() { ChatType = Components.ComponentsProperties.ChatType.Channel, Chat_id = Channel_Invitelink.FirstOrDefault().id };
            else if (Group_Invitelink.Count() == 1)
                return new IdFinderResult() { ChatType = Components.ComponentsProperties.ChatType.Group, Chat_id = Group_Invitelink.FirstOrDefault().id };
            else
                return new IdFinderResult();
        }
        public static List<NotificationResult> Notifications()
        {
            List<NotificationResult> NotificationList = new List<NotificationResult>();
            var Channels = (from a in db.tbl_ChannelMembers where a.User_id_FK == Frm_Chats.User_id select a.tbl_Channels).ToList();
            var Group = (from a in db.tbl_GroupMembers where a.User_id_FK == Frm_Chats.User_id select a.tbl_Groups).ToList();
            var PrivateChat = Rep_PrivateChat.UserPrivateChatList(Frm_Chats.User_id);
            //////////////// Chaneel Notification
            foreach (var item in Channels)
            {
                var Message = (from a in db.tbl_ChannelMessages where a.Channel_id_FK == item.id select a).ToList();
                foreach (var item1 in Message)
                    if (!Rep_Channels.IsSeenPost(Frm_Chats.User_id, item1.Message_id_FK.Value) && item1.Sender_id_FK != Frm_Chats.User_id)
                        if ((DateTime.Now - DateTime.Parse(item1.tbl_Message.Date + " " + item1.tbl_Message.Time)).TotalSeconds <= 60)
                            if (Frm_Chats.NotificationMessages.IndexOf(item1.Message_id_FK.Value) == -1)
                            {
                                NotificationList.Add(new NotificationResult()
                                {
                                    ChatType = Components.ComponentsProperties.ChatType.Channel,
                                    Message = item1.tbl_Message,
                                    tbl_Channel = item
                                });
                                Frm_Chats.NotificationMessages.Add(item1.Message_id_FK.Value);
                            }
            }
            ////////////// Group Notification
            foreach (var item in Group)
            {
                var Messages = (from a in db.tbl_GroupMessage where a.Group_id_FK == item.id && a.IsRecive == false && a.Sender_id_FK != Frm_Chats.User_id select a).ToList();
                foreach (var item1 in Messages)
                    if ((DateTime.Now - DateTime.Parse(item1.tbl_Message.Date + " " + item1.tbl_Message.Time)).TotalSeconds <= 60)
                        if (Frm_Chats.NotificationMessages.IndexOf(item1.Message_id_FK.Value) == -1)
                        {
                            NotificationList.Add(new NotificationResult()
                            {
                                ChatType = Components.ComponentsProperties.ChatType.Group,
                                Message = item1.tbl_Message,
                                tbl_Group = item
                            });
                            Frm_Chats.NotificationMessages.Add(item1.Message_id_FK.Value);
                        }
            }
            ///////////// Private Chat Notification
            foreach (var item in PrivateChat)
            {
                var Messages = (from a in db.tbl_PrivateChatMessage where a.PrivateChat_id_FK == item.id && a.IsRecive == false && a.Sender_id_FK != Frm_Chats.User_id select a).ToList();
                foreach (var item1 in Messages)
                    if ((DateTime.Now - DateTime.Parse(item1.tbl_Message.Date + " " + item1.tbl_Message.Time)).TotalSeconds <= 60)
                        if (Frm_Chats.NotificationMessages.IndexOf(item1.Message_id_FK.Value) == -1)
                        {
                            NotificationList.Add(new NotificationResult()
                            {
                                ChatType = Components.ComponentsProperties.ChatType.PrivateChat,
                                Message = item1.tbl_Message,
                                tbl_PrivateChat = item
                            });
                            Frm_Chats.NotificationMessages.Add(item1.Message_id_FK.Value);
                        }
            }
            return NotificationList;
        }
        public static List<tbl_Emoji> GetEmojiList()
        {
            return (from a in db.tbl_Emoji select a).ToList();
        }
        public static tbl_Emoji GetEmoji(int Id)
        {
            return (from a in db.tbl_Emoji where a.id == Id select a).FirstOrDefault();
        }
    }
}
