using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleManager.Application.Query.StructureCards;

public class StructureCardQuery : ICommand<StructureCardQueryResponse>
{
    [FromRoute]
    public Guid Id { get; set; }
}