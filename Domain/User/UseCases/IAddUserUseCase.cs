using Domain.SeedWork;

namespace Domain.User.UseCases
{
    public interface IAddUserUseCase : IAbstractUseCase<Entity.User, AddUserCommand>
    {
    }

    public record AddUserCommand : AbstractCommand
    {
        public Entity.User User { get; init; }
    }
}