using System.Collections.Generic;
using Domain.SeedWork;

namespace Domain.ToDo.UseCases
{
    public interface IGetToDoListUseCase : IAbstractUseCase<IEnumerable<Entity.ToDo>, GetTodoListCommand>
    {
    }
    public record GetTodoListCommand : AbstractCommand
    {
    }
}