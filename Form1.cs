using Note_Taker2._0.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static Note_Taker2._0.Components.Utils.Utility;

namespace Note_Taker2._0
{
    
    public partial class Form1 : Form
    {
        string cwd;
        List<FileContent> Files;
        List<string> currentbuffer;
        Panel popup;
        Form inputBox;
        Button btn_createfile;
        Button btn_creatfolder;
        int index1;

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

            input.KeyDown += (s, e) =>
            {
                if (e.KeyCode.Equals(Keys.Enter))
                {
                    inputBox.Visible = false;
                   
                }
            };

            accept.Click += (s, e) =>
            {
                popup.Hide();
                input.Clear();
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

                    File.Create(Path.Combine(path, tb.Text));
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
            InitializeComponent();
            InitializeLabels();
            InitiateControls(); // Initiallize our Controls
            Files = new();
            currentbuffer = new();

            Controls.Add(popup);

            popup.Controls.Add(btn_createfile);
            popup.Controls.Add(btn_creatfolder);
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
                Node.Tag = Path.Combine(path,item);
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
                            if(con.FileName == lbl_filename.Text)
                            {
                                shouldAdd = false;
                            }
                        }
                    }

                    if (shouldAdd.Equals(true))
                    {
                        Files.Add(new FileContent(lbl_filename.Text, rtb_editor.Lines.ToList()));
                    }
                    
                    rtb_editor.Clear(); //Store then clear

                    lbl_filename.Text = e.Node.Text.ToString();

                   foreach(FileContent con in Files) // check if the file has an unsaved buffer.
                   {
                        if (lbl_filename.Text.Equals(con.FileName))
                        {
                            rtb_editor.Lines = con.GetLines().ToArray();
                            currentbuffer.AddRange(rtb_editor.Lines);
                            return;
                        }
                   }

                    rtb_editor.LoadFile(fullpath, RichTextBoxStreamType.PlainText);
                    currentbuffer.AddRange(rtb_editor.Lines);

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
                fullpath = FolderView.SelectedNode.FullPath;
            }
            using(StreamWriter sw = new(fullpath,false))
            {
                foreach(string line in rtb_editor.Lines)
                {
                    sw.WriteLine(line);
                }
            }
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new(FolderView.SelectedNode.FullPath, false))
            {
                foreach (FileContent con in Files)
                {
                    foreach (string line in con.GetLines())
                    {
                        sw.WriteLine(line);
                    }
                }
            }
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
                if (rtb_editor.Text.Length > 1)
                {

                    if(Files.Count > 0)
                    {
                        DialogResult rest = MessageBox.Show("Do you want to save your changes?", "File Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (rest.Equals(DialogResult.Yes))
                        {
                            saveAllToolStripMenuItem.PerformClick();
                        }
                        
                    }


                    DialogResult res = MessageBox.Show("Do you want to save your changes?", "File Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (res.Equals(DialogResult.Yes))
                    {
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
