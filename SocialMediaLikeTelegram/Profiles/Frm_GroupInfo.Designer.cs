namespace SocialMediaLikeTelegram.Profiles
{
    partial class Frm_GroupInfo
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_ChannelInfo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txt_About = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.PanelMembers = new System.Windows.Forms.Panel();
            this.materialFlatButton3 = new MaterialSkin.Controls.MaterialFlatButton();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.PanelAdmin = new System.Windows.Forms.Panel();
            this.materialFlatButton2 = new MaterialSkin.Controls.MaterialFlatButton();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.materialFlatButton4 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_MemberCount = new System.Windows.Forms.Label();
            this.Profile_Pic = new System.Windows.Forms.PictureBox();
            this.lbl_GroupName = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.lbl_InviteLink = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.PanelMembers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.PanelAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Profile_Pic)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_ChannelInfo);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(391, 41);
            this.panel1.TabIndex = 0;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColorChanging);
            // 
            // lbl_ChannelInfo
            // 
            this.lbl_ChannelInfo.AutoSize = true;
            this.lbl_ChannelInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ChannelInfo.Location = new System.Drawing.Point(12, 12);
            this.lbl_ChannelInfo.Name = "lbl_ChannelInfo";
            this.lbl_ChannelInfo.Size = new System.Drawing.Size(89, 21);
            this.lbl_ChannelInfo.TabIndex = 3;
            this.lbl_ChannelInfo.Text = "Group info";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SocialMediaLikeTelegram.Properties.Resources.ic_close_black_48dp;
            this.pictureBox1.Location = new System.Drawing.Point(358, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.PanelMembers);
            this.panel2.Controls.Add(this.PanelAdmin);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(391, 580);
            this.panel2.TabIndex = 0;
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColorChanging);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.lbl_InviteLink);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.txt_About);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.pictureBox6);
            this.panel6.Location = new System.Drawing.Point(0, 117);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(374, 139);
            this.panel6.TabIndex = 8;
            this.panel6.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColorChanging);
            // 
            // txt_About
            // 
            this.txt_About.BackColor = System.Drawing.Color.White;
            this.txt_About.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_About.Location = new System.Drawing.Point(51, 14);
            this.txt_About.Name = "txt_About";
            this.txt_About.ReadOnly = true;
            this.txt_About.Size = new System.Drawing.Size(281, 46);
            this.txt_About.TabIndex = 7;
            this.txt_About.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Location = new System.Drawing.Point(47, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "About";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::SocialMediaLikeTelegram.Properties.Resources._18_info;
            this.pictureBox6.Location = new System.Drawing.Point(16, 23);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(18, 18);
            this.pictureBox6.TabIndex = 0;
            this.pictureBox6.TabStop = false;
            // 
            // PanelMembers
            // 
            this.PanelMembers.BackColor = System.Drawing.Color.White;
            this.PanelMembers.Controls.Add(this.materialFlatButton3);
            this.PanelMembers.Controls.Add(this.pictureBox5);
            this.PanelMembers.Controls.Add(this.line1);
            this.PanelMembers.Location = new System.Drawing.Point(0, 429);
            this.PanelMembers.Name = "PanelMembers";
            this.PanelMembers.Size = new System.Drawing.Size(374, 215);
            this.PanelMembers.TabIndex = 4;
            this.PanelMembers.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.PanelMembers_ControlRemoved);
            this.PanelMembers.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColorChanging);
            // 
            // materialFlatButton3
            // 
            this.materialFlatButton3.AutoSize = true;
            this.materialFlatButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton3.Depth = 0;
            this.materialFlatButton3.Location = new System.Drawing.Point(51, 13);
            this.materialFlatButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton3.Name = "materialFlatButton3";
            this.materialFlatButton3.Primary = false;
            this.materialFlatButton3.Size = new System.Drawing.Size(117, 36);
            this.materialFlatButton3.TabIndex = 3;
            this.materialFlatButton3.Text = "+   Add member";
            this.materialFlatButton3.UseVisualStyleBackColor = true;
            this.materialFlatButton3.Click += new System.EventHandler(this.materialFlatButton3_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::SocialMediaLikeTelegram.Properties.Resources._18_users;
            this.pictureBox5.Location = new System.Drawing.Point(16, 23);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(18, 18);
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            // 
            // line1
            // 
            this.line1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.line1.Location = new System.Drawing.Point(0, 43);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(391, 23);
            this.line1.TabIndex = 4;
            this.line1.Text = "line1";
            // 
            // PanelAdmin
            // 
            this.PanelAdmin.BackColor = System.Drawing.Color.White;
            this.PanelAdmin.Controls.Add(this.materialFlatButton2);
            this.PanelAdmin.Controls.Add(this.pictureBox4);
            this.PanelAdmin.Controls.Add(this.pictureBox3);
            this.PanelAdmin.Controls.Add(this.materialFlatButton4);
            this.PanelAdmin.Controls.Add(this.materialFlatButton1);
            this.PanelAdmin.Controls.Add(this.pictureBox2);
            this.PanelAdmin.Location = new System.Drawing.Point(0, 262);
            this.PanelAdmin.Name = "PanelAdmin";
            this.PanelAdmin.Size = new System.Drawing.Size(374, 161);
            this.PanelAdmin.TabIndex = 0;
            this.PanelAdmin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColorChanging);
            // 
            // materialFlatButton2
            // 
            this.materialFlatButton2.AutoSize = true;
            this.materialFlatButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton2.Depth = 0;
            this.materialFlatButton2.Location = new System.Drawing.Point(51, 13);
            this.materialFlatButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton2.Name = "materialFlatButton2";
            this.materialFlatButton2.Primary = false;
            this.materialFlatButton2.Size = new System.Drawing.Size(131, 36);
            this.materialFlatButton2.TabIndex = 3;
            this.materialFlatButton2.Text = "Administrator\'s";
            this.materialFlatButton2.UseVisualStyleBackColor = true;
            this.materialFlatButton2.Click += new System.EventHandler(this.materialFlatButton2_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::SocialMediaLikeTelegram.Properties.Resources._18_leave;
            this.pictureBox4.Location = new System.Drawing.Point(16, 116);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(18, 18);
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::SocialMediaLikeTelegram.Properties.Resources._18_block;
            this.pictureBox3.Location = new System.Drawing.Point(16, 68);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(18, 18);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // materialFlatButton4
            // 
            this.materialFlatButton4.AutoSize = true;
            this.materialFlatButton4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton4.Depth = 0;
            this.materialFlatButton4.Location = new System.Drawing.Point(51, 107);
            this.materialFlatButton4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton4.Name = "materialFlatButton4";
            this.materialFlatButton4.Primary = false;
            this.materialFlatButton4.Size = new System.Drawing.Size(43, 36);
            this.materialFlatButton4.TabIndex = 1;
            this.materialFlatButton4.Text = "Left";
            this.materialFlatButton4.UseVisualStyleBackColor = true;
            this.materialFlatButton4.Click += new System.EventHandler(this.materialFlatButton4_Click);
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.Location = new System.Drawing.Point(51, 59);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(87, 36);
            this.materialFlatButton1.TabIndex = 1;
            this.materialFlatButton1.Text = "Ban User\'s";
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            this.materialFlatButton1.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SocialMediaLikeTelegram.Properties.Resources._18_User;
            this.pictureBox2.Location = new System.Drawing.Point(16, 23);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(18, 18);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.lbl_MemberCount);
            this.panel3.Controls.Add(this.Profile_Pic);
            this.panel3.Controls.Add(this.lbl_GroupName);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(374, 111);
            this.panel3.TabIndex = 7;
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColorChanging);
            // 
            // lbl_MemberCount
            // 
            this.lbl_MemberCount.AutoSize = true;
            this.lbl_MemberCount.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MemberCount.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lbl_MemberCount.Location = new System.Drawing.Point(116, 56);
            this.lbl_MemberCount.Name = "lbl_MemberCount";
            this.lbl_MemberCount.Size = new System.Drawing.Size(111, 17);
            this.lbl_MemberCount.TabIndex = 6;
            this.lbl_MemberCount.Text = "200000 members";
            // 
            // Profile_Pic
            // 
            this.Profile_Pic.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Profile_Pic.Location = new System.Drawing.Point(13, 11);
            this.Profile_Pic.Name = "Profile_Pic";
            this.Profile_Pic.Size = new System.Drawing.Size(80, 80);
            this.Profile_Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Profile_Pic.TabIndex = 4;
            this.Profile_Pic.TabStop = false;
            this.Profile_Pic.Click += new System.EventHandler(this.Profile_Pic_Click);
            // 
            // lbl_GroupName
            // 
            this.lbl_GroupName.AutoSize = true;
            this.lbl_GroupName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GroupName.Location = new System.Drawing.Point(112, 27);
            this.lbl_GroupName.Name = "lbl_GroupName";
            this.lbl_GroupName.Size = new System.Drawing.Size(127, 21);
            this.lbl_GroupName.TabIndex = 5;
            this.lbl_GroupName.Text = "Telegram Group";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 80;
            this.bunifuElipse1.TargetControl = this.Profile_Pic;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 10;
            this.bunifuElipse2.TargetControl = this;
            // 
            // lbl_InviteLink
            // 
            this.lbl_InviteLink.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(142)))), ((int)(((byte)(192)))));
            this.lbl_InviteLink.AutoSize = true;
            this.lbl_InviteLink.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_InviteLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lbl_InviteLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(144)))), ((int)(((byte)(195)))));
            this.lbl_InviteLink.Location = new System.Drawing.Point(46, 91);
            this.lbl_InviteLink.Name = "lbl_InviteLink";
            this.lbl_InviteLink.Size = new System.Drawing.Size(113, 17);
            this.lbl_InviteLink.TabIndex = 9;
            this.lbl_InviteLink.TabStop = true;
            this.lbl_InviteLink.Text = "+98 909 000 0000";
            this.lbl_InviteLink.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(144)))), ((int)(((byte)(195)))));
            this.lbl_InviteLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_InviteLink_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(48, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Link";
            // 
            // Frm_GroupInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(391, 621);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_GroupInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.Frm_GroupInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.PanelMembers.ResumeLayout(false);
            this.PanelMembers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.PanelAdmin.ResumeLayout(false);
            this.PanelAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Profile_Pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_ChannelInfo;
        private System.Windows.Forms.Label lbl_MemberCount;
        private System.Windows.Forms.Label lbl_GroupName;
        private System.Windows.Forms.PictureBox Profile_Pic;
        private System.Windows.Forms.Panel PanelAdmin;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton2;
        private System.Windows.Forms.Panel PanelMembers;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private DevComponents.DotNetBar.Controls.Line line1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txt_About;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton4;
        private System.Windows.Forms.LinkLabel lbl_InviteLink;
        private System.Windows.Forms.Label label1;
    }
}