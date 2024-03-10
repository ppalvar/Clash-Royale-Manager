using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Wars;

public class ListWarQuery : ICommand<ListWarQueryResponse>
{
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
}