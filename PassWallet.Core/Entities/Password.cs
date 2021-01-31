namespace PassWallet.Core.Entities
{
    public class Password : Entity
    {
        public string PasswordHash { get; set; }
        public string Website { get; set; }
        public string Login { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public bool IsDeleted { get; set; }
        
    }
}