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

        [Option('u', Required = false, Default = "http://localhost", HelpText = "Url Server Destiny")]
        public string UrlBase { get; set; }

        [Option('e', Required = false, Default = "/status/500", HelpText = "EndPoint Server Destiny")]
        public string EndPoint { get; set; }

        [Option('t', Required = false, Default = 10, HelpText = "Time Execution Seconds")]
        public int Interval { get; set; }

    }
}
