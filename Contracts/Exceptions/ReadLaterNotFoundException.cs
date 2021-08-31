namespace Contracts.Exceptions
{
    using System;

    [Serializable]
    public class ReadLaterNotFoundException : Exception
    {
        public ReadLaterNotFoundException() : base("Not found !") { }

        public ReadLaterNotFoundException(string message) : base(message) { }

        public ReadLaterNotFoundException(string message, Exception ex) : base(message, ex) { }
    }
}
