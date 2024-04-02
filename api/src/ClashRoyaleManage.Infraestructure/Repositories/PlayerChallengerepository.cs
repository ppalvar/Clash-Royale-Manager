using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using ClashRoyaleManager.Infraestructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleManager.Infraestructure.Repositories;

public class PlayerChallengeRepository(DefaultDbContext _dbContext) : IPlayerChallengeRepository
{
    public async Task Create(PlayerChallenge entity)
    {
        var playerChallenge = await _dbContext.PlayerChallenges.Where(c => c.IdPlayer == entity.IdPlayer)
                                               .Where(c => c.IdChallenge == entity.IdChallenge)
                                               .FirstOrDefaultAsync();

        if (playerChallenge != null)
            throw new EntityDoesNotExistException($"The entity of type <{nameof(PlayerChallenge)}> already exists");

        await _dbContext.PlayerChallenges.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public Task<PlayerChallenge?> Get(Guid Id) => throw new NotImplementedException();

    public Task<IQueryable<PlayerChallenge>> GetAll()
    {
        return Task.FromResult(_dbContext.PlayerChallenges.AsQueryable());
    }

    public async Task<PlayerChallenge> Remove(Guid idPlayer, Guid idChallenge)
    {
        var playerChallenge = await _dbContext.PlayerChallenges.Where(c => c.IdPlayer == idPlayer)
                                               .Where(c => c.IdChallenge == idChallenge)
                                               .FirstOrDefaultAsync()
                      ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(PlayerChallenge)}> does not exists");

        _dbContext.PlayerChallenges.Remove(playerChallenge);
        await _dbContext.SaveChangesAsync();

        return playerChallenge;
    }

    public async Task Update(PlayerChallenge entity)
    {
        var playerChallenge = await _dbContext.PlayerChallenges.Where(c => c.IdPlayer == entity.IdPlayer)
                                               .Where(c => c.IdChallenge == entity.IdChallenge)
                                               .FirstOrDefaultAsync()
                      ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(PlayerChallenge)}> does not exists");

        _dbContext.PlayerChallenges.Remove(playerChallenge);
        await _dbContext.SaveChangesAsync();
    }

    Task<(IQueryable<PlayerChallenge> playerChallenges, int Page, int totalPages)> IPlayerChallengeRepository.GetPagination(int page, int pageSize)
    {
        int skip = (page - 1) * pageSize;
        int size = pageSize;
        int cantElements = size;
        int totalElements = _dbContext.PlayerChallenges.Count();
        int totalPages = (int)Math.Ceiling((double)totalElements / size);

        if (page == totalPages && totalElements % size != 0)
        {
            cantElements = totalElements % size;
        }
        var all = _dbContext.PlayerChallenges.AsQueryable();
        var playerChallenge = all.OrderByDescending(x => x.IdPlayer).Skip(skip).Take(cantElements);
        return Task.FromResult((playerChallenge, page, totalElements));
    }
}