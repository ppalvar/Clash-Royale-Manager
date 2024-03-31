using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleManager.Application.Query.TroopCards;

public class TroopCardQuery : ICommand<TroopCardQueryResponse>
{
    [FromRoute]
    public Guid Id { get; set; }
}