using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.SeedWork;
using Domain.User.Entity;
using Domain.User.Port;
using Domain.User.UseCases;

namespace Application.UseCases.UserUseCases
{
    public class GetUserListUseCase : AbstractUseCase<IEnumerable<User>, GetUserListCommand>, IGetUserListUseCase
    {
        private readonly IUserRepository _userRepository;

        public GetUserListUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public override async Task<UseCaseResult<IEnumerable<User>>> Work(GetUserListCommand command)
        {
            var userList = await _userRepository.GetList();
            return Result.Ok(data: userList, message: "Список успешно загружен");
        }
    }
}