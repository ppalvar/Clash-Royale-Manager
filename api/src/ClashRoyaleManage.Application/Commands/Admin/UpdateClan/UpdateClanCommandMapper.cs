using ClashRoyaleManager.Application.Commands.Admin;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdateClan;

public class UpdateClanCommandMapper : AbstractMapper<Clan, UpdateClanCommand, UpdateClanCommandResponse>
{
    public override Clan ToEntity(UpdateClanCommand command)
    {
        return new Clan{
            Id = command.Id,
            IdType = command.IdType,
            Name = command.Name,
            Description = command.Description,
            NumberOfTrophiesObtainedInWars = command.NumberOfTrophiesObtainedInWars,
            Region = command.Region,
            NumberOfMembers = command.NumberOfMembers,
            TrophiesNeededToEnter = command.TrophiesNeededToEnter
        };
    }
    public override UpdateClanCommandResponse ToResponse(Clan entity)
    {
        return new UpdateClanCommandResponse
        {
            IdType = entity.IdType,
            Name =entity.Name,
            Description = entity.Description,
            NumberOfTrophiesObtainedInWars = entity.NumberOfTrophiesObtainedInWars,
            Region = entity.Region,
            NumberOfMembers = entity.NumberOfMembers,
            TrophiesNeededToEnter = entity.TrophiesNeededToEnter
        };
    }
}
