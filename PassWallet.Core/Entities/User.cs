using System.Collections.Generic;

namespace PassWallet.Core.Entities
{
    public class User : Entity
    {
        private static List<string> _roles = new List<string>
        {
            "user", "admin"
        };

        public User()
        {
            Passwords = new HashSet<Password>(); 
        }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string Role { get; set; }
        public virtual ICollection<Password> Passwords { get; set; }

        public void SetRole(string role)
        {
            if (!string.IsNullOrWhiteSpace(role))
            {
                role = role.ToLowerInvariant();
                if (_roles.Contains(role))
                {
                    Role = role;
                }
            }
        }
        
    }
}