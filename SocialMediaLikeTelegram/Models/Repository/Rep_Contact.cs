using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaLikeTelegram.Models.Repository
{
    class Rep_Contact
    {
        private static SocialMediaDBEntities db = new SocialMediaDBEntities();
        public static bool IsUser(string PhoneNumber)
        {
            return Convert.ToBoolean((from a in db.tbl_Users where a.PhoneNumber == PhoneNumber select a).Count());
        }
        public static bool AddContact(string Name, string Lname, string PhoneNumber)
        {
            try
            {
                tbl_Contact tbl = new tbl_Contact()
                {
                    Contact_id_FK = (from a in db.tbl_Users where a.PhoneNumber == PhoneNumber select a).FirstOrDefault().id,
                    Lname = Lname,
                    Name = Name,
                    User_id_FK = Frm_Chats.User_id
                };
                db.tbl_Contact.Add(tbl);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public static bool EditContact(string Name, string Lname, long User_id)
        {
            try
            {
                var Q = (from a in db.tbl_Contact where a.Contact_id_FK == User_id && a.User_id_FK == Frm_Chats.User_id select a).FirstOrDefault();
                Q.Name = Name;
                Q.Lname = Lname;
                db.Entry(Q).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public static bool DeleteContact(long User_id)
        {
            try
            {
                var Q = (from a in db.tbl_Contact where a.Contact_id_FK == User_id && a.User_id_FK == Frm_Chats.User_id select a).FirstOrDefault();
                db.tbl_Contact.Remove(Q);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
    }
}
