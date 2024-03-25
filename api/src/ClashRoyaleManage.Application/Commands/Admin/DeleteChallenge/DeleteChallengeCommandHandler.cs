using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.DeleteChallenge;

public class DeleteChallengeCommandHandler : CommandHandler<DeleteChallengeCommand, DeleteChallengeCommandResponse>
{
    private readonly IChallengeRepository _repository;
    private readonly DeleteChallengeCommandMapper _mapper;

    public DeleteChallengeCommandHandler(IChallengeRepository repository)
    {
        _repository = repository;
        _mapper = new DeleteChallengeCommandMapper();
    }
    
    public override async Task<DeleteChallengeCommandResponse> ExecuteAsync(DeleteChallengeCommand command, CancellationToken ct = default)
    {
        Challenge? challenge = await _repository.Get(command.Id)  
            ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(Challenge)}> and Id <{command.Id}> not exists");

        await _repository.Remove(challenge.Id);
        
        return _mapper.ToResponse(challenge);
    }
}
