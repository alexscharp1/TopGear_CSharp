using System;
using System.IO;

namespace Banking
{
    /* Records the changes made to an account's balance in a text file. */
    class Audit
    {
        // Default location for audit files
        internal static string auditFileDirectory;
        internal static string auditFileFullPath;

        // Single txt file for all audit / account objects
        private readonly BankAccount account;
        private string auditFileName;

        static Audit()
        {
            // Initialize default audit file directory and name
            char separator = Path.DirectorySeparatorChar;
            string bin = $"{separator}bin{separator}";
            string projDir = Directory.GetCurrentDirectory().Split(bin)[0];
            if (Directory.Exists(projDir))
            {
                auditFileDirectory = projDir;
            }
            else
            {
                // Print error and request user input instead.
                Console.WriteLine("Unable to locate project directory to write the audit file.");
                string input = "";
                while (!Directory.Exists(input))
                {
                    Console.WriteLine("Please input a valid directory to write the audit file:");
                    input = Console.ReadLine();
                }
                auditFileDirectory = input;
            }

            // Initialize audit file full path
            auditFileFullPath = auditFileDirectory + separator + "TestAudit.txt";
        }

        internal Audit(BankAccount account)
        {
            this.account = account;
            auditFileName = auditFileFullPath;

            // Subscribe to Auditing event
            account.Auditing += c_Auditing;
        }

        // Set allows audit file name default value to be overriden (ex for testing)
        // but does NOT test if the given value is a valid file.
        internal string AuditFileName
        {
            get { return auditFileName; }
            set { auditFileName = value; }
        }

        /* Records the transaction in a txt file. */
        private void c_Auditing(object sender, AuditingEventArgs e)
        {
            using (StreamWriter auditFile = new StreamWriter(auditFileName, true))
            {
                string str = string.Format("{0},{1},{2}",
                    account.AccountNumber,
                    e.Transaction.Time,
                    e.Transaction.Amount);
                auditFile.WriteLine(str);
            }
        }
    }
}
