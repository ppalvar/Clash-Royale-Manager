using ClashRoyaleManager.Application.Repositories.Common;
using ClashRoyaleManager.Domain.Entities;


namespace ClashRoyaleManager.Application.Repositories;


public interface IStructureCardRepository 
{
    Task Create(StructureCard entity);
    Task Update(StructureCard entity);
    Task Remove(Guid Id);
    Task<(StructureCard? StructureCard, string Name, string Description)?> Get(Guid Id);
    Task<IQueryable<CardInfo1>> GetAll();
    Task<StructureCard?> Get1(Guid Id);

}

public class CardInfo1
{
    public StructureCard? StructureCard { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}