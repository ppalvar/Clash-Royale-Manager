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

    public async Task Create(Battle entity)
    {
        Battle? Battle = await Get(entity.Player1Id, entity.Player2Id, entity.Date);

        if (Battle != null) 
        {
            throw new EntityDoesNotExistException($"The entity of type <{nameof(Battle)}> and Player1 <{entity.Player1Id}> and Player2 <{entity.Player2Id}> already exists");
        }

        _dbContext.Battles.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Battle?> Get(Guid Player1Id, Guid Player2Id, DateTime Date)
    {
        Battle? Battle = await _dbContext.Battles
            .Where(battle => 
                battle.Player1Id == Player1Id &&
                battle.Player2Id == Player2Id &&
                battle.Date == Date
            )
            .FirstOrDefaultAsync();
        return Battle;
    }

    public Task<IQueryable<Battle>> GetByPlayer(Guid Id)
    {
        // Realizar un Join entre Battles y Players para encontrar los jugadores en la batalla
        var playersInBattleQuery = from b in _dbContext.Battles
                                   join p1 in _dbContext.Players on b.Player1Id equals p1.Id
                                   where b.Player1Id == Id
                                   select b;

        // Realizar la unión para los player2
        var players2InBattleQuery = from b in _dbContext.Battles
                                    join p2 in _dbContext.Players on b.Player2Id equals p2.Id
                                    where b.Player2Id == Id
                                    select b;

        // Unir los resultados de ambos queries
        var allPlayersInBattle = playersInBattleQuery.Union(players2InBattleQuery);

        return Task.FromResult(allPlayersInBattle);
    }

    public Task<Battle?> Get(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<Battle>> GetAll()
    {
        return Task.FromResult(_dbContext.Battles.AsQueryable());
    }

    public Task Update(Battle entity)
    {
        throw new NotImplementedException();
    }
}