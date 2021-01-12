using System;

namespace Sandbox.Business.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        protected Entity()
        {
            //TODO: needs refactoring
            if (Id.Equals(null))
                Id = Guid.NewGuid();
        }
    }
}