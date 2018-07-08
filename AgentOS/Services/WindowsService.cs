using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentOS.Services
{
    public class WindowsService
    {
        public WindowsService()
        {
        }

        public WinOSInfo GetDataServer()
        {
            var winOSInfo = new WinOSInfo();
            winOSInfo = WinOSInformation.GetInfoProcessor(winOSInfo);
            winOSInfo = WinOSInformation.GetInfoMemory(winOSInfo);
            winOSInfo = WinOSInformation.GetInfoDisk(winOSInfo);

            winOSInfo = WinOSInformation.GetInfoEthernet(winOSInfo);



            return winOSInfo;
        }



    }
}
