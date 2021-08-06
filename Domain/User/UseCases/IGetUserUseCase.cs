using Domain.SeedWork;

namespace Domain.User.UseCases
{
    public interface IGetUserUseCase : IAbstractUseCase<Entity.User, GetUserCommand>
    {
    }

    public record GetUserCommand : AbstractCommand
    {
        public string EMail { get; init; }
    }
}