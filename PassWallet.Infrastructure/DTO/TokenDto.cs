using System;

namespace PassWallet.Infrastructure.DTO
{
    public class TokenDto
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public long Expires { get; set; }
    }
}