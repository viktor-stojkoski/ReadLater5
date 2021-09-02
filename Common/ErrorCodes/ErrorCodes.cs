namespace Shared.ErrorCodes
{
    public static class ErrorCodes
    {
        #region Category

        public const string CategoryNotFound = "CATEGORY_NOT_FOUND";
        public const string CategoryNameAlreadyExists = "CATEGORY_NAME_ALREADY_EXISTS";
        public const string CategoryNameInvalid = "CATEGORY_NAME_INVALID";
        public const string CategoryNameInvalidLength = "CATEGORY_NAME_INVALID_LENGTH";

        #endregion

        #region Bookmark

        public const string BookmarkNotFound = "BOOKMARK_NOT_FOUND";
        public const string BookmarkUrlInvalidLength = "BOOKMARK_URL_INVALID_LENGTH";

        #endregion

        #region User

        public const string UserNotFound = "USER_NOT_FOUND";
        public const string UserUserNameInvalidLength = "USER_USER_NAME_INVALID_LENGTH";
        public const string UserEmailInvalid = "USER_EMAIL_INVALID";
        public const string UserEmailInvalidLength = "USER_EMAIL_INVALID_LENGTH";
        public const string UserNoPasswordSet = "USER_NO_PASSWORD_SET";

        #endregion
    }
}
