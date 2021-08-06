using System;

namespace Domain.ToDo.Entity
{
    public record ToDo
    {
        public int Id { get; init; }
        public string Title { get; set; }

        public DateTime DateCreated { get; init; } = DateTime.Now;

        public DateTime DateEnding { get; set; }

        public bool End { get; set; }
        
        public User.Entity.User User { get; set; }
    };
}