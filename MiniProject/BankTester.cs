using System;
using System.Text;
using System.IO;
using Banking;

namespace TestBanking
{
    class BankTester
    {
        /* Verify account values equal expected values.
         * Return empty string if all values are equal.
         * Otherwise return a message containing the mismatches. */
        private static string ValidateAccount(BankAccount account,
            long expAccNum, decimal expAccBal, int expAccType)
        {
            StringBuilder sb = new StringBuilder();
            if (account.AccountNumber != expAccNum)
            {
                sb.AppendLine(string.Format(
                    "Account number: Expected {0}. Instead got {1}.",
                    expAccNum, account.AccountNumber));
            }
            if (account.AccountBalance != expAccBal)
            {
                sb.AppendLine(string.Format(
                    "Account balance: Expected {0}. Instead got {1}.",
                    expAccBal, account.AccountBalance));
            }
            if (account.AccountType != expAccType)
            {
                sb.AppendLine(string.Format(
                    "Account type: Expected {0}. Instead got {1}.",
                    expAccType, account.AccountType));
            }
            return sb.ToString();
        }

        public static void TestCreateAccount()
        {
            // Test CreateAccount() with no args
            BankAccount account0 = Bank.CreateAccount();
            string str0 = ValidateAccount(account0, 0, 0, 0);
            if (str0 == string.Empty)
            {
                Console.WriteLine("Test PASSED -- CreateAccount().");
            }
            else
            {
                Console.WriteLine("Test FAILED -- CreateAccount().");
                Console.WriteLine(str0);
            }

            // Test CreateAccount() with balance provided
            decimal balance1 = 500;
            BankAccount account1 = Bank.CreateAccount(balance1);
            string str1 = ValidateAccount(account1, 1, balance1, 0);
            if (str1 == string.Empty)
            {
                Console.WriteLine("Test PASSED -- CreateAccount(balance).");
            }
            else
            {
                Console.WriteLine("Test FAILED -- CreateAccount(balance).");
                Console.WriteLine(str1);
            }

            // Test CreateAccount() with type provided
            int type2 = 0;
            BankAccount account2 = Bank.CreateAccount(type2);
            string str2 = ValidateAccount(account2, 2, 0, type2);
            if (str2 == string.Empty)
            {
                Console.WriteLine("Test PASSED -- CreateAccount(type).");
            }
            else
            {
                Console.WriteLine("Test FAILED -- CreateAccount(type).");
                Console.WriteLine(str2);
            }

            // Test CreateAccount() with balance and type provided
            decimal balance3 = -1000;
            int type3 = 1;
            BankAccount account3 = Bank.CreateAccount(balance3, type3);
            string str3 = ValidateAccount(account3, 3, balance3, type3);
            if (str3 == string.Empty)
            {
                Console.WriteLine("Test PASSED -- CreateAccount(balance, type).");
            }
            else
            {
                Console.WriteLine("Test FAILED -- CreateAccount(balance, type).");
                Console.WriteLine(str3);
            }

            // Test CreateAccount() with invalid type values provided
            try
            {
                Bank.CreateAccount(-5);
                Console.WriteLine("Test FAILED -- CreateAccount(invalid type).");
                Console.WriteLine("Failed to throw InvalidAccountTypeException.");
            }
            catch (InvalidAccountTypeException)
            {
                Console.WriteLine("Test PASSED -- CreateAccount(invalid type).");
            }
        }

        public static void TestDeposit(BankAccount account, decimal amount)
        {
            // Test Despoit()
            account.Deposit(amount);
            if (account.AccountBalance == amount)
            {
                Console.WriteLine("Test PASSED -- Deposit().");
            }
            else
            {
                Console.WriteLine("Test FAILED -- Deposit().");
                Console.WriteLine("Account balance: Expected {0}. " +
                    "Instead got {1}.", amount, account.AccountBalance);
            }
        }

        public static void TestWithdraw(BankAccount account, 
            decimal amount1, decimal amount2)
        {
            // Test Withdraw() with sufficient funds
            decimal balance1 = account.AccountBalance;
            account.Withdraw(amount1);
            if (account.AccountBalance == balance1 - amount1)
            {
                Console.WriteLine("Test PASSED -- Withdraw().");
            }
            else
            {
                Console.WriteLine("Test FAILED -- Withdraw().");
                Console.WriteLine("Account balance: " +
                    "Expected {0}. Instead got {1}.",
                    balance1 - amount1, account.AccountBalance);
            }

            // Test Withdraw() without sufficient funds
            decimal balance2 = account.AccountBalance;
            try
            {
                account.Withdraw(amount2);
                Console.WriteLine("Test FAILED -- " +
                    "Withdraw() without sufficient funds.");
                Console.WriteLine("Failed to throw InsufficientFundsException.");
            }
            catch (InsufficientFundsException)
            {
                Console.WriteLine("Test PASSED -- " +
                    "Withdraw() without sufficient funds.");
            }
        }

        public static void TestTransactions(BankAccount account, 
            decimal depAmt, decimal withAmt)
        {
            // There should be exactly two transactions
            int expNumTran = 2;
            if (account.Transactions.Count == expNumTran)
            {
                Console.WriteLine("Test PASSED -- Transactions count.");
            }
            else
            {
                Console.WriteLine("Test FAILED -- Transactions count.");
                Console.WriteLine("Expected {0}. Instead got {1}.", 
                    expNumTran, account.Transactions.Count);
                // If < 2 transactions, return now to prevent crash
                if (account.Transactions.Count < expNumTran)
                {
                    return;
                }
            }

            // Check the deposit transaction value
            if (account.Transactions[0].Amount == depAmt)
            {
                Console.WriteLine("Test PASSED -- Deposit transaction amount.");
            }
            else
            {
                Console.WriteLine("Test FAILED -- Deposit transaction amount.");
                Console.WriteLine("Expected {0}. Instead got {1}.",
                    depAmt, account.Transactions[0].Amount);
            }

            // Check the withdraw transaction value
            if (account.Transactions[1].Amount == -1 * withAmt)
            {
                Console.WriteLine("Test PASSED -- Withdraw transaction amount.");
            }
            else
            {
                Console.WriteLine("Test FAILED -- Deposit transaction amount.");
                Console.WriteLine("Expected {0}. Instead got {1}.",
                    -1 * withAmt, account.Transactions[1].Amount);
            }
        }

