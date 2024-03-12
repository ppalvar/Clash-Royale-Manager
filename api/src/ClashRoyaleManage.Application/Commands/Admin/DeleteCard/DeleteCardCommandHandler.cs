using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.DeleteCard;

public class DeleteCardCommandHandler : CommandHandler<DeleteCardCommand, DeleteCardCommandResponse>
{
    private readonly ICardRepository _repository;
    private readonly DeleteCardCommandMapper _mapper;

    public DeleteCardCommandHandler(ICardRepository repository)
    {
        _repository = repository;
        _mapper = new DeleteCardCommandMapper();
    }
    
    public override async Task<DeleteCardCommandResponse> ExecuteAsync(DeleteCardCommand command, CancellationToken ct = default)
    {
        Card? card = await _repository.Get(command.Id)  
            ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(Card)}> and Id <{command.Id}> not exists");

        await _repository.Remove(card.Id);
        
        return _mapper.ToResponse(card);
    }
}
