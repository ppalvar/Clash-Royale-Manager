using ClashRoyaleManager.Application.Query.Challenges;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class ListChallengeEndpoint : Endpoint<ListChallengeQuery, ListChallengeQueryResponse>
{
    private readonly ICommandHandler<ListChallengeQuery, ListChallengeQueryResponse> _listChallengeQueryHandler;

    public ListChallengeEndpoint(ICommandHandler<ListChallengeQuery, ListChallengeQueryResponse> listChallengeQueryHandler)
    {
        _listChallengeQueryHandler = listChallengeQueryHandler;
    }
    
    public override void Configure()
    {
        Get("/challenges");
        AllowAnonymous();
    }

    public async override Task HandleAsync(ListChallengeQuery req, CancellationToken ct)
    {
        var response = await _listChallengeQueryHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}