using System.Threading.Tasks;
using Domain.SeedWork;
using Domain.ToDo.Entity;
using Domain.ToDo.Port;
using Domain.ToDo.UseCases;

namespace Application.UseCases.ToDoUseCases
{
    public class UpdateToDoUseCase : AbstractUseCase<ToDo, UpdateTodoCommand>, IUpdateToDoUseCase
    {
        private readonly IToDoRepository _toDoRepository;

        public UpdateToDoUseCase(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public override async Task<UseCaseResult<ToDo>> Work(UpdateTodoCommand command)
        {
            var updatedToDo = await _toDoRepository.Update(command.Id, command.ToDo);
            return Result.Ok(updatedToDo, $"Объект {command.Id} обновлен успешно");
        }
    }
}