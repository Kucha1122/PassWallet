using System;

namespace PassWallet.Infrastructure.Exceptions
{
    public class UserAlreadyExistException : CustomException
    {
        public UserAlreadyExistException(string login) 
            : base($"User with login: 'login' already exist.")
        {
        }
    }
}