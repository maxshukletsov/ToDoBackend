using Domain.SeedWork;

namespace Domain.ToDo.UseCases
{
    public interface IGetToDoUseCase : IAbstractUseCase<Entity.ToDo, GetTodoCommand>
    {
    }

    public record GetTodoCommand : AbstractCommand
    {
        public int Id { get; init; }
        public string User { get; init; }
    }
}