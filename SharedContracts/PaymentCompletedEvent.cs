using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedContracts
{
    public class PaymentCompletedEvent
    {
        public string OrderId { get; set; }
        public bool Success { get; set; }
    }
}
