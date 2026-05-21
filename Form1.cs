using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Note_Taker2._0
{
    public partial class Form1 : Form
    {
        string cwd;
        Panel popup;
        Button btn_createfile;
        Button btn_creatfolder;

        private void InitiateControls()
        {
            btn_createfile = new()
            {
                Text = "Create File",
                Enabled = true,
                Size = new(190, 30),
                Location = new(5, 0)
            };

            btn_creatfolder = new()
            {
                Text = "Create Folder",
                Enabled = true,
                Size = new(190, 30),
                Location = new(5, btn_createfile.Height + 5)
            };


            popup = new()
            {
                Size = new Size(200, 300),
                Name = "Note Taker Popup",
                Visible = false,
                BackColor = Color.DarkGray,
                ForeColor = Color.White,
                BorderStyle = BorderStyle.Fixed3D
               
               
            };
        }

        public Form1()
        {
            InitializeComponent();
            InitializeLabels();
            InitiateControls(); // Initiallize our Controls

            Controls.Add(popup);

            popup.Controls.Add(btn_createfile);
            popup.Controls.Add(btn_creatfolder);
        }

        private void InitializeTreeview()
        {
            TreeNode Root = new(cwd);
            FolderView.Nodes.Add(Root);

            AddNode(cwd,Root);

            Root.Expand();

            
        }

        private void InitializeLabels()
        {
            lbl_dir.Text = "None";
            lbl_filename.Text = "None";
        }


        private void AddNode(string path,TreeNode ParentNode)
        {
            foreach(string item in Directory.GetFileSystemEntries(path))
            {
                string name = Path.GetFileName(item);

                TreeNode Node = new(name);
                ParentNode.Nodes.Add(Node);

                if (File.GetAttributes(item).HasFlag(FileAttributes.Directory))
                {
                    AddNode(item, Node);
                }
            }
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog open = new FolderBrowserDialog
                {
                    ShowNewFolderButton = true
                };

                DialogResult res = open.ShowDialog();

                if (res.Equals(DialogResult.OK))
                {
                    cwd = open.SelectedPath;
                    if (Directory.Exists(cwd))
                    {
                        InitializeTreeview();
                        lbl_dir.Text = Directory.GetParent(cwd).Name;
                    }
                }

            }
            catch (DirectoryNotFoundException) { }
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                if (e.Location.X < this.Width && e.Location.Y < this.Height)
                {
                    popup.Location = e.Location;
                    popup.BringToFront();
                    popup.Show();
                }
            }
            else
            {
                popup.Hide();
            }
        }

        private void FolderView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                string fullpath = e.Node.FullPath;
                if (File.GetAttributes(fullpath).HasFlag(FileAttributes.Directory))
                {
                  //  MessageBox.Show($"{e.Node.Text.ToString()} is not a File!", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (rtb_editor.Text.Length < 1)
                {
                    lbl_filename.Text = e.Node.Text.ToString();
                    rtb_editor.LoadFile(fullpath,RichTextBoxStreamType.PlainText);
                }
                else
                {
                    rtb_editor.Clear(); // we're clearing for now, but later we are saving the changes in a list of line buffers because its 9:45 Pm and I need to sleep so yeah

                    lbl_filename.Text = e.Node.Text.ToString();
                    rtb_editor.LoadFile(fullpath, RichTextBoxStreamType.PlainText);
                    
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
