using ClashRoyaleManager.Application.Query.Users;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetAllUserEndpoint : Endpoint<ListUserQuery, ListUserQueryResponse>
{
    public override void Configure()
    {
        Get("/admin/users");
        AllowAnonymous();
    }

    public async override Task HandleAsync(ListUserQuery req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}