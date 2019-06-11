using System;

namespace Banking
{
    class InvalidAccountTypeException : Exception
    {
        public InvalidAccountTypeException()
        {
        }

        public InvalidAccountTypeException(string message)
            : base(message)
        {
        }

        public InvalidAccountTypeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
