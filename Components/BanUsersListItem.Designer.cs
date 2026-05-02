namespace Components
{
    partial class BanUsersListItem
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_Remove = new System.Windows.Forms.LinkLabel();
            this.lbl_lastSeen = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.Location = new System.Drawing.Point(0, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 47;
            this.bunifuElipse1.TargetControl = this.pictureBox1;
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Name.Location = new System.Drawing.Point(53, 3);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(63, 17);
            this.lbl_Name.TabIndex = 1;
            this.lbl_Name.Text = "Telegram";
            // 
            // lbl_Remove
            // 
            this.lbl_Remove.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(227)))));
            this.lbl_Remove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Remove.AutoSize = true;
            this.lbl_Remove.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lbl_Remove.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(227)))));
            this.lbl_Remove.Location = new System.Drawing.Point(231, 16);
            this.lbl_Remove.Name = "lbl_Remove";
            this.lbl_Remove.Size = new System.Drawing.Size(47, 15);
            this.lbl_Remove.TabIndex = 2;
            this.lbl_Remove.TabStop = true;
            this.lbl_Remove.Text = "remove";
            this.lbl_Remove.Visible = false;
            this.lbl_Remove.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(227)))));
            this.lbl_Remove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_Remove_LinkClicked);
            // 
            // lbl_lastSeen
            // 
            this.lbl_lastSeen.AutoSize = true;
            this.lbl_lastSeen.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_lastSeen.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_lastSeen.Location = new System.Drawing.Point(53, 23);
            this.lbl_lastSeen.Name = "lbl_lastSeen";
            this.lbl_lastSeen.Size = new System.Drawing.Size(49, 15);
            this.lbl_lastSeen.TabIndex = 3;
            this.lbl_lastSeen.Text = "recently";
            // 
            // BanUsersListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbl_lastSeen);
            this.Controls.Add(this.lbl_Remove);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "BanUsersListItem";
            this.Size = new System.Drawing.Size(290, 49);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AdminListItem_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.LinkLabel lbl_Remove;
        private System.Windows.Forms.Label lbl_lastSeen;
    }
}
