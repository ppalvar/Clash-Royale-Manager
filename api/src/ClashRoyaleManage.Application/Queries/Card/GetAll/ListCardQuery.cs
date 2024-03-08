using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Cards;

public class ListCardQuery : ICommand<ListCardQueryResponse>
{
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
}