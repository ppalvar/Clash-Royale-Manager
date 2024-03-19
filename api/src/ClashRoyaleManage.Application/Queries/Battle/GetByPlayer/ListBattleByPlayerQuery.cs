using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Battles;

public class ListBattleByPlayerQuery : ICommand<ListBattleByPlayerQueryResponse>
{
    public Guid Id { get; set; }
}