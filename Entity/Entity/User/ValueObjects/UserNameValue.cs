namespace Entity.User.ValueObjects
{
    using System.Collections.Generic;

    using Entity.Common.ValueObjects;

    using Shared.ErrorCodes;
    using Shared.Exceptions;

    public class UserNameValue : ValueObject
    {
        private const uint MaxLength = 256;

        public string Value { get; }

        public UserNameValue() { }

        public UserNameValue(string userName)
        {
            if (userName.Length > MaxLength)
            {
                throw new ReadLaterValidationException(ErrorCodes.UserUserNameInvalidLength);
            }

            Value = userName;
        }

        public static implicit operator string(UserNameValue userName) => userName?.Value;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
