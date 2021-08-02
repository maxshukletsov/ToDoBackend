using System;

namespace Domain.ToDo.Entity
{
    public record ToDo
        {
            public int id { get; set; }
            public string Title { get; set; }
        
            public DateTime DateCreated { get; set; } = DateTime.Now;
        
            public DateTime DateEnding { get; set; }

            public bool End { get; set; } = false;
        }
    }