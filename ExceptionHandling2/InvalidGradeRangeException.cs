using System;

namespace ExceptionHandling2
{
    class GradeRangeException : Exception
    {
        public GradeRangeException()
            : base()
        {
        }

        public GradeRangeException(string message)
            : base(message)
        {
        }

        public GradeRangeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
