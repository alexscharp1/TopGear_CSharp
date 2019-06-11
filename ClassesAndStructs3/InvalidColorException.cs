using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesAndStructs3
{
    class InvalidColorException : Exception
    {
        public InvalidColorException()
        {
        }

        public InvalidColorException(string message)
            : base(message)
        {
        }

        public InvalidColorException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
