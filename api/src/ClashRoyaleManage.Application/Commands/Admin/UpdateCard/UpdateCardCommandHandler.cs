using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdateCard;

public class UpdateCardCommandHandler : CommandHandler<UpdateCardCommand, UpdateCardCommandResponse>
{
    private readonly ICardRepository _repository;
    private readonly UpdateCardCommandMapper _mapper;

    public UpdateCardCommandHandler(ICardRepository repository)
    {
        _repository = repository;
        _mapper = new UpdateCardCommandMapper();
    }
    
    public override async Task<UpdateCardCommandResponse> ExecuteAsync(UpdateCardCommand command, CancellationToken ct = default)
    {
        Card? card = await _repository.Get(command.Id)  
            ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(Card)}> and Id <{command.Id}> not exists");
        
        if (NotChanges(card, command))
        {
            throw new EntityAlreadyExistException("The current card can't be modified!");
        }

        card.Name = command.Name;
        card.Description = command.Description;
        card.ElixirCost = command.ElixirCost;
        card.Quality = command.Quality;

        await _repository.Update(card);
        UpdateCardCommandResponse dev = _mapper.ToResponse(card);
        return dev;
    }

    private bool NotChanges(Card card, UpdateCardCommand command) => card.Name == command.Name && card.Description == command.Description
            && card.ElixirCost == command.ElixirCost && card.Quality == command.Quality;
}
