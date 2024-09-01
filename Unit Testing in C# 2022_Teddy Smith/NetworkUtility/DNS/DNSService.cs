using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.DNS
{
    //要被拿來注入的範例
    public class DNSService : IDNS
    {
        public bool SendDNS()
        {
            return true;
        }
    }
}
