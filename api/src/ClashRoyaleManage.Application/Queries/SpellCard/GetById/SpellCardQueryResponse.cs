using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Query.SpellCards;

public record SpellCardQueryResponse
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Radio { get; set; }
    public int Duration { get; set; }
    public int DamageToTowers { get; set; }
    public int DamageInArea { get; set; }
}