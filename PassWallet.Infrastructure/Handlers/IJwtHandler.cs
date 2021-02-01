using System;
using PassWallet.Infrastructure.DTO;

namespace PassWallet.Infrastructure.Handlers
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(Guid userId, string role);
    }
}