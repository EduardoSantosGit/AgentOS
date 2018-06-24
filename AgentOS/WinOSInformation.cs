using System;
using System.Collections.Generic;
using System.Text;

namespace AgentOS
{
    public class WinOSInformation
    {
        public static WinOSInfo GetOSInfo()
        {
            var winos = new WinOSInfo();

            winos = GetInfoProcessor(winos);

            return winos;
        }

        private static WinOSInfo GetInfoProcessor(WinOSInfo winos)
        {
            winos.ProcessorArchitecture = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE",
                EnvironmentVariableTarget.Machine);
            winos.ProcessorIden = Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
            winos.ProcessorLevel = Environment.GetEnvironmentVariable("PROCESSOR_LEVEL");
            winos.ProcessorNumber = Environment.ProcessorCount.ToString();
            return winos;
        }



    }
}
