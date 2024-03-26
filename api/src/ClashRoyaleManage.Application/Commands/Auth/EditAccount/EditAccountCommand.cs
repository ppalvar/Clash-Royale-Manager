using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleManager.Application.Commands.Auth;

public class EditAccountCommand : ICommand<EditAccountCommandResponse>
{
    [FromRoute]
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
}