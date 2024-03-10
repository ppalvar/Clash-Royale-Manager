using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Query.Cards;

public record CardQueryResponse
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    
    public double ElixirCost { get; set; }

    public string Quality { get; set; } = null!;
}