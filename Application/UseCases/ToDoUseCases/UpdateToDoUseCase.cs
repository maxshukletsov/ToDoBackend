using System.Threading.Tasks;
using Domain.SeedWork;
using Domain.ToDo.Entity;
using Domain.ToDo.Port;
using Domain.ToDo.UseCases;
using AutoMapper;

namespace Application.UseCases.ToDoUseCases
{
    public class UpdateToDoUseCase : AbstractUseCase<ToDo, UpdateTodoCommand>, IUpdateToDoUseCase
    {
        private readonly IToDoRepository _toDoRepository;
        private readonly IMapper _mapper;

        public UpdateToDoUseCase(IToDoRepository toDoRepository, IMapper mapper)
        {
            _toDoRepository = toDoRepository;
            _mapper = mapper;
        }

        public override async Task<UseCaseResult<ToDo>> Work(UpdateTodoCommand command)
        {
            var toDo = await _toDoRepository.Get(command.Id);
            if (toDo == null)
                return Result.NotFound(toDo,$"Задача с id: {command.Id} не найдена");
            if (command.User != null && toDo.User != command.User)
                return Result.Forbidden(toDo = null, "У вас нет доступа к этой задаче");
            var updateToDo = _mapper.Map(command.ToDo, toDo);
            var updatedToDo = await _toDoRepository.Update(command.Id, updateToDo);
            return Result.Ok(updatedToDo, $"Объект {command.Id} обновлен успешно");
        }
    }
}