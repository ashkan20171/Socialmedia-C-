namespace Components.Bubble
{
    partial class TextMessageBubble
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
            this.lblTime = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.IsSeen = new System.Windows.Forms.PictureBox();
            this.txtMessages = new System.Windows.Forms.RichTextBox();
            this.pic_Seen = new System.Windows.Forms.PictureBox();
            this.lblSeen = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.IsSeen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Seen)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTime.Location = new System.Drawing.Point(383, 49);
            this.lblTime.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(36, 15);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "10:22";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblFrom.Location = new System.Drawing.Point(3, 0);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(63, 16);
            this.lblFrom.TabIndex = 1;
            this.lblFrom.Text = "Telegram";
            // 
            // IsSeen
            // 
            this.IsSeen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.IsSeen.Location = new System.Drawing.Point(419, 47);
            this.IsSeen.Name = "IsSeen";
            this.IsSeen.Size = new System.Drawing.Size(18, 18);
            this.IsSeen.TabIndex = 3;
            this.IsSeen.TabStop = false;
            // 
            // txtMessages
            // 
            this.txtMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessages.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtMessages.Location = new System.Drawing.Point(3, 22);
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtMessages.Size = new System.Drawing.Size(431, 22);
            this.txtMessages.TabIndex = 5;
            this.txtMessages.Text = "";
            // 
            // pic_Seen
            // 
            this.pic_Seen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_Seen.Image = global::Components.Properties.Resources.Seen;
            this.pic_Seen.Location = new System.Drawing.Point(328, 48);
            this.pic_Seen.Name = "pic_Seen";
            this.pic_Seen.Size = new System.Drawing.Size(18, 18);
            this.pic_Seen.TabIndex = 6;
            this.pic_Seen.TabStop = false;
            // 
            // lblSeen
            // 
            this.lblSeen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSeen.AutoSize = true;
            this.lblSeen.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeen.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSeen.Location = new System.Drawing.Point(344, 49);
            this.lblSeen.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblSeen.Name = "lblSeen";
            this.lblSeen.Size = new System.Drawing.Size(42, 15);
            this.lblSeen.TabIndex = 7;
            this.lblSeen.Text = "00000";
            // 
            // TextMessageBubble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pic_Seen);
            this.Controls.Add(this.txtMessages);
            this.Controls.Add(this.IsSeen);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.lblSeen);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TextMessageBubble";
            this.Size = new System.Drawing.Size(440, 67);
            this.Resize += new System.EventHandler(this.TextMessageBubble_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.IsSeen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Seen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.PictureBox IsSeen;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.RichTextBox txtMessages;
        private System.Windows.Forms.PictureBox pic_Seen;
        private System.Windows.Forms.Label lblSeen;
    }
}
