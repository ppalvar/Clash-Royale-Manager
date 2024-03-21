using System.Security.Cryptography;
using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using ClashRoyaleManager.Infraestructure.DbContexts;
using Microsoft.EntityFrameworkCore;


namespace ClashRoyaleManager.Infraestructure.Repositories;


public class BattleRepository : IBattleRepository
{
    private readonly DefaultDbContext _dbContext;

    public BattleRepository(DefaultDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    //TODO - Administar que cada jugador solo pueda tener una batalla en el mismo día y 
    // la llave sea un solo juagador
    public async Task Create(Battle entity)
    {
        var battle = await Get(entity.Player1Id, entity.Player2Id, entity.Date);

        if (battle != null) 
        {
            throw new EntityDoesNotExistException($"The entity of type <{nameof(Battle)}> and Player1 <{entity.Player1Id}> and Player2 <{entity.Player2Id}> already exists");
        }

        _dbContext.Battles.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<(Battle? Battle, string Player1, string  Player2)?> Get(Guid Player1Id, Guid Player2Id, DateTime Date)
    {
        var battleWithPlayers = (from b in _dbContext.Battles
                                join p1 in _dbContext.Players on b.Player1Id equals p1.Id
                                join p2 in _dbContext.Players on b.Player2Id equals p2.Id
                                where b.Player1Id == Player1Id && b.Player2Id == Player2Id
                                select new 
                                {
                                    Battle = b,
                                    Player1 = p1.Nickname,
                                    Player2 = p2.Nickname
                                }).FirstOrDefault();

        if (battleWithPlayers is null)
        {
            return null;
        }

        return (battleWithPlayers.Battle, battleWithPlayers.Player1, battleWithPlayers.Player2);
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