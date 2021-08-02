using Domain.SeedWork;

namespace Domain.ToDo.UseCases
{
    public interface IAddToDoUseCase : IAbstractUseCase<Entity.ToDo, AddToDoCommand>
    {
    }
    
    public record AddToDoCommand : AbstractCommand
    {
        public Entity.ToDo ToDo { get; init; }
    }
}