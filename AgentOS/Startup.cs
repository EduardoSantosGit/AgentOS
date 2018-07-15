using AgentOS.Services;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AgentOS
{
    public class Startup
    {
        public void StartInputFlowMonitor(Options options)
        {
            using (var cts = new CancellationTokenSource())
            {
                Console.CancelKeyPress += (sender, eventArgs) =>
                {
                    cts.Cancel();

                    eventArgs.Cancel = true;
                };

                var timer = new Timer(
                   e => TaskMonitorSystem(options.UrlBase, options.EndPoint),
                   "",
                   TimeSpan.Zero,
                   TimeSpan.FromSeconds(5)
                );

                while (cts.IsCancellationRequested == false)
                    Thread.Sleep(1000);
            }
        }

        public void TaskMonitorSystem(string urlBase, string urlEndPoint)
        {
            var service = new WindowsService(urlBase, urlEndPoint);

            service.OnMonitorServer();
        }


        public void ErrorInput(IEnumerable<Error> errors)
        {

        }
    }
}
