using Domain.SeedWork;

namespace Domain.Auth
{
    public interface IRegistrationUseCase : IAbstractUseCase<User.Entity.User, RegistrationCommand>
    {
    }

    public record RegistrationCommand : AbstractCommand
    {
        public User.Entity.User User { get; init; }
    }
}