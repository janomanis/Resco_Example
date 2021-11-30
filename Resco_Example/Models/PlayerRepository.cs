using Resco_Example.Hack;
using Resco_Example.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Resco_Example.Models
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IHackORM _orm;
        private readonly IWalletRepository _playersWalletRepository;

        public PlayerRepository(IHackORM orm, IWalletRepository playersWalletRepository)
        {
            _orm = orm;
            _playersWalletRepository = playersWalletRepository;
        }

        public Player CreatePlayer(PlayerViewModel viewModel)
        {
            var player = _orm.Create<Player>(viewModel.Id);
            //map viewmodel to model

            _playersWalletRepository.CreateWallet(player.Id);

            return player;
        }

        public async Task<Player> GetPlayerAsync(Guid playersId)
        {
            return await Task.Run(() => _orm.GetData<Player>(playersId));
        }
    }
}
