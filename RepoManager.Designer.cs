namespace Note_Taker2._0
{
    partial class RepoManager
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.list_status = new System.Windows.Forms.ListBox();
            this.list_branches = new System.Windows.Forms.ListBox();
            this.list_commits = new System.Windows.Forms.ListBox();
            this.lbl_reponame = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Silver;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.list_status, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.list_branches, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.list_commits, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 34);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(989, 257);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // list_status
            // 
            this.list_status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_status.FormattingEnabled = true;
            this.list_status.ItemHeight = 16;
            this.list_status.Location = new System.Drawing.Point(3, 3);
            this.list_status.Name = "list_status";
            this.list_status.Size = new System.Drawing.Size(488, 122);
            this.list_status.TabIndex = 0;
            // 
            // list_branches
            // 
            this.list_branches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_branches.FormattingEnabled = true;
            this.list_branches.ItemHeight = 16;
            this.list_branches.Location = new System.Drawing.Point(497, 3);
            this.list_branches.Name = "list_branches";
            this.list_branches.Size = new System.Drawing.Size(489, 122);
            this.list_branches.TabIndex = 1;
            // 
            // list_commits
            // 
            this.list_commits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_commits.FormattingEnabled = true;
            this.list_commits.ItemHeight = 16;
            this.list_commits.Location = new System.Drawing.Point(3, 131);
            this.list_commits.Name = "list_commits";
            this.list_commits.Size = new System.Drawing.Size(488, 123);
            this.list_commits.TabIndex = 2;
            // 
            // lbl_reponame
            // 
            this.lbl_reponame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_reponame.AutoSize = true;
            this.lbl_reponame.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_reponame.Location = new System.Drawing.Point(3, 8);
            this.lbl_reponame.Name = "lbl_reponame";
            this.lbl_reponame.Size = new System.Drawing.Size(58, 22);
            this.lbl_reponame.TabIndex = 1;
            this.lbl_reponame.Text = "label1";
            // 
            // RepoManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Controls.Add(this.lbl_reponame);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RepoManager";
            this.Size = new System.Drawing.Size(995, 294);
            this.Load += new System.EventHandler(this.RepoManager_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox list_status;
        private System.Windows.Forms.ListBox list_branches;
        private System.Windows.Forms.Label lbl_reponame;
        private System.Windows.Forms.ListBox list_commits;
    }
}
