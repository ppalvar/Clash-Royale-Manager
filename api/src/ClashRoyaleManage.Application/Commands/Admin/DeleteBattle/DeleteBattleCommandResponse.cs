using ClashRoyaleManager.Application.Common;

namespace ClashRoyaleManager.Application.Commands.Admin.DeleteBattle;

public class DeleteBattleCommandResponse
{
    public Guid Player1Id { get; set; }
    public Guid Player2Id { get; set; } 
    public bool Winner { get; set; }
    public int NumberOfTrophies { get; set; }
    public DateTime Date { get; set; }
    public DateTime Duration { get; set; }
}