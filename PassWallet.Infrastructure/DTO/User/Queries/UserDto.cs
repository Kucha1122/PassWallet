using System;
using System.Collections.Generic;
using PassWallet.Core.Entities;

namespace PassWallet.Infrastructure.DTO.User.Queries
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string Role { get; set; }
        
        public List<Password> Passwords { get; set; }
    }
}