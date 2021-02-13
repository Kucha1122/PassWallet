using System;

namespace PassWallet.Infrastructure.Exceptions
{
    internal class PasswordNotFoundException : CustomException
    {
        public PasswordNotFoundException(Guid passwordId) 
            : base($"Password with ID: 'passwordId' was not found.")
        {
        }
    }
}