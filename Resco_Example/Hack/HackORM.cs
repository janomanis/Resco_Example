using System.Collections.Generic;

namespace Resco_Example.Hack
{
    public class HackORM : IHackORM
    {
        public IEnumerable<T> GetData<T>()
        {
            return new List<T>();
        }
    }
}
