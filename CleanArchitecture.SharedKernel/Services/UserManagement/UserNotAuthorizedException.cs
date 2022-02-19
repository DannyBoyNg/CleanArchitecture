using System.Runtime.Serialization;

namespace CleanArchitecture.SharedKernel.Services.UserManagement;

[Serializable]
public class UserNotAuthorizedException : Exception
{
    public UserNotAuthorizedException()
    {
    }

    public UserNotAuthorizedException(string? message) : base(message)
    {
    }

    public UserNotAuthorizedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected UserNotAuthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
