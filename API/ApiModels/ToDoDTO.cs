using System;
using Domain.ToDo.Entity;

namespace API.ApiModels
{
    public record ToDoDTO
    {
        public string Title { get; init; }

        public DateTime DateEnding { get; init; }
    }
}