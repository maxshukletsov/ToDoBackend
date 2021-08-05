using System.Threading.Tasks;
using Domain.SeedWork;
using Domain.User.Port;
using Domain.User.UseCases;

namespace Application.UseCases.UserUseCases
{
    public class DeleteUserUseCase : AbstractUseCase<DeleteUserCommand>, IDeleteUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public override async Task<UseCaseResult> Work(DeleteUserCommand command)
        {
            var deletedUser = await _userRepository.Delete(command.EMail);
            return Result.Ok(deletedUser);
        }
    }
}