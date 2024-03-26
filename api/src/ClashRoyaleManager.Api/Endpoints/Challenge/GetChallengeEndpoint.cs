using ClashRoyaleManager.Application.Query.Challenges;
using FastEndpoints;
using Microsoft.EntityFrameworkCore.Query;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetChallengeEndpoint : Endpoint<ChallengeQuery, ChallengeQueryResponse>
{
    private readonly ICommandHandler<ChallengeQuery, ChallengeQueryResponse> _ChallengeQueryHandler;
    public GetChallengeEndpoint(ICommandHandler<ChallengeQuery, ChallengeQueryResponse> ChallengeQueryHandler)
    {
        _ChallengeQueryHandler = ChallengeQueryHandler;

    }
    
    public override void Configure()
    {
        Get("/challenges/{challengeId}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(ChallengeQuery req, CancellationToken ct)
    {
        req.Id = Route<Guid>("challengeId"); 
        var response = await _ChallengeQueryHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}