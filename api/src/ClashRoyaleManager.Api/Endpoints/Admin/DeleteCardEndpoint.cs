using ClashRoyaleManager.Application.Commands.Admin.DeleteCard;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class DeleteCardEndpoint : Endpoint<DeleteCardCommand, DeleteCardCommandResponse>
{
    public override void Configure()
    {
        Delete("/admin/delete-card/{userId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteCardCommand req, CancellationToken ct)
    {
        req.Id = Route<Guid>("userId");
        DeleteCardCommandResponse response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}