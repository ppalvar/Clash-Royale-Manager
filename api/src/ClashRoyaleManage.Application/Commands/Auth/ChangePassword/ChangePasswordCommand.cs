using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Auth;

public class ChangePasswordCommand : ICommand<ChangePasswordCommandResponse>
{
    public Guid Id { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
}