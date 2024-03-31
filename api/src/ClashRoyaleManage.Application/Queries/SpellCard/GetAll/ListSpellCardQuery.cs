using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.SpellCards;

public class ListSpellCardQuery : ICommand<ListSpellCardQueryResponse>
{
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
}