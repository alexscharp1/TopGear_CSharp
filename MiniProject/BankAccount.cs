using System;
using System.Text;
using System.Collections.Generic;

namespace Banking
{
    /* Represents a single bank account of type checking or savings.
     * Contains account number, balance, and type.
     */
    class BankAccount
    {
        public enum AccountTypes
        {
            Checking = 0,
            Savings = 1
        }
        private long accountNumber;
        private decimal accountBalance;
        private int accountType;
        private List<BankTransaction> transactions;
        private Audit audit;

        internal BankAccount(
            long accountNumber, decimal accountBalance, int accountType)
        {
            AccountNumber = accountNumber;
            AccountBalance = accountBalance;
            AccountType = accountType;
            transactions = new List<BankTransaction>();
            audit = new Audit(this);
        }

        /* This event should be triggered by only Withdraw and Desposit to 
         * signal that a transaction successfully occurred. */
        public event EventHandler<AuditingEventArgs> Auditing;

        /* Setter throws INvalidAccountNumberException if 
         * value is not positive. */
        public long AccountNumber
        {
            get { return accountNumber; }
            set
            {
                if (value < 0)
                {
                    string msg = string.Format(
                        "Invalid account number. Expected a nonnegative " +
                        "number. Instead got {0}.", value);
                    throw new InvalidAccountNumberException(msg);
                }
                accountNumber = value;
            }
        }

        public decimal AccountBalance
        {
            get { return accountBalance; }
            set { accountBalance = value; }
        }

        /* Setter throws InvalidAccountTypeException if 
         * value is neither 0 (checking) nor 1 (savings). */
        public int AccountType
        {
            get { return accountType; }
            set
            {
                switch (value)
                {
                    case (int)AccountTypes.Checking:
                        accountType = (int)AccountTypes.Checking;
                        break;
                    case (int)AccountTypes.Savings:
                        accountType = (int)AccountTypes.Savings;
                        break;
                    default:
                        string msg = string.Format("Invalid account type. " +
                            "Expected 0 (checking) or 1 (savings). " +
                            "Instead received {0}.", value);
                        throw new InvalidAccountTypeException(msg);
                }
            }
        }
        
        /* No setter since transactions are readonly. */
        public List<BankTransaction> Transactions
        {
            get { return transactions; }
        }

        /* No setter since Audit should never be changed. */
        public Audit Audit
        {
            get { return audit; }
        }

        /* Creates a BankTransaction with the given amount, and adds it to
         * the account's hashtable of transactions.
         * Returns the created BankTransaction.
         * This method should be called only by Withdraw and Deposit to 
         * report a successful transaction. */
        private BankTransaction AddTransaction(decimal amount)
        {
            BankTransaction transaction = new BankTransaction(amount);
            transactions.Add(transaction);
            return transaction;
        }

        /* Converts BankTransaction param into AuditingEventArgs object,
         * and passes to OnAuditing method. */
        private void RaiseOnAuditing(BankTransaction transaction)
        {
            AuditingEventArgs args = new AuditingEventArgs();
            args.Transaction = transaction;
            OnAuditing(args);
        }

        /* Raises an Auditing event with passed args (BankTransaction).
         * This event should be triggered by only Withdraw and Deposit 
         * after a transaction is successfully added to the account. */
        protected virtual void OnAuditing(AuditingEventArgs e)
        {
            Auditing?.Invoke(this, e);
        }

        /* If sufficient funds are available:
         *   Reduces account balance by amount,
         *   Creates and stores a BankTransaction object of amount, and
         *   Raises the Auditing event with the transaction as parameter.
         * Otherwise, throws InsufficientFundsException. */
        public void Withdraw(decimal amount)
        {
            if (AccountBalance > amount)
            {
                AccountBalance -= amount;
                BankTransaction transaction = AddTransaction(-1 * amount);
                RaiseOnAuditing(transaction);
            }
            else
            {
                string msg = string.Format(
                    "A request to withdraw {0:C} from acount {1} was denied " +
                    "due to insufficient funds.", amount, AccountNumber);
                throw new InsufficientFundsException(msg);
            }
        }

        /* Deposits amount into account balance,
         * Creates and stores a BankTransaction object of amount, and
         * Raises the Auditing event with the transaction as parameter.*/
        public void Deposit(decimal amount)
        {
            AccountBalance += amount;
            BankTransaction transaction = AddTransaction(amount);
            RaiseOnAuditing(transaction);
        }

        /* Prints Account's number, balance, and type */
        public void PrintAccountInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(
                "Account number:  {0,20}", AccountNumber));
            sb.AppendLine(string.Format(
                "Account balance: {0,20:C}", AccountBalance));
            sb.AppendLine(string.Format(
                "Account type:    {0,20}",
                (AccountType == 0) ? "Checking" : "Savings"));
            Console.Write(sb.ToString());
        }

        /* Prints Account's transactions */
        public void PrintTransactions()
        {
            foreach (BankTransaction transaction in transactions)
            {
                transaction.PrintTransaction();
            }
        }
    }
}
