using Resco_Example.ORM;
using System;

namespace Resco_Example.Models
{
    public class WalletTransaction : IORMObject
    {
        public Guid Id { get; set; }

        public Guid WalletId { get; set; }

        public TransactionType Type { get; set; }

        public decimal Amount { get; set; }
    }
}
