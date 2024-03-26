using System.Linq;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ClashRoyaleManager.Application.Query.Wars;

public class WarQueryMapper : AbstractMapper<War, WarQuery, WarQueryResponse>
{
    public override WarQueryResponse ToResponse(War entitie)
    {
        return new WarQueryResponse {
            Date = entitie.Date
        };
    }
}