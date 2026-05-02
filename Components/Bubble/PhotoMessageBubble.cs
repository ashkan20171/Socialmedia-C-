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
    public partial class PhotoMessageBubble : UserControl
    {
        public PhotoMessageBubble()
        {
            InitializeComponent();
            SetHeight();
            isSeen = false;
            ChatType = ComponentsProperties.ChatType.Channel;
        }
        public PhotoMessageBubble(string _Caption, string _Pic, string _From, string _Time)
        {
            InitializeComponent();
            From = _From;
            PhotoCaption = _Caption;
            Time = _Time;
            Pic = _Pic;
            isSeen = false;
            if (MessageMode == ComponentsProperties.MessageMode.incoming || ChatType == ComponentsProperties.ChatType.Channel)
            {
                this.BackColor = IncommingColor;
                IsSeen.Visible = false;
                lblTime.Left = IsSeen.Left;
            }
            else
            {
                this.BackColor = OutingColor;
                IsSeen.Visible = true;
                lblTime.Left = lblTime.Left - IsSeen.Width;
            }
        }
        #region PhotoMessageBubbleProperties
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
        public bool IsEdited
        {
            get { return _isEdit; }
            set
            {
                _isEdit = value;
                if (value)
                {
                    if (ChatType == ComponentsProperties.ChatType.Channel)
                    {
                        lblTime.Text = "Edited  " + lblTime.Text;
                        lblSeen.Left -= 39;
                        pic_Seen.Left -= 39;
                        lblTime.Left -= 39;
                    }
                    else
                    {
                        lblTime.Text = "Edited  " + lblTime.Text;
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
                    }
                }
            }
        }
        private static long _seenCount = 1;
        public long SeenCount
        {
            get { return _seenCount; }
            set
            {
                _seenCount = value;
                if (ChatType == ComponentsProperties.ChatType.Channel)
                {
                    lblSeen.Visible = true;
                    pic_Seen.Visible = true;
                    lblSeen.Text = value.ToString();
                    lblSeen.Left = lblTime.Left - lblSeen.Width;
                    pic_Seen.Left = lblSeen.Left - pic_Seen.Width;
                    pic_Seen.Top = lblSeen.Top = lblTime.Top;
                }
                else
                {
                    lblSeen.Visible = false;
                    pic_Seen.Visible = false;
                }
            }
        }
        private static ComponentsProperties.ChatType _chatType = 0;
        public long Message_id { get; set; }
        public ComponentsProperties.ChatType ChatType
        {
            get { return _chatType; }
            set
            {
                _chatType = value;
                if (value == ComponentsProperties.ChatType.Channel)
                {
                    IsSeen.Visible = false;
                    lblTime.Left = this.Width - lblTime.Width;
                    lblSeen.Visible = true;
                    pic_Seen.Visible = true;
                    SeenCount = 1;
                }
                else
                {
                    lblSeen.Visible = false;
                    pic_Seen.Visible = false;
                    IsSeen.Visible = true;
                    lblTime.Left = lblTime.Left - IsSeen.Width;
                }
                if (ChatType == ComponentsProperties.ChatType.PrivateChat)
                    lblFrom.Visible = false;
                else
                    lblFrom.Visible = true;
            }
        }
        public string Picc { get { return pic.ImageLocation; } }
        private static ComponentsProperties.MessageMode _messageMode = 0;
        public ComponentsProperties.MessageMode MessageMode
        {
            get { return _messageMode; }
            set
            {
                if (value == ComponentsProperties.MessageMode.incoming)
                {
                    this.BackColor = IncommingColor;
                    IsSeen.Visible = false;
                    lblTime.Left = IsSeen.Left;
                }
                else
                {
                    this.BackColor = OutingColor;
                    IsSeen.Visible = true;
                    lblTime.Left = lblTime.Left - IsSeen.Width;
                }
                _messageMode = value;
            }
        }
        public string PhotoCaption
        {
            get { return txt_Caption.Text; }
            set
            {
                txt_Caption.Rtf = value;
                SetHeight();
            }
        }
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
        public string Time
        {
            get { return lblTime.Text; }
            set
            {
                lblTime.Text = value;
                if (ChatType == ComponentsProperties.ChatType.Channel)
                {
                    lblTime.Left = this.Width - lblTime.Width - 1;
                    lblSeen.Left = this.Width - lblTime.Width - lblSeen.Width - 3;
                    pic_Seen.Left = lblSeen.Left - lblSeen.Width - 5;
                }
                else
                {
                    IsSeen.Left = this.Width - IsSeen.Width - 3;
                    lblTime.Left = this.Width - IsSeen.Width - lblTime.Width - 5;
                }
            }
        }
        private static string _Pic = @"G:\C# Project\SocialMediaLikeTelegram\SocialMediaLikeTelegram\bin\Debug\fake.png";
        public string Pic { get { return _Pic; } set { _Pic = value; } }
        private Color _incommingColor;
        public Color IncommingColor
        {
            get { return _incommingColor; }
            set
            {
                _incommingColor = value;
                if (MessageMode == ComponentsProperties.MessageMode.incoming)
                {
                    this.BackColor = value;
                    pic.BackColor = value;
                    txt_Caption.BackColor = value;
                    lblFrom.BackColor = value;
                    lblTime.BackColor = value;
                }
            }
        }
        private Color _outingColor;
        public Color OutingColor
        {
            get { return _outingColor; }
            set
            {
                _outingColor = value;
                if (MessageMode == ComponentsProperties.MessageMode.outing)
                {
                    this.BackColor = value;
                    pic.BackColor = value;
                    txt_Caption.BackColor = value;
                    lblFrom.BackColor = value;
                    lblTime.BackColor = value;
                }
            }
        }
        private static bool _isSeen = false;
        public bool isSeen
        {
            get
            {
                return _isSeen;
            }
            set
            {
                _isSeen = value;
                if (value)
                    IsSeen.Image = global::Components.Properties.Resources.double_tick;
                else
                    IsSeen.Image = global::Components.Properties.Resources.single_tick;
            }
        }
        #endregion
        public event EventHandler PhotoClicked;
        private void SetHeight()
        {
            var _Pic = Image.FromFile(Pic);
            var ratioX = (double)pic.Width / _Pic.Width;
            var ratioY = (double)pic.Height / _Pic.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(_Pic.Width * ratio);
            var newHeight = (int)(_Pic.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphic = Graphics.FromImage(newImage))
                graphic.DrawImage(_Pic, 0, 0, newWidth, newHeight);
            string Name = Guid.NewGuid().ToString().Replace("-", "");
            if (!System.IO.Directory.Exists(@"C://Telegram Temps"))
                System.IO.Directory.CreateDirectory(@"C://Telegram Temps");
            newImage.Save(@"C:/Telegram Temps/" + Name + ".png", System.Drawing.Imaging.ImageFormat.Png);
            string Tumb_Pic = @"C:/Telegram Temps/" + Name + ".png";
            pic.ImageLocation = Tumb_Pic;
            pic.Height = newHeight;
            txt_Caption.Top = pic.Bottom + 8;
            /////////////////////////
            this.Width = newWidth;
            txt_Caption.Size = new Size(newWidth - 6, txt_Caption.Height);
            txt_Caption.Left = 3;
            /////////////////////////
            var size = TextRenderer.MeasureText(txt_Caption.Text, txt_Caption.Font, txt_Caption.Size, TextFormatFlags.WordBreak);
            txt_Caption.Height = size.Height+10;
            ////////////////////////
            this.Height = lblFrom.Bottom + newHeight + txt_Caption.Height + lblTime.Height + 20;
        }

        private void PhotoMessageBubble_Load(object sender, EventArgs e)
        {

        }
        public void SetMouseDownEvent()
        {
            foreach (Control item in this.Controls)
                item.MouseDown += ParentChatControl.BubbleMouseDown;
        }

        private void pic_Click(object sender, EventArgs e)
        {
            if (PhotoClicked != null)
                PhotoClicked(this, e);
        }
    }
}
