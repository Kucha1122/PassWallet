﻿using System;

namespace PassWallet.Core.Entities
{
    public class Entity
    {
        public Guid Id { get; protected set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}