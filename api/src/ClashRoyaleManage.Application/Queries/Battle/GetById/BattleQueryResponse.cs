using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Query.Battles;

public record BattleQueryResponse
{
    public Guid Player1Id { get; set; }
    public Guid Player2Id { get; set; }
    public string Player1Name { get; set; } 
    public string Player2Name { get; set; } 
    public bool Winner { get; set; }    //NOTE - [false] -> Jugador 1  [true] -> Jugador 2
    public int NumberOfTrophies { get; set; }
    public DateTime Date { get; set; }
    public DateTime Duration { get; set; }
}