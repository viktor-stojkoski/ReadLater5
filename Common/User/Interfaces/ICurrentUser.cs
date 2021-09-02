namespace Shared.User.Interfaces
{
    public interface ICurrentUser
    {
        /// <summary>
        /// Current logged in user id.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Current logged in user name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Current logged in user email.
        /// </summary>
        string Email { get; }
    }
}
