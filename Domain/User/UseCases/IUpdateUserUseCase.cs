using Domain.SeedWork;

namespace Domain.User.UseCases
{
    public interface IUpdateUserUseCase : IAbstractUseCase<Entity.User, UpdateUserCommand>
    {
    }

    public record UpdateUserCommand : AbstractCommand
    {
        public string EMail { get; init; }
        public Entity.User User { get; init; }
    }
}