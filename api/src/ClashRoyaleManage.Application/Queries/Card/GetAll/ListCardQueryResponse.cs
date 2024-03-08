using System.Collections.Generic;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Cards;

public record ListCardQueryResponse
{ 
    public IEnumerable<Card> Cards { get; set; } = null!;
}