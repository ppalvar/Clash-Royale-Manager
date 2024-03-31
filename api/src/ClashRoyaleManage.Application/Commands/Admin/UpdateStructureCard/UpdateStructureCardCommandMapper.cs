using ClashRoyaleManager.Application.Commands.Admin;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdateStructureCard;

public class UpdateStructureCardCommandMapper : AbstractMapper<StructureCard, UpdateStructureCardCommand, UpdateStructureCardCommandResponse>
{
    public override StructureCard ToEntity(UpdateStructureCardCommand command)
    {
        return new StructureCard{
            CardId = command.Id,
            LifePoints = command.LifePoints
        };
    }
    public override UpdateStructureCardCommandResponse ToResponse(StructureCard entity)
    {
        return new UpdateStructureCardCommandResponse
        {
            Id = entity.CardId,
            LifePoints = entity.LifePoints
        };
    }
}
