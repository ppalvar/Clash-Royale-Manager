using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using ClashRoyaleManager.Infraestructure.DbContexts;
using Microsoft.EntityFrameworkCore;


namespace ClashRoyaleManager.Infraestructure.Repositories;


public class TypeClanRepository : ITypeClanRepository
{
    private readonly DefaultDbContext _dbContext;

    public TypeClanRepository(DefaultDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(TypeClan entity)
    {
        TypeClan? TypeClan = await Get(entity.Id);

        if (TypeClan != null)
        {
            throw new EntityDoesNotExistException($"The entity of type <{nameof(TypeClan)}> and Id <{entity.Id}> already exists");
        }

        _dbContext.TypeClans.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<TypeClan?> Get(Guid Id)
    {
        TypeClan? TypeClan = await _dbContext.TypeClans.Where(typeclan => typeclan.Id == Id).FirstOrDefaultAsync();
        return TypeClan;
    }

    public Task<IQueryable<TypeClan>> GetAll()
    {
        return Task.FromResult(_dbContext.TypeClans.AsQueryable());
    }

    public Task Update(TypeClan entity)
    {
        throw new NotImplementedException();
    }
}