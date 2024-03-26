using System.Linq;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ClashRoyaleManager.Application.Query.Challenges;

public class ChallengeQueryMapper : AbstractMapper<Challenge, ChallengeQuery, ChallengeQueryResponse>
{
    public override ChallengeQueryResponse ToResponse(Challenge entitie)
    {
        return new ChallengeQueryResponse {
            Name = entitie.Name,
            Description = entitie.Description,
            Cost = entitie.Cost,
            NumberOfPrizes = entitie.NumberOfPrizes,
            NumberOfAdmissibleDefeats = entitie.NumberOfAdmissibleDefeats,
            Duration = entitie.Duration,
            MaximumLevel = entitie.MaximumLevel,
            Date = entitie.Date
        };
    }
}