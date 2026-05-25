using Note_Taker2._0.Components;
using Note_Taker2._0.ConfigEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static Note_Taker2._0.Components.Utils.Utility;

namespace Note_Taker2._0
{
    
    public partial class Form1 : Form
    {
        string cwd,currentNodePath;
        List<FileContent> Files;
        List<string> currentbuffer;
        Panel popup;
        Form inputBox;
        Button btn_createfile;
        Button btn_creatfolder,btnpop,btnrename;
        int index1;
        readonly string Assets = "Assets";

        private string GetAssets()
        {
            return Path.Combine(AppContext.BaseDirectory,Assets);
        }

        private void UpdateTreeview()
        {
            FolderView.Nodes.Clear();
            InitializeTreeview();
        }

        public DialogResult Announce(string msg,MessageBoxButtons btn)
        {
            return MessageBox.Show(msg, "Note Taker", btn, MessageBoxIcon.Asterisk);
        }

        private void InitiateControls()
        {
            popup = new()
            {
                Size = new Size(200, 300),
                Name = "Note Taker Popup",
                Visible = false,
                BackColor = Color.DarkGray,
                ForeColor = Color.White,
                BorderStyle = BorderStyle.Fixed3D


            };



            inputBox = new() {
                Size = new(200, 200),
                Name = "InputBox",
                BackColor = Color.Azure,
                ControlBox = false,
                StartPosition = FormStartPosition.CenterScreen,
                Visible = false

            };


            TextBox input = new()
            {
                Size = new(190, 20),
                Location = new(5, 40),
                Name = "tb_in"

            };



            Label lb = new()
            {
                Text = "Enter Folder/File:",
                Location = new(5, 20),
                Visible = true,
                ForeColor = Color.Black,
                Font = new("Arial", 8)


            };

            Label header = new()
            {
                Text = "Input Box",
                Location = new(5, 5),
                Visible = true,
                ForeColor = Color.Black,
                Font = new("Arial", 8,FontStyle.Bold)

            };

            Button accept = new()
            {
                Text = "Ok",
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new(100, 40),
                Location = new(50, 100),
                DialogResult = DialogResult.OK
            };
            btn_createfile = new()
            {
                Text = "Create File",
                Enabled = true,
                Size = new(190, 30),
                Location = new(5, 0)
            };

            btn_createfile.Click += (s, e) => CreateFile_click(s,e);

            btn_creatfolder = new()
            {
                Text = "Create Folder",
                Enabled = true,
                Size = new(190, 30),
                Location = new(5, btn_createfile.Height + 5)
            };

            btn_creatfolder.Click += (s, e) => CreateFolder_Click(s, e);

            btnpop = new()
            {
                Text = "Delete",
                Enabled = true,
                Size = new(190, 30),
                Location = new(5,(btn_creatfolder.Height * 2) + 5)
            };

            btnpop.Click += (s, e) =>
            {
                try
                {
                    TreeNode Current = FolderView.SelectedNode;
                    string path;

                    if (Current.BackColor.Equals(Color.LightGray))
                    {
                        path = Current.Tag.ToString();

                        if (Directory.GetFileSystemEntries(path).Count() > 0)
                        {
                            DialogResult res = MessageBox.Show($"Are you sure you want to delete {Current.Name}", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (res.Equals(DialogResult.Yes))
                            {
                                Directory.Delete(path, true);
                                UpdateTreeview();
                                Announce($"{path} Deleted Successfully", MessageBoxButtons.OK);
                                return;
                            }
                            else
                            {
                                return;
                            }
                        }

                        Directory.Delete(path);
                        UpdateTreeview();
                        Announce($"{path} Deleted Successfully", MessageBoxButtons.OK);
                    }
                    else
                    {
                        path = Current.Tag.ToString();

                        File.Delete(path);
                        UpdateTreeview();
                        Announce($"{path} Deleted Successfully",MessageBoxButtons.OK);
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            btnrename = new()
            {
                Text = "Rename",
                Enabled = true,
                Size = new(190, 30),
                Location = new(5, (btnpop.Height * 3) + 5)
            };

            btnrename.Click += (s, e) =>
            {
                try
                {
                    TreeNode Current = FolderView.SelectedNode;
                    string oldname = Current.Tag.ToString(), newname;

                    if (inputBox.ShowDialog().Equals(DialogResult.OK))
                    {
                        Control tb = inputBox.Controls[index1];
                        newname = Path.Combine(Directory.GetParent(oldname).FullName, tb.Text);

                        MessageBox.Show(newname, "Debug");

                        if (Current.BackColor.Equals(Color.LightGray))
                        {
                            Directory.Move(oldname, newname);
                            UpdateTreeview();
                        }
                        else
                        {
                            File.Move(oldname, newname);
                            UpdateTreeview();
                        }
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            input.KeyDown += (s, e) =>
            {
                if (e.KeyCode.Equals(Keys.Enter))
                {
                    inputBox.DialogResult = DialogResult.OK;
                    inputBox.Close();
                   
                }
            };

            accept.Click += (s, e) =>
            {
                popup.Hide();
            
            };

            Control[] cons = { input, lb,accept,header };
            inputBox.Controls.AddRange(cons);

            index1 = inputBox.Controls.IndexOf(input);
        }

        public void CreateFile_click(object sender,EventArgs e)
        {
            try
            {
                TreeNode node = FolderView.SelectedNode;
                Control tb = inputBox.Controls[index1];
                
                string path = node.Tag.ToString();

                if (!Directory.Exists(path))
                {
                    return;
                }

                if (inputBox.ShowDialog() == DialogResult.OK){

                    File.Create(Path.Combine(path, tb.Text)).Dispose();
                    FolderView.Nodes.Clear();
                    InitializeTreeview(); //Update Tree view
                    
                }
            }catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message} | {ex.StackTrace}","Exception",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public void CreateFolder_Click(object sender,EventArgs e)
        {
            try
            {
                TreeNode node = FolderView.SelectedNode;
                Control tb = inputBox.Controls[index1];

                string path = node.Tag.ToString();

                if (!Directory.Exists(path))
                {
                    return;
                }

                if (inputBox.ShowDialog() == DialogResult.OK)
                {
                    Directory.CreateDirectory(Path.Combine(path, tb.Text));
                    FolderView.Nodes.Clear();
                    InitializeTreeview();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        

        public Form1()
        {
            try
            {
                if (!Directory.Exists(GetAssets())){
                    Directory.CreateDirectory(GetAssets());
                }

                this.Icon = new Icon(Path.Combine(GetAssets(), "NTIcon.ico"));

                Read reader = new();
                Terminal.SetWorkingDirectory(cwd);
                string shell = reader.GetValue("shell");
                //MessageBox.Show(shell, "Debug");

                Terminal.GetShell(shell);

                InitializeComponent();
                InitializeLabels();
                InitiateControls(); // Initiallize our Controls

                Files = new();
                currentbuffer = new();

                Controls.Add(popup);

                popup.Controls.AddRange(new[] { btn_createfile,btn_creatfolder,btnrename,btnpop });
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeTreeview()
        {
            TreeNode Root = new(Path.GetFileName(cwd));
            Root.Tag = cwd;
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
                Node.Tag = item;
                ParentNode.Nodes.Add(Node);

                if (File.GetAttributes(item).HasFlag(FileAttributes.Directory))
                {
                    Node.BackColor = Color.LightGray;
                    AddNode(item, Node);
                }
            }
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FolderView.Nodes.Clear();
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

                    terminal1.ChangeWorkingDirectory(open.SelectedPath);
                }

            }
            catch (DirectoryNotFoundException) { }
            
        }

        private void ShowPopup(MouseEventArgs e)
        {
            popup.Location = e.Location;
            popup.BringToFront();
            popup.Show();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                if (e.Location.X < this.Width && e.Location.Y < this.Height)
                {
                    ShowPopup(e);
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
                
                string fullpath = e.Node.Tag.ToString();

                if (currentbuffer.Count > 0 && rtb_editor.Lines.Count() > 0 && FileModified(currentbuffer, rtb_editor.Lines.ToList()))
                {
                    DialogResult res = MessageBox.Show("Do you want to save your changes?", "File Information",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                    if(res == DialogResult.Yes)
                    {
                        saveToolStripMenuItem.PerformClick();
                    }
                }


                if (File.GetAttributes(fullpath).HasFlag(FileAttributes.Directory))
                {
                  //  MessageBox.Show($"{e.Node.Text.ToString()} is not a File!", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (rtb_editor.Text.Length < 1)
                {
                    if (lbl_filename.Text == "None")
                    {
                        currentNodePath = e.Node.Tag.ToString();
                    }

                    lbl_filename.Text = e.Node.Text.ToString();
                    rtb_editor.LoadFile(fullpath,RichTextBoxStreamType.PlainText);
                    currentbuffer.AddRange(rtb_editor.Lines);
                }
                else
                {
                    bool shouldAdd = true;
                    currentbuffer.Clear();
                    if(Files.Count >= 1)
                    {
                        foreach(FileContent con in Files)
                        {
                            if(con.FilePath == fullpath)
                            {
                                shouldAdd = false;
                            }
                        }
                    }

                    if (shouldAdd.Equals(true))
                    {
                        Files.Add(new FileContent(lbl_filename.Text, rtb_editor.Lines.ToList(),currentNodePath));
                    }
                    
                    rtb_editor.Clear(); //Store then clear

                    lbl_filename.Text = e.Node.Text.ToString();

                   foreach(FileContent con in Files) // check if the file has an unsaved buffer.
                   {
                        if (fullpath.Equals(con.FilePath))
                        {
                            rtb_editor.Lines = con.GetLines().ToArray();
                            currentbuffer.AddRange(rtb_editor.Lines);
                            currentNodePath = fullpath;
                            return;
                        }
                   }

                    rtb_editor.LoadFile(fullpath, RichTextBoxStreamType.PlainText);
                    currentbuffer.AddRange(rtb_editor.Lines);
                    currentNodePath = fullpath;

                }
            }catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message} | {ex.StackTrace}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Files.Count < 1)
            {
                saveAllToolStripMenuItem.Enabled = false;
            }
            else
            {
                saveAllToolStripMenuItem.Enabled = true;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fullpath;
            if(FolderView.Nodes.Count < 1)
            {
                fullpath = Path.GetFullPath(lbl_filename.Text);
            }
            else
            {
                fullpath = FolderView.SelectedNode.Tag.ToString();
            }
            using(StreamWriter sw = new(fullpath,false))
            {
                foreach(string line in rtb_editor.Lines)
                {
                    sw.WriteLine(line);
                }
            }
        }

        private void editSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editSettingsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Process proc = new()
            {

                StartInfo = new()
                {
                    FileName = "notepad",
                    Arguments = Path.Combine(AppContext.BaseDirectory, "Assets", "NT.con"),
                }

            };

            proc.Start();
        }

        private void AboutMenuItem1_Click(object sender, EventArgs e)
        {
            string Msg = @"
                About:
            Note Taker is a open source, note taking tool developed in C#.
            Primarily for the goal of creating an alternative to existing tools
            Like Obsidian, VSCode and more. 

            Note Taker is under the License: GNU GPL v3.
            ";

            MessageBox.Show(Msg, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

                foreach (FileContent con in Files)
                {
                    using (StreamWriter sw = new(con.FilePath, false))
                    {
                        foreach (string line in con.GetLines())
                        {

                            sw.WriteLine(line);

                        }
                    }
                }

            Files.Clear();
            
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new()
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Choose File",
                CheckFileExists = true

            };
            file.ShowDialog();

            lbl_filename.Text = file.FileName;
            rtb_editor.LoadFile(Path.GetFullPath(file.FileName),RichTextBoxStreamType.PlainText);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (FileModified(currentbuffer,rtb_editor.Lines.ToList())) // Ensure that the file IS modified rather than basing it on string length
                {

                    DialogResult res = MessageBox.Show("Do you want to save your changes?", "File Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (res.Equals(DialogResult.Yes))
                    {
                        if (Files.Count > 0)
                        {

                            saveAllToolStripMenuItem.PerformClick();
                        }

                        saveToolStripMenuItem.PerformClick();
                    }
                }

                

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
