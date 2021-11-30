using Resco_Example.ORM;
using System;

namespace Resco_Example.Models
{
    public class Player : IORMObject
    {
        public Guid Id { get; set; }
    }
}
