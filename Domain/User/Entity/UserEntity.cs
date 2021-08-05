using System.ComponentModel.DataAnnotations;

namespace Domain.User.Entity
{
    public record User
    {
        [Key] public string Email { get; init; }

        public string Password { get; init; }
    }
}