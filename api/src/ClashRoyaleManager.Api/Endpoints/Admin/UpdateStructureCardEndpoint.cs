using ClashRoyaleManager.Application.Commands.Admin.UpdateStructureCard;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class UpdateStructureCardEndpoint : Endpoint<UpdateStructureCardCommand, UpdateStructureCardCommandResponse>
{
    public override void Configure()
    {
        Post("/admin/update-structurecard/{Id}");
    }

    public override async Task HandleAsync(UpdateStructureCardCommand req, CancellationToken ct)
    {
        req.Id = Route<Guid>("Id");
        UpdateStructureCardCommandResponse response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}