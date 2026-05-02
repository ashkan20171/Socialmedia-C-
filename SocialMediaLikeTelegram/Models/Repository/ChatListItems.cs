using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaLikeTelegram.Models.Repository
{
    class ChatListItems
    {
        public long Chat_id { get; set; }
        public string ChatName { get; set; }
        public Components.ComponentsProperties.ChatType ChatType { get; set; }
        public Components.ComponentsProperties.MessageType LastMessageType { get; set; }
        public Components.ComponentsProperties.MessageMode LastMessageMode { get; set; }
        public tbl_Message LastMessage { get; set; }
        public tbl_Users LastMessageSender { get; set; }
        public Image ProfilePic { get; set; }
        public int BadgeCount { get; set; }
        public bool IsResive { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minuts { get; set; }
    }
    class IdFinderResult
    {
        public long Chat_id { get; set; }
        public Components.ComponentsProperties.ChatType ChatType { get; set; }
    }
    class NotificationResult
    {
        public tbl_Message Message { get; set; }
        public Components.ComponentsProperties.ChatType ChatType { get; set; }
        public tbl_Channels tbl_Channel { get; set; }
        public tbl_Groups tbl_Group { get; set; }
        public tbl_PrivateChat tbl_PrivateChat { get; set; }
    }
}
