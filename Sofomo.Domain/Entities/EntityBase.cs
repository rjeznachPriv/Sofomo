namespace Sofomo.Domain.Entities
{

    using System;

    public abstract class EntityBase : IEntity
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

    }
}