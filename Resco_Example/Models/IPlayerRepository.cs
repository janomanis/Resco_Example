using System;

namespace Resco_Example.Models
{
    public interface IPlayerRepository
    {
        /// <summary>
        /// Return player by Id.
        /// </summary>
        /// <param name="id">Guid identifier.</param>
        public Player GetPlayer(Guid id);
    }
}
