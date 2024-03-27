using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using ClashRoyaleManager.Infraestructure.DbContexts;
using Microsoft.EntityFrameworkCore;


namespace ClashRoyaleManager.Infraestructure.Repositories;


public class ClanRepository : IClanRepository
{
    private readonly DefaultDbContext _dbContext;
    private readonly TypeClanRepository _typeClanRepository;
    public ClanRepository(DefaultDbContext dbContext)
    {
        _dbContext = dbContext;
        _typeClanRepository = new TypeClanRepository(dbContext);
    }

    public async Task Create(Clan entity)
    {
        Clan? Clan = await Get1(entity.Id);

        if (Clan != null)
        {
            throw new EntityDoesNotExistException($"The entity of type <{nameof(Clan)}> and Id <{entity.Id}> already exists");
        }

        _dbContext.Clans.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<(Clan? Clan, string Type)?> Get(Guid Id)
    {
        Clan? Clan = await _dbContext.Clans
        .Where(clan => clan.Id == Id)
        .Include(clan => clan.TypeClan)
        .FirstOrDefaultAsync();
        return (Clan, Clan.TypeClan.Name.ToString());
    }

    public Task<IQueryable<ClanTypeInfo>> GetAll()
    {
        var resultQuery = _dbContext.Clans
        .Join(_dbContext.TypeClans, b => b.IdType, p => p.Id, (b, p1) => new ClanTypeInfo
        {
            Clan = b,
            Type = b.TypeClan.Name.ToString(),
        })
        .AsQueryable();
        return Task.FromResult(resultQuery.Cast<ClanTypeInfo?>());
    }

    public async Task Update(Clan entity)
    {
        Clan? clan = await Get1(entity.Id) ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(Clan)}> and Id <{entity.Id}> not exists");

        _dbContext.Clans.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
     public async Task<Clan?> Get1(Guid Id)
    {
        Clan? Clan = await _dbContext.Clans.Where(clan => clan.Id == Id).FirstOrDefaultAsync();
        return Clan;
    }
    public async Task Remove(Guid Id)
    {
        Clan? clan = await Get1(Id) ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(Clan)}> and Id <{Id}> not exists");

        _dbContext.Clans.Remove(clan);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<(Clan? Clan, string Type)?> GetBestRegion(int region)
    {
        RegionsEnum r = (RegionsEnum)region;
        Clan? Clan = await _dbContext.Clans
                                    .Where(clan => clan.Region == r)
                                    .Include(clan => clan.TypeClan)
                                    .OrderByDescending(clan => clan.NumberOfTrophiesObtainedInWars)
                                    .FirstOrDefaultAsync();
        return (Clan, Clan.TypeClan.Name.ToString());
    }
}