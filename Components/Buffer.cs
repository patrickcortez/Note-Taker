using System.Collections.Generic;
using System.Linq;

namespace Note_Taker2._0.Components
{
    internal struct FileContent
    {
        private List<string> FileBuffer;
        public string FileName;
        public string FilePath;

        public FileContent(string Name, List<string> Buffer, string FileP)
        {
            FileName = Name;
            FileBuffer = new(Buffer);
            FilePath = FileP;
        }

        public void AddLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                return;
            }

            FileBuffer.Add(line);
        }

        public void AddLines(string[] lines)
        {
            if (lines.Count() < 2)
            {
                return;
            }

            FileBuffer.AddRange(lines);
        }

        private bool LineExists(string line)
        {
            foreach (string l in FileBuffer)
            {
                if (l.Equals(line))
                {
                    return true;
                }
            }

            return false;
        }

        public bool PopLine(string line)
        {
            if (LineExists(line))
            {
                FileBuffer.Remove(line);
                return true;
            }

            return false;
        }

        public List<string> GetLines()
        {
            return FileBuffer;
        }
    }


}
