namespace Entity.Bookmark.ValueObjects
{
    using System;
    using System.Collections.Generic;

    using Entity.Common.ValueObjects;

    using Shared.ErrorCodes;
    using Shared.Exceptions;

    public sealed class UrlValue : ValueObject
    {
        private const uint MaxLength = 500;

        public static readonly UrlValue Empty = new(null);

        public Uri Value { get; }

        private UrlValue() { }

        public UrlValue(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                Value = Empty;
            }

            if (url.Length > MaxLength)
            {
                throw new ReadLaterValidationException(ErrorCodes.BookmarkUrlInvalidLength);
            }

            Value = new Uri(url);
        }

        public static implicit operator Uri(UrlValue url) => url?.Value;

        public static implicit operator string(UrlValue url) => url?.Value.AbsoluteUri;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
