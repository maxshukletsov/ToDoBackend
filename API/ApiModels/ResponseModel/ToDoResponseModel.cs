using System;

namespace API.ApiModels
{
    public record ToDoResponseModel()
    {
        public int Id { get; init; }
        public string Title{ get; init; }
        public DateTime DateCreated{ get; init; }
        public DateTime DateEnding{ get; init; }
        public bool IsEnd{ get; init; }
    }
}