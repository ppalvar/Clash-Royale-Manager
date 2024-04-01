using ClashRoyaleManager.Application.Repositories.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Repositories;

public interface IPlayerCardRepository : IBaseRepository<PlayerCard>
{
    Task<PlayerCard> Remove(Guid idPlayer, Guid idCard);
    Task<(IQueryable<PlayerCard> playerCards, int Page, int totalPages)> GetPagination(int page, int pageSize);
}