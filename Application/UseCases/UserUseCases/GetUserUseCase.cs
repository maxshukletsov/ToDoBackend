using System.Threading.Tasks;
using Domain.SeedWork;
using Domain.User.Entity;
using Domain.User.Port;
using Domain.User.UseCases;

namespace Application.UseCases.UserUseCases
{
    public class GetUserUseCase : AbstractUseCase<User, GetUserCommand>, IGetUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public GetUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public override async Task<UseCaseResult<User>> Work(GetUserCommand command)
        {
            var User = await _userRepository.Get(command.EMail);
            return Result.Ok(User, $"Загружен пользователь {command.EMail}");
        }
    }
}