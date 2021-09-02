namespace Shared.User
{
    using Shared.User.Interfaces;

    public class CurrentUser : ICurrentUser
    {
        public string Id { get; }

        public string Name { get; }

        public string Email { get; }

        public CurrentUser(string id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}
