using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleManager.Application.Commands.Admin.DeleteBattle;

public class DeleteBattleCommand : ICommand<DeleteBattleCommandResponse>
{
    [FromRoute]
    public Guid Id { get; set; }

    [FromRoute]
    public DateTime Date { get; set; }
}