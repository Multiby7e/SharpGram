namespace SharpGram
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.tabBot = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.groupMain = new System.Windows.Forms.GroupBox();
            this.chkComment = new System.Windows.Forms.CheckBox();
            this.chkFollow = new System.Windows.Forms.CheckBox();
            this.chkLike = new System.Windows.Forms.CheckBox();
            this.tabTags = new System.Windows.Forms.TabPage();
            this.groupTags = new System.Windows.Forms.GroupBox();
            this.btnRemoveTag = new System.Windows.Forms.Button();
            this.btnAddTag = new System.Windows.Forms.Button();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.listTags = new System.Windows.Forms.ListBox();
            this.tabComments = new System.Windows.Forms.TabPage();
            this.groupComment = new System.Windows.Forms.GroupBox();
            this.btnRemoveComment = new System.Windows.Forms.Button();
            this.btnAddComment = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.listComments = new System.Windows.Forms.ListBox();
            this.tabLogs = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabData = new System.Windows.Forms.TabPage();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.txtLogs = new System.Windows.Forms.RichTextBox();
            this.tabImg = new System.Windows.Forms.TabPage();
            this.listLikedImages = new System.Windows.Forms.ListView();
            this.menuImages = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.likeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unlikeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            this.tabBot.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.groupMain.SuspendLayout();
            this.tabTags.SuspendLayout();
            this.groupTags.SuspendLayout();
            this.tabComments.SuspendLayout();
            this.groupComment.SuspendLayout();
            this.tabLogs.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabData.SuspendLayout();
            this.tabImg.SuspendLayout();
            this.menuImages.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgLogo
            // 
            this.imgLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.imgLogo.Image = global::SharpGram.Properties.Resources.logo;
            this.imgLogo.Location = new System.Drawing.Point(0, 0);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(439, 62);
            this.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgLogo.TabIndex = 1;
            this.imgLogo.TabStop = false;
            // 
            // tabBot
            // 
            this.tabBot.Controls.Add(this.tabMain);
            this.tabBot.Controls.Add(this.tabTags);
            this.tabBot.Controls.Add(this.tabComments);
            this.tabBot.Controls.Add(this.tabLogs);
            this.tabBot.Location = new System.Drawing.Point(0, 55);
            this.tabBot.Name = "tabBot";
            this.tabBot.SelectedIndex = 0;
            this.tabBot.Size = new System.Drawing.Size(439, 255);
            this.tabBot.TabIndex = 2;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.groupMain);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(431, 229);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // groupMain
            // 
            this.groupMain.Controls.Add(this.chkComment);
            this.groupMain.Controls.Add(this.chkFollow);
            this.groupMain.Controls.Add(this.chkLike);
            this.groupMain.Location = new System.Drawing.Point(8, 6);
            this.groupMain.Name = "groupMain";
            this.groupMain.Size = new System.Drawing.Size(415, 217);
            this.groupMain.TabIndex = 0;
            this.groupMain.TabStop = false;
            // 
            // chkComment
            // 
            this.chkComment.AutoSize = true;
            this.chkComment.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkComment.Location = new System.Drawing.Point(3, 50);
            this.chkComment.Name = "chkComment";
            this.chkComment.Size = new System.Drawing.Size(409, 17);
            this.chkComment.TabIndex = 2;
            this.chkComment.Text = "Comment";
            this.chkComment.UseVisualStyleBackColor = true;
            // 
            // chkFollow
            // 
            this.chkFollow.AutoSize = true;
            this.chkFollow.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkFollow.Location = new System.Drawing.Point(3, 33);
            this.chkFollow.Name = "chkFollow";
            this.chkFollow.Size = new System.Drawing.Size(409, 17);
            this.chkFollow.TabIndex = 1;
            this.chkFollow.Text = "Follow";
            this.chkFollow.UseVisualStyleBackColor = true;
            // 
            // chkLike
            // 
            this.chkLike.AutoSize = true;
            this.chkLike.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkLike.Location = new System.Drawing.Point(3, 16);
            this.chkLike.Name = "chkLike";
            this.chkLike.Size = new System.Drawing.Size(409, 17);
            this.chkLike.TabIndex = 0;
            this.chkLike.Text = "Like";
            this.chkLike.UseVisualStyleBackColor = true;
            // 
            // tabTags
            // 
            this.tabTags.Controls.Add(this.groupTags);
            this.tabTags.Location = new System.Drawing.Point(4, 22);
            this.tabTags.Name = "tabTags";
            this.tabTags.Padding = new System.Windows.Forms.Padding(3);
            this.tabTags.Size = new System.Drawing.Size(431, 229);
            this.tabTags.TabIndex = 1;
            this.tabTags.Text = "Tags";
            this.tabTags.UseVisualStyleBackColor = true;
            // 
            // groupTags
            // 
            this.groupTags.Controls.Add(this.btnRemoveTag);
            this.groupTags.Controls.Add(this.btnAddTag);
            this.groupTags.Controls.Add(this.txtTag);
            this.groupTags.Controls.Add(this.listTags);
            this.groupTags.Location = new System.Drawing.Point(8, 6);
            this.groupTags.Name = "groupTags";
            this.groupTags.Size = new System.Drawing.Size(415, 217);
            this.groupTags.TabIndex = 0;
            this.groupTags.TabStop = false;
            // 
            // btnRemoveTag
            // 
            this.btnRemoveTag.Location = new System.Drawing.Point(354, 188);
            this.btnRemoveTag.Name = "btnRemoveTag";
            this.btnRemoveTag.Size = new System.Drawing.Size(55, 23);
            this.btnRemoveTag.TabIndex = 3;
            this.btnRemoveTag.Text = "Remove";
            this.btnRemoveTag.UseVisualStyleBackColor = true;
            this.btnRemoveTag.Click += new System.EventHandler(this.btnRemoveTag_Click);
            // 
            // btnAddTag
            // 
            this.btnAddTag.Location = new System.Drawing.Point(293, 188);
            this.btnAddTag.Name = "btnAddTag";
            this.btnAddTag.Size = new System.Drawing.Size(55, 23);
            this.btnAddTag.TabIndex = 2;
            this.btnAddTag.Text = "Add";
            this.btnAddTag.UseVisualStyleBackColor = true;
            this.btnAddTag.Click += new System.EventHandler(this.btnAddTag_Click);
            // 
            // txtTag
            // 
            this.txtTag.Location = new System.Drawing.Point(6, 190);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(281, 20);
            this.txtTag.TabIndex = 1;
            this.txtTag.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTag_KeyDown);
            // 
            // listTags
            // 
            this.listTags.Location = new System.Drawing.Point(6, 12);
            this.listTags.Name = "listTags";
            this.listTags.Size = new System.Drawing.Size(403, 173);
            this.listTags.TabIndex = 0;
            this.listTags.DoubleClick += new System.EventHandler(this.listTags_DoubleClick);
            // 
            // tabComments
            // 
            this.tabComments.Controls.Add(this.groupComment);
            this.tabComments.Location = new System.Drawing.Point(4, 22);
            this.tabComments.Name = "tabComments";
            this.tabComments.Size = new System.Drawing.Size(431, 229);
            this.tabComments.TabIndex = 3;
            this.tabComments.Text = "Comment";
            this.tabComments.UseVisualStyleBackColor = true;
            // 
            // groupComment
            // 
            this.groupComment.Controls.Add(this.btnRemoveComment);
            this.groupComment.Controls.Add(this.btnAddComment);
            this.groupComment.Controls.Add(this.txtComment);
            this.groupComment.Controls.Add(this.listComments);
            this.groupComment.Location = new System.Drawing.Point(8, 6);
            this.groupComment.Name = "groupComment";
            this.groupComment.Size = new System.Drawing.Size(415, 217);
            this.groupComment.TabIndex = 1;
            this.groupComment.TabStop = false;
            // 
            // btnRemoveComment
            // 
            this.btnRemoveComment.Location = new System.Drawing.Point(354, 188);
            this.btnRemoveComment.Name = "btnRemoveComment";
            this.btnRemoveComment.Size = new System.Drawing.Size(55, 23);
            this.btnRemoveComment.TabIndex = 7;
            this.btnRemoveComment.Text = "Remove";
            this.btnRemoveComment.UseVisualStyleBackColor = true;
            this.btnRemoveComment.Click += new System.EventHandler(this.btnRemoveComment_Click);
            // 
            // btnAddComment
            // 
            this.btnAddComment.Location = new System.Drawing.Point(293, 188);
            this.btnAddComment.Name = "btnAddComment";
            this.btnAddComment.Size = new System.Drawing.Size(55, 23);
            this.btnAddComment.TabIndex = 6;
            this.btnAddComment.Text = "Add";
            this.btnAddComment.UseVisualStyleBackColor = true;
            this.btnAddComment.Click += new System.EventHandler(this.btnAddComment_Click);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(6, 190);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(281, 20);
            this.txtComment.TabIndex = 5;
            this.txtComment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtComment_KeyDown);
            // 
            // listComments
            // 
            this.listComments.Location = new System.Drawing.Point(6, 12);
            this.listComments.Name = "listComments";
            this.listComments.Size = new System.Drawing.Size(403, 173);
            this.listComments.TabIndex = 4;
            this.listComments.DoubleClick += new System.EventHandler(this.listComments_DoubleClick);
            // 
            // tabLogs
            // 
            this.tabLogs.Controls.Add(this.tabControl1);
            this.tabLogs.Location = new System.Drawing.Point(4, 22);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogs.Size = new System.Drawing.Size(431, 229);
            this.tabLogs.TabIndex = 4;
            this.tabLogs.Text = "Logs";
            this.tabLogs.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabData);
            this.tabControl1.Controls.Add(this.tabImg);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(425, 223);
            this.tabControl1.TabIndex = 0;
            // 
            // tabData
            // 
            this.tabData.Controls.Add(this.btnClearLogs);
            this.tabData.Controls.Add(this.txtLogs);
            this.tabData.Location = new System.Drawing.Point(4, 22);
            this.tabData.Name = "tabData";
            this.tabData.Padding = new System.Windows.Forms.Padding(3);
            this.tabData.Size = new System.Drawing.Size(417, 197);
            this.tabData.TabIndex = 0;
            this.tabData.Text = "Data";
            this.tabData.UseVisualStyleBackColor = true;
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.Location = new System.Drawing.Point(8, 168);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(52, 23);
            this.btnClearLogs.TabIndex = 8;
            this.btnClearLogs.Text = "Clear";
            this.btnClearLogs.UseVisualStyleBackColor = true;
            // 
            // txtLogs
            // 
            this.txtLogs.Location = new System.Drawing.Point(8, 6);
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ReadOnly = true;
            this.txtLogs.Size = new System.Drawing.Size(403, 156);
            this.txtLogs.TabIndex = 7;
            this.txtLogs.Text = "";
            // 
            // tabImg
            // 
            this.tabImg.Controls.Add(this.listLikedImages);
            this.tabImg.Location = new System.Drawing.Point(4, 22);
            this.tabImg.Name = "tabImg";
            this.tabImg.Padding = new System.Windows.Forms.Padding(3);
            this.tabImg.Size = new System.Drawing.Size(417, 197);
            this.tabImg.TabIndex = 1;
            this.tabImg.Text = "Liked images";
            this.tabImg.UseVisualStyleBackColor = true;
            // 
            // listLikedImages
            // 
            this.listLikedImages.ContextMenuStrip = this.menuImages;
            this.listLikedImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listLikedImages.Location = new System.Drawing.Point(3, 3);
            this.listLikedImages.Name = "listLikedImages";
            this.listLikedImages.Size = new System.Drawing.Size(411, 191);
            this.listLikedImages.TabIndex = 1;
            this.listLikedImages.UseCompatibleStateImageBehavior = false;
            this.listLikedImages.View = System.Windows.Forms.View.Tile;
            // 
            // menuImages
            // 
            this.menuImages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.likeToolStripMenuItem,
            this.unlikeToolStripMenuItem});
            this.menuImages.Name = "menuImages";
            this.menuImages.Size = new System.Drawing.Size(108, 48);
            // 
            // likeToolStripMenuItem
            // 
            this.likeToolStripMenuItem.Name = "likeToolStripMenuItem";
            this.likeToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.likeToolStripMenuItem.Text = "Like";
            // 
            // unlikeToolStripMenuItem
            // 
            this.unlikeToolStripMenuItem.Name = "unlikeToolStripMenuItem";
            this.unlikeToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.unlikeToolStripMenuItem.Text = "Unlike";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(350, 309);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(89, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 332);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tabBot);
            this.Controls.Add(this.imgLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpGram - User";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            this.tabBot.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.groupMain.ResumeLayout(false);
            this.groupMain.PerformLayout();
            this.tabTags.ResumeLayout(false);
            this.groupTags.ResumeLayout(false);
            this.groupTags.PerformLayout();
            this.tabComments.ResumeLayout(false);
            this.groupComment.ResumeLayout(false);
            this.groupComment.PerformLayout();
            this.tabLogs.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabData.ResumeLayout(false);
            this.tabImg.ResumeLayout(false);
            this.menuImages.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgLogo;
        private System.Windows.Forms.TabControl tabBot;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabTags;
        private System.Windows.Forms.GroupBox groupMain;
        private System.Windows.Forms.TabPage tabComments;
        private System.Windows.Forms.GroupBox groupTags;
        private System.Windows.Forms.GroupBox groupComment;
        private System.Windows.Forms.CheckBox chkComment;
        private System.Windows.Forms.CheckBox chkFollow;
        private System.Windows.Forms.CheckBox chkLike;
        private System.Windows.Forms.ListBox listTags;
        private System.Windows.Forms.Button btnRemoveTag;
        private System.Windows.Forms.Button btnAddTag;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TabPage tabLogs;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabImg;
        private System.Windows.Forms.TabPage tabData;
        private System.Windows.Forms.Button btnClearLogs;
        private System.Windows.Forms.RichTextBox txtLogs;
        private System.Windows.Forms.ListView listLikedImages;
        private System.Windows.Forms.Button btnRemoveComment;
        private System.Windows.Forms.Button btnAddComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.ListBox listComments;
        private System.Windows.Forms.ContextMenuStrip menuImages;
        private System.Windows.Forms.ToolStripMenuItem likeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unlikeToolStripMenuItem;
    }
}