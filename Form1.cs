using LibGit2Sharp;
using Note_Taker2._0.Components;
using Note_Taker2._0.ConfigEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static Note_Taker2._0.Components.Utils.Utility;
using Author = (string Name, string Email);

namespace Note_Taker2._0
{


    public partial class Form1 : Form
    {
        string cwd, currentNodePath;
        List<FileContent> Files;
        List<string> currentbuffer;
        Panel popup;
        Form inputBox;
        Button btn_createfile;
        Button btn_creatfolder, btnpop, btnrename;
        int lastexitcode;
        string shell;
        bool saveLogs,isRepo;
        Repository repo;
        Author auth;
        List<Theme> Themes;

        int index1;
        readonly string Assets = "Assets";

        private string GetAssets()
        {
            return Path.Combine(AppContext.BaseDirectory, Assets);
        }

        private void UpdateTreeview()
        {
            FolderView.Nodes.Clear();
            InitializeTreeview();
        }

        public DialogResult Announce(string msg, MessageBoxButtons btn)
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

            

            inputBox = new()
            {
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
                Font = new("Arial", 8, FontStyle.Bold)

            };

            Button accept = new()
            {
                Text = "Ok",
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
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

            btn_createfile.Click += (s, e) => CreateFile_click(s, e);

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
                Location = new(5, (btn_creatfolder.Height * 2) + 5)
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
                        Announce($"{path} Deleted Successfully", MessageBoxButtons.OK);
                    }
                }
                catch (Exception ex)
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
                }
                catch (Exception ex)
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

            Control[] cons = { input, lb, accept, header };
            inputBox.Controls.AddRange(cons);

            index1 = inputBox.Controls.IndexOf(input);
        }

        public void CreateFile_click(object sender, EventArgs e)
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

                    File.Create(Path.Combine(path, tb.Text)).Dispose();
                    FolderView.Nodes.Clear();
                    InitializeTreeview(); //Update Tree view

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} | {ex.StackTrace}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CreateFolder_Click(object sender, EventArgs e)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SetupLogs()
        {
            rtb_log.AppendText("Logs:" + Environment.NewLine);
        }

        public Form1()
        {
            Read reader = new();
            Terminal.SetWorkingDirectory(cwd);
            string xshell = reader.GetValue("shell");


            if (!string.IsNullOrEmpty(xshell))
            {
                shell = xshell;
                Terminal.GetShell(xshell);
            }
            


            InitializeComponent();
            this.DoubleBuffered = true;
 
        }

        private void InitializeTreeview()
        {
            TreeNode Root = new("📁 " + Path.GetFileName(cwd));
            Root.Tag = cwd;
            FolderView.Nodes.Add(Root);

            AddNode(cwd, Root);

            Root.Expand();
        }

        private void InitializeLabels()
        {
            lbl_dir.Text = "None";
            lbl_filename.Text = "None";
        }


        private void AddNode(string path, TreeNode ParentNode)
        {
            foreach (string item in Directory.GetFileSystemEntries(path))
            {
                string name = Path.GetFileName(item);
                bool isDir = File.GetAttributes(item).HasFlag(FileAttributes.Directory);

                if (isDir)
                {
                    name = "📁 " + name;
                }
                else
                {
                    if (Path.GetExtension(item).Equals(".exe"))
                    {
                        name = "⚙ " + name;
                    }
                    else
                    {
                        name = "🗎 " + name;
                    }
                }

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

        private string[] ListAllFiles(StatusEntry[] files)
        {
            List<string> xFiles = new();

            foreach(StatusEntry file in files)
            {
                xFiles.Add(Path.GetFileName(file.FilePath));
            }

            return xFiles.ToArray();

        }

        private void InitSplitPanes()
        {
            try
            {
                if (Directory.GetDirectories(cwd).Contains(Path.Combine(cwd, ".git")))
                {
                    RepositoryStatus rs = repo.RetrieveStatus();
                    StatusEntry[] files = rs.Untracked.ToArray();
                    string[] filecol = ListAllFiles(files);
                    list_branch.Items.AddRange(repo.Branches.ToArray());
                    list_commits.Items.AddRange(repo.Commits.ToArray());
                    list_status.Items.AddRange(filecol);
                    lbl_branchname.Text = repo.Head.FriendlyName;
                    isRepo = true;
                }
                else
                {
                    lbl_branchname.Text = $"Not a git Repository!";
                    isRepo = false;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void ClearPane()
        {
            list_branch.Items.Clear();
            list_commits.Items.Clear();
            list_status.Items.Clear();
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
                    FolderView.Nodes.Clear();
                    ClearPane();
                    cwd = open.SelectedPath;
                    if (Directory.Exists(cwd))
                    {
                        InitializeTreeview();
                        lbl_dir.Text = Directory.GetParent(cwd).Name;
                    }

                    terminal1.ChangeWorkingDirectory(open.SelectedPath);
                    repo = new(cwd);
                    InitSplitPanes();
                    rtb_log.AppendText($"> Opened Folder: {open.SelectedPath} " + Environment.NewLine);
                }

            }
            catch (DirectoryNotFoundException) {  }

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
                rtb_log.AppendText($"> Editing {fullpath}" + Environment.NewLine);

                if (currentbuffer.Count > 0 && rtb_editor.Lines.Count() > 0 && FileModified(currentbuffer, rtb_editor.Lines.ToList()))
                {
                    DialogResult res = MessageBox.Show("Do you want to save your changes?", "File Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (res == DialogResult.Yes)
                    {
                        saveToolStripMenuItem.PerformClick();

                    }
                }




                if (File.GetAttributes(fullpath).HasFlag(FileAttributes.Directory))
                {
                    //  MessageBox.Show($"{e.Node.Text.ToString()} is not a File!", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Path.GetExtension(fullpath).Equals(".exe"))
                {
                    //  MessageBox.Show(fullpath);
                    Process exe = new()
                    {
                        StartInfo = new()
                        {
                            FileName = fullpath,
                            UseShellExecute = true,
                            WindowStyle = ProcessWindowStyle.Normal
                        },

                    }; ;

                    exe.Start();
                    exe.WaitForExit();

                    lastexitcode = exe.ExitCode;

                    rtb_log.AppendText($"Process: {fullpath} | Exited with {lastexitcode}" + Environment.NewLine);

                    return;
                }

                if (rtb_editor.Text.Length < 1)
                {
                    if (lbl_filename.Text == "None")
                    {
                        currentNodePath = e.Node.Tag.ToString();
                    }

                    lbl_filename.Text = e.Node.Text.ToString();
                    rtb_editor.LoadFile(fullpath, RichTextBoxStreamType.PlainText);
                    currentbuffer.AddRange(rtb_editor.Lines);
                }
                else
                {
                    bool shouldAdd = true;
                    currentbuffer.Clear();
                    if (Files.Count >= 1)
                    {
                        foreach (FileContent con in Files)
                        {
                            if (con.FilePath == fullpath)
                            {
                                shouldAdd = false;
                            }
                        }
                    }

                    if (shouldAdd.Equals(true))
                    {
                        Files.Add(new FileContent(lbl_filename.Text, rtb_editor.Lines.ToList(), currentNodePath));
                    }

                    rtb_editor.Clear(); //Store then clear

                    lbl_filename.Text = e.Node.Text.ToString();

                    foreach (FileContent con in Files) // check if the file has an unsaved buffer.
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} | {ex.StackTrace}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void InitComboBox()
        {
            toolStripComboBox1.Text = "Sergei UI";
            InstalledFontCollection fonts = new();

            foreach (FontFamily font in fonts.Families)
            {
                toolStripComboBox1.Items.Add(font.Name);
            }
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
            {
                return;
            }

            if (!GitExists()) // Check if git exists
            {
                MessageBox.Show("Git is not installed, Repo Management is disabled","Git Check",MessageBoxButtons.OK,MessageBoxIcon.Information);
                rb_Repo.Enabled = false;
                rb_Repo.Visible = false;
            }

            isRepo = false; // Initiate variable.

            Read reader = new();


                SetupLogs();
                InitializeLabels();
                InitiateControls(); // Initiallize our Controls
                InitComboBox();
                InitThemes();

                if (!Directory.Exists(GetAssets()))
                {
                    Directory.CreateDirectory(GetAssets());
                }

                string iconPath = Path.Combine(GetAssets(), "NTIcon.ico");
                if (File.Exists(iconPath))
                {
                    this.Icon = new Icon(iconPath);
                }

                rtb_log.AppendText($">Shell: {shell} initiated..." + Environment.NewLine);

                string font = reader.GetValue("font");
                string sizeStr = reader.GetValue("size");
                string logs = reader.GetValue("saveLogs");
                string theme = reader.GetValue("theme");

                if(theme != "none")
                {
                    Theme current = FindTheme(theme);
                    ChangeControlThemes(current);
                }

                auth = new(reader.GetValue("gitName"), reader.GetValue("gitEmail"));    

                if (!string.IsNullOrEmpty(font) && int.TryParse(sizeStr, out int size))
                {
                    rtb_editor.Font = new(font, size);
                }

                if (!string.IsNullOrEmpty(logs))
                {
                    if (bool.TryParse(logs,out bool save))
                    {
                        saveLogs = save;
                    }
                }

                Files = new();
                currentbuffer = new();

                Controls.Add(popup);

                popup.Controls.AddRange(new[] { btn_createfile, btn_creatfolder, btnrename, btnpop });
                terminal1.tb_input.KeyDown += terminal1_KeyDown;
                
                
                
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Files.Count < 1)
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
            if (FolderView.Nodes.Count < 1)
            {
                fullpath = Path.GetFullPath(lbl_filename.Text);
            }
            else
            {
                fullpath = FolderView.SelectedNode.Tag.ToString();
            }
            using (StreamWriter sw = new(fullpath, false))
            {
                foreach (string line in rtb_editor.Lines)
                {
                    sw.WriteLine(line);
                }
            }

            rtb_log.AppendText($"> Saved {fullpath}" + Environment.NewLine);
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



        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you sure?", "Inquiry", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                string fontname = toolStripComboBox1.SelectedItem.ToString();
                rtb_editor.Font = new(fontname, 11);
            }
        }

        private void rb_terminal_CheckedChanged(object sender, EventArgs e)
        {
            terminal1.Show();
            rtb_log.Hide();
            splitContainer1.Hide();
        }

        private void rb_logs_CheckedChanged(object sender, EventArgs e)
        {
            rtb_log.Show();
            terminal1.Hide();
            splitContainer1.Hide();
            
        }


        int count = 1;

        private void terminal1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                rtb_log.AppendText($"CMD [{count}]> {terminal1.LastInput}" + Environment.NewLine);
                count++;
            }
        }



        private void rb_Repo_CheckedChanged(object sender, EventArgs e)
        {
            splitContainer1.Show();
            terminal1.Hide();
            rtb_log.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                repo.Network.Push(repo.Head);
            }catch(Exception) { }
        }

        private void button1_Click(object sender, EventArgs e) // Commit Button
        {
            try
            {
                if (string.IsNullOrEmpty(auth.Name) || string.IsNullOrEmpty(auth.Email))
                {
                    MessageBox.Show("Auth Name or Email cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!isRepo)
                {
                    return;
                }

                Commands.Stage(repo, "*");
                repo.Index.Write();
                Control tb = inputBox.Controls[index1];

                DialogResult res = inputBox.ShowDialog();

                if (res.Equals(DialogResult.OK))
                {
                    string msg = tb.Text;
                    Commit comm = repo.Commit(msg, new(new(auth.Name, auth.Email), DateTimeOffset.Now), new(new(auth.Name, auth.Email), DateTimeOffset.Now));

                    if (comm.IsMissing)
                    {
                        MessageBox.Show("Commit Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception) { }
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

                rtb_log.AppendText($"> Saved {con.FileName}" + Environment.NewLine);
            }

            Files.Clear();

        }

        private void ChangeControlThemes(Theme current)
        {
            rtb_editor.ChangeColors(current);
            FolderView.ChangeColors(current);
            menuStrip1.ChangeColors(current);
            this.ChangeColors(current);
        }
        
        private void themebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = themebox.SelectedItem.ToString();

            Theme current = FindTheme(item);

            ChangeControlThemes(current);
            
        }

        private Theme FindTheme(string target)
        {
            Theme match = new();
            foreach(Theme curr in Themes)
            {
                if (curr.ThemeName.Equals(target))
                {
                    match = curr;
                    break;
                }
            }

            return match;
        }

        private void InitThemes()
        {

            Theme[] themes =
                            {
                                new(Color.Black, Color.White, "Classic Dark"),
                                new(Color.White, Color.Black, "Classic Light"),

                                new(Color.FromArgb(30,30,30), Color.Gainsboro, "Soft Dark"),
                                new(Color.FromArgb(45,45,48), Color.WhiteSmoke, "Visual Studio"),

                                new(Color.MidnightBlue, Color.LightCyan, "Ocean"),
                                new(Color.DarkSlateGray, Color.Aquamarine, "Matrix"),

                                new(Color.DarkRed, Color.MistyRose, "Crimson"),
                                new(Color.Maroon, Color.PeachPuff, "Rosewood"),

                                new(Color.DarkGreen, Color.Honeydew, "Nature"),
                                new(Color.ForestGreen, Color.Beige, "Forest"),

                                new(Color.Indigo, Color.Lavender, "Purple Night"),
                                new(Color.DarkViolet, Color.White, "Violet"),

                                new(Color.FromArgb(20,20,20), Color.Lime, "Hacker"),
                                new(Color.Black, Color.DeepSkyBlue, "Cyber Blue"),

                                new(Color.SaddleBrown, Color.Wheat, "Retro Paper"),
                                new(Color.Peru, Color.Cornsilk, "Vintage"),

                                new(Color.Navy, Color.Gold, "Royal"),
                                new(Color.DarkSlateBlue, Color.Khaki, "Empire"),

                                new(Color.FromArgb(250,250,250), Color.FromArgb(40,40,40), "Modern Light"),
                                new(Color.FromArgb(15,15,15), Color.FromArgb(220,220,220), "Modern Dark")
                            };

            Themes = new(themes);
            string[] ThemeNames = CountThemeNames(themes);
            themebox.Items.AddRange(ThemeNames);

        }

        private string[] CountThemeNames(Theme[] themes)
        {
            List<string> tns = new(); 
            foreach(Theme theme in themes)
            {
                tns.Add(theme.ThemeName);
            }

            return tns.ToArray();
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
            rtb_editor.LoadFile(Path.GetFullPath(file.FileName), RichTextBoxStreamType.PlainText);

            rtb_log.AppendText($"Opened File: {file.FileName} " + Environment.NewLine);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (FileModified(currentbuffer, rtb_editor.Lines.ToList())) // Ensure that the file IS modified rather than basing it on string length
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

                if (saveLogs)
                {

                    
                    string now = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

                    string logfolder = Path.Combine(Environment.GetEnvironmentVariable("APPDATA"), "NoteTaker", "Logs");

                    if (!Directory.Exists(logfolder))
                    {
                        Directory.CreateDirectory(logfolder);
                    }

                    string logpath = Path.Combine(logfolder, $"Log-{now}.log");

                    MessageBox.Show(logpath);

                    File.Create(logpath).Close();

                    using(StreamWriter sw = new(logpath,true))
                    {
                        foreach(string line in rtb_log.Lines)
                        {
                            sw.WriteLine(line);
                        }
                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }

    public static class Extension
    {
        public static void ChangeColors(this Control? ctr, Theme theme)
        {
            if (ctr != null)
            {
                if (theme.ForeColor != null)
                {
                    ctr.ForeColor = theme.ForeColor;
                }

                if (theme.BackColor != null)
                {
                    ctr.BackColor = theme.BackColor;
                }
            }
        }




    }

    public struct Theme
    {
        public Color ForeColor { get; set; }
        public Color BackColor { get; set; }

        public string ThemeName;

        public Theme(Color FC, Color BC, string TN)
        {
            ForeColor = FC;
            BackColor = BC;
            ThemeName = TN;
        }

        public override string ToString() => ThemeName;
    }
}
