using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using ClashRoyaleManager.Infraestructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleManager.Infraestructure.Repositories;

public class ClanWarRepository(DefaultDbContext _dbContext) : IClanWarRepository
{
    public async Task Create(ClanWar entity)
    {
        var clanWar = await _dbContext.ClanWars.Where(c => c.IdWar == entity.IdWar)
                                               .Where(c => c.IdClan == entity.IdClan)
                                               .FirstOrDefaultAsync();

        if (clanWar != null)
            throw new EntityDoesNotExistException($"The entity of type <{nameof(ClanWar)}> already exists");

        await _dbContext.ClanWars.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public Task<ClanWar?> Get(Guid Id) => throw new NotImplementedException();

    public Task<IQueryable<ClanWar>> GetAll()
    {
        return Task.FromResult(_dbContext.ClanWars.AsQueryable());
    }

    public Task<(IQueryable<ClanWar> clanWar,  int Page, int totalPages)> GetPagination(int page, int pageSize)
    {
        int skip = (page - 1) * pageSize;
        var all = _dbContext.ClanWars.AsQueryable();
        var clanWar = all.OrderByDescending(x => x.Clan).Skip(skip).Take(pageSize);
        return Task.FromResult((clanWar, page, all.Count() / pageSize));
    }

    public async Task<ClanWar> Remove(Guid clanId, Guid warId)
    {
        var clanWar = await _dbContext.ClanWars.Where(c => c.IdWar == warId)
                                               .Where(c => c.IdClan == clanId)
                                               .FirstOrDefaultAsync()
                      ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(ClanWar)}> does not exists");

        _dbContext.ClanWars.Remove(clanWar);
        await _dbContext.SaveChangesAsync();

        return clanWar;
    }

    public async Task Update(ClanWar entity)
    {
        var clanWar = await _dbContext.ClanWars.Where(c => c.IdWar == entity.IdWar)
                                               .Where(c => c.IdClan == entity.IdClan)
                                               .FirstOrDefaultAsync()
                      ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(ClanWar)}> does not exists");

        _dbContext.ClanWars.Remove(clanWar);
        await _dbContext.SaveChangesAsync();
    }
}