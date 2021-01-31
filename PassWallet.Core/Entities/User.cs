namespace PassWallet.Core.Entities
{
    public class User : Entity
    {
        public string Login { get; protected set; }
        public string PasswordHash { get; set; }
        
    }
}