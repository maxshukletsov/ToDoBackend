using System.Threading.Tasks;
using Domain.SeedWork;
using Domain.ToDo.Port;
using Domain.ToDo.UseCases;

namespace Application.UseCases.ToDoUseCases
{
    public class DeleteToDoUseCase : AbstractUseCase<DeleteTodoCommand>, IDeleteToDoUseCase
    {
        private readonly IToDoRepository _toDoRepository;

        public DeleteToDoUseCase(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public override async Task<UseCaseResult> Work(DeleteTodoCommand command)
        {
            var toDo = await _toDoRepository.Get(command.Id);
            if (toDo == null)
                return Result.NotFound($"Задача с id: {command.Id} не найдена");
            if (command.User != null && toDo.User != command.User)
                return Result.Forbidden("У вас нет доступа к этой задаче");
            var deletedToDo = await _toDoRepository.Delete(toDo);
            return Result.Ok(deletedToDo);
        }
    }
}