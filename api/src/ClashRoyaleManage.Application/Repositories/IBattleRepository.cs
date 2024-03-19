using ClashRoyaleManager.Application.Repositories.Common;
using ClashRoyaleManager.Domain.Entities;


namespace ClashRoyaleManager.Application.Repositories;


public interface IBattleRepository : IBaseRepository<Battle> {
    Task<Battle?> Get(Guid Player1Id, Guid Player2Id, DateTime Date);
    Task<IQueryable<Battle>> GetByPlayer(Guid Id);
}