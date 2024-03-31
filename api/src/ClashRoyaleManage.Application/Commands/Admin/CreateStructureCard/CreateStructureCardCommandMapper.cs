using ClashRoyaleManager.Application.Commands.Admin;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.CreateStructureCard;

public class CreateStructureCardCommandMapper : AbstractMapper<StructureCard, CreateStructureCardCommand, CreateStructureCardCommandResponse>
{
    public override StructureCard ToEntity(CreateStructureCardCommand command)
    {
        return new StructureCard{
            CardId = command.CardId,
            LifePoints =command.LifePoints
        };
    }
    public override CreateStructureCardCommandResponse ToResponse(StructureCard entity)
    {
        return new CreateStructureCardCommandResponse
        {
            CardId = entity.CardId,
            LifePoints = entity.LifePoints
        };
    }
}
