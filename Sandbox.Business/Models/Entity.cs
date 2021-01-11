using System;

namespace Sandbox.Business.Models
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }

        protected Entity()
        {
            Id = new Guid();
        }
    }
}