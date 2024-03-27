using ClashRoyaleManager.Application.Query.Challenges;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class CompletedBySomePlayer : Endpoint<CompletedBySomePlayerQuery, ListChallengeQueryResponse>
{
    public override void Configure()
    {
        AllowAnonymous();
        Get("/challenges/completed-by-some-player");
    }

    public override async Task<ListChallengeQueryResponse> ExecuteAsync(CompletedBySomePlayerQuery req, CancellationToken ct)
    {
        return await req.ExecuteAsync(ct);
    }
}