using ClashRoyaleManager.Application.Repositories.Common;
using ClashRoyaleManager.Domain.Entities;


namespace ClashRoyaleManager.Application.Repositories;


public interface IUserRepository : IBaseRepository<User> {
    Task<User> GetByEmail(string email);
}