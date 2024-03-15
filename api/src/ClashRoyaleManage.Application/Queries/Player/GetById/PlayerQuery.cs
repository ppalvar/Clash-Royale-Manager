using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Players;

public class PlayerQuery : ICommand<PlayerQueryResponse>
{
    public Guid Id { get; set; }
}