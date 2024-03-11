using ClashRoyaleManager.Application.Repositories.Common;
using ClashRoyaleManager.Domain.Entities;


namespace ClashRoyaleManager.Application.Repositories;


public interface ICardRepository : IBaseRepository<Card> {
    Task<(IQueryable<Card> Cards, int Page, int TotalPages)> GetPagination(int page=1, int size=10);
}