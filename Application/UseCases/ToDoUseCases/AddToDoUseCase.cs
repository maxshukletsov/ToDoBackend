using System.Threading.Tasks;
using Domain.ToDo.UseCases;
using Domain.SeedWork;
using Domain.ToDo.Entity;
using Domain.ToDo.Port;


namespace Application.UseCases.ToDoUseCases
{
    public class AddToDoUseCase : AbstractUseCase<ToDo, AddToDoCommand>, IAddToDoUseCase
    {
        private readonly IToDoRepository _toDoRepository;

        public AddToDoUseCase(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public override async Task<UseCaseResult<ToDo>> Work(AddToDoCommand command)
        {
            var addedToDo = await _toDoRepository.Add(command.ToDo);
            return Result.Ok(addedToDo, "Задача добавлена");
        }
    }
}