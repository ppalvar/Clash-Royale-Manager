using ClashRoyaleManager.Application.Commands.Admin.UpdateTroopCard;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class UpdateTroopCardEndpoint : Endpoint<UpdateTroopCardCommand, UpdateTroopCardCommandResponse>
{
    public override void Configure()
    {
        Post("/admin/update-troopcard/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateTroopCardCommand req, CancellationToken ct)
    {
        req.Id = Route<Guid>("Id");
        UpdateTroopCardCommandResponse response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}