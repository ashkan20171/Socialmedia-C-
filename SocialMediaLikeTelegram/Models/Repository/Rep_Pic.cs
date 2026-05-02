using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaLikeTelegram.Models.Repository
{
    class Rep_Pic
    {
        private static SocialMediaDBEntities db = new SocialMediaDBEntities();
        public static long InsertPhoto(string Path)
        {
            if (Path == "")
                Path = @"G:\C# Project\SocialMediaLikeTelegram\SocialMediaLikeTelegram\bin\Debug\fake.png";
            tbl_Pic tbl = new tbl_Pic()
            {
                Pic_Url = Path,
                Uploader_id_FK = Frm_Chats.User_id
            };
            db.tbl_Pic.Add(tbl);
            db.SaveChanges();
            return (from a in db.tbl_Pic orderby a.id descending select a).FirstOrDefault().id;
        }
        public static string GetPicUrl(long Pic_id)
        {
            return (from a in db.tbl_Pic where a.id == Pic_id select a).FirstOrDefault().Pic_Url;
        }
    }
}
