using System;

namespace PassWallet.Infrastructure.DTO.Commands
{
    public class GetDecryptedPassword
    {
        public Guid PasswordId { get; set; }
        public string VaultKey { get; set; }
    }
}