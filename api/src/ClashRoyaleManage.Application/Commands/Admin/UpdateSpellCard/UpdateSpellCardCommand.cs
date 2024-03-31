using FastEndpoints;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdateSpellCard;

public class UpdateSpellCardCommand : ICommand<UpdateSpellCardCommandResponse>
{
    public Guid Id { get; set; }
    public int Radio { get; set; }
    public int Duration { get; set; }
    public int DamageToTowers { get; set; }
    public int DamageInArea { get; set; }

}