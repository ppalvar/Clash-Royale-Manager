using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using ClashRoyaleManager.Infraestructure.DbContexts;
using Microsoft.EntityFrameworkCore;


namespace ClashRoyaleManager.Infraestructure.Repositories;


public class TroopCardRepository : ITroopCardRepository
{
    private readonly DefaultDbContext _dbContext;
    private readonly CardRepository _cardRepository;
    public TroopCardRepository(DefaultDbContext dbContext)
    {
        _dbContext = dbContext;
        _cardRepository = new CardRepository(dbContext);
    }

    public async Task Create(TroopCard entity)
    {
        TroopCard? TroopCard = await Get1(entity.CardId);

        if (TroopCard != null)
        {
            throw new EntityDoesNotExistException($"The entity of type <{nameof(TroopCard)}> and Id <{entity.CardId}> already exists");
        }

        _dbContext.TroopCards.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<(TroopCard? TroopCard, Card Card)?> Get(Guid Id)
    {
        TroopCard? TroopCard = await _dbContext.TroopCards
        .Where(troopCard => troopCard.CardId == Id)
        .Include(troopCard => troopCard.Card)
        .FirstOrDefaultAsync();

        if (TroopCard is null)
        {
            throw new EntityDoesNotExistException($"The entity of type <{nameof(TroopCard)}> and Id <{Id}> already exists");
        }

        return (TroopCard, TroopCard!.Card);
    }

    public Task<IQueryable<CardInfo2>> GetAll()
    {
        var resultQuery = _dbContext.TroopCards
        .Join(_dbContext.Cards, b => b.CardId, p => p.Id, (b, p1) => new CardInfo2
        {
            TroopCard = b,
            Name = b.Card.Name.ToString(),
            Description = b.Card.Description.ToString(),
        })
        .AsQueryable();
        return Task.FromResult(resultQuery.Cast<CardInfo2?>());
    }
    public async Task<(IQueryable<CardInfo2> TroopCards, int Page, int TotalPages)> GetPagination(int page, int size)
    {
        int skipCount = (page - 1) * size;
        int cantElements = size;
        int totalElements = _dbContext.TroopCards.Count();
        int totalPages = (int)Math.Ceiling((double)totalElements / size);

        if (page == totalPages && totalElements % size != 0)
        {
            cantElements = totalElements % size;
        }

        var resultQuery = _dbContext.TroopCards
        .Join(_dbContext.Cards, b => b.CardId, p => p.Id, (b, p1) => new CardInfo2
        {
            TroopCard = b,
            Name = b.Card.Name.ToString(),
            Description = b.Card.Description.ToString(),
        })
            //.OrderBy(cd => cd.Name)
            .Skip(skipCount)
            .Take(cantElements)
            .AsQueryable();

        return (resultQuery.Cast<CardInfo2?>(), page, totalPages);
    }
    public async Task Update(TroopCard entity)
    {
        TroopCard? TroopCard = await Get1(entity.CardId) ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(TroopCard)}> and Id <{entity.CardId}> not exists");

        _dbContext.TroopCards.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
     public async Task<TroopCard?> Get1(Guid Id)
    {
        TroopCard? TroopCard = await _dbContext.TroopCards.Where(troopCard => troopCard.CardId == Id).FirstOrDefaultAsync();
        return TroopCard;
    }
    public async Task Remove(Guid Id)
    {
        TroopCard? troopCard = await Get1(Id) ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(TroopCard)}> and Id <{Id}> not exists");

        _dbContext.TroopCards.Remove(troopCard);
        await _dbContext.SaveChangesAsync();
    }
}