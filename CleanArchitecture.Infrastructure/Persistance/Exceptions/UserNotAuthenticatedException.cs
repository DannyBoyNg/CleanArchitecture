namespace CleanArchitecture.Infrastructure.Persistence.Exceptions;

public class UserNotAuthenticatedException : Exception
{
    public UserNotAuthenticatedException()
    {
    }

    public UserNotAuthenticatedException(string message) : base(message)
    {
    }

    public UserNotAuthenticatedException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
