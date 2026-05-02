using SocialMediaLikeTelegram.Models.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialMediaLikeTelegram.Profiles
{
    public partial class Frm_ChannelInfo : Form
    {
        public static long Channel_id = 0;
        public Frm_ChannelInfo()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_ChannelInfo_Load(object sender, EventArgs e)
        {
            lbl_ChannelName.Text = Rep_Channels.GetChannelName(Channel_id);
            lbl_MemberCount.Text = Rep_Channels.GetChannelMemberCount(Channel_id).ToString();
            lbl_ChannelUsername.Text = Rep_Channels.GetChannelInfo(Channel_id).Username;
            txt_About.Text = Rep_Channels.GetChannelInfo(Channel_id).Description;
            Profile_Pic.ImageLocation = Rep_Channels.GetChannelInfo(Channel_id).tbl_Pic.Pic_Url;
            lbl_InviteLink.Text = Rep_Channels.GetChannelInfo(Channel_id).InviteLink;
            if (!Rep_Channels.IsChannelAdmin(Frm_Chats.User_id, Channel_id))
            {
                panel5.Top = PanelAdmin.Top;
                this.Height -= PanelAdmin.Height;
                PanelAdmin.Visible = false;
                lbl_InviteLink.Visible = false;
                label1.Top = lbl_ChannelUsername.Bottom + 5;
            }
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            Channels.Frm_ManageAdministrator.ChatType = Components.ComponentsProperties.ChatType.Channel;
            Channels.Frm_ManageAdministrator.Chat_id = Channel_id;
            new Channels.Frm_ManageAdministrator().ShowDialog(this);
        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            Channels.Frm_ManageMembers.Chat_id = Channel_id;
            new Channels.Frm_ManageMembers().ShowDialog(this);
        }

        private void Profile_Pic_Click(object sender, EventArgs e)
        {
            Pics.Frm_ShowProfilesPics.ChatType = Components.ComponentsProperties.ChatType.Channel;
            Pics.Frm_ShowProfilesPics.Chat_id = Channel_id;
            new Pics.Frm_ShowProfilesPics().ShowDialog(this);
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            if (AdvanceMethod.AdvanceMessageBox("are you sure to leave the group?") == DialogResult.OK)
                if (Rep_Channels.IsChannelAdmin(Frm_Chats.User_id, Channel_id))
            {
                if (Rep_Channels.GetAdminPrometor(Channel_id, Frm_Chats.User_id) == "Creator")
                {
                    foreach (var item in Rep_Channels.GetChannelAdminList(Channel_id))
                        Rep_Channels.RemoveChannelAdmin(item.id);
                    foreach (var item in Rep_Channels.GetChannelMember(Channel_id))
                        Rep_Channels.DeleteChannelMember(Channel_id, item.id);
                    Rep_Channels.DeleteChannel(Channel_id);
                    Frm_Chats Frm;
                    Frm = (Frm_Chats)this.Owner;
                    Frm.UpdateChatList();
                    this.Close();
                }
                else
                {
                    Rep_Channels.RemoveChannelAdmin(Channel_id, Frm_Chats.User_id);
                    Rep_Channels.DeleteChannelMember(Channel_id, Frm_Chats.User_id);
                    Frm_Chats Frm;
                    Frm = (Frm_Chats)this.Owner;
                    Frm.UpdateChatList();
                    this.Close();
                }
            }
            else
            {
                Rep_Channels.DeleteChannelMember(Channel_id, Frm_Chats.User_id);
                Frm_Chats Frm;
                Frm = (Frm_Chats)this.Owner;
                Frm.UpdateChatList();
                this.Close();
            }
        }

        private void lbl_InviteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(lbl_InviteLink.Text);
            DevComponents.DotNetBar.ToastNotification.Show(PanelAdmin, "Invite Link Copoid!!");
        }
    }
}
