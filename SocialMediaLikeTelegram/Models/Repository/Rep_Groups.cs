using Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaLikeTelegram.Models.Repository
{
    class Rep_Groups
    {
        private static SocialMediaDBEntities db = new SocialMediaDBEntities();
        public static tbl_Message LastMessage(long Group_id)
        {
            var Q = (from a in db.tbl_GroupMessage where a.Group_id_FK == Group_id orderby a.id descending select a.tbl_Message).FirstOrDefault();
            if (Q != null)
                return Q;
            else
                return (from a in db.tbl_Message where a.id == 1 select a).FirstOrDefault();
        }
        public static tbl_Users LastMessageSender(long Group_id)
        {
            var Q = (from a in db.tbl_GroupMessage where a.Group_id_FK == Group_id orderby a.id descending select a).FirstOrDefault();
            if (Q != null)
                return Q.tbl_Users;
            else
                return Rep_Users.GetUser(Frm_Chats.User_id);
        }
        public static Components.ComponentsProperties.MessageMode GetLastMessageMode(long Group_id, long User_id)
        {
            var LastMessage = (from a in db.tbl_GroupMessage where a.id == Group_id orderby a.id descending select a).FirstOrDefault();
            if (LastMessage != null)
                if (LastMessage.Sender_id_FK == User_id)
                    return Components.ComponentsProperties.MessageMode.outing;
                else
                    return Components.ComponentsProperties.MessageMode.incoming;
            else
                return ComponentsProperties.MessageMode.incoming;
        }
        public static List<tbl_Groups> UserGroupsList(long User_id)
        {
            return (from a in db.tbl_GroupMembers where a.User_id_FK == User_id select a.tbl_Groups).ToList();
        }
        public static bool IsResiveLastMessage(long Group_id)
        {
            var Q = (from a in db.tbl_GroupMessage where a.id == Group_id orderby a.id descending select a).FirstOrDefault();
            if (Q != null)
                return Q.IsRecive.Value;
            else
                return false;
        }
        public static int BadgeCount(long Group_id, long User_id)
        {
            return (from a in db.tbl_GroupMessage where a.Group_id_FK == Group_id && a.IsRecive == false && a.Sender_id_FK != User_id select a).Count();
        }
        public static List<tbl_GroupMessage> GetGroupMessage(long Group_id)
        {
            db = new SocialMediaDBEntities();
            return (from a in db.tbl_GroupMessage where a.Group_id_FK == Group_id orderby a.Message_id_FK select a).ToList();
        }
        public static bool IsSendigMessage(long User_id, long GroupMessage_id)
        {
            var Q = (from a in db.tbl_GroupMessage where a.id == GroupMessage_id select a).FirstOrDefault();
            if (Q.Sender_id_FK == User_id)
                return true;
            else
                return false;
        }
        public static void SeenGroupPosts(long Group_id)
        {
            var Q = (from a in db.tbl_GroupMessage where a.Group_id_FK == Group_id && a.IsRecive == false select a).ToList();
            foreach (var item in Q)
            {
                item.IsRecive = true;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified; ;
                db.SaveChanges();
            }
        }
        public static Image GetGroupProfileImage(long Group_id)
        {
            return Image.FromFile((from a in db.tbl_Groups where a.id == Group_id select a).FirstOrDefault().tbl_Pic.Pic_Url);
        }
        public static int GetGroupMemberCount(long Group_id)
        {
            return (from a in db.tbl_GroupMembers where a.Group_id_FK == Group_id select a).Count();
        }
        public static string GetGroupName(long Group_id)
        {
            return (from a in db.tbl_Groups where a.id == Group_id select a).FirstOrDefault().Name;
        }
        public static tbl_GroupMessage InsertGroupMessage(long Message_id, long Group_id, long Sender_id)
        {
            tbl_GroupMessage tbl = new tbl_GroupMessage()
            {
                Message_id_FK = Message_id,
                Sender_id_FK = Sender_id,
                Group_id_FK = Group_id,
                IsRecive = false
            };
            db.tbl_GroupMessage.Add(tbl);
            db.SaveChanges();
            return (from a in db.tbl_GroupMessage orderby a.id descending select a).FirstOrDefault();
        }
        public static bool DeleteGroupMessage(long Message_id, long Chat_id)
        {
            try
            {
                var Q = (from a in db.tbl_GroupMessage where a.Group_id_FK == Chat_id && a.Message_id_FK == Message_id select a).FirstOrDefault();
                db.tbl_GroupMessage.Remove(Q);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static AdminPermisions GroupAdminPermision(long Group_id, long User_id)
        {
            try
            {
                var Q = (from a in db.tbl_GroupAdmin where a.User_id_FK == User_id && a.Group_id_FK == Group_id select a).FirstOrDefault();
                if (Q == null)
                    return new AdminPermisions()
                    {
                        CanDeleteMessages = false,
                        CanEditMessages = false,
                        CanPinMessages = false,
                        CanBanUser = false
                    };
                else
                    return new AdminPermisions()
                    {
                        CanDeleteMessages = Q.CanDelete.Value,
                        CanEditMessages = false,
                        CanPinMessages = Q.CanPin.Value,
                        CanBanUser = Q.CanBanMember.Value
                    };
            }
            catch
            {
                return new AdminPermisions()
                {
                    CanDeleteMessages = false,
                    CanEditMessages = false,
                    CanPinMessages = false,
                    CanBanUser = false
                };
            }
        }
        public static tbl_Message GetGroupPinMessage(long Group_id)
        {
            var Q = (from b in db.tbl_Message where b.id == (from a in db.tbl_Groups where a.id == Group_id select a).FirstOrDefault().PinMessage_id_FK select b).FirstOrDefault();
            if (Q != null)
                return Q;
            else
                return new tbl_Message();
        }
        public static bool PinMessage(long Message_id, long Group_id)
        {
            try
            {
                var Q = (from a in db.tbl_Groups where a.id == Group_id select a).FirstOrDefault();
                Q.PinMessage_id_FK = Message_id;
                db.Entry(Q).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public static bool DeletePinMessage(long Group_id)
        {
            try
            {
                var Q = (from a in db.tbl_Groups where a.id == Group_id select a).FirstOrDefault();
                Q.PinMessage_id_FK = null;
                db.Entry(Q).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public static tbl_Groups GetGroupInfo(long Group_id)
        {
            return (from a in db.tbl_Groups where a.id == Group_id select a).FirstOrDefault();
        }
        public static bool IsGroupAdmin(long User_id, long Group_id)
        {
            return Convert.ToBoolean((from a in db.tbl_GroupAdmin where a.Group_id_FK == Group_id && a.User_id_FK == User_id select a).Count());
        }
        public static List<tbl_Users> GetGroupMember(long Group_id)
        {
            return (from a in db.tbl_GroupMembers where a.Group_id_FK == Group_id select a.tbl_Users).ToList();
        }
        public static List<tbl_GroupAdmin> GetGroupAdminList(long Group_id)
        {
            return (from a in db.tbl_GroupAdmin where a.Group_id_FK == Group_id select a).ToList();
        }
        public static string GetAdminPrometer(long Group_id, long User_id)
        {
            var Q = (from a in db.tbl_Groups where a.id == Group_id select a).FirstOrDefault();
            if (Q.Creator_id_FK == User_id)
                return "Creator";
            else
                return "Prometed By " + Rep_Users.GetUser(Q.Creator_id_FK.Value).Name + " " + Rep_Users.GetUser(Q.Creator_id_FK.Value).Lname;
        }
        public static bool DeleteGroupAdmin(long GroupAdmin_id)
        {
            try
            {
                var Q = (from a in db.tbl_GroupAdmin where a.id == GroupAdmin_id select a).FirstOrDefault();
                db.tbl_GroupAdmin.Remove(Q);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public static bool DeleteGroupAdmin(long Group_id, long User_id)
        {
            try
            {
                var Q = (from a in db.tbl_GroupAdmin where a.Group_id_FK == Group_id && a.User_id_FK == User_id select a).FirstOrDefault();
                db.tbl_GroupAdmin.Remove(Q);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public static tbl_GroupAdmin GetGroupAdmin(long AdminGroup_id)
        {
            return (from a in db.tbl_GroupAdmin where a.id == AdminGroup_id select a).FirstOrDefault();
        }
        public static bool EditGroupAdminPermition(long AdminGroup_id, bool IsBan, bool IsDelete, bool IsPin)
        {
            try
            {
                var Q = (from a in db.tbl_GroupAdmin where a.id == AdminGroup_id select a).FirstOrDefault();
                Q.CanDelete = IsDelete;
                Q.CanPin = IsPin;
                Q.CanBanMember = IsBan;
                db.Entry(Q).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public static bool DeleteGroupMember(long Group_id, long User_id)
        {
            try
            {
                var Q = (from a in db.tbl_GroupMembers where a.Group_id_FK == Group_id && a.User_id_FK == User_id select a).FirstOrDefault();
                db.tbl_GroupMembers.Remove(Q);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public static List<tbl_GroupBanList> GroupBanList(long Group_id)
        {
            return (from a in db.tbl_GroupBanList where a.Group_id_FK == Group_id select a).ToList();
        }
        public static bool UnbanGroupUser(long GroupUserBan_id)
        {
            try
            {
                var Q = (from a in db.tbl_GroupBanList where a.id == GroupUserBan_id select a).FirstOrDefault();
                db.tbl_GroupBanList.Remove(Q);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public static bool AddGroupAdmin(long User_id, long Group_id, long? Prometer_id)
        {
            try
            {
                tbl_GroupAdmin tbl = new tbl_GroupAdmin()
                {
                    CanBanMember = true,
                    CanDelete = true,
                    CanPin = true,
                    Group_id_FK = Group_id,
                    Promoter_id_FK = Prometer_id,
                    User_id_FK = User_id
                };
                db.tbl_GroupAdmin.Add(tbl);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public static bool AddGroupMember(long User_id, long Group_id)
        {
            try
            {
                tbl_GroupMembers tbl = new tbl_GroupMembers()
                {
                    Date = AdvanceMethod.Date,
                    Time = AdvanceMethod.Time,
                    Group_id_FK = Group_id,
                    User_id_FK = User_id
                };
                db.tbl_GroupMembers.Add(tbl);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public static List<tbl_Users> AddMemberGroupList(long Group_id, long User_id)
        {
            var Q1 = (from a in db.tbl_Contact where a.User_id_FK == User_id select a.tbl_Users1).ToList();
            var Q2 = (from a in db.tbl_GroupMembers where a.Group_id_FK == Group_id select a.tbl_Users).ToList();
            var Q3 = (from a in db.tbl_GroupBanList where a.Group_id_FK == Group_id select a.tbl_Users).ToList();
            foreach (var item in Q2)
                Q1.Remove(item);
            foreach (var item in Q3)
                Q1.Remove(item);
            return Q1;
        }
        public static bool BanGroupUser(long Group_id, long User_id)
        {
            try
            {
                tbl_GroupBanList tbl = new tbl_GroupBanList()
                {
                    Date = AdvanceMethod.Date,
                    Time = AdvanceMethod.Time,
                    Group_id_FK = Group_id,
                    Restrictor_id_FK = Frm_Chats.User_id,
                    User_id_FK = User_id
                };
                db.tbl_GroupBanList.Add(tbl);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public static List<tbl_Users> AvalableUsersToBanList(long Group_id)
        {
            var Q = (from a in db.tbl_GroupAdmin where a.Group_id_FK == Group_id select a.tbl_Users).ToList();
            var Q1 = (from a in db.tbl_GroupBanList where a.Group_id_FK == Group_id select a.tbl_Users).ToList();
            var Q2 = (from a in db.tbl_GroupMembers where a.Group_id_FK == Group_id select a.tbl_Users).ToList();
            foreach (var item in Q)
                Q2.Remove(item);
            foreach (var item in Q1)
                Q2.Remove(item);
            return Q2;
        }
        public static long CreateGroup(string Name, string Des, string ProfilePic)
        {
            try
            {
                long Pic_id = Rep_Pic.InsertPhoto(ProfilePic);
                tbl_Groups tbl = new tbl_Groups()
                {
                    PinMessage_id_FK = null,
                    Creator_id_FK = Frm_Chats.User_id,
                    Name = Name,
                    Description = Des,
                    Pic_id_FK = Pic_id,
                    InviteLink = GetInviteLink()
                };
                db.tbl_Groups.Add(tbl);
                db.SaveChanges();
                return (from a in db.tbl_Groups orderby a.id descending select a).FirstOrDefault().id;
            }
            catch { return 0; }
        }
        public static string GetInviteLink()
        {
            string InviteLink = "";
            while (true)
            {
                InviteLink = Guid.NewGuid().ToString().Replace("-", "");
                var Q = (from a in db.tbl_Groups where a.InviteLink == InviteLink select a).Count();
                var Q1 = (from a in db.tbl_Channels where a.InviteLink == InviteLink select a).Count();
                if (Q == 0 && Q1 == 0)
                    break;
            }
            return InviteLink;
        }
        public static bool DeleteGroup(long Group_id)
        {
            try
            {
                var Q = (from a in db.tbl_Groups where a.id == Group_id select a).FirstOrDefault();
                db.tbl_Groups.Remove(Q);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public static bool IsGroupMember(long Group_id,long User_id)
        {
            return Convert.ToBoolean((from a in db.tbl_GroupMembers where a.User_id_FK == User_id && a.Group_id_FK == Group_id select a).Count());
        }
    }
}
