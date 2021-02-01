using System;
using System.Runtime.InteropServices;

namespace PassWallet.Infrastructure.Exceptions
{
    internal class UserNotFoundException : CustomException
    {
        public UserNotFoundException(Guid userId) : base($"User with ID: 'userId' was not found.")
        {
        }
        
        public UserNotFoundException(string login) : base($"User with Login: 'login' was not found.")
        {
        }
    }
}