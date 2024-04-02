using ClashRoyaleManager.Application.Repositories.Common;
using ClashRoyaleManager.Domain.Entities;


namespace ClashRoyaleManager.Application.Repositories;


public interface IBattleRepository
{
    Task Create(Battle entity);
    Task Update(Battle entity);
    Task Remove(Battle entity);
    Task<BattlePlayerInfo> Get(Guid Player1Id, DateTime Date);
    Task<IQueryable<BattlePlayerInfo>> GetByPlayer(Guid Id);
    Task<IQueryable<BattlePlayerInfo>> GetAll();
    Task<(IQueryable<BattlePlayerInfo> Battles, int Page, int TotalPages)> GetPagination(int page = 1, int size = 10);
}


public class BattlePlayerInfo
{
    public Battle? Battle { get; set; }
    public string Player1 { get; set; }
    public string Player2 { get; set; }
}