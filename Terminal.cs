using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Note_Taker2._0
{
    public partial class Terminal : UserControl
    {
        private Process Shell;
        private static string WorkingDirectory;
        static string shell { get; set; }


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
            shell = Xshell;
        }

        private bool NLFONT()
        {
            InstalledFontCollection fonts = new();

            foreach(FontFamily font in fonts.Families)
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

            tb_input.KeyDown += (s, e) => Input_KeyDown(s, e);
            tb_input.TextChanged += (s, e) => Input_TextChange(s, e);

            Console.Font = NLFONT() ? new("JetBrainsMonoNLNerdFont-Light", 11) : new("Sergei UI",8);


            Shell = new()
            {
                StartInfo = new()
                {
                    FileName = !string.IsNullOrEmpty(shell) ? shell : "cmd",
                    Arguments = "-NoProfile",
                    UseShellExecute = false,
                    WorkingDirectory = WorkingDirectory != String.Empty ? WorkingDirectory : Environment.GetEnvironmentVariable("USERPROFILE"),
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
                Console.Invoke(() => {

                    Console.AppendText(e.Data + Environment.NewLine);
                
                });
            };

            Shell.ErrorDataReceived += (s, e) =>
            {
                Console.Invoke(() => {

                    Console.AppendText("[ERROR]> " + e.Data + Environment.NewLine);
                });
            };

            Shell.Start();

            Shell.BeginOutputReadLine();
            Shell.BeginErrorReadLine();

        }

        internal void ChangeWorkingDirectory(string dir)
        {
            Shell.StandardInput.WriteLine($"cd {dir}");
            Shell.StandardInput.Flush();
        }



        private void Input_KeyDown(object sender,KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (tb_input.Text.Equals("exit"))
                {
                    MessageBox.Show("Cannot Exit Root Terminal Session!", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }

                Shell.StandardInput.WriteLine(tb_input.Text);
                Shell.StandardInput.Flush();

                if (tb_input.Text.Equals("cls") || tb_input.Text.Equals("clear"))
                {
                    Console.Clear();
                }


                tb_input.Clear();
            }
        }

        private void Input_TextChange(object sender,EventArgs e)
        {

        }

    }
}
