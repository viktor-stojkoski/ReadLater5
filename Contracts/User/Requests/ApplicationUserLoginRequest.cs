namespace Contracts.User.Requests
{
    using System.ComponentModel.DataAnnotations;

    public class ApplicationUserLoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
