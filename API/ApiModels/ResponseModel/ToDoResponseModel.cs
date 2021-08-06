using System;

namespace API.ApiModels
{
    public record ToDoResponseModel(int Id, string Title, DateTime DateCreated, DateTime DateEnding, bool IsEnd);
}