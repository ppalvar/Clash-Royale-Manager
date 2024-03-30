using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Application.Services;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using ClashRoyaleManager.Infraestructure.DbContexts;
using Microsoft.EntityFrameworkCore;


namespace ClashRoyaleManager.Infraestructure.Repositories;


public class BattleRepository : IBattleRepository
{
    private readonly DefaultDbContext _dbContext;
    private readonly IDateTimeProvider _dateTimeProvider;

    public BattleRepository(DefaultDbContext dbContext, IDateTimeProvider dateTimeProvider)
    {
        _dbContext = dbContext;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task Create(Battle entity)
    {
        var battle1 = (await GetByPlayer(entity.Player1Id)).Where(b => b.Battle!.Date == entity.Date).FirstOrDefault();
        var battle2 = (await GetByPlayer(entity.Player2Id)).Where(b => b.Battle!.Date == entity.Date).FirstOrDefault();

        if (battle1 != null)
        {
            throw new EntityDoesNotExistException($"The entity of type <{nameof(Battle)}> and Player1 <{entity.Player1Id}> already exists");
        }

        if (battle2 != null)
        {
            throw new EntityDoesNotExistException($"The entity of type <{nameof(Battle)}> and Player1 <{entity.Player2Id}> already exists");
        }

        _dbContext.Battles.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Battle entity)
    {
        var existingBattle = await _dbContext.Battles
                            .FirstOrDefaultAsync(b => b.Player1Id == entity.Player1Id && b.Date == entity.Date) ?? 
                            throw new EntityDoesNotExistException($"The entity of type <{nameof(Battle)}> with Player1 <{entity.Player1Id}> and Date <{entity.Date}> does not exist.");
        
        _dbContext.Entry(existingBattle).CurrentValues.SetValues(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Remove(Battle entity)
    {
        var existingBattle = await _dbContext.Battles
                            .FirstOrDefaultAsync(b => b.Player1Id == entity.Player1Id && b.Date == entity.Date) ?? 
                            throw new EntityDoesNotExistException($"The entity of type <{nameof(Battle)}> with Player1 <{entity.Player1Id}> and Date <{entity.Date}> does not exist.");
        
        _dbContext.Battles.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<BattlePlayerInfo> Get(Guid Player1Id, DateTime Date)
    {
        var battleWithPlayers = await _dbContext.Battles.Where(b => b.Player1Id == Player1Id)
                                                        .Include(b => b.Player1)
                                                        .Include(b => b.Player2)
                                                        .FirstOrDefaultAsync();

        if (battleWithPlayers is null)
        {
            return null;
        }

        return new BattlePlayerInfo {
            Battle = battleWithPlayers,
            Player1 = battleWithPlayers.Player1.Nickname,
            Player2 = battleWithPlayers.Player2.Nickname
        };
    }

    public Task<IQueryable<BattlePlayerInfo>> GetByPlayer(Guid Id)
    {
        var resultQuery = _dbContext.Battles
        .Where(b => b.Player1Id == Id || b.Player2Id == Id)
        .Join(_dbContext.Players, b => b.Player1Id, p => p.Id, (b, p1) => new { b, p1 })
        .Join(_dbContext.Players, bp1 => bp1.b.Player2Id, p2 => p2.Id, (bp1, p2) => new BattlePlayerInfo
        {
            Battle = bp1.b,
            Player1 = bp1.p1.Nickname,
            Player2 = p2.Nickname
        })
        .AsQueryable();

        return Task.FromResult(resultQuery.Cast<BattlePlayerInfo?>());
    }

    public Task<IQueryable<BattlePlayerInfo>> GetAll()
    {
        var resultQuery = _dbContext.Battles
        .Join(_dbContext.Players, b => b.Player1Id, p => p.Id, (b, p1) => new { b, p1 })
        .Join(_dbContext.Players, bp1 => bp1.b.Player2Id, p2 => p2.Id, (bp1, p2) => new BattlePlayerInfo
        {
            Battle = bp1.b,
            Player1 = bp1.p1.Nickname,
            Player2 = p2.Nickname
        })
        .AsQueryable();

        return Task.FromResult(resultQuery.Cast<BattlePlayerInfo?>());
    }
}