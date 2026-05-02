namespace SocialMediaLikeTelegram.Pics
{
    partial class Frm_ShowProfilesPics
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
            this.semiTransparentPanel4 = new SocialMediaLikeTelegram.SemiTransparentPanel();
            this.ShowPicturebox = new System.Windows.Forms.PictureBox();
            this.semiTransparentPanel3 = new SocialMediaLikeTelegram.SemiTransparentPanel();
            this.btn_Next = new System.Windows.Forms.PictureBox();
            this.semiTransparentPanel2 = new SocialMediaLikeTelegram.SemiTransparentPanel();
            this.btn_Preview = new System.Windows.Forms.PictureBox();
            this.semiTransparentPanel1 = new SocialMediaLikeTelegram.SemiTransparentPanel();
            this.btn_Download = new System.Windows.Forms.PictureBox();
            this.lbl_ProfileName = new System.Windows.Forms.Label();
            this.semiTransparentPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPicturebox)).BeginInit();
            this.semiTransparentPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Next)).BeginInit();
            this.semiTransparentPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Preview)).BeginInit();
            this.semiTransparentPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Download)).BeginInit();
            this.SuspendLayout();
            // 
            // semiTransparentPanel4
            // 
            this.semiTransparentPanel4.Alpha = 0;
            this.semiTransparentPanel4.BaseColor = System.Drawing.Color.Lime;
            this.semiTransparentPanel4.Controls.Add(this.ShowPicturebox);
            this.semiTransparentPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.semiTransparentPanel4.Location = new System.Drawing.Point(74, 0);
            this.semiTransparentPanel4.Name = "semiTransparentPanel4";
            this.semiTransparentPanel4.Size = new System.Drawing.Size(731, 535);
            this.semiTransparentPanel4.TabIndex = 2;
            this.semiTransparentPanel4.Click += new System.EventHandler(this.semiTransparentPanel1_Click);
            // 
            // ShowPicturebox
            // 
            this.ShowPicturebox.Image = global::SocialMediaLikeTelegram.Properties.Resources.TlgNotification;
            this.ShowPicturebox.Location = new System.Drawing.Point(128, 0);
            this.ShowPicturebox.Name = "ShowPicturebox";
            this.ShowPicturebox.Size = new System.Drawing.Size(451, 476);
            this.ShowPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShowPicturebox.TabIndex = 0;
            this.ShowPicturebox.TabStop = false;
            this.ShowPicturebox.Click += new System.EventHandler(this.semiTransparentPanel1_Click);
            // 
            // semiTransparentPanel3
            // 
            this.semiTransparentPanel3.Alpha = 60;
            this.semiTransparentPanel3.BaseColor = System.Drawing.Color.Black;
            this.semiTransparentPanel3.Controls.Add(this.btn_Next);
            this.semiTransparentPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.semiTransparentPanel3.Location = new System.Drawing.Point(805, 0);
            this.semiTransparentPanel3.Name = "semiTransparentPanel3";
            this.semiTransparentPanel3.Size = new System.Drawing.Size(74, 535);
            this.semiTransparentPanel3.TabIndex = 0;
            // 
            // btn_Next
            // 
            this.btn_Next.Image = global::SocialMediaLikeTelegram.Properties.Resources.Next;
            this.btn_Next.Location = new System.Drawing.Point(54, 266);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(20, 26);
            this.btn_Next.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_Next.TabIndex = 0;
            this.btn_Next.TabStop = false;
            this.btn_Next.Visible = false;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // semiTransparentPanel2
            // 
            this.semiTransparentPanel2.Alpha = 60;
            this.semiTransparentPanel2.BaseColor = System.Drawing.Color.Black;
            this.semiTransparentPanel2.Controls.Add(this.btn_Preview);
            this.semiTransparentPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.semiTransparentPanel2.Location = new System.Drawing.Point(0, 0);
            this.semiTransparentPanel2.Name = "semiTransparentPanel2";
            this.semiTransparentPanel2.Size = new System.Drawing.Size(74, 535);
            this.semiTransparentPanel2.TabIndex = 1;
            // 
            // btn_Preview
            // 
            this.btn_Preview.Image = global::SocialMediaLikeTelegram.Properties.Resources.Pereview;
            this.btn_Preview.Location = new System.Drawing.Point(0, 266);
            this.btn_Preview.Name = "btn_Preview";
            this.btn_Preview.Size = new System.Drawing.Size(27, 26);
            this.btn_Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_Preview.TabIndex = 1;
            this.btn_Preview.TabStop = false;
            this.btn_Preview.Visible = false;
            this.btn_Preview.Click += new System.EventHandler(this.btn_Preview_Click);
            // 
            // semiTransparentPanel1
            // 
            this.semiTransparentPanel1.Alpha = 0;
            this.semiTransparentPanel1.BaseColor = System.Drawing.SystemColors.Control;
            this.semiTransparentPanel1.Controls.Add(this.btn_Download);
            this.semiTransparentPanel1.Controls.Add(this.lbl_ProfileName);
            this.semiTransparentPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.semiTransparentPanel1.Location = new System.Drawing.Point(0, 535);
            this.semiTransparentPanel1.Name = "semiTransparentPanel1";
            this.semiTransparentPanel1.Size = new System.Drawing.Size(879, 45);
            this.semiTransparentPanel1.TabIndex = 0;
            this.semiTransparentPanel1.Click += new System.EventHandler(this.semiTransparentPanel1_Click);
            // 
            // btn_Download
            // 
            this.btn_Download.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Download.Image = global::SocialMediaLikeTelegram.Properties.Resources._64_download1;
            this.btn_Download.Location = new System.Drawing.Point(850, 7);
            this.btn_Download.Name = "btn_Download";
            this.btn_Download.Size = new System.Drawing.Size(29, 38);
            this.btn_Download.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_Download.TabIndex = 2;
            this.btn_Download.TabStop = false;
            this.btn_Download.Click += new System.EventHandler(this.btn_Download_Click);
            // 
            // lbl_ProfileName
            // 
            this.lbl_ProfileName.AutoSize = true;
            this.lbl_ProfileName.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_ProfileName.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_ProfileName.Location = new System.Drawing.Point(3, 7);
            this.lbl_ProfileName.Name = "lbl_ProfileName";
            this.lbl_ProfileName.Size = new System.Drawing.Size(140, 19);
            this.lbl_ProfileName.TabIndex = 1;
            this.lbl_ProfileName.Text = "Telegram      recently";
            this.lbl_ProfileName.Visible = false;
            // 
            // Frm_ShowProfilesPics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 580);
            this.Controls.Add(this.semiTransparentPanel4);
            this.Controls.Add(this.semiTransparentPanel3);
            this.Controls.Add(this.semiTransparentPanel2);
            this.Controls.Add(this.semiTransparentPanel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ShowProfilesPics";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_ShowProfilesPics_Load);
            this.semiTransparentPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ShowPicturebox)).EndInit();
            this.semiTransparentPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Next)).EndInit();
            this.semiTransparentPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Preview)).EndInit();
            this.semiTransparentPanel1.ResumeLayout(false);
            this.semiTransparentPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Download)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SemiTransparentPanel semiTransparentPanel1;
        private SemiTransparentPanel semiTransparentPanel2;
        private SemiTransparentPanel semiTransparentPanel3;
        private SemiTransparentPanel semiTransparentPanel4;
        private System.Windows.Forms.PictureBox ShowPicturebox;
        private System.Windows.Forms.Label lbl_ProfileName;
        private System.Windows.Forms.PictureBox btn_Next;
        private System.Windows.Forms.PictureBox btn_Download;
        private System.Windows.Forms.PictureBox btn_Preview;
    }
}