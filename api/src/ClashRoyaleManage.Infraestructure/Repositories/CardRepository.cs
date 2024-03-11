using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Application.Repositories.Common;
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

    public async Task<(IQueryable<Card> Cards, int Page, int TotalPages)> GetPagination(int page, int size)
    {
        int skipCount = (page - 1) * size;

        IQueryable<Card> cards = _dbContext.Cards
            .OrderBy(cd => cd.Id)
            .Skip(skipCount)
            .Take(size);

        return (cards, page, _dbContext.Cards.Count() / size);
    }

    public Task Update(Card entity)
    {
        throw new NotImplementedException();
    }

}