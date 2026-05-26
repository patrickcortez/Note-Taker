using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Note_Taker2._0
{
    public partial class Terminal : UserControl
    {
        private Process Shell;
        private static string WorkingDirectory;
        static string shell { get; set; }
        internal string LastInput { get; private set; }


        internal static void SetWorkingDirectory(string Dir)
        {
            if (!Directory.Exists(Dir))
            {
                return;
            }

            WorkingDirectory = Dir;
        }

        internal static void GetShell(string Xshell)
        {
            //MessageBox.Show(Xshell, "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);
            shell = Xshell;
        }

        private bool NLFONT()
        {
            InstalledFontCollection fonts = new();

            foreach (FontFamily font in fonts.Families)
            {
                if (font.Name.Equals("JetBrains Mono"))
                {
                    return true;
                }
            }

            MessageBox.Show("JetBrainsMonoNL Nerd Font not installed! Reverting to Sergei UI", "Warning");

            return false;
        }

        public Terminal()
        {
            InitializeComponent();

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;

            tb_input.KeyDown += (s, e) => Input_KeyDown(s, e);
            tb_input.TextChanged += (s, e) => Input_TextChange(s, e);

            Console.Font = NLFONT() ? new("JetBrainsMonoNLNerdFont-Light", 11) : new("Sergei UI", 8);

           // MessageBox.Show(shell, "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Shell = new()
            {
                StartInfo = new()
                {
                    FileName = !string.IsNullOrEmpty(shell) ? shell : "cmd",
                    Arguments = "-NoProfile",
                    UseShellExecute = false,
                    WorkingDirectory = string.IsNullOrEmpty(WorkingDirectory) ? Environment.GetEnvironmentVariable("USERPROFILE") : WorkingDirectory,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    StandardOutputEncoding = Encoding.UTF8,
                    StandardErrorEncoding = Encoding.UTF8,
                    CreateNoWindow = true
                }


            };

            Shell.OutputDataReceived += (s, e) =>
            {
                if (e.Data == null) return;
                if (!Console.IsHandleCreated || Console.IsDisposed) return;
                try
                {
                    Console.BeginInvoke(new Action(() =>
                    {
                        if (!Console.IsDisposed) Console.AppendText(e.Data + Environment.NewLine);
                    }));
                } catch { }
            };

            Shell.ErrorDataReceived += (s, e) =>
            {
                if (e.Data == null) return;
                if (!Console.IsHandleCreated || Console.IsDisposed) return;
                try
                {
                    Console.BeginInvoke(new Action(() =>
                    {
                        if (!Console.IsDisposed) Console.AppendText("[ERROR]> " + e.Data + Environment.NewLine);
                    }));
                } catch { }
            };

            

            this.Load += (s, e) => 
            {
                if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;
                Shell.Start();
                Shell.BeginOutputReadLine();
                Shell.BeginErrorReadLine();
            };

        }


        internal void ChangeWorkingDirectory(string dir)
        {
            Shell.StandardInput.WriteLine($"cd {dir}");
            Shell.StandardInput.Flush();
        }



        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (tb_input.Text.Equals("exit"))
                {
                    MessageBox.Show("Cannot Exit Root Terminal Session!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                LastInput = tb_input.Text;
                Shell.StandardInput.WriteLine(tb_input.Text);
                Shell.StandardInput.Flush();

                if (tb_input.Text.Equals("cls") || tb_input.Text.Equals("clear"))
                {
                    Console.Clear();
                }


                tb_input.Clear();
            }
        }

        private void Input_TextChange(object sender, EventArgs e)
        {

        }

    }
}
