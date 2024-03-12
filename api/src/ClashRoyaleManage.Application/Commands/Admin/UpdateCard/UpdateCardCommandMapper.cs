using ClashRoyaleManager.Application.Commands.Admin;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdateCard;

public class UpdateCardCommandMapper : AbstractMapper<Card, UpdateCardCommand, UpdateCardCommandResponse>
{
    public override Card ToEntity(UpdateCardCommand command)
    {
        return new Card{
            Name =command.Name,
            ElixirCost =command.ElixirCost,
            Quality=command.Quality,
            Description = command.Description
        };
    }
    public override UpdateCardCommandResponse ToResponse(Card entity)
    {
        return new UpdateCardCommandResponse
        {
            Name = entity.Name,
            ElixirCost = entity.ElixirCost,
            Quality = entity.Quality,
            Description = entity.Description
        };
    }
}
