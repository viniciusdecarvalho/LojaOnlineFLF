using System;

namespace LojaOnlineFLF.DataModel
{
    public abstract class EntityKey<E>
    {
        public virtual E Id { get; set; }
    }
}