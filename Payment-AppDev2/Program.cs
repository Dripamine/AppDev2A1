using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace Payment_AppDev2
{
    internal class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        public static void Main(string[] args)
        {
            XmlConfigurator.Configure(); // Initialize log4net
            log.Info("Application starting...");

            PaymentCard card = new PaymentCard(100);
            Console.WriteLine(card);
            card.AddMoney(49.99);
            Console.WriteLine(card);
            card.AddMoney(10000.0);
            Console.WriteLine(card);
            card.AddMoney(-10);
            Console.WriteLine(card);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(); // Keeps the console window open

            log.Info("Application ended.");
        }

    }
}
