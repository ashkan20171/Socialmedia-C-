using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SocialMediaLikeTelegram.Models.Repository;

namespace SocialMediaLikeTelegram
{
    public partial class Frm_LastSeenPrivacy : Form
    {
        public Frm_LastSeenPrivacy()
        {
            InitializeComponent();
        }
        #region FormShadow
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
         );
        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);
        private bool m_aeroEnabled = true;                     // variables for box shadow
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;
        public struct MARGINS                           // struct for box shadow
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:                        // box shadow
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 1,
                            rightWidth = 1,
                            topHeight = 1
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);

                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }
        #endregion
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_LastSeenPrivacy_Load(object sender, EventArgs e)
        {
            var user = Rep_Users.GetUser(Frm_Chats.User_id);
            if (user.LastSeenPrivacy.Value == 0)
                chk_Evrybody.Checked = true;
            else if (user.LastSeenPrivacy.Value == 1)
                chk_Nobody.Checked = true;
            else
                chk_mycontact.Checked = true;
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            var User = Rep_Users.GetUser(Frm_Chats.User_id);
            int Flag = 0;
            if (chk_Evrybody.Checked)
                Flag = 0;
            else if (chk_mycontact.Checked)
                Flag = 2;
            else if (chk_Nobody.Checked)
                Flag = 1;
            User.LastSeenPrivacy = Flag;
            Rep_Users.EditUser(User);
            this.Close();
        }
    }
}
