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

namespace SocialMediaLikeTelegram.Setting
{
    public partial class Frm_ChatBackgroundLibrary : Form
    {
        string SelectPic = "";
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
        public Frm_ChatBackgroundLibrary()
        {
            InitializeComponent();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "Chatbackground", SelectPic);
            this.Close();
        }

        private void Frm_EditBio_Load(object sender, EventArgs e)
        {
            string R6 = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "Chatbackground", "").ToString();
            if (R6 == "1" || R6 == "2" || R6 == "3" || R6 == "4" || R6 == "5" || R6 == "6" || R6 == "7" || R6 == "8" || R6 == "9")
            {
                int X = this.Controls["pictureBox" + R6].Location.X + this.Controls["pictureBox" + R6].Width - PicTick.Width;
                int Y = this.Controls["pictureBox" + R6].Location.Y + this.Controls["pictureBox" + R6].Height - PicTick.Height;
                PicTick.Location = new Point(X, Y);
            }
            else
                PicTick.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Control C = ((Control)sender);
            SelectPic = C.Name.Remove(0, 10);
            int X = C.Location.X + C.Width - PicTick.Width;
            int Y = C.Location.Y + C.Height - PicTick.Height;
            PicTick.Location = new Point(X, Y);
            PicTick.Visible = true;
        }
    }
}
