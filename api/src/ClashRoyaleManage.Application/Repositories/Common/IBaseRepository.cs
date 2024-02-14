namespace ClashRoyaleManager.Application.Repositories.Common;

public interface IBaseRepository <TEntity>
{
    Task Create(TEntity entity);
    Task Update(TEntity entity);
    Task<TEntity?> Get(Guid Id);
    Task<IQueryable<TEntity>> GetAll();
}