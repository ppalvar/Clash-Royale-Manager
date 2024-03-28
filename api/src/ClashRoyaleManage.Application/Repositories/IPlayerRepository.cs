using ClashRoyaleManager.Application.Repositories.Common;
using ClashRoyaleManager.Domain.Entities;


namespace ClashRoyaleManager.Application.Repositories;


public interface IPlayerRepository : IBaseRepository<Player>
{
    Task<(IQueryable<Player> Players, int Page, int TotalPages)> GetPagination(int page = 1, int size = 10);
    Task Remove(Guid Id);
    Task<(IQueryable<Player> Players, int Page, int TotalPages)> GetBestInWar(Guid warId, int page = 1, int size = 10);
    Task<(IQueryable<Clan> Clans, int Page, int TotalPages)> GetClansCanJoin(Guid playerId, int page = 1, int size = 10);
}