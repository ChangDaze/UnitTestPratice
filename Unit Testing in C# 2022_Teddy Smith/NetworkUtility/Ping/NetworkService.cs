using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
        public DateTime LastPingDate()
        {
            return DateTime.Now;
        }
        public PingOptions GetPingOptions()
        {
            return new PingOptions() //是.Net內建的型別，單純拿來測試用
            {
                DontFragment = true,
                Ttl = 1 //設成0好像會錯， must be a non-negative and non-zero value...
            };
        }
        public IEnumerable<PingOptions> MostRecentPings()
        {
            IEnumerable<PingOptions> pingOptions = new[]
            {
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1
                },
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1
                },
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1
                },
            };
            return pingOptions;
        }
    }
}
