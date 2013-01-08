using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITOps.Contracts;
using NServiceBus;

namespace Shopping
{
    public class ShoppingAPIHandler : IHandleMessages<ShoppingOrder>
    {
        public void Handle(ShoppingOrder message)
        {
            //persist to shopping service db
            Console.WriteLine("ShoppingOrder: " + message.OrderId.ToString());
        }
    }
}
