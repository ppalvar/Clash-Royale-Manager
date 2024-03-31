using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.TroopCards;

public class ListTroopCardQuery : ICommand<ListTroopCardQueryResponse>
{
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
}