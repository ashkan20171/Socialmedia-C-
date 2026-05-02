using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialMediaLikeTelegram.Setting
{
    public partial class Frm_ManageLocalStotage : Form
    {
        public Frm_ManageLocalStotage()
        {
            InitializeComponent();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private long CalculateTelegramTempSize(ref string Mod)
        {
            long TelegramTempSize = 0;
            foreach (string item in System.IO.Directory.GetFiles(@"C:\Telegram Temps"))
            {
                System.IO.FileInfo F = new System.IO.FileInfo(item);
                TelegramTempSize += F.Length;
            }
            TelegramTempSize /= 1024;
            Mod = "KB";
            if (TelegramTempSize > 0)
            {
                TelegramTempSize /= 1024;
                Mod = "MB";
            }
            return TelegramTempSize;
        }
        private void Frm_ManageLocalStotage_Load(object sender, EventArgs e)
        {
            string Mod = "";
            long FolderSize = CalculateTelegramTempSize(ref Mod);
            lbl_Size.Text = " " + FolderSize + " " + Mod;
        }

        private void lbl_PhoneNumber_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (string item in System.IO.Directory.GetFiles(@"C:\Telegram Temps"))
                System.IO.File.Delete(item);
            Frm_ManageLocalStotage_Load(null, null);
        }
    }
}
