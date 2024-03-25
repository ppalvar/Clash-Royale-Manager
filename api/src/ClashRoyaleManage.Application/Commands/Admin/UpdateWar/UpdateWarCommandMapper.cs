using ClashRoyaleManager.Application.Commands.Admin;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdateWar;

public class UpdateWarCommandMapper : AbstractMapper<War, UpdateWarCommand, UpdateWarCommandResponse>
{
    public override War ToEntity(UpdateWarCommand command)
    {
        return new War{
            Date = command.Date
        };
    }
    public override UpdateWarCommandResponse ToResponse(War entity)
    {
        return new UpdateWarCommandResponse
        {
            Date = entity.Date   
        };
    }
}
