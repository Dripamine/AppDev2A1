using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment_AppDev2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
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
        }

    }
}
