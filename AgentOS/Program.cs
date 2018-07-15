using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AgentOS
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var st = new Startup();

            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(opts => st.StartInputFlowMonitor(opts))
                .WithNotParsed<Options>((errs) => st.ErrorInput(errs));

        }
    }
}