using System;

namespace ExceptionHandling3
{
    class InvalidArgumentException : Exception
    {
        public InvalidArgumentException() { }

        public InvalidArgumentException(string message) : base(message) { }

        public InvalidArgumentException(string message, Exception inner) 
            : base(message, inner) { }


    }
}
