using System.Linq;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ClashRoyaleManager.Application.Query.Cards;

public class CardQueryMapper : AbstractMapper<Card, CardQuery, CardQueryResponse>
{
    public override CardQueryResponse ToResponse(Card entitie)
    {
        return new CardQueryResponse {
            Name = entitie.Name,
            Description = entitie.Description,
            ElixirCost = entitie.ElixirCost,
            Quality = entitie.Quality
        };
    }
}