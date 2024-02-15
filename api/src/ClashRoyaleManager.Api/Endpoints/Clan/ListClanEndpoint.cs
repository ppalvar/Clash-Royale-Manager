using ClashRoyaleManager.Application.Query.Clans;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class ListClanEndpoint : Endpoint<ListClanQuery>
{
    public override void Configure()
    {
        Post("/api/clans");
        AllowAnonymous();
    }

    public override async Task<ListClanQueryResponse> HandleAsync(ListClanQuery req, CancellationToken ct)
    {
        ListClanQueryResponse response = await req.ExecuteAsync(ct);
        await SendOkAsync(response, ct);

        return response;
    }
}