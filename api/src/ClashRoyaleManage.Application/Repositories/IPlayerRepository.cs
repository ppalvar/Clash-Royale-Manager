using ClashRoyaleManager.Application.Repositories.Common;
using ClashRoyaleManager.Domain.Entities;


namespace ClashRoyaleManager.Application.Repositories;


public interface IPlayerRepository : IBaseRepository<Player> {
    Task<(IQueryable<Player> Players, int Page, int TotalPages)> GetPagination(int page=1, int size=10);
    Task Remove(Guid Id);
}