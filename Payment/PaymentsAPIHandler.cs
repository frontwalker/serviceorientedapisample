using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITOps.Contracts;
using NServiceBus;

namespace Payment
{
    public class PaymentsAPIHandler : IHandleMessages<PaymentsOrder>
    {
        public void Handle(PaymentsOrder message)
        {
            //persist to payment service db
            Console.WriteLine("PaymentsOrder: " + message.OrderId.ToString());
        }
    }
}
