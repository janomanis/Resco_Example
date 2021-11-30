using Resco_Example.Hack;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Resco_Example.Models
{
    /// <summary>
    /// to reviewer:
    /// Conjoined WalletRepository and WalletTransactionRepository
    /// </summary>
    public class WalletRepository : IWalletRepository
    {
        private readonly IHackORM _orm;

        public WalletRepository(IHackORM orm)
        {
            _orm = orm;
        }

        public async Task<decimal> GetBalanceAsync(Guid walletId)
        {
            var wallet = await Task.Run(() => _orm.GetData<Wallet>(walletId));
            return wallet?.Balance ?? -1;
        }

        public async Task<Wallet> GetWalletAsync(Guid walletId)
        {
            return await Task.Run(() => _orm.GetData<Wallet>(walletId));
        }

        public async Task<Wallet> GetWallet_ByPersonIdAsync(Guid playerId)
        {
            return await Task.Run(() => _orm.GetAll<Wallet>().FirstOrDefault(x => x.PlayerId == playerId));
        }

        public void CreateWallet(Guid playerId)
        {
            var wallet = _orm.Create<Wallet>(Guid.NewGuid());
            wallet.PlayerId = playerId;
            _orm.Update(wallet);
        }

        public bool PostDeposit(Guid walletId, decimal amount, Guid transactionId)
        {
            return UpdateWallet(walletId, amount, TransactionType.Deposit, transactionId);
        }

        public bool PostStake(Guid walletId, decimal amount, Guid transactionId)
        {
            return UpdateWallet(walletId, amount, TransactionType.Stake, transactionId);
        }

        public bool PostWin(Guid walletId, decimal amount, Guid transactionId)
        {
            return UpdateWallet(walletId, amount, TransactionType.Win, transactionId);
        }

        private bool UpdateWallet(Guid walletId, decimal amount, TransactionType transactionType, Guid transactionId)
        {
            var wallet = _orm.GetData<Wallet>(walletId);

            if (transactionType == TransactionType.Stake && wallet.Balance < amount)
                return false; //insufficient funds

            if (!wallet.Transactions.ContainsKey(transactionId))
            {
                UpdateWalletCore(walletId, amount, transactionType, wallet, transactionId);
            }

            return true;
        }

        private void UpdateWalletCore(Guid walletId, decimal amount, TransactionType transactionType, Wallet wallet, Guid transactionId)
        {
            var transaction = CreateTransaction(walletId, amount, transactionType, transactionId);            
            wallet.Transactions.Add(transactionId, transaction);
            wallet.RecalculateBalance();

            _orm.Update(wallet);
        }

        private WalletTransaction CreateTransaction(Guid walletId, decimal amount, TransactionType transactionType, Guid transactionId)
            => new WalletTransaction()
            {
                Id = transactionId,
                WalletId = walletId,
                Amount = amount,
                Type = transactionType
            }; //persist not implemented
    }
}
