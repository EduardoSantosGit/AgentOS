using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentOS.Common
{
    public static class Formatter
    {

        public static string FormatSpeedNet(string value)
        {
            var speed = Convert.ToInt64(value) / 8;

            int KB = 1024;
            int MB = KB * KB;
            int GB = MB * KB;
            long TB = (long)GB * KB;

            if (speed >= TB)
                value = $"{(speed / TB)}TB";
            else if (speed >= GB)
                value = $"{(speed / GB)}GB";
            else if (speed >= MB)
                value = $"{(speed / MB)}MB";
            else if (speed >= KB)
                value = $"{(speed / KB)}KB";
            else
                value = $"{(speed / KB)}Bytes";

            return value;
        }
    }
}
