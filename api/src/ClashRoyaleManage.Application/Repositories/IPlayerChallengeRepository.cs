using ClashRoyaleManager.Application.Repositories.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Repositories;

public interface IPlayerChallengeRepository : IBaseRepository<PlayerChallenge>
{
    Task<PlayerChallenge> Remove(Guid idPlayer, Guid idChallenge);
    Task<(IQueryable<PlayerChallenge> playerChallenges, int totalPages)> GetPagination(int page, int pageSize);
    Task<(IQueryable<Player> playerChallenges, int page, int totalPages)> GetByChallenge(Guid Id, int page, int size);
}