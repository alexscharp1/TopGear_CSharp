using System;

namespace Banking
{
    /* Auditing event takes one BankTransaction as its parameter. */
    class AuditingEventArgs : EventArgs
    {
        public BankTransaction Transaction { get; set; }
    }
}
