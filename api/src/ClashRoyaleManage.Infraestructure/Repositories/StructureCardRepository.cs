using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using ClashRoyaleManager.Infraestructure.DbContexts;
using Microsoft.EntityFrameworkCore;


namespace ClashRoyaleManager.Infraestructure.Repositories;


public class StructureCardRepository : IStructureCardRepository
{
    private readonly DefaultDbContext _dbContext;
    private readonly CardRepository _cardRepository;
    public StructureCardRepository(DefaultDbContext dbContext)
    {
        _dbContext = dbContext;
        _cardRepository = new CardRepository(dbContext);
    }

    public async Task Create(StructureCard entity)
    {
        StructureCard? StructureCard = await Get1(entity.CardId);

        if (StructureCard != null)
        {
            throw new EntityDoesNotExistException($"The entity of type <{nameof(StructureCard)}> and Id <{entity.CardId}> already exists");
        }

        _dbContext.StructureCards.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<(StructureCard? StructureCard, Card Card)?> Get(Guid Id)
    {
        StructureCard? StructureCard = await _dbContext.StructureCards
        .Where(structureCard => structureCard.CardId == Id)
        .Include(structureCard => structureCard.Card)
        .FirstOrDefaultAsync();

        if (StructureCard is null)
        {
            throw new EntityDoesNotExistException($"The entity of type <{nameof(StructureCard)}> and Id <{Id}> already exists");
        }

        return (StructureCard, StructureCard!.Card);
    }

    public Task<IQueryable<CardInfo1>> GetAll()
    {
        var resultQuery = _dbContext.StructureCards
        .Join(_dbContext.Cards, b => b.CardId, p => p.Id, (b, p1) => new CardInfo1
        {
            StructureCard = b,
            Name = b.Card.Name.ToString(),
            Description = b.Card.Description.ToString(),
        })
        .AsQueryable();
        return Task.FromResult(resultQuery.Cast<CardInfo1?>());
    }
    public async Task<(IQueryable<CardInfo1> StructureCards, int Page, int TotalPages)> GetPagination(int page, int size)
    {
        int skipCount = (page - 1) * size;
        int cantElements = size;
        int totalElements = _dbContext.StructureCards.Count();
        int totalPages = (int)Math.Ceiling((double)totalElements / size);

        if (page == totalPages && totalElements % size != 0)
        {
            cantElements = totalElements % size;
        }

        var resultQuery = _dbContext.StructureCards
        .Join(_dbContext.Cards, b => b.CardId, p => p.Id, (b, p1) => new CardInfo1
        {
            StructureCard = b,
            Name = b.Card.Name.ToString(),
            Description = b.Card.Description.ToString(),
        })
            //.OrderBy(cd => cd.Name)
            .Skip(skipCount)
            .Take(cantElements)
            .AsQueryable();

        return (resultQuery.Cast<CardInfo1?>(), page, totalPages);
    }
    public async Task Update(StructureCard entity)
    {
        StructureCard? structureCard = await Get1(entity.CardId) ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(StructureCard)}> and Id <{entity.CardId}> not exists");

        _dbContext.StructureCards.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
     public async Task<StructureCard?> Get1(Guid Id)
    {
        StructureCard? StructureCard = await _dbContext.StructureCards.Where(structureCard => structureCard.CardId == Id).FirstOrDefaultAsync();
        return StructureCard;
    }
    public async Task Remove(Guid Id)
    {
        StructureCard? structureCard = await Get1(Id) ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(StructureCard)}> and Id <{Id}> not exists");

        _dbContext.StructureCards.Remove(structureCard);
        await _dbContext.SaveChangesAsync();
    }
}