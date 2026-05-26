using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Note_Taker2._0
{
    public partial class RepoManager : UserControl
    {
        internal static string RepoPath { get; private set; }
        Repository repo;
         
        public RepoManager()
        {
            InitializeComponent();
      
        }

       

        private void RepoManager_Load(object sender, EventArgs e)
        {

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            if (string.IsNullOrEmpty(RepoPath))
                return;

            lbl_reponame.Text = Path.GetDirectoryName(RepoPath);
            repo = new(RepoPath);

            if (repo.RetrieveStatus().Equals(FileStatus.Nonexistent))
            {
                MessageBox.Show("The specified path does not contain a git repository.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
            }

            list_branches.Items.Clear();
            list_commits.Items.Clear();
            list_status.Items.Clear();
            
            list_branches.Items.AddRange(repo.Branches.ToArray());
            list_commits.Items.AddRange(repo.Commits.ToArray());
            list_status.Items.AddRange(repo.RetrieveStatus().ToArray());
        }
    }
}
