using Resco_Example.Models;
using Resco_Example.ORM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resco_Example.Hack
{
    /// <summary>
    /// to reviewer:
    /// This class is complete hack.
    /// </summary>
    public class HackORM : IHackORM
    {
        private Dictionary<Guid, Wallet> _wallets;
        private Dictionary<Guid, Player> _players;

        public HackORM()
        {
            _wallets = new Dictionary<Guid, Wallet>();
            _players = new Dictionary<Guid, Player>();
        }

        public T Create<T>(Guid id) where T : class, IORMObject
        {
            if (typeof(T) == typeof(Player))
            {
                var player = new Player() { Id = id };
                _players.Add(player.Id, player);

                return (T)Convert.ChangeType(player, typeof(T));
            }
            if (typeof(T) == typeof(Wallet))
            {
                var wallet = new Wallet() { Id = id };
                _wallets.Add(wallet.Id, wallet);

                return (T)Convert.ChangeType(wallet, typeof(T));
            }

            return null;
        }

        public T GetData<T>(Guid id) where T : class, IORMObject
        {
            if (typeof(T) == typeof(Wallet))
                return _wallets.ContainsKey(id) ? (T)Convert.ChangeType(_wallets[id], typeof(T)) : null;
            if (typeof(T) == typeof(Player))
                return _players.ContainsKey(id) ? (T)Convert.ChangeType(_players[id], typeof(T)) : null;

            return null;
        }

        public void Update<T>(T obj) where T : class, IORMObject
        {
            //Update logic
        }

        public IEnumerable<T> GetAll<T>() where T : class, IORMObject
        {
            if (typeof(T) == typeof(Wallet))
                return _wallets.Select(x=> (T)Convert.ChangeType(x.Value, typeof(T)));
            if (typeof(T) == typeof(Player))
                return _players.Select(x => (T)Convert.ChangeType(x.Value, typeof(T)));

            return Enumerable.Empty<T>();
        }
    }
}
