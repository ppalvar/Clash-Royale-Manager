using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Battles;

public class ListBattleQuery : ICommand<ListBattleQueryResponse>
{
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
}