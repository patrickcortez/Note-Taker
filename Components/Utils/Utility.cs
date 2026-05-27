using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;


namespace Note_Taker2._0.Components.Utils
{
    internal static class Utility
    {
        public static bool FileModified(List<string> currentbuffer, List<string> rtb_lines)
        {
            return !currentbuffer.SequenceEqual(rtb_lines);
        }

        public static bool GitExists()
        {
            try
            {
                Process Git = new()
                {
                    StartInfo = new()
                    {
                        FileName = "cmd",
                        Arguments = "/c git --version",
                        CreateNoWindow = true,
                        UseShellExecute = false

                    }
                };

                Git.Start();
                Git.WaitForExit();

                int exitCode = Git.ExitCode;



                return exitCode == 0;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


    }
}
