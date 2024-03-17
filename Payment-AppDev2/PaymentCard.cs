using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment_AppDev2
{
    public class PaymentCard
    {
        private double balance;
        private const double MaxBalance = 150.0;

        public PaymentCard(double openingBalance)
        {
            balance = openingBalance;
        }
        public void EatLunch()
        {
            if (balance >= 10.60)
            {
                balance -= 10.60;
            }
        }

        public void DrinkCoffee()
        {
            if (balance >= 2.0)
            {
                balance -= 2.0;
            }
        }
        public void AddMoney(double amount)
        {
            if (amount < 0)
            {
                // Do not allow negative amount to be added.
                return;
            }

            balance += amount;
            if (balance > MaxBalance)
            {
                balance = MaxBalance; // Set balance to MaxBalance if it exceeds the limit.
            }
        }
        public override string ToString()
        {
            return $"The card has a balance of {balance} euros"; 
        }
    }
}
