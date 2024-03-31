using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Query.StructureCards;

public record StructureCardQueryResponse
{
    public int LifePoints { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}