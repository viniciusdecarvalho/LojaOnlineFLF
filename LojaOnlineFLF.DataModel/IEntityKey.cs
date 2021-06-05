using System;

namespace LojaOnlineFLF.DataModel
{
    public abstract class EntityKey<E>
    {
        public virtual E Id { get; set; }

        public bool Equals(EntityKey<E> other)
        {
            if (other is null)
            {
                return false;
            }

            return this.Id.Equals(other.Id);
        }
    }
}