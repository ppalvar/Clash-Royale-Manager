using ClashRoyaleManager.Application.Repositories.Common;
using ClashRoyaleManager.Domain.Entities;


namespace ClashRoyaleManager.Application.Repositories;


public interface ISpellCardRepository 
{
    Task Create(SpellCard entity);
    Task Update(SpellCard entity);
    Task Remove(Guid Id);
    Task<(SpellCard? SpellCard, Card Card)?> Get(Guid Id);
    Task<IQueryable<CardInfo>> GetAll();
    Task<SpellCard?> Get1(Guid Id);

}

public class CardInfo
{
    public SpellCard? SpellCard { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}