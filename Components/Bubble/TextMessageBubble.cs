using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Components.Bubble
{
    public partial class TextMessageBubble : UserControl
    {
        public TextMessageBubble()
        {
            InitializeComponent();
            ChatType = ComponentsProperties.ChatType.Channel;
            if (MessageMode == ComponentsProperties.MessageMode.incoming || ChatType == ComponentsProperties.ChatType.Channel)
            {
                this.BackColor = IncomingColor;
                IsSeen.Visible = false;
                lblTime.Left = IsSeen.Left - 15;
            }
            else
            {
                IsSeen.Visible = true;
                lblTime.Left = lblTime.Left - IsSeen.Width - 10;
                this.BackColor = OutingColor;
            }
            if (ChatType == ComponentsProperties.ChatType.Channel)
            {
                pic_Seen.Top = lblSeen.Top = lblTime.Top;
                lblSeen.Visible = true;
                pic_Seen.Visible = true;
            }
            SetHeight();
        }
        public TextMessageBubble(string Message, string _Time, string _From)
        {
            lblTime.Text = _Time;
            lblFrom.Text = _From;
            txtMessages.Text = Message;
            if (ChatType == ComponentsProperties.ChatType.PrivateChat || MessageMode == ComponentsProperties.MessageMode.outing)
                lblFrom.Visible = false;
            if (MessageMode == ComponentsProperties.MessageMode.incoming)
            {
                this.BackColor = IncomingColor;
                IsSeen.Visible = false;
                lblTime.Left = IsSeen.Left - 20;
            }
            else
            {
                IsSeen.Visible = true;
                lblTime.Left = lblTime.Left - IsSeen.Width - 5;
                this.BackColor = OutingColor;
            }
            if (ChatType == ComponentsProperties.ChatType.Channel)
            {
                lblSeen.Visible = true;
                pic_Seen.Visible = true;
            }
            SetHeight();
        }
        #region TextMessageBubble Properties
        public ChatControl ParentChatControl { get; set; }

        private static bool _isForward = false;
        public bool IsForward
        {
            get { return _isForward; }
            set
            {
                if (value)
                    lblFrom.Text = "Forward From " + lblFrom.Text;
                else
                    lblFrom.Text = lblFrom.Text.Replace("Forward From ", "");
                _isForward = value;
            }
        }
        private static bool _isEdit = false;
        public bool IsEdit
        {
            get { return _isEdit; }
            set
            {
                _isEdit = value;
                if (value)
                {
                    if (ChatType == ComponentsProperties.ChatType.Channel)
                    {
                        lblSeen.Left -= 39;
                        pic_Seen.Left -= 39;
                        lblTime.Left -= 39;
                        lblTime.Text = "Edited  " + lblTime.Text;
                    }
                    else
                    {
                        lblTime.Text = "Edited  " + lblTime.Text;
                        lblSeen.Visible = false;
                        pic_Seen.Visible = false;
                        lblTime.Left -= 39;
                    }
                }
                else
                {
                    if (ChatType == ComponentsProperties.ChatType.Channel)
                    {
                        lblTime.Text = lblTime.Text.Replace("Edited  ", "");
                        lblSeen.Left += 39;
                        pic_Seen.Left += 39;
                        lblTime.Left += 39;
                    }
                    else
                    {
                        lblTime.Text = lblTime.Text.Replace("Edited  ", "");
                        lblTime.Left += 39;
                        lblSeen.Visible = false;
                        pic_Seen.Visible = false;
                    }
                }
            }
        }
        private static long _seenCount = 0;
        public long SeenCount
        {
            get { return _seenCount; }
            set
            {
                _seenCount = value;
                lblSeen.Text = value.ToString();
                lblSeen.Left = lblTime.Left - lblSeen.Width;
                pic_Seen.Left = lblSeen.Left - pic_Seen.Width;
            }
        }
        public long Message_id { get; set; }
        private ComponentsProperties.ChatType _chatType = ComponentsProperties.ChatType.PrivateChat;
        public ComponentsProperties.ChatType ChatType
        {
            get { return _chatType; }
            set
            {
                if (value == ComponentsProperties.ChatType.Channel)
                {
                    this.BackColor = IncomingColor;
                    IsSeen.Visible = false;
                    lblTime.Left = IsSeen.Left - 20;
                    lblSeen.Visible = true;
                    pic_Seen.Visible = true;
                    SeenCount = 1;
                }
                else
                {
                    lblSeen.Visible = false;
                    pic_Seen.Visible = false;
                    IsSeen.Visible = true;
                    if (_isseen)
                        IsSeen.Image = global::Components.Properties.Resources.double_tick;
                    else
                        IsSeen.Image = global::Components.Properties.Resources.single_tick;
                    lblTime.Left = this.Width - lblTime.Width - IsSeen.Width - 5;
                    this.BackColor = OutingColor;
                }
                if (value == ComponentsProperties.ChatType.PrivateChat)
                {
                    lblFrom.Visible = false;
                    lblTime.Left = this.Width - lblTime.Width - IsSeen.Width - 5;
                }
                else
                    lblFrom.Visible = true;
                _chatType = value;
            }
        }
        private static ComponentsProperties.MessageMode _MessageMode;
        public ComponentsProperties.MessageMode MessageMode
        {
            get { return _MessageMode; }
            set
            {
                if (value == ComponentsProperties.MessageMode.incoming)
                {
                    this.BackColor = IncomingColor;
                    IsSeen.Visible = false;
                    lblTime.Left = IsSeen.Left - 20;
                }
                else
                {
                    IsSeen.Visible = true;
                    lblTime.Left = lblTime.Left - IsSeen.Width - 5;
                    this.BackColor = OutingColor;
                }
                _MessageMode = value;
            }
        }
        public string MessageText { get { return txtMessages.Text; } set { txtMessages.Rtf = value; SetHeight(); } }
        public string Time { get { return lblTime.Text; } set { lblTime.Text = value; } }
        public string From
        {
            get { return lblFrom.Text; }
            set
            {
                lblFrom.Text = value;
                if (IsForward)
                    lblFrom.Text = "Forward From " + lblFrom.Text;
            }
        }
        public Color IncomingColor
        {
            get { return this.BackColor; }
            set
            {
                if (MessageMode == ComponentsProperties.MessageMode.incoming)
                {
                    txtMessages.BackColor = value;
                    IsSeen.BackColor = value;
                    lblTime.BackColor = value;
                    lblFrom.BackColor = value;
                    this.BackColor = value;
                }
            }
        }
        public Color OutingColor
        {
            get { return this.BackColor; }
            set
            {
                if (MessageMode == ComponentsProperties.MessageMode.outing)
                {
                    txtMessages.BackColor = value;
                    IsSeen.BackColor = value;
                    lblTime.BackColor = value;
                    lblFrom.BackColor = value;
                    this.BackColor = value;
                }
            }
        }
        static private bool _isseen = true;
        public bool isseen
        {
            get { return _isseen; }
            set
            {
                if (value == true)
                    IsSeen.Image = global::Components.Properties.Resources.double_tick;
                else
                    IsSeen.Image = global::Components.Properties.Resources.single_tick;
                _isseen = value;
            }
        }
        #endregion

        private void SetHeight()
        {
            var size = TextRenderer.MeasureText(txtMessages.Text, txtMessages.Font, txtMessages.Size, TextFormatFlags.WordBreak);
            txtMessages.Height = size.Height+2;
            this.Height = txtMessages.Bottom + lblTime.Height + 12;
        }

        private void TextMessageBubble_Resize(object sender, EventArgs e)
        {
            SetHeight();
        }
        public void SetMouseDownEvent()
        {
            foreach (Control item in this.Controls)
                item.MouseDown += ParentChatControl.BubbleMouseDown;
        }
    }
}
