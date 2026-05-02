using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Components.Bubble;

namespace Components
{
    public partial class ChatControl : UserControl
    {
        public ChatControl()
        {
            InitializeComponent();
        }
        private int MessagesTop
        {
            get
            {
                if (this.Controls.Count == 0)
                    return 5;
                else
                    return this.Controls[this.Controls.Count - 1].Bottom + 10;
            }
        }
        #region ChatControl Properties
        public long Chat_id { get; set; }
        public ComponentsProperties.ChatType ChatType { get; set; }
        public bool CanSendMessage { get; set; }
        public string SendTextBoxWatermark { get; set; }
        public Control TargetControlRightClick { get; set; }
        public MaterialSkin.Controls.MaterialContextMenuStrip BubblesContextMenuStrip { get; set; }
        public AdminPermisions AdminPermision { get; set; }
        #endregion
        public string PhotoBubblePicUrl { get; set; }
        public event EventHandler PhotoBubbleClicked;
        private void TT(object sender,EventArgs e)
        {
            var Q = ((PhotoMessageBubble)sender);
            PhotoBubblePicUrl = Q.Picc;
            if (PhotoBubbleClicked != null)
                PhotoBubbleClicked(sender, e);
        }
        public void SendMessage(ComponentsProperties.MessageType MessageType, ComponentsProperties.MessageMode MessageMode, string Text, string PicPath, bool IsEdited, string Time, string Date, long Message_id, string From, bool IsRecive, int SeenCount)
        {
            if (MessageType == ComponentsProperties.MessageType.PhotoMessage)
            {
                if (ChatType == ComponentsProperties.ChatType.Channel)
                {
                    Bubble.PhotoMessageBubble _photomessage = new Bubble.PhotoMessageBubble();
                    _photomessage.Pic = PicPath;
                    _photomessage.PhotoCaption = Text;
                    _photomessage.ChatType = ComponentsProperties.ChatType.Channel;
                    _photomessage.IsEdited = IsEdited;
                    _photomessage.MessageMode = ComponentsProperties.MessageMode.incoming;
                    _photomessage.Message_id = Message_id;
                    _photomessage.IncommingColor = Color.White;
                    _photomessage.From = From;
                    _photomessage.SeenCount = SeenCount;
                    _photomessage.Time = Time;
                    _photomessage.Top = MessagesTop;
                    _photomessage.Left = 5;
                    _photomessage.PhotoClicked += TT;
                    if (AdminPermision.ShowMenu)
                    {
                        _photomessage.MouseDown += BubbleMouseDown;
                        _photomessage.ParentChatControl = this;
                        _photomessage.SetMouseDownEvent();
                    }
                    this.Controls.Add(_photomessage);
                }
                else if (ChatType == ComponentsProperties.ChatType.Group)
                {
                    if (MessageMode == ComponentsProperties.MessageMode.incoming)
                    {
                        Bubble.PhotoMessageBubble _photomessage = new Bubble.PhotoMessageBubble();
                        _photomessage.Pic = PicPath;
                        _photomessage.PhotoCaption = Text;
                        _photomessage.ChatType = ComponentsProperties.ChatType.Group;
                        _photomessage.IsEdited = IsEdited;
                        _photomessage.MessageMode = ComponentsProperties.MessageMode.incoming;
                        _photomessage.Message_id = Message_id;
                        _photomessage.IncommingColor = Color.White;
                        _photomessage.From = From;
                        _photomessage.Time = Time;
                        _photomessage.Top = MessagesTop;
                        _photomessage.Left = 5;
                        _photomessage.PhotoClicked += TT;
                        if (AdminPermision.ShowMenu)
                        {
                            _photomessage.MouseDown += BubbleMouseDown;
                            _photomessage.ParentChatControl = this;
                            _photomessage.SetMouseDownEvent();
                        }
                        this.Controls.Add(_photomessage);
                    }
                    else
                    {
                        Bubble.PhotoMessageBubble _photomessage = new Bubble.PhotoMessageBubble();
                        _photomessage.Pic = PicPath;
                        _photomessage.PhotoCaption = Text;
                        _photomessage.MessageMode = ComponentsProperties.MessageMode.outing;
                        _photomessage.ChatType = ComponentsProperties.ChatType.Group;
                        _photomessage.IsEdited = IsEdited;
                        _photomessage.Message_id = Message_id;
                        _photomessage.OutingColor = Color.FromArgb(239, 253, 222);
                        _photomessage.isSeen = IsRecive;
                        _photomessage.From = "";
                        _photomessage.Time = Time;
                        _photomessage.Top = MessagesTop;
                        _photomessage.MouseDown += BubbleMouseDown;
                        _photomessage.ParentChatControl = this;
                        _photomessage.PhotoClicked += TT;
                        _photomessage.SetMouseDownEvent();
                        _photomessage.Left = this.Width - _photomessage.Width - 18;
                        this.Controls.Add(_photomessage);
                    }
                }
                else if (ChatType == ComponentsProperties.ChatType.PrivateChat)
                {
                    if (MessageMode == ComponentsProperties.MessageMode.incoming)
                    {
                        Bubble.PhotoMessageBubble _photomessage = new Bubble.PhotoMessageBubble();
                        _photomessage.Pic = PicPath;
                        _photomessage.PhotoCaption = Text;
                        _photomessage.ChatType = ComponentsProperties.ChatType.PrivateChat;
                        _photomessage.IsEdited = IsEdited;
                        _photomessage.MessageMode = ComponentsProperties.MessageMode.incoming;
                        _photomessage.Message_id = Message_id;
                        _photomessage.IncommingColor = Color.White;
                        _photomessage.From = "";
                        _photomessage.Time = Time;
                        _photomessage.Top = MessagesTop;
                        _photomessage.Left = 5;
                        _photomessage.PhotoClicked += TT;
                        this.Controls.Add(_photomessage);
                    }
                    else
                    {
                        Bubble.PhotoMessageBubble _photomessage = new Bubble.PhotoMessageBubble();
                        _photomessage.Pic = PicPath;
                        _photomessage.PhotoCaption = Text;
                        _photomessage.MessageMode = ComponentsProperties.MessageMode.outing;
                        _photomessage.ChatType = ComponentsProperties.ChatType.PrivateChat;
                        _photomessage.IsEdited = IsEdited;
                        _photomessage.Message_id = Message_id;
                        _photomessage.OutingColor = Color.FromArgb(239, 253, 222);
                        _photomessage.isSeen = IsRecive;
                        _photomessage.From = "";
                        _photomessage.Time = Time;
                        _photomessage.Top = MessagesTop;
                        _photomessage.MouseDown += BubbleMouseDown;
                        _photomessage.ParentChatControl = this;
                        _photomessage.SetMouseDownEvent();
                        _photomessage.PhotoClicked += TT;
                        _photomessage.Left = this.Width - _photomessage.Width - 18;
                        this.Controls.Add(_photomessage);
                    }
                }
            }
            else if (MessageType == ComponentsProperties.MessageType.TextMessage)
            {
                if (ChatType == ComponentsProperties.ChatType.Channel)
                {
                    Bubble.TextMessageBubble _textmessage = new Bubble.TextMessageBubble();
                    _textmessage.MessageText = Text;
                    _textmessage.Time = Time;
                    _textmessage.IsEdit = IsEdited;
                    _textmessage.ChatType = ComponentsProperties.ChatType.Channel;
                    _textmessage.MessageMode = ComponentsProperties.MessageMode.incoming;
                    _textmessage.IncomingColor = Color.White;
                    _textmessage.Message_id = Message_id;
                    _textmessage.From = From;
                    _textmessage.SeenCount = SeenCount;
                    _textmessage.Top = MessagesTop;
                    if (AdminPermision.ShowMenu)
                    {
                        _textmessage.MouseDown += BubbleMouseDown;
                        _textmessage.ParentChatControl = this;
                        _textmessage.SetMouseDownEvent();
                    }
                    _textmessage.Left = 5;
                    this.Controls.Add(_textmessage);
                }
                else if (ChatType == ComponentsProperties.ChatType.Group)
                {
                    if (MessageMode == ComponentsProperties.MessageMode.incoming)
                    {
                        Bubble.TextMessageBubble _textmessage = new Bubble.TextMessageBubble();
                        _textmessage.MessageText = Text;
                        _textmessage.Time = Time;
                        _textmessage.IsEdit = IsEdited;
                        _textmessage.ChatType = ComponentsProperties.ChatType.Group;
                        _textmessage.MessageMode = ComponentsProperties.MessageMode.incoming;
                        _textmessage.IncomingColor = Color.White;
                        _textmessage.Message_id = Message_id;
                        _textmessage.From = From;
                        _textmessage.Top = MessagesTop;
                        _textmessage.Left = 5;
                        if (AdminPermision.ShowMenu)
                        {
                            _textmessage.MouseDown += BubbleMouseDown;
                            _textmessage.ParentChatControl = this;
                            _textmessage.SetMouseDownEvent();
                        }
                        this.Controls.Add(_textmessage);
                    }
                    else
                    {
                        Bubble.TextMessageBubble _textmessage = new Bubble.TextMessageBubble();
                        _textmessage.MessageText = Text;
                        _textmessage.Time = Time;
                        _textmessage.IsEdit = IsEdited;
                        _textmessage.Message_id = Message_id;
                        _textmessage.isseen = IsRecive;
                        _textmessage.Top = MessagesTop;
                        _textmessage.From = "";
                        _textmessage.MessageMode = ComponentsProperties.MessageMode.outing;
                        _textmessage.ChatType = ComponentsProperties.ChatType.Group;
                        _textmessage.OutingColor = Color.FromArgb(239, 253, 222);
                        _textmessage.MouseDown += BubbleMouseDown;
                        _textmessage.ParentChatControl = this;
                        _textmessage.SetMouseDownEvent();
                        _textmessage.Left = this.Width - _textmessage.Width - 18;
                        this.Controls.Add(_textmessage);
                    }
                }
                else if (ChatType == ComponentsProperties.ChatType.PrivateChat)
                {
                    if (MessageMode == ComponentsProperties.MessageMode.incoming)
                    {
                        Bubble.TextMessageBubble _textmessage = new Bubble.TextMessageBubble();
                        _textmessage.MessageText = Text;
                        _textmessage.Time = Time;
                        _textmessage.IsEdit = IsEdited;
                        _textmessage.ChatType = ComponentsProperties.ChatType.PrivateChat;
                        _textmessage.MessageMode = ComponentsProperties.MessageMode.incoming;
                        _textmessage.IncomingColor = Color.White;
                        _textmessage.Message_id = Message_id;
                        _textmessage.From = "";
                        _textmessage.Top = MessagesTop;
                        _textmessage.Left = 5;
                        this.Controls.Add(_textmessage);
                    }
                    else
                    {
                        Bubble.TextMessageBubble _textmessage = new Bubble.TextMessageBubble();
                        _textmessage.MessageText = Text;
                        _textmessage.Time = Time;
                        _textmessage.IsEdit = IsEdited;
                        _textmessage.Message_id = Message_id;
                        _textmessage.isseen = IsRecive;
                        _textmessage.Top = MessagesTop;
                        _textmessage.From = "";
                        _textmessage.MessageMode = ComponentsProperties.MessageMode.outing;
                        _textmessage.ChatType = ComponentsProperties.ChatType.PrivateChat;
                        _textmessage.OutingColor = Color.FromArgb(239, 253, 222);
                        _textmessage.MouseDown += BubbleMouseDown;
                        _textmessage.ParentChatControl = this;
                        _textmessage.SetMouseDownEvent();
                        _textmessage.Left = this.Width - _textmessage.Width - 18;
                        this.Controls.Add(_textmessage);
                    }
                }
            }
        }

        public void RemoveAllMessages()
        {
            int a = this.Controls.Count;
            if (a > 0)
                for (int i = 0; i <= a - 1; i++)
                {
                    var Q = this.Controls[0];
                    this.Controls.Remove(Q);
                }
        }
        public void BubbleMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Control SenderControl = (Control)(sender);
                if (SenderControl.GetType().Name.Contains("Bubble"))
                    TargetControlRightClick = SenderControl;
                else
                    TargetControlRightClick = SenderControl.Parent;
                BubblesContextMenuStrip.Show(SenderControl, e.Location);
            }
        }
    }
}
