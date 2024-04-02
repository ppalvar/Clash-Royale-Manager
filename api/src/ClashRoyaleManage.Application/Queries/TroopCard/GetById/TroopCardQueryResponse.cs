using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Query.TroopCards;

public record TroopCardQueryResponse
{
    public int LifePoints { get; set; }
    public int DamageInArea { get; set; }
    public int NumberOfUnits { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double ElixirCost { get; set; }
    public string Quality { get; set; }
}