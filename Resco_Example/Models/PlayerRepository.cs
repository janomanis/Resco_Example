using Resco_Example.Hack;
using System;
using System.Linq;

namespace Resco_Example.Models
{
    public class PlayerRepository : IPlayerRepository
    {
        private IHackORM _orm;

        public PlayerRepository(IHackORM orm)
        {
            _orm = orm;
        }

        public Player GetPlayer(Guid id)
        {
            return _orm.GetData<Player>().FirstOrDefault(x => x.Id == id);
        }
    }
}
