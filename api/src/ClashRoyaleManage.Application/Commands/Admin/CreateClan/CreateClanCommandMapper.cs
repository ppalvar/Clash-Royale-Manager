using ClashRoyaleManager.Application.Commands.Admin;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.CreateClan;

public class CreateClanCommandMapper : AbstractMapper<Clan, CreateClanCommand, CreateClanCommandResponse>
{
    public override Clan ToEntity(CreateClanCommand command)
    {
        return new Clan{
            IdType = command.IdType,
            Name =command.Name,
            Description = command.Description,
            NumberOfTrophiesObtainedInWars = command.NumberOfTrophiesObtainedInWars,
            Region = (RegionsEnum)command.Region,
            NumberOfMembers = command.NumberOfMembers,
            TrophiesNeededToEnter = command.TrophiesNeededToEnter
        };
    }
    public override CreateClanCommandResponse ToResponse(Clan entity)
    {
        return new CreateClanCommandResponse
        {
            IdType = entity.IdType,
            Name = entity.Name,
            Description = entity.Description,
            NumberOfTrophiesObtainedInWars = entity.NumberOfTrophiesObtainedInWars,
            Region = (RegionsEnum)entity.Region,
            NumberOfMembers = entity.NumberOfMembers,
            TrophiesNeededToEnter = entity.TrophiesNeededToEnter
        };
    }
}
