using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.SeedWork;
using Domain.ToDo.Entity;
using Domain.ToDo.Port;
using Domain.ToDo.UseCases;

namespace Application.UseCases.ToDoUseCases
{
    public class GetToDoListUseCase : AbstractUseCase<IEnumerable<ToDo>, GetTodoListCommand>, IGetToDoListUseCase
    {
        private readonly IToDoRepository _toDoRepository;

        public GetToDoListUseCase(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public override async Task<UseCaseResult<IEnumerable<ToDo>>> Work(GetTodoListCommand command)
        {
            var toDoList = await _toDoRepository.GetList();
            return Result.Ok(data: toDoList, message: "Список успешно загружен");
        }
    }
}