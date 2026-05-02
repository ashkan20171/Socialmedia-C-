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
    public partial class Frm_NotificationPositionAndCount : Form
    {
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
        public Frm_NotificationPositionAndCount()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void line1_Click(object sender, EventArgs e)
        {
            var SelectedLine = (DevComponents.DotNetBar.Controls.Line)(sender);
            foreach (Control item in this.Controls)
                if (item.GetType().Name.Contains("Line"))
                    ((DevComponents.DotNetBar.Controls.Line)(item)).ForeColor = Color.FromArgb(239, 234, 255);
            SelectedLine.ForeColor = Color.FromArgb(64, 167, 227);
            Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "NotificationCount", SelectedLine.Tag);
        }

        private void semiTransparentPanel1_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
                if (item.GetType().Name.Contains("SemiTransparentPanel"))
                    item.Visible = true;
            var SelectedPanel = (SemiTransparentPanel)sender;
            SelectedPanel.Visible = true;
            string Position = "";
            if (SelectedPanel.Location == new Point(33, 97))
                Position = "TopLeft";
            else if (SelectedPanel.Location == new Point(213, 97))
                Position = "TopRight";
            else if (SelectedPanel.Location == new Point(33, 240))
                Position = "BottomLeft";
            else if (SelectedPanel.Location == new Point(213, 241))
                Position = "BottomRight";
            Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "NotificationPosition", Position);
        }

        private void semiTransparentPanel4_MouseEnter(object sender, EventArgs e)
        {
            string Position = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "NotificationPosition", "").ToString();
            int Count = int.Parse(Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "NotificationCount", "").ToString());
            if (Position == "TopLeft")
            {
                int NotifiTop = 0;
                for (int i = 0; i < Count; i++)
                {
                    Frm_Notification Notifi = new Frm_Notification();
                    Notifi.Message = "XXXXXXXXXXXXXXXXXX";
                    Notifi.ChatName = "XXXXXX";
                    Notifi.Top = NotifiTop;
                    Notifi.Left = 0;
                    Notifi.Show(this);
                    NotifiTop += Notifi.Height + 5;
                }
            }
            else if (Position == "TopRight")
            {
                int NotifiTop = 0;
                for (int i = 0; i < Count; i++)
                {
                    Frm_Notification Notifi = new Frm_Notification();
                    Notifi.Message = "XXXXXXXXXXXXXXXXXX";
                    Notifi.ChatName = "XXXXXX";
                    Notifi.Top = NotifiTop;
                    Notifi.Left = Screen.PrimaryScreen.Bounds.Width - Notifi.Width;
                    Notifi.Show(this);
                    NotifiTop += Notifi.Height + 5;
                }
            }
            else if (Position == "BottomLeft")
            {
                int NotifiTop = Screen.PrimaryScreen.WorkingArea.Height - 63;
                for (int i = 0; i < Count; i++)
                {
                    Frm_Notification Notifi = new Frm_Notification();
                    Notifi.Message = "XXXXXXXXXXXXXXXXXX";
                    Notifi.ChatName = "XXXXXX";
                    Notifi.Top = NotifiTop;
                    Notifi.Left = 0;
                    Notifi.Show(this);
                    NotifiTop -= (Notifi.Height + 5);
                }
            }
            else if (Position == "BottomRight")
            {
                int NotifiTop = Screen.PrimaryScreen.WorkingArea.Height - 63;
                for (int i = 0; i < Count; i++)
                {
                    Frm_Notification Notifi = new Frm_Notification();
                    Notifi.Message = "XXXXXXXXXXXXXXXXXX";
                    Notifi.ChatName = "XXXXXX";
                    Notifi.Top = NotifiTop;
                    Notifi.Left = Screen.PrimaryScreen.Bounds.Width - Notifi.Width;
                    Notifi.Show(this);
                    NotifiTop -= (Notifi.Height + 5);
                }
            }
        }

        private void semiTransparentPanel3_MouseLeave(object sender, EventArgs e)
        {
            foreach (Form item in this.OwnedForms)
                item.Close();
        }

        private void Frm_NotificationPositionAndCount_Load(object sender, EventArgs e)
        {
            string Position = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "NotificationPosition", "").ToString();
            string Count = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "NotificationCount", "").ToString();
            foreach (Control item in this.Controls)
                if (item.GetType().Name.Contains("Line"))
                {
                    if ((string)item.Tag == Count)
                        ((DevComponents.DotNetBar.Controls.Line)(item)).ForeColor = Color.FromArgb(64, 167, 227);
                    else
                        ((DevComponents.DotNetBar.Controls.Line)(item)).ForeColor = Color.FromArgb(239, 234, 255);
                }
            if (Position == "TopLeft")
                semiTransparentPanel1.Visible = false;
            else if (Position == "TopRight")
                semiTransparentPanel4.Visible = false;
            else if (Position == "BottomLeft")
                semiTransparentPanel2.Visible = false;
            else if (Position == "BottomRight")
                semiTransparentPanel3.Visible = false;
        }
    }
}
