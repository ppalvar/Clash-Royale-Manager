using ClashRoyaleManager.Application.Commands.Admin.UpdateCard;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class UpdateCardEndpoint : Endpoint<UpdateCardCommand, UpdateCardCommandResponse>
{
    public override void Configure()
    {
        Post("/admin/update-card/{userId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateCardCommand req, CancellationToken ct)
    {
        req.Id = Route<Guid>("userId");
        UpdateCardCommandResponse response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}