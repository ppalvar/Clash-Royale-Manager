using ClashRoyaleManager.Application.Repositories.Common;
using ClashRoyaleManager.Domain.Entities;


namespace ClashRoyaleManager.Application.Repositories;


public interface IWarRepository : IBaseRepository<War>
{
    Task Remove(Guid Id);
    Task<(IQueryable<War> Wars, int Page, int TotalPages)> GetPagination(int page = 1, int size = 10);
}