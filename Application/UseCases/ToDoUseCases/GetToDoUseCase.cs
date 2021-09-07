using System.Diagnostics.Tracing;
using System.Threading.Tasks;
using Domain.SeedWork;
using Domain.ToDo.Entity;
using Domain.ToDo.Port;
using Domain.ToDo.UseCases;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.ToDoUseCases
{
    public class GetToDoUseCase : AbstractUseCase<ToDo, GetTodoCommand>, IGetToDoUseCase
    {
        private readonly IToDoRepository _toDoRepository;

        public GetToDoUseCase(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public override async Task<UseCaseResult<ToDo>> Work(GetTodoCommand command)
        {   
            var toDo = await _toDoRepository.Get(command.Id);
            if (toDo == null)
               return Result.NotFound(toDo,$"Задача с id: {command.Id} не найдена");
            if (command.User != null && toDo.User != command.User)
                return Result.Forbidden(toDo = null, "У вас нет доступа к этой задаче");
            return Result.Ok(toDo, $"Загружен результат {command.Id}");
        }
    }
}