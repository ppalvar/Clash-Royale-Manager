using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.CreateSpellCard;

public class CreateSpellCardCommand : ICommand<CreateSpellCardCommandResponse>
{
    public Guid CardId { get; set; }
    public int Radio { get; set; }
    public int Duration { get; set; }
    public int DamageToTowers { get; set; }
    public int DamageInArea { get; set; }

}