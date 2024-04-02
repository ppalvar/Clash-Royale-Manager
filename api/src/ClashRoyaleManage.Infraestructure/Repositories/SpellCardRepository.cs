using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using ClashRoyaleManager.Infraestructure.DbContexts;
using Microsoft.EntityFrameworkCore;


namespace ClashRoyaleManager.Infraestructure.Repositories;


public class SpellCardRepository : ISpellCardRepository
{
    private readonly DefaultDbContext _dbContext;
    private readonly CardRepository _cardRepository;
    public SpellCardRepository(DefaultDbContext dbContext)
    {
        _dbContext = dbContext;
        _cardRepository = new CardRepository(dbContext);
    }

    public async Task Create(SpellCard entity)
    {
        SpellCard? SpellCard = await Get1(entity.CardId);

        if (SpellCard != null)
        {
            throw new EntityDoesNotExistException($"The entity of type <{nameof(SpellCard)}> and Id <{entity.CardId}> already exists");
        }

        _dbContext.SpellCards.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<(SpellCard? SpellCard, Card Card)?> Get(Guid Id)
    {
        SpellCard? SpellCard = await _dbContext.SpellCards
        .Where(spellCard => spellCard.CardId == Id)
        .Include(spellCard => spellCard.Card)
        .FirstOrDefaultAsync();

        if (SpellCard is null){
            throw new EntityDoesNotExistException($"The entity of type <{nameof(SpellCard)}> and Id <{Id}> already exists");
        }

        return (SpellCard, SpellCard!.Card);
    }

    public Task<IQueryable<CardInfo>> GetAll()
    {
        var resultQuery = _dbContext.SpellCards
        .Join(_dbContext.Cards, b => b.CardId, p => p.Id, (b, p1) => new CardInfo
        {
            SpellCard = b,
            Name = b.Card.Name.ToString(),
            Description = b.Card.Description.ToString(),
        })
        .AsQueryable();
        return Task.FromResult(resultQuery.Cast<CardInfo?>());
    }
    public async Task<(IQueryable<CardInfo> SpellCards, int Page, int TotalPages)> GetPagination(int page, int size)
    {
        int skipCount = (page - 1) * size;

        var resultQuery = _dbContext.SpellCards
        .Join(_dbContext.Cards, b => b.CardId, p => p.Id, (b, p1) => new CardInfo
        {
            SpellCard = b,
            Name = b.Card.Name.ToString(),
            Description = b.Card.Description.ToString(),
        })
            //.OrderBy(cd => cd.Name)
            .Skip(skipCount)
            .Take(size)
            .AsQueryable();

        return (resultQuery.Cast<CardInfo?>(), page, _dbContext.SpellCards.Count() / size);
    }
    public async Task Update(SpellCard entity)
    {
        SpellCard? spellCard = await Get1(entity.CardId) ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(SpellCard)}> and Id <{entity.CardId}> not exists");

        _dbContext.SpellCards.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
     public async Task<SpellCard?> Get1(Guid Id)
    {
        SpellCard? SpellCard = await _dbContext.SpellCards.Where(spellCard => spellCard.CardId == Id).FirstOrDefaultAsync();
        return SpellCard;
    }
    public async Task Remove(Guid Id)
    {
        SpellCard? spellCard = await Get1(Id) ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(SpellCard)}> and Id <{Id}> not exists");

        _dbContext.SpellCards.Remove(spellCard);
        await _dbContext.SaveChangesAsync();
    }
    

}