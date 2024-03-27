using System.Windows.Input;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleManager.Application.Query.Players;

public record ClansCanJoinQuery(int Page = 1, int PageSize = 10) : ICommand<ClansCanJoinResponse>
{
    [FromRoute]
    public Guid PlayerId { get; set; }
}