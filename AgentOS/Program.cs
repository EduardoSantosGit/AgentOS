using CommandLine;
using FluentScheduler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentOS
{
    public class Program
    {

        public static void Main(string[] args)
        {

            JobManager.Initialize(new ScheduledJobRegistry());

            // Wait for something
            //Console.WriteLine("Press enter to terminate...");
            Console.ReadLine();

            // Stop the scheduler
            //JobManager.StopAndBlock();

            //var st = new Startup();

            //Parser.Default.ParseArguments<Options>(args)
            //    .WithParsed<Options>(opts => st.StartInputFlowMonitor(opts))
            //    .WithNotParsed<Options>((errs) => st.ErrorInput(errs));
        }

        public class ScheduledJobRegistry : Registry
        {
            public ScheduledJobRegistry()
            {
                Schedule<MyJob>().ToRunNow().AndEvery(2).Seconds();
            }
        }

        public class MyJob : IJob
        {
            public void Execute()
            {


                // Execute your scheduled task here
                Console.WriteLine("The time is {0:HH:mm:ss}", DateTime.Now);
            }
        }

    }
}
