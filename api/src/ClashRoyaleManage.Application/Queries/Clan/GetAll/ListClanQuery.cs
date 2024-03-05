using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Clans;

public class ListClanQuery : ICommand<ListClanQueryResponse>
{
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
}