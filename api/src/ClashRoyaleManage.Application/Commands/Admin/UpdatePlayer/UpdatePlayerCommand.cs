using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdatePlayer;

public class UpdatePlayerCommand : ICommand<UpdatePlayerCommandResponse>
{
    [FromRoute]
    public Guid Id { get; set; }

    public string Code { get; set; } = null!;
    public string Nickname { get; set; } = null!;

    public int Level { get; set; }

    public int NumberOfTrophies { get; set; }

    public int NumberOfWins { get; set; }

    public int MaximunTrophiesAchieved { get; set; }
    public int NumberOfCardsFound { get; set; }
}