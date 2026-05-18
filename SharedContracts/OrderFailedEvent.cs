using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedContracts
{
    public class OrderFailedEvent
    {
        public string OrderId { get; set; }
        public string Reason { get; set; }
    }
}
