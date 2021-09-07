using Domain.SeedWork;

namespace Domain.ToDo.UseCases
{
    public interface IDeleteToDoUseCase : IAbstractUseCase<DeleteTodoCommand>
    {
    }

    public record DeleteTodoCommand : AbstractCommand
    {
        public int Id { get; init; }
        public User.Entity.User User { get; init; }
    }
}