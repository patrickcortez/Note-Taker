using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;


namespace Note_Taker2._0.Components.Utils
{
    internal static class Utility
    {
        public static bool FileModified(List<string> currentbuffer,List<string> rtb_lines)
        {
            return !currentbuffer.SequenceEqual(rtb_lines);
        }

       
    }
}
