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

        public readonly string _urlServer;
        public readonly string _urlEndPoint;


        public WindowsService(string urlServer, string urlEndPoint)
        {
            _urlServer = urlServer;
            _urlEndPoint = urlEndPoint;
        }

        public void OnMonitorServer()
        {
            var dataValue = GetDataServer();
            var status = SendDataServerCentral(dataValue);
        }

        public WinOSInfo GetDataFormatServer()
        {
            return GetWinInfo(true);
        }

        public WinOSInfo GetDataServer()
        {
            return GetWinInfo();
        }

        public WinOSInfo GetWinInfo(bool format = false)
        {
            var winOSInfo = new WinOSInfo();
            winOSInfo = WinOSInformation.GetInfoProcessor(winOSInfo);
            winOSInfo = WinOSInformation.GetInfoMemory(winOSInfo);
            winOSInfo = WinOSInformation.GetInfoDisk(winOSInfo);
            winOSInfo = WinOSInformation.GetInfoEthernet(winOSInfo);

            if (format)
            {
                var netFormat = winOSInfo.Networks
                .Select(x =>
                {
                    x.Speed = Formatter.FormatSpeedNet(x.Speed); return x;
                })
                .ToList();

                winOSInfo.Networks = netFormat;
            }

            winOSInfo = WinOSInformation.GetInfoGPU(winOSInfo);
            winOSInfo = WinOSInformation.GetInfoOS(winOSInfo);
            winOSInfo = WinOSInformation.GetInfoProcesses(winOSInfo);
            winOSInfo = WinOSInformation.GetInfoServices(winOSInfo);

            return winOSInfo;
        }

        public string SendDataServerCentral(WinOSInfo winos)
        {
            var client = new HttpProvider(_urlServer);
            var result = client.SendPostJson<WinOSInfo>(_urlEndPoint, winos).Result;

            return null;
        }


    }
}
