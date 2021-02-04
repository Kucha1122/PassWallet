using System;

namespace PassWallet.Infrastructure.DTO.Commands
{
    public class GetPasswordsCommand
    {
        public Guid PasswordId { get; set; }
    }
}