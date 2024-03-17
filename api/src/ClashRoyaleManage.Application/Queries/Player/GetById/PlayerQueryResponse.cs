using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Query.Players;

public record PlayerQueryResponse
{
    public string Nickname { get; set; } = null!;

    public int Level { get; set; }

    public int NumberOfTrophies { get; set; }
    
    public int NumberOfWins { get; set; }

    public int MaximunTrophiesAchieved { get; set; }
    public int NumberOfCardsFound { get; set; }
}