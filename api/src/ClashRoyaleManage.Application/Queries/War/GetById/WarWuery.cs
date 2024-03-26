using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Wars;

public class WarQuery : ICommand<WarQueryResponse>
{
    public Guid Id { get; set; }
}