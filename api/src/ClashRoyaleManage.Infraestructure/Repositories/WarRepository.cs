using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using ClashRoyaleManager.Infraestructure.DbContexts;
using Microsoft.EntityFrameworkCore;


namespace ClashRoyaleManager.Infraestructure.Repositories;


public class WarRepository : IWarRepository
{
    private readonly DefaultDbContext _dbContext;

    public WarRepository(DefaultDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(War entity)
    {
        War? War = await Get(entity.Id);

        if (War != null)
        {
            throw new EntityDoesNotExistException($"The entity of type <{nameof(War)}> and Id <{entity.Id}> already exists");
        }

        _dbContext.Wars.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<War?> Get(Guid Id)
    {
        War? War = await _dbContext.Wars.Where(war => war.Id == Id).FirstOrDefaultAsync();
        return War;
    }

    public Task<IQueryable<War>> GetAll()
    {
        return Task.FromResult(_dbContext.Wars.AsQueryable());
    }
    public async Task<(IQueryable<War> Wars, int Page, int TotalPages)> GetPagination(int page, int size)
    {
        int skipCount = (page - 1) * size;

        IQueryable<War> wars = _dbContext.Wars
            .OrderBy(cd => cd.Id)
            .Skip(skipCount)
            .Take(size);

        return (wars, page, _dbContext.Wars.Count() / size);
    }
    public async Task Update(War entity)
    {
        War? war = await Get(entity.Id) ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(War)}> and Id <{entity.Id}> not exists");

        _dbContext.Wars.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
    public async Task Remove(Guid Id)
    {
        War? war = await Get(Id) ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(War)}> and Id <{Id}> not exists");

        _dbContext.Wars.Remove(war);
        await _dbContext.SaveChangesAsync();
    }
}