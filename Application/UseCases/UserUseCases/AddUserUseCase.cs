using System.Threading.Tasks;
using Domain.SeedWork;
using Domain.User.Entity;
using Domain.User.Port;
using Domain.User.UseCases;


namespace Application.UseCases.UserUseCases
{
    public class AddUserUseCase : AbstractUseCase<User, AddUserCommand>, IAddUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public AddUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public override async Task<UseCaseResult<User>> Work(AddUserCommand command)
        {
            var addedToDo = await _userRepository.Add(command.User);
            return Result.Ok(addedToDo, "Пользователь добавлен");
        }
    }
}