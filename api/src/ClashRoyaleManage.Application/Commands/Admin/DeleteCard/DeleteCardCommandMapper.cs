using ClashRoyaleManager.Application.Commands.Admin;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.DeleteCard;

public class DeleteCardCommandMapper : AbstractMapper<Card, DeleteCardCommand, DeleteCardCommandResponse>
{
    public override DeleteCardCommandResponse ToResponse(Card entity)
    {
        return new DeleteCardCommandResponse
        {
            Name = entity.Name,
            ElixirCost = entity.ElixirCost,
            Quality = entity.Quality,
            Description = entity.Description
        };
    }
}
