namespace Components.Bubble
{
    partial class PhotoMessageBubble
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
            this.txt_Caption = new System.Windows.Forms.RichTextBox();
            this.pic = new System.Windows.Forms.PictureBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.IsSeen = new System.Windows.Forms.PictureBox();
            this.pic_Seen = new System.Windows.Forms.PictureBox();
            this.lblSeen = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsSeen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Seen)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Caption
            // 
            this.txt_Caption.BackColor = System.Drawing.Color.White;
            this.txt_Caption.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Caption.Location = new System.Drawing.Point(4, 310);
            this.txt_Caption.Name = "txt_Caption";
            this.txt_Caption.ReadOnly = true;
            this.txt_Caption.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txt_Caption.Size = new System.Drawing.Size(266, 62);
            this.txt_Caption.TabIndex = 0;
            this.txt_Caption.Text = "";
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(1, 19);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(271, 290);
            this.pic.TabIndex = 1;
            this.pic.TabStop = false;
            this.pic.Click += new System.EventHandler(this.pic_Click);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblFrom.Location = new System.Drawing.Point(3, 0);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(63, 16);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.Text = "Telegram";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblTime.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTime.Location = new System.Drawing.Point(213, 383);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(38, 15);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "00:00";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // IsSeen
            // 
            this.IsSeen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.IsSeen.Location = new System.Drawing.Point(254, 383);
            this.IsSeen.Name = "IsSeen";
            this.IsSeen.Size = new System.Drawing.Size(18, 18);
            this.IsSeen.TabIndex = 4;
            this.IsSeen.TabStop = false;
            // 
            // pic_Seen
            // 
            this.pic_Seen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_Seen.Image = global::Components.Properties.Resources.Seen;
            this.pic_Seen.Location = new System.Drawing.Point(150, 382);
            this.pic_Seen.Name = "pic_Seen";
            this.pic_Seen.Size = new System.Drawing.Size(18, 18);
            this.pic_Seen.TabIndex = 8;
            this.pic_Seen.TabStop = false;
            // 
            // lblSeen
            // 
            this.lblSeen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSeen.AutoSize = true;
            this.lblSeen.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeen.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSeen.Location = new System.Drawing.Point(166, 383);
            this.lblSeen.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblSeen.Name = "lblSeen";
            this.lblSeen.Size = new System.Drawing.Size(42, 15);
            this.lblSeen.TabIndex = 9;
            this.lblSeen.Text = "00000";
            // 
            // PhotoMessageBubble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pic_Seen);
            this.Controls.Add(this.lblSeen);
            this.Controls.Add(this.IsSeen);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.txt_Caption);
            this.Name = "PhotoMessageBubble";
            this.Size = new System.Drawing.Size(275, 404);
            this.Load += new System.EventHandler(this.PhotoMessageBubble_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsSeen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Seen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.RichTextBox txt_Caption;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.PictureBox IsSeen;
        private System.Windows.Forms.PictureBox pic_Seen;
        private System.Windows.Forms.Label lblSeen;
    }
}
