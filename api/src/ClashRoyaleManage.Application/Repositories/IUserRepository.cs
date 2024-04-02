using ClashRoyaleManager.Application.Repositories.Common;
using ClashRoyaleManager.Domain.Entities;


namespace ClashRoyaleManager.Application.Repositories;


public interface IUserRepository : IBaseRepository<User> {
    Task<User> GetByEmail(string email);
    Task<User> Delete(Guid id);
    Task<(IQueryable<User> Users, int Page, int TotalPages)> GetPagination(int page = 1, int size = 10);
}