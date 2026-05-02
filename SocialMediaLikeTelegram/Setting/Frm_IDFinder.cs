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

namespace SocialMediaLikeTelegram.Setting
{
    public partial class Frm_IDFinder : Form
    {
        public Frm_IDFinder()
        {
            InitializeComponent();
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(bunifuMaterialTextbox1.Text))
            {
                var Result = Rep_Chats.FindId(bunifuMaterialTextbox1.Text);
                if (Result.ChatType == Components.ComponentsProperties.ChatType.Channel)
                {
                    if (Rep_Channels.IsChannelMember(Result.Chat_id, Frm_Chats.User_id))
                    {
                        Profiles.Frm_ChannelInfo.Channel_id = Result.Chat_id;
                        new Profiles.Frm_ChannelInfo().ShowDialog(this.Owner);
                    }
                    else
                    {
                        Profiles.Frm_MiniProfile.Chat_id = Result.Chat_id;
                        Profiles.Frm_MiniProfile.ChatType = Components.ComponentsProperties.ChatType.Channel;
                        new Profiles.Frm_MiniProfile().ShowDialog(this.Owner);
                    }
                }
                else if (Result.ChatType == Components.ComponentsProperties.ChatType.Group)
                {
                    if (Rep_Groups.IsGroupMember(Result.Chat_id, Frm_Chats.User_id))
                    {
                        Profiles.Frm_GroupInfo.Group_id = Result.Chat_id;
                        new Profiles.Frm_GroupInfo().ShowDialog(this.Owner);
                    }
                    else
                    {
                        Profiles.Frm_MiniProfile.Chat_id = Result.Chat_id;
                        Profiles.Frm_MiniProfile.ChatType = Components.ComponentsProperties.ChatType.Group;
                        new Profiles.Frm_MiniProfile().ShowDialog(this.Owner);
                    }
                }
                else if (Result.ChatType == Components.ComponentsProperties.ChatType.PrivateChat)
                {
                    Profiles.Frm_UserInfo.User_id = Result.Chat_id;
                    new Profiles.Frm_UserInfo().ShowDialog(this.Owner);
                }
                else
                    AdvanceMethod.AdvanceMessageBox("your username or invite link not found!");
            }
            else
                AdvanceMethod.AdvanceMessageBox("please enter username or Invite link");
        }
    }
}
