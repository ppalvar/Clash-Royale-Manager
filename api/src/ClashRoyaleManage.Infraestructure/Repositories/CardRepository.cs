using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using ClashRoyaleManager.Infraestructure.DbContexts;
using Microsoft.EntityFrameworkCore;


namespace ClashRoyaleManager.Infraestructure.Repositories;


public class CardRepository : ICardRepository
{
    private readonly DefaultDbContext _dbContext;

    public CardRepository(DefaultDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(Card entity)
    {
        Card? card = await Get(entity.Id);

        if (card != null)
        {
            throw new EntityDoesNotExistException($"The entity of type <{nameof(Card)}> and Id <{entity.Id}> already exists");
        }

        _dbContext.Cards.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Card?> Get(Guid Id)
    {
        Card? card = await _dbContext.Cards.Where(cd => cd.Id == Id).FirstOrDefaultAsync();
        return card;
    }

    public Task<IQueryable<Card>> GetAll()
    {
        return Task.FromResult(_dbContext.Cards.AsQueryable());
    }

    public Task<IQueryable<Card>> GetByPlayer(Guid Id)
    {
        var cardsQuery = from pc in _dbContext.PlayerCards
                         join c in _dbContext.Cards on pc.IdCard equals c.Id
                         where pc.IdPlayer == Id
                         select c;

        return Task.FromResult(cardsQuery);
    }

    public async Task<(IQueryable<Card> Cards, int Page, int TotalPages)> GetPagination(int page, int size)
    {
        int skipCount = (page - 1) * size;
        int cantElements = size;
        int totalElements = _dbContext.Cards.Count();
        int totalPages = (int)Math.Ceiling((double)totalElements / size);

        if (page == totalPages && totalElements % size != 0)
        {
            cantElements = totalElements % size;
        }

        IQueryable<Card> cards = _dbContext.Cards
            .OrderBy(cd => cd.Id)
            .Skip(skipCount)
            .Take(cantElements);
        
        return (cards, page, totalPages);
    }

    public async Task<Card?> MostDonatedInRegion(RegionsEnum region)
    {
        var resp = (await _dbContext.Clans.Where(c => c.Region == region)
                                    .Include(c => c.PlayerCards)
                                    .SelectMany(c => c.PlayerCards)
                                    .Select(pc => _dbContext.Cards.Find(pc.IdCard)!)
                                    .GroupBy(c => c.Id)
                                    .OrderByDescending(c => c.Count())
                                    .FirstOrDefaultAsync())?
                                    .FirstOrDefault();

        return resp;
    }

    public async Task<(IQueryable<Card> Cards, int Page, int TotalPages)> MostPopularInClan(Guid clanId, int page = 1, int size = 10)
    {
        var playerIds = (await _dbContext.Clans.Include(c => c.PlayerClans)
                                            .Where(c => c.Id == clanId)
                                            .FirstOrDefaultAsync())!.PlayerClans
                                            .Select(pc => pc.IdPlayer);

        var playerCards = _dbContext.Players.Where(p => playerIds.Contains(p.Id))
                                            .Include(p => p.PlayerCards)
                                            .SelectMany(p => p.PlayerCards)
                                            .Where(pc => pc.IsFavority)
                                            .Select(pc => pc.IdCard);

        var cards = _dbContext.Cards.Where(c => playerCards.Contains(c.Id));

        var paginatedCards = Paginate(cards, page, size);
        return (paginatedCards, page, cards.Count() / size);
    }

    public async Task Remove(Guid Id)
    {
        Card? card = await Get(Id) ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(Card)}> and Id <{Id}> not exists");

        _dbContext.Cards.Remove(card);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Card entity)
    {
        Card? card = await Get(entity.Id) ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(Card)}> and Id <{entity.Id}> not exists");

        _dbContext.Cards.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    private static IQueryable<T> Paginate<T>(IQueryable<T> players, int page, int pageSize)
    {
        int skip = (page - 1) * pageSize;
        return players.Skip(skip).Take(pageSize);
    }
}