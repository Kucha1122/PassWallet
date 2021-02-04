using System;

namespace PassWallet.Infrastructure.DTO.Commands
{
    public class UpdatePasswordCommand
    {
        public Guid PasswordId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string VaultKey { get; set; }
    }
}