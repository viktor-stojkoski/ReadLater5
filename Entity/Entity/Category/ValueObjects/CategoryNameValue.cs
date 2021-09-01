namespace Entity.Category.ValueObjects
{
    using System.Collections.Generic;

    using Entity.Common.ValueObjects;

    using Shared.ErrorCodes;
    using Shared.Exceptions;

    public sealed class CategoryNameValue : ValueObject
    {
        private const uint MaxLength = 50;

        public string Value { get; }

        private CategoryNameValue() { }

        public CategoryNameValue(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ReadLaterValidationException(ErrorCodes.CategoryNameInvalid);
            }

            if (name.Length > MaxLength)
            {
                throw new ReadLaterValidationException(ErrorCodes.CategoryNameInvalidLength);
            }

            Value = name;
        }

        public static implicit operator string(CategoryNameValue name)
        {
            return name.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
