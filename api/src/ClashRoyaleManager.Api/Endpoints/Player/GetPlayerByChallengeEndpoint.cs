using ClashRoyaleManager.Application.Queries.PlayerChallenge.GetByChallenge;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetPlayerByChallengeEndpoint : Endpoint<GetPlayerByChallengeQuery, GetPlayerByChallengeQueryResponse>
{
    public override void Configure()
    {
        Get("/players-by-challenge/{Id}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(GetPlayerByChallengeQuery req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}