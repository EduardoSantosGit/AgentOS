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
            //var st = new Startup();

            //Parser.Default.ParseArguments<Options>(args)
            //    .WithParsed<Options>(opts => st.StartInputFlowMonitor(opts))
            //    .WithNotParsed<Options>((errs) => st.ErrorInput(errs));


            using (var cts = new CancellationTokenSource())
            {
                Console.CancelKeyPress += (sender, eventArgs) =>
                {
                    cts.Cancel();
                    
                    eventArgs.Cancel = true;
                };

                var timer = new Timer(
                   e => Console.WriteLine("Action started at: {0}", DateTime.Now),
                   "",
                   TimeSpan.Zero,
                   TimeSpan.FromSeconds(5)
                );

                while (cts.IsCancellationRequested == false)
                    Thread.Sleep(1000);
            }
        }
    }
}