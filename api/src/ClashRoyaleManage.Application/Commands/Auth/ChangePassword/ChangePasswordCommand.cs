using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleManager.Application.Commands.Auth;

public class ChangePasswordCommand : ICommand<ChangePasswordCommandResponse>
{
    [FromRoute]
    public Guid Id { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
}