using System.Runtime.Serialization;

namespace CleanArchitecture.SharedKernel.Services.ApiKey;

[Serializable]
public class ApiKeyInvalidException : Exception
{
    public ApiKeyInvalidException()
    {
    }

    public ApiKeyInvalidException(string? message) : base(message)
    {
    }

    public ApiKeyInvalidException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected ApiKeyInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
