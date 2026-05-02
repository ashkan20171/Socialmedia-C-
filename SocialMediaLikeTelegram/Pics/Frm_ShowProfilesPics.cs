using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SocialMediaLikeTelegram.Models.Repository;

namespace SocialMediaLikeTelegram.Pics
{
    public partial class Frm_ShowProfilesPics : Form
    {
        List<string> Pic_log;
        int Pic_Index = 1;
        public static long Chat_id = 0;
        public static Components.ComponentsProperties.ChatType ChatType = Components.ComponentsProperties.ChatType.Channel;
        public Frm_ShowProfilesPics()
        {
            InitializeComponent();
            Pic_log = new List<string>();
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
            btn_Next.BackColor = Color.FromArgb(20, Color.Black);
            btn_Preview.BackColor = Color.FromArgb(20, Color.White);

            // Set Top And Left
            int NextAndPreviewTop = (Screen.PrimaryScreen.Bounds.Height / 2) - (btn_Next.Height / 2);
            btn_Next.Top = btn_Preview.Top = NextAndPreviewTop;
            // Set Width And Height
            int Pic_WidthAndHeight = (Screen.PrimaryScreen.Bounds.Height - semiTransparentPanel1.Height - 120);
            ShowPicturebox.Height = ShowPicturebox.Width = Pic_WidthAndHeight;
            ShowPicturebox.Top = 60;
            int LeftPicViewer = (semiTransparentPanel4.Width / 2) - (ShowPicturebox.Width / 2);
            ShowPicturebox.Left = LeftPicViewer/* + semiTransparentPanel2.Width*/;
            ///////////
            if (ChatType == Components.ComponentsProperties.ChatType.Channel)
            {
                ShowPicturebox.Image = Rep_Channels.GetChannelProfilePic(Chat_id);
            }
            else if (ChatType == Components.ComponentsProperties.ChatType.Group)
            {
                ShowPicturebox.Image = Rep_Groups.GetGroupProfileImage(Chat_id);
            }
            else
            {
                lbl_ProfileName.Visible = true;
                var Q = Rep_Users.GetUser(Chat_id);
                string Pic = Q.tbl_Pic.Pic_Url;
                Pic_log = Q.Pic_Log.Split(',').ToList();
                lbl_ProfileName.Text = Q.Name + " " + Q.Lname + "      " + Rep_PrivateChat.UserLastSeen(Q.id);
                ShowPicturebox.ImageLocation = Pic;
                if (Pic_log.ToArray().Length > 1)
                    btn_Next.Visible = true;
                Pic_log.Reverse();
                Pic_Index = 1;
            }
        }

        private void semiTransparentPanel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (ShowPicturebox.ImageLocation == Rep_Pic.GetPicUrl(long.Parse(Pic_log.ToArray()[0])))
                Pic_Index = 1;
            btn_Preview.Visible = true;
            if (Pic_log.Count == Pic_Index + 1)
                btn_Next.Visible = false;
            ShowPicturebox.ImageLocation = Rep_Pic.GetPicUrl(long.Parse(Pic_log.ToArray()[Pic_Index]));
            if (Pic_log.Count - 1 != Pic_Index)
                Pic_Index++;
        }

        private void btn_Preview_Click(object sender, EventArgs e)
        {
            Pic_Index--;
            btn_Next.Visible = true;
            if (Pic_Index <= -1)
            {
                btn_Preview.Visible = false;
                ShowPicturebox.ImageLocation = Rep_Pic.GetPicUrl(long.Parse(Pic_log.ToArray()[0]));
            }
            else
                ShowPicturebox.ImageLocation = Rep_Pic.GetPicUrl(long.Parse(Pic_log.ToArray()[Pic_Index]));
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
