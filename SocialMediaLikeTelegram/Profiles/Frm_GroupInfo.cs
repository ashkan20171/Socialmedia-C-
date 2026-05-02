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
using Components;

namespace SocialMediaLikeTelegram.Profiles
{
    public partial class Frm_GroupInfo : Form
    {
        public static long Group_id = 0;
        public Frm_GroupInfo()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_GroupInfo_Load(object sender, EventArgs e)
        {
            lbl_GroupName.Text = Rep_Groups.GetGroupName(Group_id);
            lbl_MemberCount.Text = Rep_Groups.GetGroupMemberCount(Group_id).ToString();
            txt_About.Text = Rep_Groups.GetGroupInfo(Group_id).Description;
            Profile_Pic.ImageLocation = Rep_Groups.GetGroupInfo(Group_id).tbl_Pic.Pic_Url;
            lbl_InviteLink.Text = Rep_Groups.GetGroupInfo(Group_id).InviteLink;
            if (!Rep_Groups.IsGroupAdmin(Frm_Chats.User_id, Group_id))
            {
                PanelAdmin.Visible = false;
                line1.Visible = false;
                PanelMembers.Top = panel6.Bottom + 6;
                materialFlatButton3.Visible = false;
                pictureBox5.Visible = false;
                label1.Visible = false;
                lbl_InviteLink.Visible = false;
            }
            else if (!Rep_Groups.GroupAdminPermision(Group_id, Frm_Chats.User_id).CanBanUser)
            {
                materialFlatButton1.Visible = false;
                pictureBox3.Visible = false;
            }
            foreach (Control item in PanelMembers.Controls)
                if (item.GetType().Name == "BanUsersListItem")
                    PanelMembers.Controls.Remove(item);
            if (PanelMembers.Controls.Count > 3)
                PanelMembers.Controls.RemoveAt(3);
            foreach (var item in Rep_Groups.GetGroupMember(Group_id))
            {
                bool RemoveVisibleLink = Rep_Groups.IsGroupAdmin(Frm_Chats.User_id, Group_id);
                if (Rep_Groups.IsGroupAdmin(item.id, Group_id))
                    RemoveVisibleLink = false;
                Components.BanUsersListItem MemberListItem = new Components.BanUsersListItem()
                {
                    Name = "MemberListItem_" + item.id.ToString(),
                    RemoveVisible = RemoveVisibleLink,
                    Width = 375,
                    ProfilePic = item.tbl_Pic.Pic_Url,
                    User_Name = item.Name + " " + item.Lname,
                    Top = MemberListItemTop,
                    Left = 0,
                    LastSeen = Rep_PrivateChat.UserLastSeen(item.id),
                    User_id = item.id
                };
                MemberListItem.Click += MemberItemClicked;
                MemberListItem.RemoveLinkClicked += RemoveMemberClicked;
                PanelMembers.Controls.Add(MemberListItem);
            }
        }
        private void RemoveMemberClicked(object sender, EventArgs e)
        {
            if (AdvanceMethod.AdvanceMessageBox("Are you sure to delete this user from group ?") == DialogResult.OK)
            {
                var Member = ((BanUsersListItem)sender);
                Rep_Groups.DeleteGroupMember(Group_id, Member.User_id);
                PanelMembers.Controls.Remove(Member);
                foreach (Control item in PanelMembers.Controls)
                    if (item.GetType().Name == "BanUsersListItem")
                        PanelMembers.Controls.Remove(item);
                ((Frm_Chats)this.Owner).lblLastSeenOrMemberCount.Text = Rep_Groups.GetGroupMemberCount(Group_id).ToString();
                Frm_GroupInfo_Load(null, null);
            }
        }
        private void MemberItemClicked(object sender, EventArgs e)
        {
            BanUsersListItem Member = (BanUsersListItem)sender;
            Frm_UserInfo.User_id = Member.User_id;
            new Frm_UserInfo().ShowDialog(this);
        }
        private int MemberListItemTop
        {
            get
            {
                if (PanelMembers.Controls.Count == 3 && materialFlatButton3.Visible == false)
                    return 0;
                else
                    return PanelMembers.Controls[PanelMembers.Controls.Count - 1].Bottom;
            }
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            Channels.Frm_ManageAdministrator.ChatType = Components.ComponentsProperties.ChatType.Group;
            Channels.Frm_ManageAdministrator.Chat_id = Group_id;
            new Channels.Frm_ManageAdministrator().ShowDialog();
        }
        private void ColorChanging(object sender, MouseEventArgs e)
        {
            foreach (Control item in PanelMembers.Controls)
            {
                if (item.GetType().Name == "BanUsersListItem")
                {
                    var member = (Components.BanUsersListItem)(item);
                    if (e.X >= item.Location.X || e.Y > item.Location.Y)
                    {
                        item.BackColor = Color.White;
                        if (member.RemoveVisible)
                            member.RemoveLinkVisible = false;
                    }
                }
            }
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            Groups.Frm_ManageBanUsers.Chat_id = Group_id;
            new Groups.Frm_ManageBanUsers().ShowDialog(this);
        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            Channels.Frm_AddMember.ChatType = ComponentsProperties.ChatType.Group;
            Channels.Frm_AddMember.Chat_id = Group_id;
            new Channels.Frm_AddMember().ShowDialog(this);
            Frm_GroupInfo_Load(null, null);
        }

        private void PanelMembers_ControlRemoved(object sender, ControlEventArgs e)
        {
            lbl_MemberCount.Text = Rep_Groups.GetGroupMemberCount(Group_id).ToString();
        }

        private void Profile_Pic_Click(object sender, EventArgs e)
        {
            Pics.Frm_ShowProfilesPics.ChatType = ComponentsProperties.ChatType.Group;
            Pics.Frm_ShowProfilesPics.Chat_id = Group_id;
            new Pics.Frm_ShowProfilesPics().ShowDialog(this);
        }

        private void materialFlatButton4_Click(object sender, EventArgs e)
        {
            if (AdvanceMethod.AdvanceMessageBox("are you sure to left the group?") == DialogResult.OK)
                if (Rep_Groups.IsGroupAdmin(Frm_Chats.User_id, Group_id))
                {
                    if (Rep_Groups.GetAdminPrometer(Group_id, Frm_Chats.User_id) == "Creator")
                    {
                        foreach (var item in Rep_Groups.GetGroupAdminList(Group_id))
                            Rep_Groups.DeleteGroupAdmin(item.id);
                        foreach (var item in Rep_Groups.GetGroupMember(Group_id))
                            Rep_Groups.DeleteGroupMember(Group_id, item.id);
                        Rep_Groups.DeleteGroup(Group_id);
                        Frm_Chats Frm;
                        Frm = (Frm_Chats)this.Owner;
                        Frm.UpdateChatList();
                        this.Close();
                    }
                    else
                    {
                        Rep_Groups.DeleteGroupAdmin(Group_id, Frm_Chats.User_id);
                        Rep_Groups.DeleteGroupMember(Group_id, Frm_Chats.User_id);
                        Frm_Chats Frm;
                        Frm = (Frm_Chats)this.Owner;
                        Frm.UpdateChatList();
                        this.Close();
                    }
                }
                else
                {
                    Rep_Groups.DeleteGroupMember(Group_id, Frm_Chats.User_id);
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
