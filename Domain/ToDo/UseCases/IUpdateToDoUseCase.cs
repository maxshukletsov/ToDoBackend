using Domain.SeedWork;

namespace Domain.ToDo.UseCases
{
    public interface IUpdateToDoUseCase : IAbstractUseCase<Entity.ToDo, UpdateTodoCommand>
    {
    }

    public record UpdateTodoCommand : AbstractCommand
    {
        public int Id { get; init; }
        public Entity.ToDo ToDo { get; init; }
        public string User { get; init; }
    }
}