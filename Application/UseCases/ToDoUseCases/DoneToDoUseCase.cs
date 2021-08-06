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
            var doneToDo = await _toDoRepository.Done(command.Id);
            return Result.Ok(message: $"Задача {doneToDo.Id} выполнена");
        }
    }
}