        public static void TestAudit(BankAccount account, string auditFileName,
            decimal depAmt, decimal withAmt)
        {
            string line0 = "";
            string line1 = "";
            try
            {
                // Check that audit file exists
                using (StreamReader file = new StreamReader(auditFileName))
                {
                    Console.WriteLine("Test PASSED -- Access audit file.");
                    Console.WriteLine("\tAudit file location: {0}", auditFileName);

                    // Check that audit files has exactly 2 lines of data
                    string line = "";
                    int i = 0;
                    while ((line = file.ReadLine()) != null)
                    {
                        // Need only store first two strings
                        if (i == 0)
                        {
                            line0 = line;
                        } else if (i == 1) {
                            line1 = line;
                        }
                        i++;
                    }
                    if (i == 2)
                    {
                        Console.WriteLine("Test PASSED -- Audit number of lines.");
                    }
                    else
                    {
                        Console.WriteLine("Test FAILED -- Audit number of lines.");
                        Console.WriteLine("Expected 2 lines. Instead got {0} lines.", i);
                        return;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Test FAILED -- Audit file access.");
                Console.WriteLine("The file could not be found: {0}", auditFileName);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Test FAILED -- Audit file access.");
                Console.WriteLine("The specified path is invalid: {0}", auditFileName);
            }
            catch (IOException)
            {
                Console.WriteLine("Test FAILED -- Audit file access.");
                Console.WriteLine("The path includes an incorrect or invalid syntax: {0}", auditFileName);
            }

            // Verify each line contains exactly 3 components
            string[] parts0 = line0.Split(",");
            string[] parts1 = line1.Split(",");
            if (parts0.Length == 3 && parts1.Length == 3)
            {
                Console.WriteLine("Test PASSED -- Audit transactions have 3 parts.");
            }
            else
            {
                Console.WriteLine("Test FAILED --Audit transactions have 3 parts.");
                Console.WriteLine("Expected 3 and 3. Instead got {0} and {1}.",
                    parts0.Length, parts1.Length);
            }

            // Check that item 0 is account number
            try
            {
                long accNum0 = long.Parse(parts0[0]);
                long accNum1 = long.Parse(parts1[0]);
                if (accNum0 == account.AccountNumber && accNum1 == account.AccountNumber)
                {
                    Console.WriteLine("Test PASSED -- Audit account number.");
                } else
                {
                    Console.WriteLine("Test FAILED -- Audit account number.");
                    Console.WriteLine("Expected {0}. Instead got {1} and {2}.",
                        account.AccountNumber, accNum0, accNum1);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Test FAILED -- Audit account number.");
                Console.WriteLine("Expected valid long numbers. Instead got {1} and {2}.",
                    account.AccountNumber, parts0[0], parts1[0]);
            }

            // Check that item 1 is a DateTime
            try
            {
                DateTime.Parse(parts0[1]);
                DateTime.Parse(parts1[1]);
                Console.WriteLine("Test PASSED -- Audit timestamp.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Test FAILED -- Audit timestamp.");
                Console.WriteLine("Expected valid datetimes. Instead got {0} and {1}.",
                    parts0[1], parts1[1]);
            }

            // Check that item 2 is dollar amount withdrawn or deposited
            try
            {
                // TODO: Account for currency-formatted strings
                decimal amount0 = decimal.Parse(parts0[2]);
                decimal amount1 = decimal.Parse(parts1[2]);
                if (amount0 == depAmt)
                {
                    Console.WriteLine("Test PASSED -- Audit deposit amount.");
                }
                else
                {
                    Console.WriteLine("Test FAILED -- Audit deposit amount.");
                    Console.WriteLine("Expected {0}. Instead got {1}.",
                        depAmt, amount0);
                }
                if (amount1 == -1 * withAmt)
                {
                    Console.WriteLine("Test PASSED -- Audit withdraw amount.");
                }
                else
                {
                    Console.WriteLine("Test FAILED -- Audit withdraw amount.");
                    Console.WriteLine("Expected {0}. Instead got {1}.",
                        -1 * withAmt, amount1);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Test FAILED -- Audit deposit/withdraw amounts.");
                Console.WriteLine("Expected valid decimal values. Instead got {0} and {1}.",
                    parts0[2], parts1[2]);
            }
        }

        public static void Main(string[] args)
        {
            // Setup values
            decimal initBal = 0;
            decimal depAmt = 100;
            decimal withAmt1 = 50;
            decimal withAmt2 = 500;

            // Begin tests
            Console.WriteLine("Begin tests for Banking project.");
            TestCreateAccount();

            BankAccount account = Bank.CreateAccount(initBal);
            // Start with clean audit file
            string auditFileName = account.Audit.AuditFileName;
            if (File.Exists(auditFileName))
            {
                File.Delete(auditFileName);
            }

            TestDeposit(account, depAmt);
            TestWithdraw(account, withAmt1, withAmt2);
            TestTransactions(account, depAmt, withAmt1);
            TestAudit(account, auditFileName, depAmt, withAmt1);
        }
    }
}
