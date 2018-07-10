﻿using AgentOS.Common;
using AgentOS.Provider.Http;
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

            var netFormat = winOSInfo.Networks
                .Select(x =>
                 {
                     x.Speed = Formatter.FormatSpeedNet(x.Speed); return x;
                 })
                .ToList();

            winOSInfo.Networks = netFormat;

            winOSInfo = WinOSInformation.GetInfoGPU(winOSInfo);
            winOSInfo = WinOSInformation.GetInfoOS(winOSInfo);
            winOSInfo = WinOSInformation.GetInfoProcesses(winOSInfo);
            winOSInfo = WinOSInformation.GetInfoServices(winOSInfo);

            SendDataServerCentral(winOSInfo);

            return winOSInfo;
        }

        public string SendDataServerCentral(WinOSInfo winos)
        {

            var client = new HttpProvider("http://teste.com");

            var r = client.SendPostJson<WinOSInfo>("",winos).Result;

            return null;
        }


    }
}
