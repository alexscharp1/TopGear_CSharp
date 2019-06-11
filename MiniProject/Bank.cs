using System;
using System.Collections;

namespace Banking
{
    /* Creates and maintains BankAccount objects */
    class Bank
    {
        // Default account type is Checking and balance is 0.
        internal const decimal DEFAULT_BANK_BALANCE = 0;
        internal const int DEFAULT_BANK_TYPE = 
            (int)BankAccount.AccountTypes.Checking;

        // Bank accounts are stored in a hash table where keys are 
        // account numbers (long) and values are BankAccount objects.
        private static Hashtable bankAccounts;

        // Number for generating next account number
        private static long numAccounts;

        static Bank()
        {
            bankAccounts = new Hashtable();
            numAccounts = 0;
        }

        private Bank()
        {
            // Prevent instances from being created.
        }

        public static Hashtable BankAccounts
        {
            get { return bankAccounts; }
        }

        /* Adds a key-value pair to bankAccounts hashtable where key is
         * account number and value is the account. 
         * Note: Hashtable.Add() will throw ArgumentException if key already 
         * exists in hashtable. This exception is not handled here, and 
         * must be handled in the calling method (CreateAccount) */
        private static void AddBankAccount(BankAccount account)
        {
            bankAccounts.Add(account.AccountNumber, account);
        }

        /* Some overloads to create accounts */
        public static BankAccount CreateAccount()
        {
            return CreateAccount(DEFAULT_BANK_BALANCE, DEFAULT_BANK_TYPE);
        }

        public static BankAccount CreateAccount(decimal accountBalance)
        {
            return CreateAccount(accountBalance, DEFAULT_BANK_TYPE);
        }

        public static BankAccount CreateAccount(int accountType)
        {
            return CreateAccount(DEFAULT_BANK_BALANCE, accountType);
        }

        /* Main method to create accounts. Others overload this method.
         * Creates an account, adds it to the hashtable of accounts, 
         * increments number of accounts, and returns the account. 
         * Unique account numbers are guaranteed by the hashtable; in the 
         * case that two accounts get the same number, one will be recreated
         * before being added to the hashtable. */
        public static BankAccount CreateAccount(
            decimal accountBalance, int accountType)
        {
            // Loop in case account number is already taken.
            int numAttempts = 1;
            int maxAttempts = 5;
            while (true)
            {
                try
                {
                    BankAccount account = new BankAccount(
                        numAccounts, accountBalance, accountType);
                    AddBankAccount(account);
                    numAccounts++;
                    return account;
                }
                catch (ArgumentException)
                {
                    // Key value (account number) is already taken.
                    // Retry a few times before throwing exception.
                    // Note: In truly asynch environment, better solution 
                    // would be needed to handle slow threads and locks.
                    if (numAttempts == maxAttempts)
                    {
                        string msg = string.Format("Error! Unable to create " +
                            "account after {0} attempts due to account " +
                            "number conflicts.", numAttempts);
                        throw new BankAccountCreationException(msg);
                    }
                    else
                    {
                        numAttempts++;
                    }
                }
            }
        }
    }
}
