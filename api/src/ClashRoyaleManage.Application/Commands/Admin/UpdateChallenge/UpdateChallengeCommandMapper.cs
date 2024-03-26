using ClashRoyaleManager.Application.Commands.Admin;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdateChallenge;

public class UpdateChallengeCommandMapper : AbstractMapper<Challenge, UpdateChallengeCommand, UpdateChallengeCommandResponse>
{
    public override Challenge ToEntity(UpdateChallengeCommand command)
    {
        return new Challenge{
            Id = command.Id,
            Name = command.Name,
            Description = command.Description,
            Cost = command.Cost,
            NumberOfPrizes = command.NumberOfPrizes,
            NumberOfAdmissibleDefeats = command.NumberOfAdmissibleDefeats,
            Duration = command.Duration,
            MaximumLevel = command.MaximumLevel,
            Date = command.Date
        };
    }
    public override UpdateChallengeCommandResponse ToResponse(Challenge entity)
    {
        return new UpdateChallengeCommandResponse
        {
            Id = entity.Id,
            Name =entity.Name,
            Description = entity.Description,
            Cost = entity.Cost,
            NumberOfPrizes = entity.NumberOfPrizes,
            NumberOfAdmissibleDefeats = entity.NumberOfAdmissibleDefeats,
            Duration = entity.Duration,
            MaximumLevel = entity.MaximumLevel,
            Date = entity.Date   
        };
    }
}
