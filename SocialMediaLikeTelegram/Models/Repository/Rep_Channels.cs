using Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaLikeTelegram.Models.Repository
{
    class Rep_Channels
    {
        private static SocialMediaDBEntities db = new SocialMediaDBEntities();
        public static tbl_Message LastMessage(long Channel_id)
        {
            var Q = (from a in db.tbl_ChannelMessages where a.Channel_id_FK == Channel_id orderby a.id descending select a.tbl_Message).FirstOrDefault();
            if (Q != null)
                return Q;
            else
                return (from a in db.tbl_Message where a.id == 1 select a).FirstOrDefault();
        }
        public static List<tbl_Channels> GetUserChannels(long User_id)
        {
            return (from a in db.tbl_ChannelMembers where a.User_id_FK == User_id select a.tbl_Channels).ToList();
        }
        public static int BadgeCount(long Channel_id, long User_id)
        {
            var Messages = (from a in db.tbl_ChannelMessages where a.Channel_id_FK == Channel_id select a).ToArray();
            int Badge = 0;
            for (int i = Messages.Length - 1; i >= 0; i--)
            {
                if (!IsSeenPost(User_id, Messages[i].Message_id_FK.Value) && Messages[i].Sender_id_FK != User_id)
                    Badge++;
            }
            return Badge;
        }
        public static bool IsSeenPost(long User_id, long Message_id)
        {
            return Convert.ToBoolean((from a in db.tbl_Seen where a.Message_id_FK == Message_id && a.User_id_FK == User_id select a).Count());
        }
        public static List<tbl_ChannelMessages> GetChannelMessageList(long Channel_id)
        {
            db = new SocialMediaDBEntities();
            return (from a in db.tbl_ChannelMessages where a.Channel_id_FK == Channel_id orderby a.Message_id_FK select a).ToList();
        }
        public static string GetChannelName(long Channel_id)
        {
            return (from a in db.tbl_Channels where a.id == Channel_id select a).FirstOrDefault().Name;
        }
        public static int ChannelPostsSeenCount(long Message_id)
        {
            return (from a in db.tbl_Seen where a.Message_id_FK == Message_id select a).Count();
        }
        public static void SeenChannelPosts(long Channel_id, long User_id)
        {
            var Messages = (from a in db.tbl_ChannelMessages where a.Channel_id_FK == Channel_id select a).ToArray();
            List<tbl_Message> MessageList = new List<tbl_Message>();
            for (int i = Messages.Length - 1; i >= 0; i--)
                if (!IsSeenPost(User_id, Messages[i].Message_id_FK.Value) && Messages[i].Sender_id_FK != User_id)
                    MessageList.Add(Messages[i].tbl_Message);
            List<tbl_Seen> SeenList = new List<tbl_Seen>();
            foreach (var item in MessageList)
                SeenList.Add(new tbl_Seen
                {
                    Message_id_FK = item.id,
                    User_id_FK = User_id
                });
            db.tbl_Seen.AddRange(SeenList);
            db.SaveChanges();
        }
        public static int GetChannelMemberCount(long Channel_id)
        {
            return (from a in db.tbl_ChannelMembers where a.Channel_id_FK == Channel_id select a).Count();
        }
        public static Image GetChannelProfilePic(long Channel_id)
        {
            return Image.FromFile((from a in db.tbl_Channels where a.id == Channel_id select a).FirstOrDefault().tbl_Pic.Pic_Url);
        }
        public static long InsertChannelPost(long Message_id, long Channel_id, long Sender_id)
        {
            tbl_ChannelMessages tbl = new tbl_ChannelMessages()
            {
                Message_id_FK = Message_id,
                Sender_id_FK = Sender_id,
                Channel_id_FK = Channel_id
            };
            db.tbl_ChannelMessages.Add(tbl);
            db.SaveChanges();
            return (from a in db.tbl_ChannelMessages orderby a.id descending select a).FirstOrDefault().id;
        }
        public static bool IsChannelAdmin(long User_id, long Channel_id)
        {
            return Convert.ToBoolean((from a in db.tbl_CahnnelAdmins where a.Channel_id_FK == Channel_id && a.User_id_FK == User_id select a).Count());
        }
        public static bool IsChannelMember(long Channel_id, long User_id)
        {
            return Convert.ToBoolean((from a in db.tbl_ChannelMembers where a.Channel_id_FK == Channel_id && a.User_id_FK == User_id select a).Count());
        }
        public static void JoinChannel(long Channel_id, long User_id)
        {
            tbl_ChannelMembers tbl = new tbl_ChannelMembers()
            {
                User_id_FK = User_id,
                Channel_id_FK = Channel_id,
                Time = DateTime.Now.ToShortTimeString(),
                Date = DateTime.Now.ToShortDateString()
            };
            db.tbl_ChannelMembers.Add(tbl);
            db.SaveChanges();
        }
        public static void LeaveChannel(long Channel_id, long User_id)
        {
            var Q = (from a in db.tbl_ChannelMembers where a.Channel_id_FK == Channel_id && a.User_id_FK == User_id select a).FirstOrDefault();
            db.tbl_ChannelMembers.Remove(Q);
            db.SaveChanges();
        }
        public static bool DeleteChannelMessage(long Chat_id, long Message_id)
        {
            try
            {
                var Q = (from a in db.tbl_ChannelMessages where a.Message_id_FK == Message_id && a.Channel_id_FK == Chat_id select a).FirstOrDefault();
                db.tbl_ChannelMessages.Remove(Q);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static AdminPermisions GetChannelAdminPermisions(long Channel_id, long User_id)
        {
            try
            {
                var Q = (from a in db.tbl_CahnnelAdmins where a.Channel_id_FK == Channel_id && a.User_id_FK == User_id select a).FirstOrDefault();
                if (Q == null)
                    return new AdminPermisions()
                    {
                        CanDeleteMessages = false,
                        CanEditMessages = false,
                        CanPinMessages = false
                    };
                else
                    return new AdminPermisions()
                    {
                        CanDeleteMessages = Q.CanDelete.Value,
                        CanEditMessages = Q.CanEdit.Value,
                        CanPinMessages = Q.CanPin.Value
                    };
            }
            catch
            {
                return new AdminPermisions()
                {
                    CanDeleteMessages = false,
                    CanEditMessages = false,
                    CanPinMessages = false
                };
            }
        }
        public static tbl_Message GetChannelPinMessage(long Channel_id)
        {
            var Q = (from a in db.tbl_Channels where a.id == Channel_id select a).FirstOrDefault().tbl_Message;
            if (Q != null)
                return Q;
            else
                return new tbl_Message();
        }
        public static bool PinMessage(long Message_id, long Channel_id)
        {
            try
            {
                var Q = (from a in db.tbl_Channels where a.id == Channel_id select a).FirstOrDefault();
                Q.PinMessage_id = Message_id;
                db.Entry(Q).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public static bool DeletePinMessage(long Channel_id)
        {
            try
            {
                var Q = (from a in db.tbl_Channels where a.id == Channel_id select a).FirstOrDefault();
                Q.PinMessage_id = null;
                db.Entry(Q).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public static tbl_Channels GetChannelInfo(long Channel_id)
        {
            return (from a in db.tbl_Channels where a.id == Channel_id select a).FirstOrDefault();
        }
        public static List<tbl_CahnnelAdmins> GetChannelAdminList(long Channel_id)
        {
            return (from a in db.tbl_CahnnelAdmins where a.Channel_id_FK == Channel_id select a).ToList();
        }
        public static string GetAdminPrometor(long Channel_id, long User_id)
        {
            var Q = (from a in db.tbl_Channels where a.id == Channel_id select a).FirstOrDefault();
            if (Q.Creator_id_FK == User_id)
                return "Creator";
            else
                return "Prometod By " + Rep_Users.GetUser(Q.Creator_id_FK.Value).Name + " " + Rep_Users.GetUser(Q.Creator_id_FK.Value).Lname;
        }
        public static bool RemoveChannelAdmin(long AdminChannel_id)
        {
            try
            {
                var Q = (from a in db.tbl_CahnnelAdmins where a.id == AdminChannel_id select a).FirstOrDefault();
                db.tbl_CahnnelAdmins.Remove(Q);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public static bool RemoveChannelAdmin(long Channel_id, long User_id)
        {
            try
            {
                var Q = (from a in db.tbl_CahnnelAdmins where a.Channel_id_FK == Channel_id && a.User_id_FK == User_id select a).FirstOrDefault();
                db.tbl_CahnnelAdmins.Remove(Q);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public static tbl_CahnnelAdmins GetChannelAdmin(long ChannelAdmin_id)
        {
            return (from a in db.tbl_CahnnelAdmins where a.id == ChannelAdmin_id select a).FirstOrDefault();
        }
        public static bool EditChannelAdminPermition(long ChannelAdmin_id, bool IsEdit, bool IsDelete, bool IsPin)
        {
            try
            {
                var Q = (from a in db.tbl_CahnnelAdmins where a.id == ChannelAdmin_id select a).FirstOrDefault();
                Q.CanDelete = IsDelete;
                Q.CanEdit = IsEdit;
                Q.CanPin = IsPin;
                db.Entry(Q).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public static List<tbl_Users> GetChannelMember(long Channel_id)
        {
            return (from a in db.tbl_ChannelMembers where a.Channel_id_FK == Channel_id select a.tbl_Users).ToList();
        }
        public static bool DeleteChannelMember(long Channel_id, long User_id)
        {
            try
            {
                var Q = (from a in db.tbl_ChannelMembers where a.Channel_id_FK == Channel_id && a.User_id_FK == User_id select a).FirstOrDefault();
                db.tbl_ChannelMembers.Remove(Q);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public static bool AddChannelAdmin(long User_id, long Channel_id)
        {
            try
            {
                tbl_CahnnelAdmins tbl = new tbl_CahnnelAdmins()
                {
                    CanDelete = true,
                    CanEdit = true,
                    CanPin = true,
                    Channel_id_FK = Channel_id,
                    User_id_FK = User_id
                };
                db.tbl_CahnnelAdmins.Add(tbl);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public static bool AddChannelMember(long User_id, long Channel_id)
        {
            try
            {
                tbl_ChannelMembers tbl = new tbl_ChannelMembers()
                {
                    Channel_id_FK = Channel_id,
                    Date = AdvanceMethod.Date,
                    Time = AdvanceMethod.Time,
                    User_id_FK = User_id
                };
                db.tbl_ChannelMembers.Add(tbl);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public static List<tbl_Users> AddMemberChannelList(long Channel_id, long User_id)
        {
            var Q1 = (from a in db.tbl_Contact where a.User_id_FK == User_id select a.tbl_Users1).ToList();
            var Q2 = (from a in db.tbl_ChannelMembers where a.Channel_id_FK == Channel_id select a.tbl_Users).ToList();
            foreach (var item in Q2)
                Q1.Remove(item);
            return Q1;
        }
        public static long GetLastChannelID()
        {
            return (from a in db.tbl_Channels orderby a.id descending select a).FirstOrDefault().id;
        }
        public static bool DeleteChannel(long Channel_id)
        {
            try
            {
                var Q = (from a in db.tbl_Channels where a.id == Channel_id select a).FirstOrDefault();
                db.tbl_Channels.Remove(Q);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
