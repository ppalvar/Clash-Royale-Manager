using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleManager.Application.Commands.Admin.ActiveUser;

public class ActiveUserCommand: ICommand
{
    [FromRoute]
    public Guid Id { get; set; }

    [FromRoute]
    public Boolean Active { get; set; }
}