using System;

namespace API.ApiModels
{
    public record ToDoResponseModel
    {
        public int id { get; set; }
        public string Title { get; init; }
        public DateTime DateCreated { get; init; }
        public DateTime DateEnding { get; init; }
        public bool End { get; init; } = false;
    }
}