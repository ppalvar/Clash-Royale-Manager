using ClashRoyaleManager.Application.Commands.Admin.CreateStructureCard;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class CreateStructureCardEndpoint : Endpoint<CreateStructureCardCommand, CreateStructureCardCommandResponse>
{
    public override void Configure()
    {
        Post("/admin/createstructurecard");
    }

    public override async Task HandleAsync(CreateStructureCardCommand req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}