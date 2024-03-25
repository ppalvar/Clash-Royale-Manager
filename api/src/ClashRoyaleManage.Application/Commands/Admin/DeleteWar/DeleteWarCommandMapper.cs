using ClashRoyaleManager.Application.Commands.Admin;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.DeleteWar;

public class DeleteWarCommandMapper : AbstractMapper<War, DeleteWarCommand, DeleteWarCommandResponse>
{
    public override DeleteWarCommandResponse ToResponse(War entity)
    {
        return new DeleteWarCommandResponse
        {
            Date = entity.Date
        };
    }
}
