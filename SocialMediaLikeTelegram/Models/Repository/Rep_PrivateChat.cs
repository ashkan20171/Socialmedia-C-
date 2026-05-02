using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaLikeTelegram.Models.Repository
{
    class Rep_PrivateChat
    {
        private static SocialMediaDBEntities db = new SocialMediaDBEntities();
        public static tbl_Message LastMessage(long PrivateChat_id)
        {
            return (from a in db.tbl_PrivateChatMessage where a.PrivateChat_id_FK == PrivateChat_id orderby a.id descending select a.tbl_Message).FirstOrDefault();
        }
        public static Components.ComponentsProperties.MessageMode GetLastMessageMode(long PrivateChat_id, long User_id)
        {
            var LastMessage = (from a in db.tbl_PrivateChatMessage where a.PrivateChat_id_FK == PrivateChat_id orderby a.id descending select a).FirstOrDefault();
            if (LastMessage == null)
                return Components.ComponentsProperties.MessageMode.incoming;
            else if (LastMessage.Sender_id_FK == User_id)
                return Components.ComponentsProperties.MessageMode.outing;
            else
                return Components.ComponentsProperties.MessageMode.incoming;
        }
        public static List<tbl_PrivateChat> UserPrivateChatList(long User_id)
        {
            return (from a in db.tbl_PrivateChat where a.User_1_id_FK == User_id || a.User_2_id_FK == User_id select a).ToList();
        }
        public static tbl_Users PrivateChatTarget(long PrivateChat_id, long User_id)
        {
            var PrivateChat = (from a in db.tbl_PrivateChat where a.User_1_id_FK == User_id || a.User_2_id_FK == User_id select a).FirstOrDefault();
            if (PrivateChat != null)
                if (PrivateChat.User_1_id_FK == User_id)
                    return PrivateChat.tbl_Users1;
                else
                    return PrivateChat.tbl_Users;
            else
                return Rep_Users.GetUser(User_id);
        }
        public static bool IsResiveLastMessage(long PrivateChat_id)
        {
            var Q = (from a in db.tbl_PrivateChatMessage where a.PrivateChat_id_FK == PrivateChat_id orderby a.id descending select a).FirstOrDefault();
            if (Q != null)
                return Q.IsRecive.Value;
            else
                return false;
        }
        public static int BadgeCount(long PrivateChat_id, long User_id)
        {
            return (from a in db.tbl_PrivateChatMessage where a.PrivateChat_id_FK == PrivateChat_id && a.IsRecive == false && a.Sender_id_FK != User_id select a).Count();
        }
        public static List<tbl_PrivateChatMessage> PrivateChatMessages(long PrivateChat)
        {
            db = new SocialMediaDBEntities();
            return (from a in db.tbl_PrivateChatMessage where a.PrivateChat_id_FK == PrivateChat orderby a.Message_id_FK select a).ToList();
        }
        public static bool IsSendigMessage(long User_id, long PrivateChatMessage_id)
        {
            var Q = (from a in db.tbl_PrivateChatMessage where a.id == PrivateChatMessage_id select a).FirstOrDefault();
            if (Q == null)
                return false;
            else if (Q.Sender_id_FK == User_id)
                return true;
            else
                return false;
        }
        public static void SeenPrivateChatPost(long PrivateChat_id, long User_id)
        {
            var Q = (from a in db.tbl_PrivateChatMessage where a.PrivateChat_id_FK == PrivateChat_id && a.IsRecive == false && a.Sender_id_FK != User_id select a).ToList();
            foreach (var item in Q)
            {
                item.IsRecive = true;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public static Image GetProfilePic(long PrivateChat_id, long User_id)
        {
            return (Image.FromFile(PrivateChatTarget(PrivateChat_id, User_id).tbl_Pic.Pic_Url));
        }
        public static string GetPrivateChatName(long PrivateChat_id, long User_id)
        {
            return PrivateChatTarget(PrivateChat_id, User_id).Name + " " + PrivateChatTarget(PrivateChat_id, User_id).Lname;
        }
        public static bool IsContact(long User_id, long Contact_id)
        {
            return Convert.ToBoolean((from a in db.tbl_Contact where a.Contact_id_FK == Contact_id && a.User_id_FK == User_id select a).Count());
        }
        public static string UserLastSeen(long User_id)
        {
            var User = (from a in db.tbl_Users where a.id == User_id select a).FirstOrDefault();
            Components.ComponentsProperties.LastSeenPrivacy _lastSeenPrivacy = ((Components.ComponentsProperties.LastSeenPrivacy)(User.LastSeenPrivacy));
            DateTime LastSeenDate = DateTime.Parse(User.LastSeenDate + " " + User.LastSeenTime);
            TimeSpan LastSeenTimeSpan = DateTime.Now - LastSeenDate;
            if (_lastSeenPrivacy == Components.ComponentsProperties.LastSeenPrivacy.Nobody)
                return "Last Seen recently";
            else if (_lastSeenPrivacy == Components.ComponentsProperties.LastSeenPrivacy.MyContact && !IsContact(User.id, User_id))
                return "Last Seen recently";
            else
            {
                if (LastSeenTimeSpan.TotalDays < 7)
                    return LastSeenOther(LastSeenTimeSpan);
                else
                {
                    if (LastSeenTimeSpan.TotalDays > 7 && LastSeenTimeSpan.TotalDays < 30)
                        return "Last Seen within a week";
                    else if (LastSeenTimeSpan.TotalDays > 30)
                        return "Last Seen within a month";
                    else
                        return "Last Seen withi a year";
                }
            }
        }
        private static string LastSeenOther(TimeSpan T)
        {
            if ((int)T.TotalDays > 0)
                return "Last Seen " + ((int)T.TotalDays).ToString() + "day ago";
            else if ((int)T.TotalHours > 0)
                return "Last Seen " + ((int)T.TotalHours).ToString() + "hour ago";
            else if ((int)T.Minutes > 0)
                return "Last Seen " + ((int)T.TotalMinutes).ToString() + "minuts age";
            else
                return "Last Seen recently";
        }
        public static tbl_PrivateChatMessage InsertPrivateChatMessage(long Message_id, long PrivateChat_id, long Sender_id)
        {
            tbl_PrivateChatMessage tbl = new tbl_PrivateChatMessage()
            {
                Message_id_FK = Message_id,
                Sender_id_FK = Sender_id,
                PrivateChat_id_FK = PrivateChat_id,
                IsRecive = false
            };
            db.tbl_PrivateChatMessage.Add(tbl);
            db.SaveChanges();
            return (from a in db.tbl_PrivateChatMessage orderby a.id descending select a).FirstOrDefault();
        }
        public static bool DeletePrivateChatMessage(long Chat_id, long Message_id, long Sender_id)
        {
            try
            {
                var Q = (from a in db.tbl_PrivateChatMessage where a.Message_id_FK == Message_id && a.PrivateChat_id_FK == Chat_id && a.Sender_id_FK == Sender_id select a).FirstOrDefault();
                db.tbl_PrivateChatMessage.Remove(Q);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static tbl_PrivateChat GetPrivateChatByUsers(long User_1_id, long User_2_id)
        {
            var Q1 = (from a in db.tbl_PrivateChat where a.User_1_id_FK == User_1_id && a.User_2_id_FK == User_2_id select a).FirstOrDefault();
            var Q2 = (from a in db.tbl_PrivateChat where a.User_1_id_FK == User_2_id && a.User_2_id_FK == User_1_id select a).FirstOrDefault();
            if (Q1 == null && Q2 == null)
                return null;
            else if (Q1 == null && Q2 != null)
                return Q2;
            else
                return Q1;
        }
        public static tbl_PrivateChat InsertPrivateChat(long User_1_id, long User_2_id)
        {
            try
            {
                tbl_PrivateChat tbl = new tbl_PrivateChat()
                {
                    User_1_id_FK = User_1_id,
                    User_2_id_FK = User_2_id,
                    Date = AdvanceMethod.Date,
                    Time = AdvanceMethod.Time
                };
                db.tbl_PrivateChat.Add(tbl);
                db.SaveChanges();
                return (from a in db.tbl_PrivateChat orderby a.id descending select a).FirstOrDefault();
            }
            catch { return null; }
        }
        public static tbl_PrivateChatMessage GetPrivateChatMessage(long PrivateChat_id)
        {
            var Q = (from a in db.tbl_PrivateChatMessage orderby a.id descending select a).FirstOrDefault();
            if (Q != null)
                return Q;
            else
                return new tbl_PrivateChatMessage();
        }
    }
}
