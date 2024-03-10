using ClashRoyaleManager.Application.Commands.Auth;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class ChangePasswordEndpoint : Endpoint<ChangePasswordCommand, ChangePasswordCommandResponse>
{
    private readonly ICommandHandler<ChangePasswordCommand, ChangePasswordCommandResponse> _ChangePasswordCommandHandler;
    public ChangePasswordEndpoint(ICommandHandler<ChangePasswordCommand, ChangePasswordCommandResponse> ChangePasswordCommandHandler)
    {
        _ChangePasswordCommandHandler = ChangePasswordCommandHandler;
    }
    
    public override void Configure()
    {
        Post("/auth/change-password/{userId}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(ChangePasswordCommand req, CancellationToken ct)
    {
        req.Id = Route<Guid>("userId"); 
        var response = await _ChangePasswordCommandHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}