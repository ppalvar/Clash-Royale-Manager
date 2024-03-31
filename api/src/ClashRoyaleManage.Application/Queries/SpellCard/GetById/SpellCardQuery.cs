using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleManager.Application.Query.SpellCards;

public class SpellCardQuery : ICommand<SpellCardQueryResponse>
{
    [FromRoute]
    public Guid Id { get; set; }
}