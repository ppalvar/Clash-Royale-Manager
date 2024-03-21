using System.Linq;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ClashRoyaleManager.Application.Query.Cards;

public class CardByPlayerQueryMapper : AbstractMapper<IQueryable<Card>, CardByPlayerQuery, CardByPlayerQueryResponse>
{
    public override CardByPlayerQueryResponse ToResponse(IQueryable<Card> entities)
    {
        return new CardByPlayerQueryResponse {
            Cards = entities
        };
    }
}