using ClashRoyaleManager.Application.Commands.Admin.UpdateWar;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class UpdateWarEndpoint : Endpoint<UpdateWarCommand, UpdateWarCommandResponse>
{
    public override void Configure()
    {
        Post("/admin/update-war/{warId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateWarCommand req, CancellationToken ct)
    {
        req.Id = Route<Guid>("warId");
        UpdateWarCommandResponse response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}