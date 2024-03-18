using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleManager.Application.Commands.Auth;

public class DeleteAccountCommand : ICommand<DeleteAccountCommandResponse>
{
    [FromRoute]
    public Guid Id { get; set; }
}