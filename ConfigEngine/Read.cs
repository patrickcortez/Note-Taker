using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Note_Taker2._0.ConfigEngine
{

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
                File.Create(cwd).Dispose();
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
                    if (string.IsNullOrWhiteSpace(line))
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
                string[] token = line.Split('=');

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
