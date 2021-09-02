namespace Entity.User
{
    using System;

    using Entity.Common.Entities;
    using Entity.User.ValueObjects;

    public class ApplicationUser : Entity
    {
        private ApplicationUser() { }

        /// <summary>
        /// User's user name.
        /// </summary>
        public UserNameValue UserName { get; private set; }

        /// <summary>
        /// User's email address.
        /// </summary>
        public EmailValue Email { get; private set; }

        /// <summary>
        /// User's password hash.
        /// </summary>
        public string PasswordHash { get; private set; }

        /// <summary>
        /// Only for mapping DB to Domain.
        /// </summary>
        public ApplicationUser(
            int id,
            Guid uid,
            DateTime createdOn,
            DateTime? deletedOn,
            string userName,
            string email,
            string passwordHash)
        {
            UserNameValue userNameValue = new(userName);
            EmailValue emailValue = new(email);

            Id = id;
            Uid = uid;
            CreatedOn = createdOn;
            DeletedOn = deletedOn;
            UserName = userNameValue;
            Email = emailValue;
            PasswordHash = passwordHash;
        }
    }
}
