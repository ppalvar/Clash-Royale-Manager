using ClashRoyaleManager.Application.Repositories.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Repositories;

public interface IClanWarRepository : IBaseRepository<ClanWar>
{
    Task<ClanWar> Remove(Guid clanId, Guid warId);
    Task<(IQueryable<ClanWar> clanWar, int totalPages)> GetPagination(int page, int pageSize);
}

