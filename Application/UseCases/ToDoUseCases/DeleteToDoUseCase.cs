using System.Threading.Tasks;
using Domain.SeedWork;
using Domain.ToDo.Entity;
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
            var deletedToDo = await _toDoRepository.Delete(command.Id);
            return Result.Ok(deletedToDo);
        }
    }
}