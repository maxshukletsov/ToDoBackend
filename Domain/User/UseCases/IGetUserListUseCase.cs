using System.Collections.Generic;
using Domain.SeedWork;

namespace Domain.User.UseCases
{
    public interface IGetUserListUseCase : IAbstractUseCase<IEnumerable<Entity.User>, GetUserListCommand>
    {
    }

    public record GetUserListCommand : AbstractCommand
    {
    }
}