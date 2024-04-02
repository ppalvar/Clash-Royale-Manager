using ClashRoyaleManager.Application.Commands.Admin.DeleteClan;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class DeleteClanEndpoint : Endpoint<DeleteClanCommand, DeleteClanCommandResponse>
{
    public override void Configure()
    {
        Delete("/admin/delete-clan/{clanId}");
    }

    public override async Task HandleAsync(DeleteClanCommand req, CancellationToken ct)
    {
        req.Id = Route<Guid>("clanId");
        DeleteClanCommandResponse response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}