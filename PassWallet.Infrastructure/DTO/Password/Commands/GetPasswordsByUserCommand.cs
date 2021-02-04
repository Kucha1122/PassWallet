using System;

namespace PassWallet.Infrastructure.DTO.Commands
{
    public class GetPasswordsByUserCommand
    {
        public Guid UserId { get; set; }

        public GetPasswordsByUserCommand(Guid userId)
        {
            UserId = userId;
        }
    }
}