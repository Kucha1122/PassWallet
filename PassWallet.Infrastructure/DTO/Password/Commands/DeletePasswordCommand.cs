﻿using System;

namespace PassWallet.Infrastructure.DTO.Commands
{
    public class DeletePasswordCommand
    {
        public Guid PasswordId { get; set; }
    }
}