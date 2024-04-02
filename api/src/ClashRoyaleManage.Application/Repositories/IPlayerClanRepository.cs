using ClashRoyaleManager.Application.Repositories.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Repositories;

public interface IPlayerClanRepository : IBaseRepository<PlayerClan>
{
    Task<PlayerClan> Remove(Guid idPlayer, Guid idClan);
    Task<(IQueryable<PlayerClan> playerClans,  int Page, int totalPages)> GetPagination(int page, int pageSize);
}