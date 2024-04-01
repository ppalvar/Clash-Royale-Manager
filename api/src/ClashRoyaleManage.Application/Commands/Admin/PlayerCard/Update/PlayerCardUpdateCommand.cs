using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.PlayerCard.Update;

public class PlayerCardUpdateCommand : ICommand<Domain.Entities.PlayerCard>
{
    public Guid PlayerId { get; set; }
    public Guid CardId { get; set; }
    public int Level { get; set; }
    public bool IsFavorite { get; set; }
}