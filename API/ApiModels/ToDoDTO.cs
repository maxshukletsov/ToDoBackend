using System;
using Domain.ToDo.Entity;

namespace API.ApiModels
{
    public class ToDoDTO
    {
        public string Title { get; init; }
        
        public DateTime DateEnding { get; init; }

    }
    
}