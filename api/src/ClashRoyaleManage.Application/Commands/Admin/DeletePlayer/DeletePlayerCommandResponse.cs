using ClashRoyaleManager.Application.Common;

namespace ClashRoyaleManager.Application.Commands.Admin.DeletePlayer;

public class DeletePlayerCommandResponse
{
    public string Nickname { get; set; } = null!;

    public int Level { get; set; }

    public int NumberOfTrophies { get; set; }
    
    public int NumberOfWins { get; set; }

    public int MaximunTrophiesAchieved { get; set; }
    public int NumberOfCardsFound { get; set; }

}