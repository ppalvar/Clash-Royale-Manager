using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Battles;

public class BattleQuery : ICommand<BattleQueryResponse>
{
    public Guid Player1Id { get; set; }
    public Guid Player2Id { get; set; }
    public DateTime Date { get; set; }
}