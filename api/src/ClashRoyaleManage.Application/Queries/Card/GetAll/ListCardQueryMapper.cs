using System.Linq;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ClashRoyaleManager.Application.Query.Cards;

public class ListCardQueryMapper : AbstractMapper<IQueryable<Card>, ListCardQuery, ListCardQueryResponse>
{
    public override ListCardQueryResponse ToResponse(IQueryable<Card> entities)
    {
        return new ListCardQueryResponse {
            Cards = entities.GetEnumerator()
        };
    }
}