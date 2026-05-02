using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Components
{
    public partial class AdminListItem : UserControl
    {
        public AdminListItem()
        {
            InitializeComponent();
        }
        public ComponentsProperties.ChatType ChatType { get; set; }
        public long ChatId { get; set; }
        public string ProfilePic { get { return pictureBox1.ImageLocation; } set { pictureBox1.ImageLocation = value; } }
        public long AdminChatId { get; set; }
        public string AdminName { get { return lbl_Name.Text; } set { lbl_Name.Text = value; } }
        public string Prometer { get { return lbl_Promote.Text; } set { lbl_Promote.Text = value; } }
        static private bool _isShowRemoveLink;
        public bool IsShowRemoveLink { get { return _isShowRemoveLink; } set { _isShowRemoveLink = value; } }
        public bool RemoveLinkVisible { get { return lbl_Remove.Visible; } set { lbl_Remove.Visible = value; } }
        private void AdminListItem_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X <= this.Location.X + this.Width && e.Y <= this.Location.Y + this.Height)
            {
                this.BackColor = Color.WhiteSmoke;
                if (Prometer != "Creator")
                    if (_isShowRemoveLink)
                        lbl_Remove.Visible = true;
            }
        }
        public event EventHandler RemoveLinkClicked;
        private void lbl_Remove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (RemoveLinkClicked != null)
                RemoveLinkClicked(this, e);
        }
    }
}
