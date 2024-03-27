using ClashRoyaleManager.Application.Commands.Admin.UpdateClan;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class UpdateClanEndpoint : Endpoint<UpdateClanCommand, UpdateClanCommandResponse>
{
    public override void Configure()
    {
        Post("/admin/update-clan/{clanId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateClanCommand req, CancellationToken ct)
    {
        req.Id = Route<Guid>("clanId");
        UpdateClanCommandResponse response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}