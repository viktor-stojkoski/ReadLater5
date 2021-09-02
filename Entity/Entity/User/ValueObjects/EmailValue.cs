namespace Entity.User.ValueObjects
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    using Entity.Common.ValueObjects;

    using Shared.ErrorCodes;
    using Shared.Exceptions;

    public class EmailValue : ValueObject
    {
        private const uint MaxLength = 256;
        private const string EmailAddressRegex = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";

        public string Value { get; }

        private EmailValue() { }

        public EmailValue(string email)
        {
            if (email.Length > MaxLength)
            {
                throw new ReadLaterValidationException(ErrorCodes.UserEmailInvalidLength);
            }

            Regex emailRegex = new(EmailAddressRegex);

            if (!emailRegex.IsMatch(email))
            {
                throw new ReadLaterValidationException(ErrorCodes.UserEmailInvalid);
            }

            Value = email;
        }

        public static implicit operator string(EmailValue email) => email?.Value;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
