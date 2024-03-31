using ClashRoyaleManager.Application.Commands.Admin;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.DeleteStructureCard;

public class DeleteStructureCardCommandMapper : AbstractMapper<StructureCard, DeleteStructureCardCommand, DeleteStructureCardCommandResponse>
{
    public override DeleteStructureCardCommandResponse ToResponse(StructureCard entity)
    {
        return new DeleteStructureCardCommandResponse
        {
            LifePoints = entity.LifePoints
        };
    }
}
