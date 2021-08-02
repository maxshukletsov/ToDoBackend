using System.Threading.Tasks;

namespace Domain.SeedWork
{
    public abstract class AbstractUseCase<TDataType, TCommand> : IAbstractUseCase<TDataType, TCommand> 
    where TCommand : AbstractCommand
    {
        public abstract Task<UseCaseResult<TDataType>> Work(TCommand command);
        
        public virtual async Task<UseCaseResult<TDataType>> Invoke(TCommand command)
        {
            return await Work(command);
        }
    }
    
    public abstract class AbstractUseCase<TCommand> : IAbstractUseCase<TCommand> where TCommand : AbstractCommand
    {
        public abstract Task<UseCaseResult> Work(TCommand command);
        
        public virtual async Task<UseCaseResult> Invoke(TCommand command)
        {
            return await Work(command);
        }
    }
}