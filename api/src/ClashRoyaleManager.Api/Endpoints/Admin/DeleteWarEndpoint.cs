using ClashRoyaleManager.Application.Commands.Admin.DeleteWar;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class DeleteWarEndpoint : Endpoint<DeleteWarCommand, DeleteWarCommandResponse>
{
    public override void Configure()
    {
        Delete("/admin/delete-war/{warId}");
    }

    public override async Task HandleAsync(DeleteWarCommand req, CancellationToken ct)
    {
        req.Id = Route<Guid>("warId");
        DeleteWarCommandResponse response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}