using System;
using System.ComponentModel.DataAnnotations;

namespace PassWallet.Core.Entities
{
    public class Entity
    {
        [Key]
        public Guid Id { get; protected set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}