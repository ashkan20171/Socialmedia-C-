namespace Components
{
    partial class ChatListItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.ProfilePic = new System.Windows.Forms.PictureBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblBadge = new System.Windows.Forms.Label();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.lblChatName = new System.Windows.Forms.Label();
            this.lblLastMessage = new System.Windows.Forms.Label();
            this.lblLastMessageSenderName = new System.Windows.Forms.Label();
            this.IsSeen = new System.Windows.Forms.PictureBox();
            this.pic_ChatType = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsSeen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ChatType)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 60;
            this.bunifuElipse1.TargetControl = this.ProfilePic;
            // 
            // ProfilePic
            // 
            this.ProfilePic.BackColor = System.Drawing.Color.Gainsboro;
            this.ProfilePic.Location = new System.Drawing.Point(3, 3);
            this.ProfilePic.Name = "ProfilePic";
            this.ProfilePic.Size = new System.Drawing.Size(60, 60);
            this.ProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ProfilePic.TabIndex = 0;
            this.ProfilePic.TabStop = false;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDate.Location = new System.Drawing.Point(254, 7);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(52, 17);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "18 June";
            // 
            // lblBadge
            // 
            this.lblBadge.AutoSize = true;
            this.lblBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(227)))));
            this.lblBadge.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblBadge.ForeColor = System.Drawing.Color.White;
            this.lblBadge.Location = new System.Drawing.Point(255, 37);
            this.lblBadge.Name = "lblBadge";
            this.lblBadge.Size = new System.Drawing.Size(25, 19);
            this.lblBadge.TabIndex = 2;
            this.lblBadge.Text = " 0 ";
            this.lblBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 20;
            this.bunifuElipse2.TargetControl = this.lblBadge;
            // 
            // lblChatName
            // 
            this.lblChatName.AutoSize = true;
            this.lblChatName.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblChatName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblChatName.Location = new System.Drawing.Point(82, 4);
            this.lblChatName.Name = "lblChatName";
            this.lblChatName.Size = new System.Drawing.Size(66, 19);
            this.lblChatName.TabIndex = 3;
            this.lblChatName.Text = "Telegram";
            // 
            // lblLastMessage
            // 
            this.lblLastMessage.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastMessage.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblLastMessage.Location = new System.Drawing.Point(125, 38);
            this.lblLastMessage.Name = "lblLastMessage";
            this.lblLastMessage.Size = new System.Drawing.Size(127, 25);
            this.lblLastMessage.TabIndex = 5;
            this.lblLastMessage.Text = "Hello Word . . .";
            // 
            // lblLastMessageSenderName
            // 
            this.lblLastMessageSenderName.AutoSize = true;
            this.lblLastMessageSenderName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastMessageSenderName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(163)))), ((int)(((byte)(244)))));
            this.lblLastMessageSenderName.Location = new System.Drawing.Point(69, 37);
            this.lblLastMessageSenderName.Name = "lblLastMessageSenderName";
            this.lblLastMessageSenderName.Size = new System.Drawing.Size(59, 15);
            this.lblLastMessageSenderName.TabIndex = 6;
            this.lblLastMessageSenderName.Text = "Telegram:";
            this.lblLastMessageSenderName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // IsSeen
            // 
            this.IsSeen.Image = global::Components.Properties.Resources.double_tick;
            this.IsSeen.Location = new System.Drawing.Point(233, 6);
            this.IsSeen.Name = "IsSeen";
            this.IsSeen.Size = new System.Drawing.Size(18, 18);
            this.IsSeen.TabIndex = 7;
            this.IsSeen.TabStop = false;
            // 
            // pic_ChatType
            // 
            this.pic_ChatType.Image = global::Components.Properties.Resources._18_users;
            this.pic_ChatType.Location = new System.Drawing.Point(69, 6);
            this.pic_ChatType.Name = "pic_ChatType";
            this.pic_ChatType.Size = new System.Drawing.Size(15, 15);
            this.pic_ChatType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_ChatType.TabIndex = 4;
            this.pic_ChatType.TabStop = false;
            // 
            // ChatListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.IsSeen);
            this.Controls.Add(this.lblLastMessageSenderName);
            this.Controls.Add(this.lblLastMessage);
            this.Controls.Add(this.pic_ChatType);
            this.Controls.Add(this.lblChatName);
            this.Controls.Add(this.lblBadge);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.ProfilePic);
            this.Name = "ChatListItem";
            this.Size = new System.Drawing.Size(306, 66);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChatListItem_MouseDown);
            this.MouseEnter += new System.EventHandler(this.ChatListItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ChatListItem_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChatListItem_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsSeen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ChatType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ProfilePic;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblBadge;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private System.Windows.Forms.Label lblChatName;
        private System.Windows.Forms.PictureBox pic_ChatType;
        private System.Windows.Forms.Label lblLastMessage;
        private System.Windows.Forms.Label lblLastMessageSenderName;
        private System.Windows.Forms.PictureBox IsSeen;
    }
}
