using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components
{
    public class ComponentsProperties
    {
        public enum ChatType
        {
            None,
            Group,
            Channel,
            PrivateChat
        }
        public enum MessageType
        {
            PhotoMessage,
            TextMessage,
            NoMessage
        }
        public enum MessageMode
        {
            incoming,
            outing
        }
        public enum LastSeenPrivacy
        {
            Evrybody,
            Nobody,
            MyContact
        }
        public enum LastSeen
        {
            recently,
            inaweak,
            inamonth,
            other
        }
    }
    public class AdminPermisions
    {
        public bool CanEditMessages { get; set; }
        public bool CanDeleteMessages { get; set; }
        public bool CanPinMessages { get; set; }
        public bool CanBanUser { get; set; }
        public bool ShowMenu
        {
            get
            {
                if (!CanDeleteMessages && !CanEditMessages && !CanPinMessages)
                    return false;
                else
                    return true;
            }
        }
    }
}
