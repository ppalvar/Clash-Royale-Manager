using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using ClashRoyaleManager.Infraestructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleManager.Infraestructure.Repositories;

public class PlayerCardRepository(DefaultDbContext _dbContext) : IPlayerCardRepository
{
    public async Task Create(PlayerCard entity)
    {
        var playerCard = await _dbContext.PlayerCards.Where(c => c.IdPlayer == entity.IdPlayer)
                                               .Where(c => c.IdCard == entity.IdCard)
                                               .FirstOrDefaultAsync();

        if (playerCard != null)
            throw new EntityDoesNotExistException($"The entity of type <{nameof(PlayerCard)}> already exists");

        await _dbContext.PlayerCards.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public Task<PlayerCard?> Get(Guid Id) => throw new NotImplementedException();

    public Task<IQueryable<PlayerCard>> GetAll()
    {
        return Task.FromResult(_dbContext.PlayerCards.AsQueryable());
    }

    public Task<(IQueryable<PlayerCard> playerCards, int totalPages)> GetPagination(int page, int pageSize)
    {
        int skip = (page - 1) * pageSize;
        var all = _dbContext.PlayerCards.AsQueryable();
        var playerCard = all.OrderByDescending(x => x.IdPlayer).Skip(skip).Take(pageSize);
        return Task.FromResult((playerCard, all.Count() / pageSize));
    }

    public async Task<PlayerCard> Remove(Guid idPlayer, Guid idCard)
    {
        var playerCard = await _dbContext.PlayerCards.Where(c => c.IdPlayer == idPlayer)
                                               .Where(c => c.IdCard == idCard)
                                               .FirstOrDefaultAsync()
                      ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(ClanWar)}> does not exists");

        _dbContext.PlayerCards.Remove(playerCard);
        await _dbContext.SaveChangesAsync();

        return playerCard;
    }

    public async Task Update(PlayerCard entity)
    {
        var playerCard = await _dbContext.PlayerCards.Where(c => c.IdPlayer == entity.IdPlayer)
                                               .Where(c => c.IdCard == entity.IdCard)
                                               .FirstOrDefaultAsync()
                      ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(ClanWar)}> does not exists");

        _dbContext.PlayerCards.Remove(playerCard);
        await _dbContext.SaveChangesAsync();
    }
}