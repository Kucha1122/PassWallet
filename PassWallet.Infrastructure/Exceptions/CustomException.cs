using System;

namespace PassWallet.Infrastructure.Exceptions
{
    public class CustomException : Exception
    {
        protected CustomException(string message) : base(message)
        {
            
        }
    }
}