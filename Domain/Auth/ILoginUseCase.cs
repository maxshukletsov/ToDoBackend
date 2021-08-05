using Domain.SeedWork;

namespace Domain.Auth
{
    public interface ILoginUseCase : IAbstractUseCase<string, LoginCommand>
    {
        
    }

    public record LoginCommand(string EMail, string Password, bool IsAnonymus = false) : AbstractCommand;
}