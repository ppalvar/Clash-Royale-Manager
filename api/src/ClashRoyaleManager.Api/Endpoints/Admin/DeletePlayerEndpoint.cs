using ClashRoyaleManager.Application.Commands.Admin.DeletePlayer;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class DeletePlayerEndpoint : Endpoint<DeletePlayerCommand, DeletePlayerCommandResponse>
{
    public override void Configure()
    {
        Delete("/admin/delete-player/{userId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeletePlayerCommand req, CancellationToken ct)
    {
        req.Id = Route<Guid>("userId");
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}