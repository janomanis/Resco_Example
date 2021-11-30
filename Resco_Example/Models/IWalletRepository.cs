using System;
using System.Threading.Tasks;

namespace Resco_Example.Models
{
    public interface IWalletRepository
    {
        public Task<decimal> GetBalanceAsync(Guid playersId);
        public Task<Wallet> GetWalletAsync(Guid walletId);
        public Task<Wallet> GetWallet_ByPersonIdAsync(Guid playerId);
        public void CreateWallet(Guid playerId);
        public bool PostDeposit(Guid walletId, decimal balance, Guid transactionId);
        public bool PostStake(Guid walletId, decimal balance, Guid transactionId);
        public bool PostWin(Guid walletId, decimal balance, Guid transactionId);
    }
}
