using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialMediaLikeTelegram
{
    class AdvanceMethod
    {
        public static string GetMonthString(int Month)
        {
            if (Month == 1)
                return "Jan";
            else if (Month == 2)
                return "Feb";
            else if (Month == 3)
                return "Mar";
            else if (Month == 4)
                return "Apr";
            else if (Month == 5)
                return "May";
            else if (Month == 6)
                return "Jun";
            else if (Month == 7)
                return "Jul";
            else if (Month == 8)
                return "Aug";
            else if (Month == 9)
                return "Sep";
            else if (Month == 10)
                return "Oct";
            else if (Month == 11)
                return "Nov";
            else if (Month == 12)
                return "Dec";
            else
                return "";
        }
        public static string UploadPhoto(string Pic_Path)
        {
            return Pic_Path;
        }
        public static string Date
        {
            get
            {
                return DateTime.Now.ToShortDateString();
            }
        }
        public static string Time
        {
            get
            {
                return DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00");
            }
        }
        public static DialogResult AdvanceMessageBox(string Message)
        {
            Frm_Dialog.Message = Message;
            new Frm_Dialog().ShowDialog();
            return Frm_Dialog.Result;
        }
        public static bool SendTextMessage(string Message,string Mobile)
        {
            //try
            //{
            //    ServiceReference1.WebServiceSoapClient client = new ServiceReference1.WebServiceSoapClient("WebServiceSoap12");
            //    string username = "sajjadsaharkhan";
            //    string password = "109512721379";
            //    string Number = "1000000010";
            //    bool Unicode = true;
            //    DateTime? SendDateTime = DateTime.Now;
            //    string result = client.Send(username, password, Number, Mobile.Replace("+", ""), Message, false, Unicode, false, SendDateTime);
            //    if (result == "-1" || result == "100" || result == "102" || result == "104" || result == "105" || result == "106")
            //        return false;
            //    else
            //        return true;
            //}
            //catch (Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message, "مشکل در ارسال پیامک", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            //    return false;
            //}
            return true;
        }
    }
}
