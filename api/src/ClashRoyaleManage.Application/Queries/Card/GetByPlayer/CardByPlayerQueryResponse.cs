using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Query.Cards;

public record CardByPlayerQueryResponse
{
    public IEnumerable<Card> Cards { get; set; } = null!;
}