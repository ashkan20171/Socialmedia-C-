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
    public partial class BlockUsersListItem : UserControl
    {
        public BlockUsersListItem()
        {
            InitializeComponent();
        }
        public long BlockedId { get; set; }
        public string User_Name { get { return lbl_Name.Text; } set { lbl_Name.Text = value; } }
        public string LastSeen { get { return lbl_lastSeen.Text; } set { lbl_lastSeen.Text = value; } }
        public bool RemoveLinkVisible { get { return lbl_UnBlock.Visible; } set { lbl_UnBlock.Visible = value; } }
        private void AdminListItem_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X <= this.Location.X + this.Width && e.Y <= this.Location.Y + this.Height)
            {
                this.BackColor = Color.WhiteSmoke;
                lbl_UnBlock.Visible = true;
            }
        }
        public string ProfilePic { get { return pictureBox1.ImageLocation; } set { pictureBox1.ImageLocation = value; } }
        public event EventHandler UnblockClicked;

        private void lbl_UnBlock_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (UnblockClicked != null)
                UnblockClicked(this, e);
        }
    }
}
