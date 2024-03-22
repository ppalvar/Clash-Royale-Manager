using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleManager.Application.Query.Players;

public class PlayerQuery : ICommand<PlayerQueryResponse>
{
    [FromRoute]
    public Guid Id { get; set; }
}