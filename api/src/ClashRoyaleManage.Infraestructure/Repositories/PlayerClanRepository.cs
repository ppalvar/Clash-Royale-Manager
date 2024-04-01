using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using ClashRoyaleManager.Infraestructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleManager.Infraestructure.Repositories;

public class PlayerClanRepository(DefaultDbContext _dbContext) : IPlayerClanRepository
{
    public async Task Create(PlayerClan entity)
    {
        var playerClan = await _dbContext.PlayerClans.Where(c => c.IdPlayer == entity.IdClan)
                                                  .Where(c => c.IdClan == entity.IdClan)
                                                  .FirstOrDefaultAsync();

        if (playerClan != null)
            throw new EntityDoesNotExistException($"The entity of type <{nameof(PlayerClan)}> already exists");

        await _dbContext.PlayerClans.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public Task<PlayerClan?> Get(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<PlayerClan>> GetAll()
    {
        return Task.FromResult(_dbContext.PlayerClans.AsQueryable());
    }

    public Task<(IQueryable<PlayerClan> playerClans, int totalPages)> GetPagination(int page, int pageSize)
    {
        int skip = (page - 1) * pageSize;
        var all = _dbContext.PlayerClans.AsQueryable();
        var playerClan = all.OrderByDescending(x => x.IdPlayer).Skip(skip);
        return Task.FromResult((playerClan, all.Count() / pageSize));
    }

    public async Task<PlayerClan> Remove(Guid idPlayer, Guid idClan)
    {
        var playerClan = await _dbContext.PlayerClans.Where(c => c.IdPlayer == idPlayer)
                                               .Where(c => c.IdClan == idClan)
                                               .FirstOrDefaultAsync()
                      ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(PlayerClan)}> does not exists");

        _dbContext.PlayerClans.Remove(playerClan);
        await _dbContext.SaveChangesAsync();

        return playerClan;
    }

    public async Task Update(PlayerClan entity)
    {
        var playerClan = await _dbContext.PlayerClans.Where(c => c.IdPlayer == entity.IdPlayer)
                                               .Where(c => c.IdClan == entity.IdClan)
                                               .FirstOrDefaultAsync()
                      ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(PlayerClan)}> does not exists");

        _dbContext.PlayerClans.Remove(playerClan);
        await _dbContext.SaveChangesAsync();
    }
}