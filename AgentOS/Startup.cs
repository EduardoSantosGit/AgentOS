using AgentOS.Services;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AgentOS
{
    public class Startup
    {

        public void StartInputFlowMonitor(Options options)
        {

            Console.WriteLine("Current time: {0}", DateTime.Now);

            IObservable<long> observable = Observable.Timer(TimeSpan.FromSeconds(2));

            // Token for cancelation
            CancellationTokenSource source = new CancellationTokenSource();

            Console.WriteLine("Action started at: {0}", DateTime.Now);

            // Create task to execute.
            Task task = new Task(() => StartInputFlowMonitor(options));

            // Subscribe the obserable to the task on execution.
            observable.Subscribe(x => task.Start(), source.Token);

            //if (options.Start)
            //{
            //    Task.Run(() => CronJob(options.Interval));
            //    var service = new WindowsService(options.UrlBase, options.EndPoint);
            //}

        }

        
        public void TriggerSchedule(int time)
        {

        }

        public void TaskMonitorSystem()
        {

        }


        public void ErrorInput(IEnumerable<Error> errors)
        {

        }
    }
}
