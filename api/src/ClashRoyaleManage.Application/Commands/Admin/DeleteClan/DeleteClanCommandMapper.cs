using ClashRoyaleManager.Application.Commands.Admin;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.DeleteClan;

public class DeleteClanCommandMapper : AbstractMapper<Clan, DeleteClanCommand, DeleteClanCommandResponse>
{
    public override DeleteClanCommandResponse ToResponse(Clan entity)
    {
        return new DeleteClanCommandResponse
        {
            IdType = entity.IdType,
            Name = entity.Name,
            Description = entity.Description,
            NumberOfTrophiesObtainedInWars = entity.NumberOfTrophiesObtainedInWars,
            Region = entity.Region,
            NumberOfMembers = entity.NumberOfMembers,
            TrophiesNeededToEnter = entity.TrophiesNeededToEnter
        };
    }
}
