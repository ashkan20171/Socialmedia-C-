namespace SocialMediaLikeTelegram.Channels
{
    partial class Frm_ManagePermissions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ManagePermissions));
            this.dropShadowPanel1 = new SocialMediaLikeTelegram.DropShadowPanel();
            this.lbl_LastSeen = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.swch_Pin = new Bunifu.Framework.UI.BunifuiOSSwitch();
            this.swch_Edit = new Bunifu.Framework.UI.BunifuiOSSwitch();
            this.label1 = new System.Windows.Forms.Label();
            this.swch_Delete = new Bunifu.Framework.UI.BunifuiOSSwitch();
            this.materialFlatButton2 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.dropShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dropShadowPanel1
            // 
            this.dropShadowPanel1.BackColor = System.Drawing.Color.White;
            this.dropShadowPanel1.BorderColor = System.Drawing.Color.Empty;
            this.dropShadowPanel1.Controls.Add(this.lbl_LastSeen);
            this.dropShadowPanel1.Controls.Add(this.lbl_Name);
            this.dropShadowPanel1.Controls.Add(this.pictureBox2);
            this.dropShadowPanel1.Controls.Add(this.pictureBox1);
            this.dropShadowPanel1.Controls.Add(this.label);
            this.dropShadowPanel1.Location = new System.Drawing.Point(-12, 0);
            this.dropShadowPanel1.Name = "dropShadowPanel1";
            this.dropShadowPanel1.PanelColor = System.Drawing.Color.Empty;
            this.dropShadowPanel1.Size = new System.Drawing.Size(311, 118);
            this.dropShadowPanel1.TabIndex = 0;
            // 
            // lbl_LastSeen
            // 
            this.lbl_LastSeen.AutoSize = true;
            this.lbl_LastSeen.ForeColor = System.Drawing.Color.DarkGray;
            this.lbl_LastSeen.Location = new System.Drawing.Point(95, 70);
            this.lbl_LastSeen.Name = "lbl_LastSeen";
            this.lbl_LastSeen.Size = new System.Drawing.Size(49, 15);
            this.lbl_LastSeen.TabIndex = 12;
            this.lbl_LastSeen.Text = "recently";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_Name.Location = new System.Drawing.Point(92, 45);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(66, 19);
            this.lbl_Name.TabIndex = 11;
            this.lbl_Name.Text = "Telegram";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox2.Location = new System.Drawing.Point(24, 38);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 60);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SocialMediaLikeTelegram.Properties.Resources.ic_close_black_48dp;
            this.pictureBox1.Location = new System.Drawing.Point(281, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 19);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(24, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(160, 21);
            this.label.TabIndex = 8;
            this.label.Text = "Manage permissions";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.swch_Pin);
            this.panel1.Controls.Add(this.swch_Edit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.swch_Delete);
            this.panel1.Controls.Add(this.materialFlatButton2);
            this.panel1.Controls.Add(this.materialFlatButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 200);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(66, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 19);
            this.label4.TabIndex = 17;
            this.label4.Text = "Pin message";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(66, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 19);
            this.label3.TabIndex = 16;
            this.label3.Text = "edit message\'s";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(66, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "delete message\'s";
            // 
            // swch_Pin
            // 
            this.swch_Pin.BackColor = System.Drawing.Color.Transparent;
            this.swch_Pin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("swch_Pin.BackgroundImage")));
            this.swch_Pin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.swch_Pin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.swch_Pin.Location = new System.Drawing.Point(16, 132);
            this.swch_Pin.Name = "swch_Pin";
            this.swch_Pin.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.swch_Pin.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(227)))));
            this.swch_Pin.Size = new System.Drawing.Size(35, 20);
            this.swch_Pin.TabIndex = 15;
            this.swch_Pin.Value = true;
            // 
            // swch_Edit
            // 
            this.swch_Edit.BackColor = System.Drawing.Color.Transparent;
            this.swch_Edit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("swch_Edit.BackgroundImage")));
            this.swch_Edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.swch_Edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.swch_Edit.Location = new System.Drawing.Point(16, 91);
            this.swch_Edit.Name = "swch_Edit";
            this.swch_Edit.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.swch_Edit.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(227)))));
            this.swch_Edit.Size = new System.Drawing.Size(35, 20);
            this.swch_Edit.TabIndex = 14;
            this.swch_Edit.Value = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(227)))));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "what can this admin do :";
            // 
            // swch_Delete
            // 
            this.swch_Delete.BackColor = System.Drawing.Color.Transparent;
            this.swch_Delete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("swch_Delete.BackgroundImage")));
            this.swch_Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.swch_Delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.swch_Delete.Location = new System.Drawing.Point(16, 47);
            this.swch_Delete.Name = "swch_Delete";
            this.swch_Delete.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.swch_Delete.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(167)))), ((int)(((byte)(227)))));
            this.swch_Delete.Size = new System.Drawing.Size(35, 20);
            this.swch_Delete.TabIndex = 13;
            this.swch_Delete.Value = true;
            // 
            // materialFlatButton2
            // 
            this.materialFlatButton2.AutoSize = true;
            this.materialFlatButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton2.Depth = 0;
            this.materialFlatButton2.Location = new System.Drawing.Point(222, 160);
            this.materialFlatButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton2.Name = "materialFlatButton2";
            this.materialFlatButton2.Primary = false;
            this.materialFlatButton2.Size = new System.Drawing.Size(64, 36);
            this.materialFlatButton2.TabIndex = 7;
            this.materialFlatButton2.Text = "cancel";
            this.materialFlatButton2.UseVisualStyleBackColor = true;
            this.materialFlatButton2.Click += new System.EventHandler(this.materialFlatButton2_Click);
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.Location = new System.Drawing.Point(168, 160);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(46, 36);
            this.materialFlatButton1.TabIndex = 6;
            this.materialFlatButton1.Text = "save";
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            this.materialFlatButton1.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 60;
            this.bunifuElipse1.TargetControl = this.pictureBox2;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 10;
            this.bunifuElipse2.TargetControl = this;
            // 
            // Frm_ManagePermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(290, 324);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dropShadowPanel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ManagePermissions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.Frm_ManagePermissions_Load);
            this.dropShadowPanel1.ResumeLayout(false);
            this.dropShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DropShadowPanel dropShadowPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton2;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label lbl_LastSeen;
        private System.Windows.Forms.Label lbl_Name;
        private Bunifu.Framework.UI.BunifuiOSSwitch swch_Delete;
        private Bunifu.Framework.UI.BunifuiOSSwitch swch_Pin;
        private Bunifu.Framework.UI.BunifuiOSSwitch swch_Edit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
    }
}