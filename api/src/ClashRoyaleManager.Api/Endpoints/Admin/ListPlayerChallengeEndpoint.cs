using ClashRoyaleManager.Application.Queries.PlayerChallenge.GetAll;
using FastEndpoints;

namespace ClashRoyaleManager.Api.Endpoints.Admin;

public class ListPlayerChallengeEndpoint : Endpoint<GetAllPlayerChallengesQuery, GetAllPlayerChallengesQueryResponse>
{
    public override void Configure()
    {
        AllowAnonymous();
        Get("/player-challenge");
    }

    public override async Task<GetAllPlayerChallengesQueryResponse> ExecuteAsync(GetAllPlayerChallengesQuery req, CancellationToken ct)
    {
        return await req.ExecuteAsync(ct);
    }
}