using System.Threading.Tasks;
using Domain.SeedWork;
using AutoMapper;
using Domain.User.Entity;
using Domain.User.Port;
using Domain.User.UseCases;

namespace Application.UseCases.UserUseCases
{
    public class UpdateUserUseCase : AbstractUseCase<User, UpdateUserCommand>, IUpdateUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserUseCase(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public override async Task<UseCaseResult<User>> Work(UpdateUserCommand command)
        {
            var toDo = await _userRepository.Get(command.EMail);
            var updateToDo = _mapper.Map(command.User, toDo);
            var updatedToDo = await _userRepository.Update(command.EMail, updateToDo);
            return Result.Ok(updatedToDo, $"Объект {command.EMail} обновлен успешно");
        }
    }
}