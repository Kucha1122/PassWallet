using System;

namespace PassWallet.Infrastructure.Exceptions
{
    internal class UserNotFoundException : CustomException
    {
        public UserNotFoundException(Guid userId) : base($"User with ID: 'userId' was not found.")
        {
        }
    }
}