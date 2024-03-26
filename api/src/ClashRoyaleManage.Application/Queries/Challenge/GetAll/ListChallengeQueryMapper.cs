using System.Linq;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ClashRoyaleManager.Application.Query.Challenges;

public class ListChallengeQueryMapper : AbstractMapper<IQueryable<Challenge>, ListChallengeQuery, ListChallengeQueryResponse>
{
    public override ListChallengeQueryResponse ToResponse(IQueryable<Challenge> entities)
    {
        return new ListChallengeQueryResponse {
            Challenges = entities
        };
    }
}