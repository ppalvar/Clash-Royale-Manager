using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Players;

public class ListPlayerQuery : ICommand<ListPlayerQueryResponse>
{
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
}