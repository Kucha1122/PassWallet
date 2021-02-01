namespace PassWallet.Infrastructure.DTO.Commands
{
    public class CreatePasswordCommand
    {
        public string PasswordHash { get; set; }
        public string Website { get; set; }
        public string Login { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public string VaultKey { get; set; }
    }
}