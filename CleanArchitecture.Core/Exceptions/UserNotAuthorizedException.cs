using System;

namespace CleanArchitecture.Core.Exceptions
{
    public class UserNotAuthorizedException : Exception
    {
        public UserNotAuthorizedException(string message) : base(message)
        {
        }

        public UserNotAuthorizedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public UserNotAuthorizedException()
        {
        }
    }
}
