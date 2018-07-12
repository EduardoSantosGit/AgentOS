using AgentOS.Services;
using CommandLine;
using FluentScheduler;
using System;
using System.Collections.Generic;

namespace AgentOS
{
    public class MyRegistry : Registry
    {
        public MyRegistry()
        {
        }
    }

    public class Startup
    {

        public void StartInputFlowMonitor(Options options)
        {

            JobManager.Initialize(new MyRegistry());
            JobManager.AddJob(() => Console.WriteLine("Late job!"), (s) => s.ToRunEvery(5).Seconds());

            //Console.WriteLine("Current time: {0}", DateTime.Now);

            //IObservable<long> observable = Observable.Timer(TimeSpan.FromSeconds(2));

            //// Token for cancelation
            //CancellationTokenSource source = new CancellationTokenSource();

            //Console.WriteLine("Action started at: {0}", DateTime.Now);

            //// Create task to execute.
            //Task task = new Task(() => StartInputFlowMonitor(options));

            //// Subscribe the obserable to the task on execution.
            //observable.Subscribe(x => task.Start(), source.Token);

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
