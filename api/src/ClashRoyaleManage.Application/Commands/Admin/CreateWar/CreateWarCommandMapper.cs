using ClashRoyaleManager.Application.Commands.Admin;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.CreateWar;

public class CreateWarCommandMapper : AbstractMapper<War, CreateWarCommand, CreateWarCommandResponse>
{
    public override War ToEntity(CreateWarCommand command)
    {
        return new War{
            Date = command.Date
        };
    }
    public override CreateWarCommandResponse ToResponse(War entity)
    {
        return new CreateWarCommandResponse
        {
            Id = entity.Id,
            Date = entity.Date
        };
    }
}
