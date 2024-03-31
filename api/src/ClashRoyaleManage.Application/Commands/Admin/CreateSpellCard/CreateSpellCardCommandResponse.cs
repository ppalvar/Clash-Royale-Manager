using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;
namespace ClashRoyaleManager.Application.Commands.Admin.CreateSpellCard;

public class CreateSpellCardCommandResponse
{
    public Guid CardId { get; set; }
    public int Radio { get; set; }
    public int Duration { get; set; }
    public int DamageToTowers { get; set; }
    public int DamageInArea { get; set; }

}