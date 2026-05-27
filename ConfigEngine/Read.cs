using Note_Taker2._0.Components.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace Note_Taker2._0.ConfigEngine
{
    
    public static class Extensions
    {
        public static bool isWhiteSpaceorNull(this string? str) => string.IsNullOrWhiteSpace(str);
    }
    internal class Read
    {
        readonly string configfile = "NT.con";
        List<string> Lines; // File Buffer
        Dictionary<string, string> configs;
        string cwd;

        public Read()
        {
            cwd = Path.Combine(AppContext.BaseDirectory, "Assets", configfile);

            if (!File.Exists(cwd))
            {
                string[] config = @"    
                shell=powershell
                font=SergeiUI
                size=11
                saveLogs=true
                gitName=none
                gitEmail=none
                "
                    .Split('\n').Select(line => line.Trim()).ToArray();
                File.Create(cwd).Dispose();
                File.WriteAllLines(cwd, config);
            }

            Lines = new();
            configs = new();

            ReadLines();
        }

        private void ReadLines()
        {
            using (StreamReader sr = new(cwd))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.isWhiteSpaceorNull())
                    {
                        continue;
                    }

                    // MessageBox.Show($"Line: {line}", "Debug");
                    Lines.Add(line);
                }
            }


            InterpretLines();
        }

        private void InterpretLines()
        {
            StringBuilder key = new(), value = new();

            foreach (string line in Lines)
            {
                string[] token = Utility.Tokenize(line,'=');

                if (token.Count() > 0)
                {

                    if (key.Length > 0 || value.Length > 0)
                    {
                        key.Clear(); value.Clear();
                    }



                    key.Append(token[0]);
                    value.Append(token[1]);

                    //  MessageBox.Show($"Key:{key.ToString()} , Value: {value.ToString()}", "Debug");

                    configs.Add(key.ToString(), value.ToString());
                }
            }
        }


        internal string GetValue(string key)
        {
            if (configs.Count < 1)
            {
                MessageBox.Show("No configs loaded", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return string.Empty;
            }
            return configs[key];
        }
    }
}
