using System;

namespace Blake_OOPBank
{
    internal class Bank
    {
        private double checking = 1000.00;

        public double Balance()
        {
            return checking;
        }
        public double Deposit(double amount)
        {
            checking = checking + amount;
            return checking;
        }
        public double Withdraw(double amount)
        {
            checking = checking - amount;
            if (checking <= 0)
            {
                checking = 0;
            }
            return checking;
        }
    }
}
