using Resco_Example.ViewModels;
using System;
using System.Threading.Tasks;

namespace Resco_Example.Models
{
    public interface IPlayerRepository
    {
        public Player CreatePlayer(PlayerViewModel player);
        
        /// <summary>
        /// Return player by Id.
        /// </summary>
        /// <param name="id">Guid identifier.</param>
        public Task<Player> GetPlayerAsync(Guid playerId);
    }
}
