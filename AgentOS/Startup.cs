using AgentOS.Services;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentOS
{
    public class Startup
    {

        public void StartInputFlowMonitor(Options options)
        {

            if (options.Start)
            {
                var service = new WindowsService(options.UrlBase, options.EndPoint);
            }

        }

        public void ErrorInput(IEnumerable<Error> errors)
        {

        }

        public void CronJob(int interval)
        {

        }

    }
}
