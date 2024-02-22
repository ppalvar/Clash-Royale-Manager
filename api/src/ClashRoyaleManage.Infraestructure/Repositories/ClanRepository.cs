using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using ClashRoyaleManager.Infraestructure.DbContexts;
using Microsoft.EntityFrameworkCore;


namespace ClashRoyaleManager.Infraestructure.Repositories;


public class ClanRepository : IClanRepository
{
    private readonly DefaultDbContext _dbContext;

    public ClanRepository(DefaultDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(Clan entity)
    {
        Clan? Clan = await Get(entity.IDClan);

        if (Clan != null) 
        {
            throw new EntityDoesNotExistException($"The entity of type <{nameof(Clan)}> and Id <{entity.IDClan}> already exists");
        }

        _dbContext.Clans.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Clan?> Get(Guid Id)
    {
        Clan? Clan = await _dbContext.Clans.Where(clan => clan.IDClan == Id).FirstOrDefaultAsync();
        return Clan;
    }

    public Task<IQueryable<Clan>> GetAll()
    {
        return Task.FromResult(_dbContext.Clans.AsQueryable());
    }

    public Task Update(Clan entity)
    {
        throw new NotImplementedException();
    }
}