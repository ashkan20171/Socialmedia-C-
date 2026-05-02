using SocialMediaLikeTelegram.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialMediaLikeTelegram
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var Code = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "Session", null);
            if (Code != null && Code != string.Empty)
            {
                var Q = Rep_Users.GetSession(Code.ToString());
                if (Q != null)
                {
                    Frm_Chats.User_id = Q.User_id_FK.Value;
                    Application.Run(new Frm_Chats());
                }
                else
                    Application.Run(new Frm_Main());
            }
            else
                Application.Run(new Frm_Main());
        }
    }
}