using ClashRoyaleManager.Application.Query.Challenges;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class ListChallengeEndpoint : Endpoint<ListChallengeQuery, ListChallengeQueryResponse>
{
    
    public override void Configure()
    {
        Get("/challenges");
        AllowAnonymous();
    }

    public async override Task HandleAsync(ListChallengeQuery req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}