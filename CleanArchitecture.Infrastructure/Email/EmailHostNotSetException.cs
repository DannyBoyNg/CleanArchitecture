﻿using System.Runtime.Serialization;

namespace CleanArchitecture.Infrastructure.EmailService
{
    [Serializable]
    internal class EmailHostNotSetException : Exception
    {
        public EmailHostNotSetException()
        {
        }

        public EmailHostNotSetException(string? message) : base(message)
        {
        }

        public EmailHostNotSetException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EmailHostNotSetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}