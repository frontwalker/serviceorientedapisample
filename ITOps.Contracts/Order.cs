using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;
using Payment.Contracts;
using Shipping.Contracts;

namespace ITOps.Contracts
{
    public class Order : ShoppingOrder, PaymentsOrder, ShippingOrder
    {
        public Guid OrderId { get; set; }
        public Dictionary<Guid, int> Cart { get; set; }
        public CreditCardInfo CreditCard { get; set; }
        public BaseAddress ShippingAddress { get; set; }
    }

    public interface ShoppingOrder : IMessage
    {
        Guid OrderId { get; set; }
        Dictionary<Guid, int> Cart { get; set; }
    }

    public interface PaymentsOrder : IMessage
    {
        Guid OrderId { get; set; }
        CreditCardInfo CreditCard { get; set; }
    }

    public interface ShippingOrder : IMessage
    {
        Guid OrderId { get; set; }
        BaseAddress ShippingAddress { get; set; }
    }
}
