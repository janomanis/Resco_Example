using Resco_Example.Hack;

namespace Resco_Example.Models
{
    public class PlayersWalletRepository
    {
        private IHackORM _orm;

        public PlayersWalletRepository(IHackORM orm)
        {
            _orm = orm;
        }
    }
}
