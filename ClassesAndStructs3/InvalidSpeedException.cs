using System;

namespace ClassesAndStructs3
{
    class InvalidSpeedException : Exception
    {
        public InvalidSpeedException()
        {
        }

        public InvalidSpeedException(string message)
            : base(message)
        {
        }

        public InvalidSpeedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
