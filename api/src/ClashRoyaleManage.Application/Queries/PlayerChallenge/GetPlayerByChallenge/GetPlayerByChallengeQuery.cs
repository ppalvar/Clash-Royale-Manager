using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleManager.Application.Queries.PlayerChallenge.GetByChallenge;

public record GetPlayerByChallengeQuery : ICommand<GetPlayerByChallengeQueryResponse>
{
    [FromRoute]
    public Guid Id { get; set; }

    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
