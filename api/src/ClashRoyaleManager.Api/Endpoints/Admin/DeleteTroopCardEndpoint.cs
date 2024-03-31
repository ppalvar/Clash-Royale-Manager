using ClashRoyaleManager.Application.Commands.Admin.DeleteTroopCard;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class DeleteTroopCardEndpoint : Endpoint<DeleteTroopCardCommand, DeleteTroopCardCommandResponse>
{
    public override void Configure()
    {
        Delete("/admin/delete-troopcard/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteTroopCardCommand req, CancellationToken ct)
    {
        req.Id = Route<Guid>("Id");
        DeleteTroopCardCommandResponse response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}