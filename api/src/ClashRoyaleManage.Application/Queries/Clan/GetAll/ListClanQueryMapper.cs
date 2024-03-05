using System.Linq;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ClashRoyaleManager.Application.Query.Clans;

public class ListClanQueryMapper : AbstractMapper<IQueryable<Clan>, ListClanQuery, ListClanQueryResponse>
{
    public override ListClanQueryResponse ToResponse(IQueryable<Clan> entities)
    {
        return new ListClanQueryResponse {
            Clans = entities
        };
    }
}