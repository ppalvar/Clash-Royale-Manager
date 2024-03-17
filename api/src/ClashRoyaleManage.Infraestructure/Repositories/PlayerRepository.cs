using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Application.Repositories.Common;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using ClashRoyaleManager.Infraestructure.DbContexts;
using Microsoft.EntityFrameworkCore;


namespace ClashRoyaleManager.Infraestructure.Repositories;


public class PlayerRepository : IPlayerRepository
{
    private readonly DefaultDbContext _dbContext;

    public PlayerRepository(DefaultDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(Player entity)
    {
        Player? player = await Get(entity.Id);

        if (player != null) 
        {
            throw new EntityDoesNotExistException($"The entity of type <{nameof(Player)}> and Id <{entity.Id}> already exists");
        }

        _dbContext.Players.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Player?> Get(Guid Id)
    {
        Player? player = await _dbContext.Players.Where(cd => cd.Id == Id).FirstOrDefaultAsync();
        return player;
    }

    public Task<IQueryable<Player>> GetAll()
    {
        return Task.FromResult(_dbContext.Players.AsQueryable());
    }

    public async Task<(IQueryable<Player> Players, int Page, int TotalPages)> GetPagination(int page, int size)
    {
        int skipCount = (page - 1) * size;

        IQueryable<Player> players = _dbContext.Players
            .OrderBy(cd => cd.Id)
            .Skip(skipCount)
            .Take(size);

        return (players, page, _dbContext.Players.Count() / size);
    }

    public async Task Remove(Guid Id)
    {
        Player? player = await Get(Id) ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(Player)}> and Id <{Id}> not exists");

        _dbContext.Players.Remove(player);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Player entity)
    {
        Player? player = await Get(entity.Id) ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(Player)}> and Id <{entity.Id}> not exists");

        _dbContext.Players.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

}