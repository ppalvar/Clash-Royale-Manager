using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleManager.Application.Query.Wars;

public class WarQuery : ICommand<WarQueryResponse>
{
    [FromRoute]
    public Guid Id { get; set; }
}