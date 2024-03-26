using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.CreateBattle;

public class CreateBattleCommand : ICommand<CreateBattleCommandResponse>
{
    public Guid Player1Id { get; set; }
    public Guid Player2Id { get; set; } 
    public bool Winner { get; set; }    //NOTE - [false] -> Jugador 1  [true] -> Jugador 2
    public int NumberOfTrophies { get; set; }
    public DateTime Date { get; set; }
    public DateTime Duration { get; set; }
}