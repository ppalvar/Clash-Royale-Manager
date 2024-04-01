using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.PlayerCard.Delete;

public class PlayerCardDeleteCommand : ICommand<Domain.Entities.PlayerCard>
{
    public Guid PlayerId { get; set; }
    public Guid CardId { get; set; }
}