using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Application.Repositories.Common;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using ClashRoyaleManager.Infraestructure.DbContexts;
using Microsoft.EntityFrameworkCore;


namespace ClashRoyaleManager.Infraestructure.Repositories;


public class ChallengeRepository : IChallengeRepository
{
    private readonly DefaultDbContext _dbContext;

    public ChallengeRepository(DefaultDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<(IQueryable<Challenge> Challenges, int Page, int TotalPages)> CompletedBySomePlayer(int page, int size)
    {
        var _challenges = _dbContext.Challenges.Where(c => c.PlayerChallenges.Any()).AsNoTracking();
        var resp = Paginate(_challenges, page, size);

        return Task.FromResult((resp, page, resp.Count() / size));
    }

    public async Task Create(Challenge entity)
    {
        Challenge? challenge = await Get(entity.Id);

        if (challenge != null)
        {
            throw new EntityDoesNotExistException($"The entity of type <{nameof(Challenge)}> and Id <{entity.Id}> already exists");
        }

        _dbContext.Challenges.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Challenge?> Get(Guid Id)
    {
        Challenge? challenge = await _dbContext.Challenges.Where(cd => cd.Id == Id).FirstOrDefaultAsync();
        return challenge;
    }

    public Task<IQueryable<Challenge>> GetAll()
    {
        return Task.FromResult(_dbContext.Challenges.AsQueryable());
    }

    public async Task<(IQueryable<Challenge> Challenges, int Page, int TotalPages)> GetPagination(int page, int size)
    {
        int skipCount = (page - 1) * size;
        int cantElements = size;
        int totalElements = _dbContext.Challenges.Count();
        int totalPages = (int)Math.Ceiling((double)totalElements / size);

        if (page == totalPages && totalElements % size != 0)
        {
            cantElements = totalElements % size;
        }
        IQueryable<Challenge> challenges = _dbContext.Challenges
            .OrderBy(cd => cd.Id)
            .Skip(skipCount)
            .Take(cantElements);

        return (challenges, page, totalPages);
    }

    public async Task Remove(Guid Id)
    {
        Challenge? challenge = await Get(Id) ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(Challenge)}> and Id <{Id}> not exists");

        _dbContext.Challenges.Remove(challenge);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Challenge entity)
    {
        Challenge? challenge = await Get(entity.Id) ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(Challenge)}> and Id <{entity.Id}> not exists");

        _dbContext.Challenges.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    private static IQueryable<T> Paginate<T>(IQueryable<T> players, int page, int pageSize)
    {
        int skip = (page - 1) * pageSize;
        return players.Skip(skip).Take(pageSize);
    }
}