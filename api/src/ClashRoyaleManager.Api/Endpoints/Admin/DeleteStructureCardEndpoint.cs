using ClashRoyaleManager.Application.Commands.Admin.DeleteStructureCard;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class DeleteStructureCardEndpoint : Endpoint<DeleteStructureCardCommand, DeleteStructureCardCommandResponse>
{
    public override void Configure()
    {
        Delete("/admin/delete-structurecard/{Id}");
    }

    public override async Task HandleAsync(DeleteStructureCardCommand req, CancellationToken ct)
    {
        req.Id = Route<Guid>("Id");
        DeleteStructureCardCommandResponse response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}