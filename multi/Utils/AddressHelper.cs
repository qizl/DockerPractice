using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Utils
{
    public class AddressHelper
    {
        /// <summary>
        /// 获取服务器上所有网卡的IP地址
        /// </summary>
        /// <returns></returns>
        public string GetLocalAddress(string newLine = "<br/>")
        {
            NetworkInterface[] networks = NetworkInterface.GetAllNetworkInterfaces();
            var serverIpAddresses = string.Empty;
            foreach (var network in networks)
            {
                var ipAddress = network.GetIPProperties()
                    .UnicastAddresses
                    .Where(p => p.Address.AddressFamily == AddressFamily.InterNetwork && !IPAddress.IsLoopback(p.Address)).FirstOrDefault()?.Address.ToString();
                serverIpAddresses += $"{network.Name}:{ipAddress}{newLine}";
            }
            return serverIpAddresses;
        }
    }
}
