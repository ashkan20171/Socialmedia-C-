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
    public partial class ContactListItem : UserControl
    {
        public ContactListItem()
        {
            InitializeComponent();
        }
        public string ContactName { get { return lbl_Name.Text; } set { lbl_Name.Text = value; } }
        public string LastSeen
        {
            get { return lbl_LastSeen.Text; }
            set { lbl_LastSeen.Text = value; }
        }
        public long User_id { get; set; }
        public bool IsActive { get { if (this.BackColor == Color.White) return false; else return true; } set { if (value) this.BackColor = Color.WhiteSmoke; else this.BackColor = Color.White; } }
        public string ProfilePic { get { return pictureBox1.ImageLocation; } set { pictureBox1.ImageLocation = value; } }
    }
}
