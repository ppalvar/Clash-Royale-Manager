using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleManager.Application.Query.Players;

public record ListBestPlayersInWarQuery(int Page = 1, int PageSize = 1) : ICommand<ListPlayerQueryResponse>
{
    [FromRoute]
    public Guid WarId { get; set; }
}