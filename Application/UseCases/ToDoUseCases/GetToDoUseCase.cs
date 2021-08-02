using System.Threading.Tasks;
using Domain.SeedWork;
using Domain.ToDo.Entity;
using Domain.ToDo.Port;
using Domain.ToDo.UseCases;

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
            return Result.Ok(toDo, $"Загружен результат {command.Id}");
        }
    }
}