using ClashRoyaleManager.Application.Query.Cards;
using FastEndpoints;

namespace ClashRoyaleManager.Api.Endpoints.Admin;

public class GetAllEndpoint : EndpointWithoutRequest<ListCardQueryResponse>
{
    public override void Configure()
    {
        Get("/cards");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        ListCardQuery req = new ListCardQuery();
        ListCardQueryResponse list = await req.ExecuteAsync(ct);

        await SendAsync(list);
    }
}