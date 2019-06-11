using System;

namespace Banking
{
    class BankAccountCreationException : Exception
    {
        public BankAccountCreationException()
        {
        }

        public BankAccountCreationException(string message)
            : base(message)
        {
        }

        public BankAccountCreationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
