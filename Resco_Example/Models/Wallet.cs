using Resco_Example.ORM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resco_Example.Models
{
    public class Wallet : IORMObject
    {
        public Wallet()
        {
            Transactions = new Dictionary<Guid, WalletTransaction>();
        }

        public Guid Id { get; set; }

        public Guid PlayerId { get; set; }

        public decimal Balance { get; set; }

        public Dictionary<Guid, WalletTransaction> Transactions { get; set; }

        internal void RecalculateBalance()
        {
            var plus = Transactions.Where(x => x.Value.Type == TransactionType.Win || x.Value.Type == TransactionType.Deposit).Sum(x => x.Value.Amount);
            var minus = Transactions.Where(x => x.Value.Type == TransactionType.Stake).Sum(x => x.Value.Amount);
            Balance = plus - minus;
        }
    }
}
