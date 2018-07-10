using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentOS
{
    public class Options
    {

        [Option('s', Default = true, HelpText = "Start Monitoring System")]
        public bool Start { get; set; }

        [Option('u', Required = true, HelpText = "Url Server Destiny")]
        public string UrlBase { get; set; }

        [Option('e', Required = true, HelpText = "EndPoint Server Destiny")]
        public string EndPoint { get; set; }

        [Option('t', Required = true, HelpText = "Time Execution Seconds")]
        public int Interval { get; set; }

    }
}
