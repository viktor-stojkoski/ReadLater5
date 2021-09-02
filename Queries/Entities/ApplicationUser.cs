namespace Queries.Entities
{
    using Queries.Common.Entities;

    public class ApplicationUser : Entity
    {
        public string UserName { get; protected internal set; }

        public string Email { get; protected internal set; }

        public string PasswordHash { get; protected internal set; }
    }
}
