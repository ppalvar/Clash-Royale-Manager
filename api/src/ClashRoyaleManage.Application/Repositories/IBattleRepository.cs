using ClashRoyaleManager.Application.Repositories.Common;
using ClashRoyaleManager.Domain.Entities;


namespace ClashRoyaleManager.Application.Repositories;


public interface IBattleRepository
{
    Task Create(Battle entity);
    Task<(Battle? Battle, string Player1, string  Player2)?> Get(Guid Player1Id, Guid Player2Id, DateTime Date);
    Task<IQueryable<BattlePlayerInfo>> GetByPlayer(Guid Id);
    Task<IQueryable<BattlePlayerInfo>> GetAll();
}


public class BattlePlayerInfo
{
    public Battle? Battle { get; set; }
    public string Player1 { get; set; }
    public string Player2 { get; set; }
}