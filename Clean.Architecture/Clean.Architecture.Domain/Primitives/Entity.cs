using System;
using System.Collections.Generic;
using System.Text;

namespace Clean.Architecture.Domain.Primitives
{
    public abstract class Entity
    {
        protected Entity(Guid id) => Id = id;

        protected Entity()
        {
        }

        public Guid Id { get; protected set; }
    }
}
