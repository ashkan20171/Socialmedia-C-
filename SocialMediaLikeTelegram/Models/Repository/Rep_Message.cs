using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaLikeTelegram.Models.Repository
{
    class Rep_Message
    {
        private static SocialMediaDBEntities db = new SocialMediaDBEntities();
        public static tbl_Message InsertMessage(string Text, string Pic_Url, Components.ComponentsProperties.MessageType MessageType, long PicUploader)
        {
            if (MessageType == Components.ComponentsProperties.MessageType.PhotoMessage)
            {
                tbl_Pic tbl = new tbl_Pic()
                {
                    Pic_Url = AdvanceMethod.UploadPhoto(Pic_Url),
                    Uploader_id_FK = PicUploader
                };
                db.tbl_Pic.Add(tbl);
                db.SaveChanges();
                var Pic = (from a in db.tbl_Pic orderby a.id descending select a).FirstOrDefault();
                tbl_Message tblMessage = new tbl_Message()
                {
                    IsEdited = false,
                    Type = (int)MessageType,
                    Pic_id_FK = Pic.id,
                    Text = Text,
                    Date = DateTime.Now.ToShortDateString(),
                    Time = DateTime.Now.ToShortTimeString()
                };
                db.tbl_Message.Add(tblMessage);
                db.SaveChanges();
                return (from a in db.tbl_Message orderby a.id descending select a).FirstOrDefault();
            }
            else
            {
                tbl_Message tblMessage = new tbl_Message()
                {
                    IsEdited = false,
                    Type = (int)MessageType,
                    Text = Text,
                    Date = DateTime.Now.ToShortDateString(),
                    Time = DateTime.Now.ToShortTimeString()
                };
                db.tbl_Message.Add(tblMessage);
                db.SaveChanges();
                return (from a in db.tbl_Message orderby a.id descending select a).FirstOrDefault();
            }
        }
        public static bool DeleteMessage(long Message_id)
        {
            try
            {
                var Q = (from a in db.tbl_Message where a.id == Message_id select a).FirstOrDefault();
                db.tbl_Message.Remove(Q);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public static bool EdditMessage(long Message_id,string MessageText)
        {
            try
            {
                var Q = (from a in db.tbl_Message where a.id == Message_id select a).FirstOrDefault();
                Q.Text = MessageText;
                Q.IsEdited = true;
                db.Entry(Q).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public static tbl_Message GetMessage(long Message_id)
        {
            return (from a in db.tbl_Message where a.id == Message_id select a).FirstOrDefault();
        }
    }
}
