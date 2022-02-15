using System.Runtime.Serialization;

namespace CleanArchitecture.SharedKernel.Services.ApiKey;

[Serializable]
public class ApiKeyRevokedException : Exception
{
    public ApiKeyRevokedException()
    {
    }

    public ApiKeyRevokedException(string? message) : base(message)
    {
    }

    public ApiKeyRevokedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected ApiKeyRevokedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
