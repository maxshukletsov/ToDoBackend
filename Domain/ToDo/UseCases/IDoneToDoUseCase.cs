using Domain.SeedWork;

namespace Domain.ToDo.UseCases
{
    public interface IDoneToDoUseCase : IAbstractUseCase<DoneTodoCommand>
    {
    }

    public record DoneTodoCommand : AbstractCommand
    {
        public int Id { get; init; }
        public string User { get; init; }
    }
}