using System.Runtime.Serialization;

namespace CleanArchitecture.SharedKernel.Modules.Jwt;

[Serializable]
public class TokenValidationParametersNotSetException : Exception
{
    public TokenValidationParametersNotSetException()
    {
    }

    public TokenValidationParametersNotSetException(string? message) : base(message)
    {
    }

    public TokenValidationParametersNotSetException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected TokenValidationParametersNotSetException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
