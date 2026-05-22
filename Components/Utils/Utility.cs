using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
