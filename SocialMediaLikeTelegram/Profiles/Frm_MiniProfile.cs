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
    public partial class Frm_MiniProfile : Form
    {
        public static Components.ComponentsProperties.ChatType ChatType = Components.ComponentsProperties.ChatType.Channel;
        public static long Chat_id = 0;
        public Frm_MiniProfile()
        {
            InitializeComponent();
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_MiniProfile_Load(object sender, EventArgs e)
        {
            if(ChatType==Components.ComponentsProperties.ChatType.Channel)
            {
                lbl_member_Count.Text = Rep_Channels.GetChannelMemberCount(Chat_id).ToString("n0");
                lbl_name.Text = Rep_Channels.GetChannelName(Chat_id);
                pictureBox1.ImageLocation = Rep_Channels.GetChannelInfo(Chat_id).tbl_Pic.Pic_Url;
            }
            else
            {
                lbl_member_Count.Text = Rep_Groups.GetGroupMemberCount(Chat_id).ToString("n0");
                lbl_name.Text = Rep_Groups.GetGroupName(Chat_id);
                pictureBox1.ImageLocation = Rep_Groups.GetGroupInfo(Chat_id).tbl_Pic.Pic_Url;
            }
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            if (ChatType == Components.ComponentsProperties.ChatType.Channel)
                Rep_Channels.AddChannelMember(Frm_Chats.User_id, Chat_id);
            else
                Rep_Groups.AddGroupMember(Frm_Chats.User_id, Chat_id);
            Frm_Chats Frm = (Frm_Chats)this.Owner;
            Frm.UpdateChatList();
            this.Close();
        }
    }
}
