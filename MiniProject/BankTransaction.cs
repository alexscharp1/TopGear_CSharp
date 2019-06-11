using System;

namespace Banking
{
    /* Contains info about a deposit or withdrawal transaction that is 
     * performed on an account. Whenever the balance of an account is 
     * changed by Deposit or Withdraw, a new BankTransaction object 
     * is created. */
    class BankTransaction
    {
        private readonly DateTime time;
        private readonly decimal amount;

        public BankTransaction(decimal amount)
        {
            time = DateTime.Now;
            this.amount = amount;
        }

        // No setters since data is readonly
        public DateTime Time { get { return time; } }
        public decimal Amount { get { return amount; } }

        // Prints time and amount of transaction
        public void PrintTransaction()
        {
            Console.WriteLine("Time: {0} \tAmount: {1:C}", time, amount);
        }
    }
}
