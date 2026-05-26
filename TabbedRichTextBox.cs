using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Note_Taker2._0
{
    public partial class TabbedRichTextBox : UserControl
    {
        public Dictionary<string, List<string>> Files { get; set; }

        public static TreeNode Node { get; set; }
        public TabbedRichTextBox()
        {
            InitializeComponent();
            Files = new();
        }

        private bool HasFileChanges(string key)
        {
            if (Files.ContainsKey(key))
            {
                return richTextBox1.Lines.SequenceEqual(Files[key]);
            }

            return false;
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            if (Node.Equals(null))
            {
                return;
            }

            ToolStripLabel ts = new ToolStripLabel()
            {
                Text = Node.Text,
                BackColor = Color.LightGray,
                Enabled = true
            };

            string filepath = Node.Tag.ToString();

            ts.Tag = filepath;
            MessageBox.Show(filepath);

            ts.Click += (s, e) =>
            {
                richTextBox1.Lines = File.ReadAllLines(filepath).ToArray();
            };

            ts_control.Items.Add(ts);

            if (Files.Count < 1) // Empty Dict guard clause
            {
                Files.Add(filepath, richTextBox1.Lines.ToList());
                return;
            }

            if (!Files.ContainsKey(filepath))
            {
                Files.Add(filepath, richTextBox1.Lines.ToList());
                return;
            }
            else
            {
                if (HasFileChanges(filepath))
                {
                    Files[filepath] = richTextBox1.Lines.ToList();
                }
            }

        }

        // Discontinued

    }
}
