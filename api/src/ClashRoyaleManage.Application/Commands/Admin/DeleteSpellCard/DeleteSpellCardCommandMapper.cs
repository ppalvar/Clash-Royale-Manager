using ClashRoyaleManager.Application.Commands.Admin;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.DeleteSpellCard;

public class DeleteSpellCardCommandMapper : AbstractMapper<SpellCard, DeleteSpellCardCommand, DeleteSpellCardCommandResponse>
{
    public override DeleteSpellCardCommandResponse ToResponse(SpellCard entity)
    {
        return new DeleteSpellCardCommandResponse
        {
            CardId = entity.CardId,
            Radio = entity.Radio,
            Duration = entity.Duration,
            DamageToTowers = entity.DamageToTowers,
            DamageInArea = entity.DamageInArea
        };
    }
}
