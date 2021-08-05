using System.Threading.Tasks;
using Domain.Auth;
using Domain.SeedWork;
using Domain.User.Entity;
using Domain.User.Port;

namespace Application.UseCases.AuthUseCases
{
    public class RegistrationUseCase : AbstractUseCase<User, RegistrationCommand>, IRegistrationUseCase
    {
        private readonly IUserRepository _userRepository;

        public RegistrationUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public override async Task<UseCaseResult<User>> Work(RegistrationCommand command)
        {
            var user = await _userRepository.Add(command.User);
            return Result.Ok(user, "Вы успешно зарегистрировались");
        }
    }
}