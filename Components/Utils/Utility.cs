using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Note_Taker2._0.Components.Utils
{

    public static class Extensions
    {
        public static bool isWhiteSpace(this char c) => char.IsWhiteSpace(c);
        public static bool inQoutes(this char c) => c == '"';
        

    }
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

        public static string[] Tokenize(string data,char seperator)
        {
            StringBuilder sb = new();
            List<string> tokens = new();

            bool inqoute = false;

            foreach(char c in data)
            {
                if (c.inQoutes())
                {
                    inqoute = !inqoute;
                    continue;
                }

                if ((c.isWhiteSpace() || c.Equals(seperator)) && !inqoute)
                {
                    tokens.Add(sb.ToString());
                    sb.Clear();
                    continue;
                }

                sb.Append(c);
            }

            if(sb.Length > 0)
            {
                tokens.Add(sb.ToString());
                sb.Clear();
            }

            return tokens.ToArray();
        }


    }
}
