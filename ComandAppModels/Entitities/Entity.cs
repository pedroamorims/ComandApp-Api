using System;

namespace ComandApp.Domain.Entitities
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Entity()
        {
            Id = 0;
        }

        public int Id { get; private set; }

        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}
