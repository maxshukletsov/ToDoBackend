using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.User.Entity
{
    public record User
    {
        [Key] public string Email { get; init; }

        public string Password { get; init; }
        
        public IEnumerable<ToDo.Entity.ToDo> ToDo { get; init; }
    }
}