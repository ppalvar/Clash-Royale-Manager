using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdateBattle;

public class UpdateBattleCommand : ICommand<UpdateBattleCommandResponse>
{
    [FromRoute]
    public Guid Player1Id { get; set; }
    
    [FromRoute]
    public DateTime Date { get; set; }

    public Guid Player2Id { get; set; } 
    public bool Winner { get; set; }
    public int NumberOfTrophies { get; set; }
    public DateTime Duration { get; set; }
}