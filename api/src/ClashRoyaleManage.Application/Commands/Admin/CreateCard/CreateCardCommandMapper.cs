using ClashRoyaleManager.Application.Commands.Admin;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.CreateCard;

public class CreateCardCommandMapper : AbstractMapper<Card, CreateCardCommand, CreateCardCommandResponse>
{
    public override Card ToEntity(CreateCardCommand command)
    {
        return new Card{
            Name =command.Name,
            ElixirCost =command.ElixirCost,
            Quality=command.Quality,
            Description = command.Description
        };
    }
    public override CreateCardCommandResponse ToResponse(Card entity)
    {
        return new CreateCardCommandResponse
        {
            Name = entity.Name,
            ElixirCost = entity.ElixirCost,
            Quality = entity.Quality,
            Description = entity.Description
        };
    }
}
