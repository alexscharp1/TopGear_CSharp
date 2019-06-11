using System;

namespace Banking
{
    class InvalidAccountNumberException : Exception
    {
        public InvalidAccountNumberException()
        {
        }

        public InvalidAccountNumberException(string message)
            : base(message)
        {
        }

        public InvalidAccountNumberException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
