using ClashRoyaleManager.Application.Commands.Admin;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.CreateSpellCard;

public class CreateSpellCardCommandMapper : AbstractMapper<SpellCard, CreateSpellCardCommand, CreateSpellCardCommandResponse>
{
    public override SpellCard ToEntity(CreateSpellCardCommand command)
    {
        return new SpellCard{
            CardId = command.CardId,
            Radio =command.Radio,
            Duration = command.Duration,
            DamageToTowers = command.DamageToTowers,
            DamageInArea = command.DamageInArea
        };
    }
    public override CreateSpellCardCommandResponse ToResponse(SpellCard entity)
    {
        return new CreateSpellCardCommandResponse
        {
            CardId = entity.CardId,
            Radio = entity.Radio,
            Duration = entity.Duration,
            DamageToTowers = entity.DamageToTowers,
            DamageInArea = entity.DamageInArea
        };
    }
}
