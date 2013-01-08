using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;
using Payment.Contracts;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IBus bus = Configure.With()
                .DefaultBuilder()
                .MsmqTransport()
                    .IsTransactional(true)
                    .PurgeOnStartup(false)
                .XmlSerializer()
                .DisableTimeoutManager()
                .UnicastBus()
                .Log4Net()
                .CreateBus()
                .Start(() => Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>().Install());



            while (1 == 1)
            {
                Console.WriteLine("=======================================================");
                Console.WriteLine("Press Enter to MakePurchase. Press any character and Enter to quit.");
                Console.WriteLine("=======================================================");
                var input = Console.ReadLine();

                if (input != string.Empty)
                    break;
                else if (input == "")
                {

                    var cart = new Dictionary<Guid, int>();
                    cart.Add(Guid.NewGuid(), 2);

                    var cc = new CreditCardInfo();

                    var orderId = Guid.NewGuid();

                    var shippingAddress = new Shipping.Contracts.BaseAddress() { StreetAddress = "5th avenue", City = "New York" };

                    bus.SendLocal(new ITOps.Contracts.Order
                    {
                        OrderId = orderId,
                        Cart = cart,
                        CreditCard = cc,
                        ShippingAddress = shippingAddress
                    });
                }

            }

            

        }
    }
}
