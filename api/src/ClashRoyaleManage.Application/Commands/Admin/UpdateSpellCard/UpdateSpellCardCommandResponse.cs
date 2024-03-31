using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdateSpellCard;

public class UpdateSpellCardCommandResponse
{
    public Guid Id { get; set; }
    public int Radio { get; set; }
    public int Duration { get; set; }
    public int DamageToTowers { get; set; }
    public int DamageInArea { get; set; }

}