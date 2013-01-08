using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITOps.Contracts;
using NServiceBus;

namespace Shipping
{
    public class ShippingAPIHandler : IHandleMessages<ShippingOrder>
    {
        public void Handle(ShippingOrder message)
        {
            //persist to shipping service db
            Console.WriteLine("ShippingOrder: " + message.OrderId.ToString());
        }
    }
}
