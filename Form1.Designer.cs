using System.Runtime.CompilerServices;

namespace Note_Taker2._0
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.appearanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.themebox = new System.Windows.Forms.ToolStripComboBox();
            this.lbl_filename = new System.Windows.Forms.Label();
            this.FolderView = new System.Windows.Forms.TreeView();
            this.lbl_dir = new System.Windows.Forms.Label();
            this.rtb_editor = new System.Windows.Forms.RichTextBox();
            this.rtb_log = new System.Windows.Forms.RichTextBox();
            this.rb_terminal = new System.Windows.Forms.RadioButton();
            this.rb_logs = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_Repo = new System.Windows.Forms.RadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_branchname = new System.Windows.Forms.Label();
            this.list_commits = new System.Windows.Forms.ListBox();
            this.list_branch = new System.Windows.Forms.ListBox();
            this.list_status = new System.Windows.Forms.ListBox();
            this.terminal1 = new Note_Taker2._0.Terminal();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Silver;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.appearanceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1522, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFolderToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAllToolStripMenuItem,
            this.toolStripSeparator2});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.saveAllToolStripMenuItem.Text = "Save All";
            this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.saveAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(171, 6);
            // 
            // appearanceToolStripMenuItem
            // 
            this.appearanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editSettingsToolStripMenuItem,
            this.AboutMenuItem1,
            this.toolStripComboBox1,
            this.themebox});
            this.appearanceToolStripMenuItem.Name = "appearanceToolStripMenuItem";
            this.appearanceToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.appearanceToolStripMenuItem.Text = "Configs";
            // 
            // editSettingsToolStripMenuItem
            // 
            this.editSettingsToolStripMenuItem.Name = "editSettingsToolStripMenuItem";
            this.editSettingsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.editSettingsToolStripMenuItem.Text = "Edit Settings";
            this.editSettingsToolStripMenuItem.Click += new System.EventHandler(this.editSettingsToolStripMenuItem_Click_1);
            // 
            // AboutMenuItem1
            // 
            this.AboutMenuItem1.Name = "AboutMenuItem1";
            this.AboutMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.AboutMenuItem1.Text = "About";
            this.AboutMenuItem1.Click += new System.EventHandler(this.AboutMenuItem1_Click);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 28);
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // themebox
            // 
            this.themebox.Name = "themebox";
            this.themebox.Size = new System.Drawing.Size(121, 28);
            this.themebox.SelectedIndexChanged += new System.EventHandler(this.themebox_SelectedIndexChanged);
            // 
            // lbl_filename
            // 
            this.lbl_filename.AutoSize = true;
            this.lbl_filename.Location = new System.Drawing.Point(234, 34);
            this.lbl_filename.Name = "lbl_filename";
            this.lbl_filename.Size = new System.Drawing.Size(44, 16);
            this.lbl_filename.TabIndex = 2;
            this.lbl_filename.Text = "label1";
            // 
            // FolderView
            // 
            this.FolderView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FolderView.BackColor = System.Drawing.Color.Gray;
            this.FolderView.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FolderView.ForeColor = System.Drawing.Color.Black;
            this.FolderView.HotTracking = true;
            this.FolderView.Location = new System.Drawing.Point(15, 54);
            this.FolderView.Name = "FolderView";
            this.FolderView.Size = new System.Drawing.Size(184, 338);
            this.FolderView.TabIndex = 3;
            this.FolderView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.FolderView_NodeMouseClick);
            // 
            // lbl_dir
            // 
            this.lbl_dir.AutoSize = true;
            this.lbl_dir.Location = new System.Drawing.Point(12, 34);
            this.lbl_dir.Name = "lbl_dir";
            this.lbl_dir.Size = new System.Drawing.Size(44, 16);
            this.lbl_dir.TabIndex = 4;
            this.lbl_dir.Text = "label1";
            // 
            // rtb_editor
            // 
            this.rtb_editor.AcceptsTab = true;
            this.rtb_editor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_editor.BackColor = System.Drawing.Color.Gray;
            this.rtb_editor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb_editor.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_editor.ForeColor = System.Drawing.Color.White;
            this.rtb_editor.Location = new System.Drawing.Point(237, 53);
            this.rtb_editor.Name = "rtb_editor";
            this.rtb_editor.Size = new System.Drawing.Size(1273, 339);
            this.rtb_editor.TabIndex = 0;
            this.rtb_editor.Text = "";
            // 
            // rtb_log
            // 
            this.rtb_log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_log.BackColor = System.Drawing.Color.DimGray;
            this.rtb_log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb_log.ForeColor = System.Drawing.Color.White;
            this.rtb_log.Location = new System.Drawing.Point(0, 441);
            this.rtb_log.Name = "rtb_log";
            this.rtb_log.ReadOnly = true;
            this.rtb_log.Size = new System.Drawing.Size(1522, 316);
            this.rtb_log.TabIndex = 8;
            this.rtb_log.Text = "";
            // 
            // rb_terminal
            // 
            this.rb_terminal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_terminal.AutoSize = true;
            this.rb_terminal.BackColor = System.Drawing.Color.Silver;
            this.rb_terminal.Checked = true;
            this.rb_terminal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_terminal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rb_terminal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_terminal.Location = new System.Drawing.Point(6, 18);
            this.rb_terminal.Name = "rb_terminal";
            this.rb_terminal.Size = new System.Drawing.Size(98, 21);
            this.rb_terminal.TabIndex = 6;
            this.rb_terminal.TabStop = true;
            this.rb_terminal.Text = "Terminal";
            this.rb_terminal.UseVisualStyleBackColor = false;
            this.rb_terminal.CheckedChanged += new System.EventHandler(this.rb_terminal_CheckedChanged);
            // 
            // rb_logs
            // 
            this.rb_logs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_logs.AutoSize = true;
            this.rb_logs.BackColor = System.Drawing.Color.Silver;
            this.rb_logs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_logs.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rb_logs.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_logs.Location = new System.Drawing.Point(110, 19);
            this.rb_logs.Name = "rb_logs";
            this.rb_logs.Size = new System.Drawing.Size(71, 21);
            this.rb_logs.TabIndex = 7;
            this.rb_logs.Text = "Logs";
            this.rb_logs.UseVisualStyleBackColor = false;
            this.rb_logs.CheckedChanged += new System.EventHandler(this.rb_logs_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.rb_Repo);
            this.groupBox1.Controls.Add(this.rb_logs);
            this.groupBox1.Controls.Add(this.rb_terminal);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 398);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1522, 45);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // rb_Repo
            // 
            this.rb_Repo.AutoSize = true;
            this.rb_Repo.Location = new System.Drawing.Point(187, 18);
            this.rb_Repo.Name = "rb_Repo";
            this.rb_Repo.Size = new System.Drawing.Size(104, 20);
            this.rb_Repo.TabIndex = 8;
            this.rb_Repo.TabStop = true;
            this.rb_Repo.Text = "Repository";
            this.rb_Repo.UseVisualStyleBackColor = true;
            this.rb_Repo.CheckedChanged += new System.EventHandler(this.rb_Repo_CheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 441);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_branchname);
            this.splitContainer1.Panel1.Controls.Add(this.list_commits);
            this.splitContainer1.Panel1.Controls.Add(this.list_branch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.list_status);
            this.splitContainer1.Size = new System.Drawing.Size(1522, 316);
            this.splitContainer1.SplitterDistance = 507;
            this.splitContainer1.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(414, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 24);
            this.button2.TabIndex = 5;
            this.button2.Text = "Push";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(307, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 24);
            this.button1.TabIndex = 4;
            this.button1.Text = "Commit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Commits:";
            // 
            // lbl_branchname
            // 
            this.lbl_branchname.AutoSize = true;
            this.lbl_branchname.Location = new System.Drawing.Point(12, 16);
            this.lbl_branchname.Name = "lbl_branchname";
            this.lbl_branchname.Size = new System.Drawing.Size(44, 16);
            this.lbl_branchname.TabIndex = 2;
            this.lbl_branchname.Text = "label1";
            // 
            // list_commits
            // 
            this.list_commits.FormattingEnabled = true;
            this.list_commits.ItemHeight = 16;
            this.list_commits.Location = new System.Drawing.Point(0, 205);
            this.list_commits.Name = "list_commits";
            this.list_commits.Size = new System.Drawing.Size(504, 100);
            this.list_commits.TabIndex = 1;
            // 
            // list_branch
            // 
            this.list_branch.FormattingEnabled = true;
            this.list_branch.ItemHeight = 16;
            this.list_branch.Location = new System.Drawing.Point(0, 35);
            this.list_branch.Name = "list_branch";
            this.list_branch.Size = new System.Drawing.Size(504, 148);
            this.list_branch.TabIndex = 0;
            // 
            // list_status
            // 
            this.list_status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_status.FormattingEnabled = true;
            this.list_status.ItemHeight = 16;
            this.list_status.Location = new System.Drawing.Point(0, 0);
            this.list_status.Name = "list_status";
            this.list_status.Size = new System.Drawing.Size(1011, 316);
            this.list_status.TabIndex = 1;
            // 
            // terminal1
            // 
            this.terminal1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.terminal1.AutoScroll = true;
            this.terminal1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.terminal1.BackColor = System.Drawing.Color.Transparent;
            this.terminal1.Location = new System.Drawing.Point(0, 441);
            this.terminal1.Name = "terminal1";
            this.terminal1.Size = new System.Drawing.Size(1522, 316);
            this.terminal1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1522, 752);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_dir);
            this.Controls.Add(this.FolderView);
            this.Controls.Add(this.lbl_filename);
            this.Controls.Add(this.rtb_editor);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.terminal1);
            this.Controls.Add(this.rtb_log);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "NoteTaker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private System.Windows.Forms.Label lbl_filename;
        private System.Windows.Forms.TreeView FolderView;
        private System.Windows.Forms.Label lbl_dir;
        private System.Windows.Forms.RichTextBox rtb_editor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem appearanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.RichTextBox rtb_log;
        private Terminal terminal1;
        private System.Windows.Forms.RadioButton rb_terminal;
        private System.Windows.Forms.RadioButton rb_logs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_Repo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox list_commits;
        private System.Windows.Forms.ListBox list_branch;
        private System.Windows.Forms.ListBox list_status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_branchname;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripComboBox themebox;
    }
}

