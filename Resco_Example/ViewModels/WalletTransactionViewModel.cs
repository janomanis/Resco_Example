using System;

namespace Resco_Example.ViewModels
{
    public class WalletTransactionViewModel
    {
        public Guid Id { get; set; }

        public Guid PlayerId { get; set; }

        public decimal Amount { get; set; }
    }
}
