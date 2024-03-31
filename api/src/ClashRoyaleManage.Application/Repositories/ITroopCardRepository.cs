using ClashRoyaleManager.Application.Repositories.Common;
using ClashRoyaleManager.Domain.Entities;


namespace ClashRoyaleManager.Application.Repositories;


public interface ITroopCardRepository 
{
    Task Create(TroopCard entity);
    Task Update(TroopCard entity);
    Task Remove(Guid Id);
    Task<(TroopCard? TroopCard, string Name, string Description)?> Get(Guid Id);
    Task<IQueryable<CardInfo2>> GetAll();
    Task<TroopCard?> Get1(Guid Id);

}

public class CardInfo2
{
    public TroopCard? TroopCard { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}