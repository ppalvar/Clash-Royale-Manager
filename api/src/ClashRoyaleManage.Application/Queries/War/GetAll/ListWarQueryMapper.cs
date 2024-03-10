using System.Linq;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ClashRoyaleManager.Application.Query.Wars;

public class ListWarQueryMapper : AbstractMapper<IQueryable<War>, ListWarQuery, ListWarQueryResponse>
{
    public override ListWarQueryResponse ToResponse(IQueryable<War> entities)
    {
        return new ListWarQueryResponse {
            Wars = entities
        };
    }
}