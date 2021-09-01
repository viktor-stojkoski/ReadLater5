namespace Shared.Exceptions
{
    using System;

    [Serializable]
    public class ReadLaterValidationException : Exception
    {
        public ReadLaterValidationException() : base("Invalid !") { }

        public ReadLaterValidationException(string message) : base(message) { }

        public ReadLaterValidationException(string message, Exception ex) : base(message, ex) { }
    }
}
