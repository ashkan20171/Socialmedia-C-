using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;

namespace SocialMediaLikeTelegram.Models.Repository
{
    class Rep_Users
    {
        private static SocialMediaDBEntities db = new SocialMediaDBEntities();

        public static tbl_Users GetUser(long User_id)
        {
            db = new SocialMediaDBEntities();
            return db.tbl_Users.FirstOrDefault(a => a.id == User_id);
        }

        public static bool IsContact(long MainUser_id, long User_id)
        {
            try
            {
                return db.tbl_Contact.Any(a => a.User_id_FK == MainUser_id && a.Contact_id_FK == User_id);
            }
            catch { return false; }
        }

        public static string GetContactName(long MainUser_id, long User_id)
        {
            db = new SocialMediaDBEntities();

            var Q = db.tbl_Contact
                .FirstOrDefault(a => a.Contact_id_FK == User_id && a.User_id_FK == MainUser_id);

            if (Q == null)
                return "";

            return Q.Name + " " + Q.Lname;
        }

        public static List<tbl_Users> GetUserContactList(long User_id)
        {
            return db.tbl_Contact
                .Where(a => a.User_id_FK == User_id)
                .Select(a => a.tbl_Users1)
                .ToList();
        }

        public static bool EditUser(tbl_Users User)
        {
            try
            {
                db.Entry(User).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public static bool ValidateUsername(string Username)
        {
            try
            {
                bool existChannel = db.tbl_Channels.Any(a => a.Username == Username);
                bool existUser = db.tbl_Users.Any(a => a.Username == Username);

                return !(existChannel || existUser);
            }
            catch { return false; }
        }

        public static bool BlockUser(long User_id)
        {
            try
            {
                tbl_BlockList tbl = new tbl_BlockList()
                {
                    Blocked_id_FK = User_id,
                    Blocker_id_FK = Frm_Chats.User_id,
                    Date = AdvanceMethod.Date,
                    Time = AdvanceMethod.Time
                };

                db.tbl_BlockList.Add(tbl);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public static bool UnblockUser(long User_id)
        {
            try
            {
                var Q = db.tbl_BlockList
                    .FirstOrDefault(a => a.Blocked_id_FK == User_id && a.Blocker_id_FK == Frm_Chats.User_id);

                if (Q == null)
                    return false;

                db.tbl_BlockList.Remove(Q);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public static bool IsBlockUser(long Blocked_id, long Blocker_id)
        {
            try
            {
                return db.tbl_BlockList.Any(a => a.Blocked_id_FK == Blocked_id && a.Blocker_id_FK == Blocker_id);
            }
            catch { return false; }
        }

        public static List<tbl_Users> GetUserBlockList(long User_id)
        {
            return db.tbl_BlockList
                .Where(a => a.Blocker_id_FK == User_id)
                .Select(a => a.tbl_Users1)
                .ToList();
        }

        public static tbl_OpenSessions GetSession(string Code)
        {
            return db.tbl_OpenSessions.FirstOrDefault(a => a.Code == Code);
        }

        public static bool DeleteSession(string Code)
        {
            try
            {
                var Q = db.tbl_OpenSessions.FirstOrDefault(a => a.Code == Code);

                if (Q == null)
                    return false;

                db.tbl_OpenSessions.Remove(Q);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public static List<tbl_OpenSessions> GetAllSession(long User_id)
        {
            return db.tbl_OpenSessions
                .Where(a => a.User_id_FK == User_id)
                .ToList();
        }

        public static string ActivationCode(string PhoneNumber)
        {
            tbl_ActivationCode tbl = new tbl_ActivationCode()
            {
                Code = GetActivationCode(),
                PhoneNumber = PhoneNumber,
                IsActivate = false
            };

            db.tbl_ActivationCode.Add(tbl);
            db.SaveChanges();

            return tbl.Code;
        }

        private static string GetActivationCode()
        {
            string Code = "";
            Random rnd = new Random();

            while (true)
            {
                Code = rnd.Next(10000, 99999).ToString();

                bool exist = db.tbl_ActivationCode.Any(a => a.Code == Code);

                if (!exist)
                    break;
            }

            return Code;
        }

        public static string GetLastActivationCode(string PhoneNumber)
        {
            var result = db.tbl_ActivationCode
                .Where(a => a.PhoneNumber == PhoneNumber)
                .OrderByDescending(a => a.id)
                .FirstOrDefault();

            if (result == null)
                return null;

            return result.Code;
        }

        public static bool SetActiveActivationCode(string Code)
        {
            var Q = db.tbl_ActivationCode.FirstOrDefault(a => a.Code == Code);

            if (Q == null)
                return false;

            if (!Q.IsActivate)
            {
                Q.IsActivate = true;
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public static long InsertUser(string Name, string Lname, string PhoneNumber, string Username, string Bio, string Email, string Pic_Path)
        {
            long newId = 1;

            var lastUser = db.tbl_Users.OrderByDescending(a => a.id).FirstOrDefault();

            if (lastUser != null)
                newId = lastUser.id + 1;

            tbl_Users tbl = new tbl_Users()
            {
                id = newId,
                Biography = Bio,
                EMail = Email,
                LastSeenDate = DateTime.Now.ToShortDateString(),
                LastSeenPrivacy = 0,
                LastSeenTime = DateTime.Now.ToShortTimeString(),
                Name = Name,
                Lname = Lname,
                PhoneNumber = PhoneNumber,
                Username = Username
            };

            if (Pic_Path != "")
            {
                long Pic_id = Rep_Pic.InsertPhoto(AdvanceMethod.UploadPhoto(Pic_Path));
                tbl.Pic_id_FK = Pic_id;
                tbl.Pic_Log = Pic_id + ",";
            }

            db.tbl_Users.Add(tbl);
            db.SaveChanges();

            return tbl.id;
        }

        public static string InsertSession(long User_id)
        {
            tbl_OpenSessions tbl = new tbl_OpenSessions()
            {
                Code = GetSessionCode(),
                Date = DateTime.Now.ToShortDateString(),
                Time = DateTime.Now.ToShortTimeString(),
                User_id_FK = User_id,
                IP = GetLocalIPAddress(),
                OS = GetOS()
            };

            db.tbl_OpenSessions.Add(tbl);
            db.SaveChanges();

            return tbl.Code;
        }

        private static string GetSessionCode()
        {
            string Code = "";

            while (true)
            {
                Code = Guid.NewGuid().ToString().Replace("-", "0");

                bool exist = db.tbl_OpenSessions.Any(a => a.Code == Code);

                if (!exist)
                    break;
            }

            return Code;
        }

        private static string GetOS()
        {
            var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem")
                        .Get()
                        .Cast<ManagementObject>()
                        select x.GetPropertyValue("Caption")).FirstOrDefault();

            return name != null ? name.ToString() : "Unknown";
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            }

            return "0.0.0.0";
        }

        public static tbl_Users GetUserByPhoneNumber(string PhoneNumber)
        {
            return db.tbl_Users.FirstOrDefault(a => a.PhoneNumber == PhoneNumber);
        }
    }
}
