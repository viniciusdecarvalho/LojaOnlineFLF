using System;

namespace LojaOnlineFLF.DataModel
{
    public abstract class EntityKey<E>
    {
        public virtual E Id { get; set; }

        public override bool Equals(object other)
        {
            if (other is null)
            {
                return false;
            }

            if (!other.GetType().Equals(this.GetType()))
            {
                return false;
            }

            var otherEntity = other as EntityKey<E>;

            return this.Id.Equals(otherEntity.Id);
        }            

        public override int GetHashCode() => this.Id.GetHashCode();

        public override string ToString() => $"{this.GetType().Name}({Id})";
    }
}