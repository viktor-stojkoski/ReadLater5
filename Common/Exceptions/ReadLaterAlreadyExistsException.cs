namespace Shared.Exceptions
{
    using System;

    [Serializable]
    public class ReadLaterAlreadyExistsException : Exception
    {
        public ReadLaterAlreadyExistsException() : base("Already exists !") { }

        public ReadLaterAlreadyExistsException(string message) : base(message) { }

        public ReadLaterAlreadyExistsException(string message, Exception ex) : base(message, ex) { }
    }
}
