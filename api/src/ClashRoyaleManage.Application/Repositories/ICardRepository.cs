using ClashRoyaleManager.Application.Repositories.Common;
using ClashRoyaleManager.Domain.Entities;


namespace ClashRoyaleManager.Application.Repositories;


public interface ICardRepository : IBaseRepository<Card>
{
    Task<(IQueryable<Card> Cards, int Page, int TotalPages)> GetPagination(int page = 1, int size = 10);
    Task<IQueryable<Card>> GetByPlayer(Guid Id);
    Task Remove(Guid Id);
    Task<Card?> MostDonatedInRegion(RegionsEnum region);
}