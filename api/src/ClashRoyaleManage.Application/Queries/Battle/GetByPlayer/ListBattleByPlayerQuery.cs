using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleManager.Application.Query.Battles;

public class ListBattleByPlayerQuery : ICommand<ListBattleByPlayerQueryResponse>
{
    [FromRoute]
    public Guid Id { get; set; }
}