using System;

namespace PassWallet.Infrastructure.DTO.Commands
{
    public class UpdatePasswordCommand
    {
        public Guid Id { get; set; }
        public string PasswordHash { get; set; }
        public string VaultKey { get; set; }
    }
}