using Resco_Example.ORM;
using System;
using System.Collections.Generic;

namespace Resco_Example.Hack
{
    public interface IHackORM
    {
        public IEnumerable<T> GetAll<T>() where T : class, IORMObject;

        public T GetData<T>(Guid id) where T : class, IORMObject;

        public T Create<T>(Guid id) where T : class, IORMObject;

        public void Update<T>(T obj) where T : class, IORMObject;
    }
}
