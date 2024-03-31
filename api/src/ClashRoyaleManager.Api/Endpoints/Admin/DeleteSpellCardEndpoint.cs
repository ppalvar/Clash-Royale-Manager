using ClashRoyaleManager.Application.Commands.Admin.DeleteSpellCard;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class DeleteSpellCardEndpoint : Endpoint<DeleteSpellCardCommand, DeleteSpellCardCommandResponse>
{
    public override void Configure()
    {
        Delete("/admin/delete-spellcard/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteSpellCardCommand req, CancellationToken ct)
    {
        req.Id = Route<Guid>("Id");
        DeleteSpellCardCommandResponse response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}