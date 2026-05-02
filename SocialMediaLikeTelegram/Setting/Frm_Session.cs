using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialMediaLikeTelegram.Setting
{
    public partial class Frm_Session : Form
    {
        public Frm_Session()
        {
            InitializeComponent();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private int SessionListItemTop
        {
            get
            {
                if (panel2.Controls.Count > 0)
                    return panel2.Controls[panel2.Controls.Count - 1].Bottom;
                else
                    return 0;
            }
        }
        private void Frm_Session_Load(object sender, EventArgs e)
        {
            var Code = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\SocialMediaLikeTelegram", "Session", null);
            var Q = Models.Repository.Rep_Users.GetSession(Code.ToString());
            sessionListItem1.OS = Q.OS;
            sessionListItem1.IP = Q.IP;
            sessionListItem1.Date = Q.Date;
            sessionListItem1.Time = Q.Time;
            var Q1 = Models.Repository.Rep_Users.GetAllSession(Frm_Chats.User_id);
            Q1.Remove(Q);
            foreach (var item in Q1)
            {
                if (item.Code != sessionListItem1.Session_Code)
                {
                    Components.SessionListItem _sessionlistitem = new Components.SessionListItem();
                    _sessionlistitem.OS = item.OS;
                    _sessionlistitem.Date = item.Date;
                    _sessionlistitem.Time = item.Time;
                    _sessionlistitem.Session_Code = item.Code;
                    _sessionlistitem.IP = item.IP;
                    _sessionlistitem.Top = SessionListItemTop;
                    _sessionlistitem.DeleteSessionClicked += DeleteSession;
                    panel2.Controls.Add(_sessionlistitem);
                }
            }
        }
        private void DeleteSession(object sender, EventArgs e)
        {
            var Session = (Components.SessionListItem)sender;
            if (AdvanceMethod.AdvanceMessageBox("Are you sure to remove this session ?") == DialogResult.OK)
            {
                Models.Repository.Rep_Users.DeleteSession(Session.Session_Code);
                foreach (Control item in panel2.Controls)
                    panel2.Controls.Remove(item);
                if (panel2.Controls.Count > 0)
                    panel2.Controls.RemoveAt(0);
                Frm_Session_Load(null, null);
            }
        }
    }
}
