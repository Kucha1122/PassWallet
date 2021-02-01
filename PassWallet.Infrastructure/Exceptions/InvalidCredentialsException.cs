namespace PassWallet.Infrastructure.Exceptions
{
    public class InvalidCredentialsException : CustomException
    {
        public InvalidCredentialsException() : base($"Invalid credentials.")
        {
        }
    }
}