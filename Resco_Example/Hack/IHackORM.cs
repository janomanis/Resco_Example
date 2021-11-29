using System.Collections.Generic;

namespace Resco_Example.Hack
{
    public interface IHackORM
    {
        /// <summary>
        /// Returnse collection of dummy data.
        /// </summary>
        public IEnumerable<T> GetData<T>();
    }
}
