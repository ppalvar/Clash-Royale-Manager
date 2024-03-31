using ClashRoyaleManager.Application.Commands.Admin.UpdateSpellCard;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class UpdateSpellCardEndpoint : Endpoint<UpdateSpellCardCommand, UpdateSpellCardCommandResponse>
{
    public override void Configure()
    {
        Post("/admin/update-spellcard/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateSpellCardCommand req, CancellationToken ct)
    {
        req.Id = Route<Guid>("Id");
        UpdateSpellCardCommandResponse response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}