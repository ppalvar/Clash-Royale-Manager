using ClashRoyaleManager.Application.Query.Challenges;
using FastEndpoints;
using Microsoft.EntityFrameworkCore.Query;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetChallengeEndpoint : Endpoint<ChallengeQuery, ChallengeQueryResponse>
{
    
    public override void Configure()
    {
        Get("/challenges/{Id}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(ChallengeQuery req, CancellationToken ct)
    {
        //req.Id = Route<Guid>("challengeId"); 
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}