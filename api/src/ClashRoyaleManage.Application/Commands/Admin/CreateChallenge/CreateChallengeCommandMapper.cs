using ClashRoyaleManager.Application.Commands.Admin;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.CreateChallenge;

public class CreateChallengeCommandMapper : AbstractMapper<Challenge, CreateChallengeCommand, CreateChallengeCommandResponse>
{
    public override Challenge ToEntity(CreateChallengeCommand command)
    {
        return new Challenge{
            Name =command.Name,
            Description = command.Description,
            Cost = command.Cost,
            NumberOfPrizes = command.NumberOfPrizes,
            NumberOfAdmissibleDefeats = command.NumberOfAdmissibleDefeats,
            Duration = command.Duration,
            MaximumLevel = command.MaximumLevel,
            Date = command.Date
        };
    }
    public override CreateChallengeCommandResponse ToResponse(Challenge entity)
    {
        return new CreateChallengeCommandResponse
        {
            Name = entity.Name,
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
