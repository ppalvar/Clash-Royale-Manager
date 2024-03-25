using ClashRoyaleManager.Application.Commands.Admin;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.DeleteChallenge;

public class DeleteChallengeCommandMapper : AbstractMapper<Challenge, DeleteChallengeCommand, DeleteChallengeCommandResponse>
{
    public override DeleteChallengeCommandResponse ToResponse(Challenge entity)
    {
        return new DeleteChallengeCommandResponse
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
