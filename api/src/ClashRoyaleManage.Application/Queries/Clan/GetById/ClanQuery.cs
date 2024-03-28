using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleManager.Application.Query.Clans;

public class ClanQuery : ICommand<ClanQueryResponse>
{
    [FromRoute]
    public Guid Id { get; set; }
}