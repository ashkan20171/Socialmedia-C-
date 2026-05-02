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

namespace SocialMediaLikeTelegram.Profiles
{
    public partial class Frm_UserInfo : Form
    {
        public static long User_id = 0;
        public Frm_UserInfo()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_UserInfo_Load(object sender, EventArgs e)
        {
            var User = Rep_Users.GetUser(User_id);
            lbl_Name.Text = User.Name + " " + User.Lname;
            lbl_Username.Text = User.Username;
            if (!Rep_Users.IsBlockUser(Frm_Chats.User_id, User_id))
            {
                lbl_LastSeen.Text = Rep_PrivateChat.UserLastSeen(User_id);
                Profile_Pic.ImageLocation = User.tbl_Pic.Pic_Url;
            }
            if (Rep_Users.IsContact(Frm_Chats.User_id, User_id))
            {
                btn_DeleteContact.Visible = true;
                btn_EditContact.Visible = true;
                lbl_Mobile.Text = User.PhoneNumber;
                lbl_Mobile.Visible = true;
                lbl_DesMobile.Visible = true;
                lbl_Name.Text = Rep_Users.GetContactName(Frm_Chats.User_id, User_id);
            }
            else
            {
                btn_DeleteContact.Visible = false;
                btn_EditContact.Visible = false;
                lbl_Mobile.Visible = false;
                lbl_DesMobile.Visible = false;
                lbl_DesUsername.Top = lbl_DesBio.Top;
                lbl_Username.Top = lbl_Bio.Top;
                lbl_DesBio.Top = lbl_DesMobile.Top;
                lbl_Bio.Top = lbl_Mobile.Top;
                panel4.Height -= lbl_DesMobile.Bottom;
                panel5.Top = panel4.Bottom + 6;
                this.Height = panel5.Bottom;
            }
            if (Rep_Users.IsBlockUser(User_id, Frm_Chats.User_id))
                materialFlatButton3.Text = "UNBLOCK USER";
        }

        private void materialFlatButton4_Click(object sender, EventArgs e)
        {
            var PrivateChat = Rep_PrivateChat.GetPrivateChatByUsers(User_id, Frm_Chats.User_id);
            if (PrivateChat != null)
            {
                Frm_Chats Frm;
                if (this.Owner.GetType().Name == "Frm_Chats")
                    Frm = (Frm_Chats)this.Owner;
                else
                    Frm = (Frm_Chats)this.Owner.Owner;
                Frm.ShowChat(PrivateChat.id);
                this.Close();
            }
            else
            {
                PrivateChat = Rep_PrivateChat.InsertPrivateChat(User_id, Frm_Chats.User_id);
                Frm_Chats Frm;
                if (this.Owner.GetType().Name == "Frm_Chats")
                    Frm = (Frm_Chats)this.Owner;
                else
                    Frm = (Frm_Chats)this.Owner.Owner;
                Frm.InsertChatListItem(Components.ComponentsProperties.ChatType.PrivateChat, PrivateChat);
                Frm.ShowChat(PrivateChat.id);
                this.Close();
            }
        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            if (materialFlatButton3.Text == "BLOCK USER")
            {
                Rep_Users.BlockUser(User_id);
                materialFlatButton3.Text = "UNBLOCK USER";
            }
            else
            {
                Rep_Users.UnblockUser(User_id);
                materialFlatButton3.Text = "BLOCK USER";
            }
        }

        private void Profile_Pic_Click(object sender, EventArgs e)
        {
            Pics.Frm_ShowProfilesPics.ChatType = Components.ComponentsProperties.ChatType.PrivateChat;
            Pics.Frm_ShowProfilesPics.Chat_id = User_id;
            new Pics.Frm_ShowProfilesPics().ShowDialog(this);
        }

        private void btn_EditContact_Click(object sender, EventArgs e)
        {
            Contacts.Frm_EditContact.User_id = User_id;
            new Contacts.Frm_EditContact().ShowDialog(this);
            Frm_UserInfo_Load(null, null);
        }

        private void btn_DeleteContact_Click(object sender, EventArgs e)
        {
            if (AdvanceMethod.AdvanceMessageBox("are you sure to delete this contact ?") == DialogResult.OK)
            {
                Rep_Contact.DeleteContact(User_id);
                Frm_UserInfo_Load(null, null);
            }
        }
    }
}
