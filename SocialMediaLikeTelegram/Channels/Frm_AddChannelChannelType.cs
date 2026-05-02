using MaterialSkin;
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

namespace SocialMediaLikeTelegram.Channels
{
    public partial class Frm_AddChannelChannelType : Form
    {
        public static string ChannelType = "";
        public static string InviteLink = "";
        public static string Channel_id = "";
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
        public Frm_AddChannelChannelType()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue400, Primary.Grey500, Primary.Grey700, Accent.LightBlue400, TextShade.WHITE);
        }

        private void materialRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (materialRadioButton2.Checked)
            {
                lbl_Title.Text = "Channel ID";
                txt_id.Visible = true;
                lbl_InviteLink.Visible = false;
            }
        }

        private void materialRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (materialRadioButton1.Checked)
            {
                lbl_Title.Text = "Invite Link";
                txt_id.Visible = false;
                lbl_InviteLink.Visible = true;
                lbl_InviteLink.Text = Models.Repository.Rep_Groups.GetInviteLink();
            }
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_id_TextChanged(object sender, EventArgs e)
        {
            if (!Models.Repository.Rep_Users.ValidateUsername(txt_id.Text))
            {
                txt_id.Tag = false;
                txt_id.LineMouseHoverColor = Color.Red;
                txt_id.LineIdleColor = Color.Red;
                txt_id.LineFocusedColor = Color.Red;
            }
            else
            {
                txt_id.LineMouseHoverColor = Color.Green;
                txt_id.LineIdleColor = Color.Green;
                txt_id.LineFocusedColor = Color.Green;
            }
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            if (materialRadioButton2.Checked)
            {
                if (txt_id.LineFocusedColor == Color.Green)
                {
                    ChannelType = "Public";
                    Channel_id = txt_id.Text;
                    this.Hide();
                    new Channels.Frm_AddChannelAddMember().ShowDialog(this.Owner);
                }
                else
                    AdvanceMethod.AdvanceMessageBox("please enter a valid username !");
            }
            else
            {
                ChannelType = "Private";
                InviteLink = lbl_InviteLink.Text;
                this.Hide();
                new Channels.Frm_AddChannelAddMember().ShowDialog(this.Owner);
            }
        }

        private void Frm_AddChannelChannelType_Load(object sender, EventArgs e)
        {
            materialRadioButton2.Checked = true;
        }
    }
}
