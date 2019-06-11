using System;

namespace ClassesAndStructs3
{
    class InvalidRadiusException : Exception
    {
        public InvalidRadiusException()
        {
        }

        public InvalidRadiusException(string message)
            : base(message)
        {
        }

        public InvalidRadiusException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
