using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.StructureCards;

public class ListStructureCardQuery : ICommand<ListStructureCardQueryResponse>
{
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
}