using ClashRoyaleManager.Application.Repositories.Common;
using ClashRoyaleManager.Domain.Entities;


namespace ClashRoyaleManager.Application.Repositories;


public interface IWarRepository : IBaseRepository<War>
{
    Task Remove(Guid Id);
}