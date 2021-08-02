using System.Threading.Tasks;

namespace Domain.SeedWork
{
    public interface IAbstractUseCase<TDataType, in TCommand> where TCommand : AbstractCommand
    {
        Task<UseCaseResult<TDataType>> Work(TCommand command);
        Task<UseCaseResult<TDataType>> Invoke(TCommand command);
    }

    public interface IAbstractUseCase<in TCommand> where TCommand : AbstractCommand
    {
        Task<UseCaseResult> Work(TCommand command);
        Task<UseCaseResult> Invoke(TCommand command);
    }
}