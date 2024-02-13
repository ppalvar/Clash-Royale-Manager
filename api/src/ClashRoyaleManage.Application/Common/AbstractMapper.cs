using FastEndpoints;

namespace ClashRoyaleManager.Application.Common;

public abstract class AbstractMapper<TEntity, TCommand, TResponse>
    where TCommand : ICommand
{
    public virtual TEntity ToEntity(TCommand command)
    {
        return default!;
    }
    public virtual TCommand ToCommand(TEntity entity)
    {
        return default!;
    }

    public virtual TResponse ToResponse(TEntity entity)
    {
        return default!;
    }
}