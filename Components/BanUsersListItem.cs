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
    public partial class BanUsersListItem : UserControl
    {
        public BanUsersListItem()
        {
            InitializeComponent();
        }
        public ComponentsProperties.ChatType ChatType { get; set; }
        public long ChatId { get; set; }
        public long BanChatId { get; set; }
        public bool RemoveVisible { get; set; }
        public string User_Name { get { return lbl_Name.Text; } set { lbl_Name.Text = value; } }
        public string LastSeen { get { return lbl_lastSeen.Text; } set { lbl_lastSeen.Text = value; } }
        public bool RemoveLinkVisible { get { return lbl_Remove.Visible; } set { lbl_Remove.Visible = value; } }
        public string ProfilePic { get { return pictureBox1.ImageLocation; } set { pictureBox1.ImageLocation = value; } }
        private void AdminListItem_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X <= this.Location.X + this.Width && e.Y <= this.Location.Y + this.Height)
            {
                this.BackColor = Color.WhiteSmoke;
                if (RemoveVisible)
                    lbl_Remove.Visible = true;
            }
        }
        public long User_id { get; set; }
        public event EventHandler RemoveLinkClicked;
        private void lbl_Remove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (RemoveLinkClicked != null)
                RemoveLinkClicked(this, e);
        }
    }
}
