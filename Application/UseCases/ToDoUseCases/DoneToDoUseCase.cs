using System.Threading.Tasks;
using Domain.SeedWork;
using Domain.ToDo.Port;
using Domain.ToDo.UseCases;

namespace Application.UseCases.ToDoUseCases
{
    public class DoneToDoUseCase : AbstractUseCase<DoneTodoCommand>, IDoneToDoUseCase
    {
        private readonly IToDoRepository _toDoRepository;

        public DoneToDoUseCase(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public override async Task<UseCaseResult> Work(DoneTodoCommand command)
        {
            var toDo = await _toDoRepository.Get(command.Id);
            if (toDo == null)
                return Result.NotFound($"Задача с id: {command.Id} не найдена");
            if (command.User != null && toDo.User != command.User)
                return Result.Forbidden("У вас нет доступа к этой задаче");
            var doneToDo = await _toDoRepository.Done(toDo);
            return Result.Ok(message: $"Задача {doneToDo.Id} выполнена");
        }
    }
}