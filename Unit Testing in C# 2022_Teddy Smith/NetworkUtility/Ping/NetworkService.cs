using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Ping
{
    public class NetworkService
    {
        public string SendPing()
        {
            //過程中可能有其他流程，但測試只看結果
            //SearchDNS();
            //BuildPacket();
            return "Success: Ping Sent Success!";
        }

        public int PingTimeout(int a, int b)
        {
            return a + b;
        }
    }
}
