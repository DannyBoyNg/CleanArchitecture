using System.Runtime.Serialization;

namespace CleanArchitecture.SharedKernel.Modules.Jwt;

[Serializable]
internal class KeyNotSetException : Exception
{
    public KeyNotSetException()
    {
    }

    public KeyNotSetException(string? message) : base(message)
    {
    }

    public KeyNotSetException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected KeyNotSetException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
