using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialMediaLikeTelegram.Pics
{
    public partial class Frm_ShowChatPics : Form
    {
        public static string Pic_Url = "";
        public static Components.ComponentsProperties.ChatType ChatType = Components.ComponentsProperties.ChatType.Channel;
        public static long Chat_id = 0;
        public Frm_ShowChatPics()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams CP = base.CreateParams;
                CP.ExStyle |= 0x00000020;
                return CP;
            }
        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //base.OnPaintBackground(pevent);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(220, 0, 0, 0)), this.ClientRectangle);
        }

        private void Frm_ShowProfilesPics_Load(object sender, EventArgs e)
        {
            btn_Download.BackColor = lbl_ProfileName.BackColor = Color.FromArgb(0, Color.Black);
            // Set Width And Height
            int Pic_WidthAndHeight = (Screen.PrimaryScreen.Bounds.Height - semiTransparentPanel1.Height - 120);
            ShowPicturebox.Height = ShowPicturebox.Width = Pic_WidthAndHeight;
            ShowPicturebox.Top = 60;
            int LeftPicViewer = (semiTransparentPanel4.Width / 2) - (ShowPicturebox.Width / 2);
            ShowPicturebox.Left = LeftPicViewer/* + semiTransparentPanel2.Width*/;
            ShowPicturebox.ImageLocation = Pic_Url;
            if (ChatType == Components.ComponentsProperties.ChatType.Channel)
                lbl_ProfileName.Text = Models.Repository.Rep_Channels.GetChannelName(Chat_id);
            else if (ChatType == Components.ComponentsProperties.ChatType.Group)
                lbl_ProfileName.Text = Models.Repository.Rep_Groups.GetGroupName(Chat_id);
            else
                lbl_ProfileName.Text = Models.Repository.Rep_Users.GetUser(Frm_Chats.User_id).Name+" "+ Models.Repository.Rep_Users.GetUser(Frm_Chats.User_id).Lname;
        }

        private void semiTransparentPanel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Download_Click(object sender, EventArgs e)
        {
            string FileName = @"C:\Users\" + Environment.UserName + @"\Downloads\SocialMedia Download\" + Guid.NewGuid().ToString() + ".jpg";
            if (System.IO.Directory.Exists(@"C:\Users\" + Environment.UserName + @"\Downloads\SocialMedia Download"))
                ShowPicturebox.Image.Save(FileName);
            else
            {
                System.IO.Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\Downloads\SocialMedia Download");
                ShowPicturebox.Image.Save(FileName);
            }
        }
    }
}
