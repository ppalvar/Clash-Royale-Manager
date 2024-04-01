using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleManager.Application.Query.Battles;

public class BattleQuery : ICommand<BattleQueryResponse>
{
    [FromRoute]
    public Guid Player1Id { get; set; }
    
    [FromRoute]
    public DateTime Date { get; set; }
}