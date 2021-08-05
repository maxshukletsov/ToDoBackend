using Domain.SeedWork;

namespace Domain.User.UseCases
{
    public interface IDeleteUserUseCase : IAbstractUseCase<DeleteUserCommand>
    {
    }

    public record DeleteUserCommand : AbstractCommand
    {
        public string EMail { get; init; }
    }
}